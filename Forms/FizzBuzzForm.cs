using System.ComponentModel.DataAnnotations;
namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "Twój rok urodzenia")]
        [Required]
        [Range(1899, 2024, ErrorMessage = "Oczekiwany rok {0} z zakresu {1} i {2}.")]
        public int? Number { get; set; } = 0;

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public string otbet { get; set; }



    }
}
