using BlogNetCore.AppService.Domain.Core;
using BlogNetCore.AppService.Extensions;
using BlogNetCore.AppService.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace BlogNetCore.AppService.Context
{
    public class BlogDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BlogDbContext(DbContextOptions<BlogDbContext> options, IHttpContextAccessor _httpContextAccessor)
            : base(options)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddEntityConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            AddAuditData<int>();
            return base.SaveChanges();
        }

        public int SaveChangesWithoutAudit()
        {
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddAuditData<int>();
            return await base.SaveChangesAsync();
        }

        protected void AddAuditData<TId>()
        {
            var entities = this.ChangeTracker.Entries().Where(x => x.Entity is BlogCoreEntity<TId> && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();
            var userName = "";
            try
            {
                userName = httpContextAccessor.HttpContext.User.Identity.Name;
            }
            catch (Exception)
            {
                // Ignored
            }

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BlogCoreEntity<TId>)entity.Entity).CreatedDate = DateTime.Now;
                    ((BlogCoreEntity<TId>)entity.Entity).CreatedBy = userName;
                    ((BlogCoreEntity<TId>)entity.Entity).UpdatedDate = DateTime.Now;
                    ((BlogCoreEntity<TId>)entity.Entity).UpdatedBy = userName;
                }
                else if (entity.State == EntityState.Modified)
                {
                    if (((BlogCoreEntity<TId>)entity.Entity) != null)
                    {
                        entity.Property("CreatedDate").IsModified = false;
                        entity.Property("CreatedBy").IsModified = false;
                        ((BlogCoreEntity<TId>)entity.Entity).UpdatedDate = DateTime.Now;
                        ((BlogCoreEntity<TId>)entity.Entity).UpdatedBy = userName;
                    }
                }
            }
        }
    }
}
