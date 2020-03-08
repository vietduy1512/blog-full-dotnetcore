using BlogNetCore.AppService.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogNetCore.AppService.Identity.UserStore
{
    public class DLRoleStore : RoleStore<Role, BlogDbContext, int, UserRole, RoleClaim>
    {
        public DLRoleStore(BlogDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
