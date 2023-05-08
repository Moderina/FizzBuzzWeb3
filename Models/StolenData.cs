﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FizzBuzzWeb.Models
{
    public class StolenData
    {
        [Display(Name = "Twój rok urodzenia")]
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1899, 2024, ErrorMessage = "Oczekiwany rok {0} z zakresu {1} i {2}.")]
        public int? Year { get; set; }

        public string Wynik { get; set; }
       
        public string Nick { get; set; } = "No name";

        [AllowNull]
        public string UserId { get; set; }

        public DateTime Time { get; set; }

    }
}
