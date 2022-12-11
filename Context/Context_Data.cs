using Microsoft.EntityFrameworkCore;
using MVC_Roles.Models;

namespace MVC_Roles.Context
{
    public class Context_Data : DbContext
    {
        public Context_Data(DbContextOptions<Context_Data>options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        
    }
}
