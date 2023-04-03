using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;



namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public FizzBuzzForm? FizzBuzz { get; set; }
        public List<FizzBuzzForm> FizzBuzzArray = new List<FizzBuzzForm>();

        public string otbet { get; set; }

        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Array");
            if (Data != null)
            {
                FizzBuzzArray = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(Data).ToList();

                ViewData["FizzBuzz"] = FizzBuzzArray;

            }

        }

        public IActionResult OnPost()
        {
            ViewData["FizzBuzz"] = null;
            FizzBuzzArray.Clear();
            string jsonData = JsonConvert.SerializeObject(FizzBuzzArray);
            HttpContext.Session.SetString("Array", jsonData);
            return RedirectToPage("./Index");
        }
    }
}
