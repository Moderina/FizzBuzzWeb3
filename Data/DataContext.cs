using FizzBuzzWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace FizzBuzzWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<StolenData> StolenData { get; set; }

    }


}
