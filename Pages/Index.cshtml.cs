using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public FizzBuzzForm[] FizzBuzzArray;
    [BindProperty]
    public FizzBuzzForm FizzBuzz { get; set; }
    //[BindProperty(SupportsGet = true)]
    //public string Name { get; set; }
    //public string cobet { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        //if (FizzBuzz != null)
        //{
        //    string html = $"<p>{FizzBuzz.Name} urodził/a się w {FizzBuzz.Number} roku. {FizzBuzz.otbet}</p>";
        //    ViewData["Dane"] = html;
        //}
        var Data = HttpContext.Session.GetString("Data");
        System.Diagnostics.Debug.WriteLine("dupa");
        if (Data != null)
        {
            System.Diagnostics.Debug.WriteLine(Data);
            FizzBuzzArray = JsonConvert.DeserializeObject<FizzBuzzForm[]>(Data);

            foreach (var FizzBuzz in FizzBuzzArray)
            {

                if (FizzBuzz.Number % 4 == 0) FizzBuzz.otbet = "To był rok przestępny";
                else FizzBuzz.otbet = "To nie był rok przestępny";

                //if (FizzBuzz.Number >= 1899 && FizzBuzz.Number <= 2024 && FizzBuzz.Name.Length <= 100)
                //{
                //    string html = $"<p>{FizzBuzz.Name} urodził/a się w {FizzBuzz.Number} roku. {FizzBuzz.otbet}</p>";
                //    ViewData["Dane"] = html;
                //}
            }


        }
            

        
    }

    //public IActionResult OnConfirm(FizzBuzzForm FizzBuzz)
    //{
    //    // Save the form data to a session or database
    //    string jsonData = JsonConvert.SerializeObject(FizzBuzz);
    //    HttpContext.Session.SetString("Data", jsonData);
    //    // Store the form data in the ViewData dictionary
    //    ViewData["FormData"] = FizzBuzz;

    //    // Return the same page
    //    return Page();
    //}

    public IActionResult OnPost()
    {
        //if (!ModelState.IsValid)
        //{
        //    return Page();
        //}
        //FizzBuzzArray.Append(FizzBuzz);
        //string jsonData = JsonConvert.SerializeObject(FizzBuzzArray);
        //HttpContext.Session.SetString("Data", jsonData);
        //return Page();
        if (FizzBuzz.Number % 4 == 0) FizzBuzz.otbet = "To był rok przestępny";
        else FizzBuzz.otbet = "To nie był rok przestępny";

        ViewData["FizzBuzz"] = FizzBuzz;
        return Page();


        //return RedirectToPage("./SavedInSession");

        //return Page();

    }

}
