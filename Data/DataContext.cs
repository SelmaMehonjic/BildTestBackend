using bildExamNew.Models;
using Microsoft.EntityFrameworkCore;

namespace bildExamNew.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<DeviceTypes> DeviceTypes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceTypeProperties> DeviceTypesProperties { get; set; }
        public DbSet<DevicePropertyValues> DevicePropertyValues { get; set; }

    }
}