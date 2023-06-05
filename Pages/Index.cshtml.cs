using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using FizzBuzzWeb.Models;
using FizzBuzzWeb.Data;
using System.Security.Claims;
using System.Collections;
using System.Drawing.Printing;
using FizzBuzzWeb.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FizzBuzzWeb.Pages;

public class IndexModel : PageModel
{

    [BindProperty]
    public StolenData StolenData { get; set; }

    private readonly ILogger<IndexModel> _logger;

    private readonly IDataService _dataService;


    public IndexModel(ILogger<IndexModel> logger, IDataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }


    public IActionResult OnPost()
    {
        if (StolenData.Year < 1899 || StolenData.Year > 2023) return Page();
        StolenData.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        StolenData.Time = DateTime.Now;
        if (StolenData.Nick == null)
        {
            if (StolenData.UserId != null)
            {
                StolenData.Nick = User.FindFirstValue(ClaimTypes.Email);
            }
            else
            {
                StolenData.Nick = "No name";
                StolenData.UserId = "NULL";
            }
        }
        else if (StolenData.UserId == null)
        {
            StolenData.UserId = "NULL";
        }
        if (StolenData.Year % 4 == 0) StolenData.Wynik = "Przestępny";
        else StolenData.Wynik = "Zwykły";
        _dataService.AddStolenData(StolenData);
        return Page();
        


    }

}
