using System;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Interfaces
{
    public interface IDataService
    {
        public IQueryable<StolenData> GetStolenData();

        public void AddStolenData(StolenData sd);

        public void DeleteStolenData(StolenData sd);
    }
}
