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
using FizzBuzzWeb.ViewModels.Person;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public PaginatedList<PersonForListVM> Stolenpages { get; set; }

        private readonly IDataService _dataService;


        public SavedInSessionModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void OnGet(int pageIndex = 1)
        {
            Stolenpages = _dataService.GetMatchingSearchData(SearchTerm, pageIndex);
        }

        public IActionResult OnPost(int remid, int pageIndex = 1)
        {
            //System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAA" + remid);
            _dataService.DeleteStolenData(remid);
            Stolenpages = _dataService.GetMatchingSearchData(SearchTerm, pageIndex);
            return Page();
        }
    }
}
