using IdentityServer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Data.Context
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
                       
        }
        public DbSet<Customer> Customers { get; set; }
    }
}