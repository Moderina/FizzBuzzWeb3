using FizzBuzzWeb.Models;
using System;

namespace FizzBuzzWeb.Interfaces
{
    public interface IRepository
    {
        IQueryable<StolenData> GetMatchingData(string SearchTerm);

        void AddStolenData(StolenData sd);

        void DeleteStolenData(StolenData sd);
    }
}
