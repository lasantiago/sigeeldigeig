using Microsoft.AspNet.Identity.EntityFramework;

namespace api.Models
{
    public class SIGEeLDBContext : IdentityDbContext<IdentityUser>
    {
        public SIGEeLDBContext()
            : base("SIGEeLDBContext")
        {
        }
    }
}