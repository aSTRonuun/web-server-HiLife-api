using Microsoft.EntityFrameworkCore;

namespace HiLife_API.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Patient> Patients { get; set; }
    }
}
