using Frankfurt.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Frankfurt.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
