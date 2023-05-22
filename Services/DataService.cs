using FizzBuzzWeb.Models;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Interfaces;

namespace FizzBuzzWeb.Services
{
    public class DataService : IDataService
    {
        private readonly DataContext _context;

        public DataService(DataContext context)
        {
            _context = context;
        }

        public IQueryable<StolenData> GetStolenData()
        {
            return _context.StolenData;
        }

        public void AddStolenData(StolenData sd) 
        {
            _context.StolenData.Add(sd);
            _context.SaveChanges();
        }

        public void DeleteStolenData(StolenData sd)
        {
            _context.StolenData.Remove(sd);
            _context.SaveChanges();
        }
    }
}
