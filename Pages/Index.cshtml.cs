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

namespace FizzBuzzWeb.Pages;

public class IndexModel : PageModel
{

    [BindProperty]
    public StolenData StolenData { get; set; }
    public IList<StolenData> stolenDataList { get; set; }

    private readonly ILogger<IndexModel> _logger;
    private readonly DataContext _context;

    public IndexModel(ILogger<IndexModel> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        var stolenDataList = _context.StolenData.ToList();
    }

    public IActionResult OnPost()
    {
        if (StolenData.Year < 1899 || StolenData.Year > 2023) return Page();
        stolenDataList = _context.StolenData.ToList();
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
        _context.StolenData.Add(StolenData);
        _context.SaveChanges();
        return Page();
        


    }

}
