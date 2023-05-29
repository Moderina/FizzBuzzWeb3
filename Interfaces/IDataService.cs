using System;
using FizzBuzzWeb.Models;
using FizzBuzzWeb.ViewModels.Person;

namespace FizzBuzzWeb.Interfaces
{
    public interface IDataService
    {

        public void AddStolenData(StolenData sd);

        public void DeleteStolenData(int id);

        public PaginatedList<PersonForListVM> GetMatchingSearchData(string SearchTerm, int pageIndex);
    }
}
