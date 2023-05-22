using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Models;
using FizzBuzzWeb.Data;
using System.Security.Claims;
using System;
using FizzBuzzWeb.Interfaces;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        //[BindProperty]
        //public ForExtermination ForExtermination { get; set; }

        //public StolenData StolenData { get; set; }
        public PaginatedList<StolenData> Stolenpages { get; set; }
        //private readonly DataContext _context;

        private readonly IDataService _dataService;


        public SavedInSessionModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void OnGet(int pageIndex = 1)
        {

            var query = _dataService.GetStolenData();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(d => d.Nick.Contains(SearchTerm) || d.Year.ToString().Contains(SearchTerm));
            }
            query = query.OrderByDescending(x => x.Time);
            Stolenpages = PaginatedList<StolenData>.Create(query, pageIndex, 20);
            //stolenDataList = query.ToList();
            //return Page();
        }

        public IActionResult OnPost(int remid, int pageIndex = 1)
        {
            System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAA" + remid);
            var query = _dataService.GetStolenData();
            var remove = query.Where(d => d.Id == remid).FirstOrDefault();
            _dataService.DeleteStolenData(remove);
            query = _dataService.GetStolenData();
            query = query.OrderByDescending(x => x.Time);
            Stolenpages = PaginatedList<StolenData>.Create(query, pageIndex, 20);
            return Page();
        }
    }
}
