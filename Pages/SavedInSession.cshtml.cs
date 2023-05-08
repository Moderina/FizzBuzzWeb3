using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Models;
using FizzBuzzWeb.Data;
using System.Security.Claims;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public StolenData StolenData { get; set; }
        public IList<StolenData> stolenDataList { get; set; }
        public PaginatedList<StolenData> Stolenpages { get; set; }
        private readonly DataContext _context;


        public SavedInSessionModel(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnChange(int pageIndex = 1)
        {
            IQueryable<StolenData> query = _context.StolenData;
            query.OrderByDescending(x => x.Time);



            Stolenpages = PaginatedList<StolenData>.Create(query, pageIndex, 20);
            return Page();
        }

        public void OnGet(int pageIndex = 1)
        {
            var query = _context.StolenData.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(d => d.Nick.Contains(SearchTerm) || d.Year.ToString().Contains(SearchTerm));
            }
            query.OrderByDescending(x => x.Time);
            Stolenpages = PaginatedList<StolenData>.Create(query, pageIndex, 20);
            stolenDataList = query.ToList();
            //return Page();
        }

        public IActionResult OnPost()
        {
            //ViewData["FizzBuzz"] = null;
            //FizzBuzzArray.Clear();
            //string jsonData = JsonConvert.SerializeObject(FizzBuzzArray);
            //HttpContext.Session.SetString("Array", jsonData);
            return RedirectToPage("./Index");
        }
    }
}
