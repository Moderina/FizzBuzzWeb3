using FizzBuzzWeb.Data;
using FizzBuzzWeb.Interfaces;
using FizzBuzzWeb.Models;
using System;

namespace FizzBuzzWeb.Services
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<StolenData> GetMatchingData(string SearchTerm)
        {
            if (SearchTerm == null)
            {
                return _context.StolenData;
            }
            return _context.StolenData.Where(d => d.Nick.Contains(SearchTerm) || d.Year.ToString().Contains(SearchTerm));
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
