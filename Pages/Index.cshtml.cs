using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace FizzBuzzWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public List<FizzBuzzForm> FizzBuzzArray = new List<FizzBuzzForm>();
    [BindProperty]
    public FizzBuzzForm FizzBuzz { get; set; }
    //[BindProperty(SupportsGet = true)]

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        //if (ViewData.ContainsKey("FizzBuzz"))
        //{
        //    FizzBuzzArray = ViewData["FizzBuzz"] as List<FizzBuzzForm>;
        //    foreach (var fizzbuzz in FizzBuzzArray)
        //    {
        //        System.Diagnostics.Debug.WriteLine(fizzbuzz.Number);
        //    }
        //}

        var Data = HttpContext.Session.GetString("Array");
        System.Diagnostics.Debug.WriteLine(Data);
        if (Data != null)
        {
            FizzBuzzArray = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(Data).ToList();
        }
        ViewData["FizzBuzz"] = FizzBuzzArray;


    }

    public IActionResult OnPost()
    {

        //DESERIALIZACJA
        var Data = HttpContext.Session.GetString("Array");
        if (Data != null)
        {
            FizzBuzzArray = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(Data).ToList();
        }

        //NOWE WPROWADZONE DANE
        if (FizzBuzz.Name.Length < 100 && FizzBuzz.Number > 1898 && FizzBuzz.Number < 2025)
        {
            if (FizzBuzz.Number % 4 == 0) FizzBuzz.otbet = "To był rok przestępny";
            else FizzBuzz.otbet = "To nie był rok przestępny";

            //DODANIE NOWYCH DANYCH DO LISTY
            FizzBuzzArray.Add(FizzBuzz);

        }
        ViewData["FizzBuzz"] = FizzBuzzArray;

        //SERIALIZACJA NOWEJ UZUPELNIONEJ LISTY
        string jsonData = JsonConvert.SerializeObject(FizzBuzzArray);
        HttpContext.Session.SetString("Array", jsonData);


        return Page();

    }

}
