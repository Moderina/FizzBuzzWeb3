using FizzBuzzWeb.Models;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Interfaces;
using FizzBuzzWeb.Pages;
using FizzBuzzWeb.ViewModels;
using FizzBuzzWeb.ViewModels.Person;

namespace FizzBuzzWeb.Services
{
    public class DataService : IDataService
    {
        private readonly IRepository _repo;

        public DataService(IRepository repo)
        {
            _repo = repo;
        }

        public void AddStolenData(StolenData sd) 
        {
            _repo.AddStolenData(sd);
        }

        public void DeleteStolenData(int id)
        {
            var query = _repo.GetMatchingData("");
            var remove = query.Where(d => d.Id == id).FirstOrDefault();
            _repo.DeleteStolenData(remove);
        }

        public PaginatedList<PersonForListVM> GetMatchingSearchData(string SearchTerm, int pageIndex)
        {
            //var query = GetStolenData();

            //if (!string.IsNullOrEmpty(SearchTerm))
            //{
            //    query = query.Where(d => d.Nick.Contains(SearchTerm) || d.Year.ToString().Contains(SearchTerm));
            //}
            var query = _repo.GetMatchingData(SearchTerm);
            query = query.OrderByDescending(x => x.Time);
            ListPersonForListVM result = new ListPersonForListVM();
            result.People = new List<PersonForListVM>();
            foreach (var person in query)
            {
                var pVM = new PersonForListVM()
                {
                    UserId = person.UserId,
                    Nick = person.Nick,
                    Year = person.Year,
                    Id = person.Id
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;
            return PaginatedList<PersonForListVM>.Create(result.People, pageIndex, 20);
        }
    }
}
