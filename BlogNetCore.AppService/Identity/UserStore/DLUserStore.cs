using BlogNetCore.AppService.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogNetCore.AppService.Identity.UserStore
{
    public class DLUserStore : UserStore<User, Role, BlogDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public DLUserStore(BlogDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
