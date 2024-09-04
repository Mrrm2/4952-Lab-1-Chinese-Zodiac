using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zodiac.Models;
using System.Diagnostics;

namespace Zodiac.Pages
{
    public class GetZodiacModel : PageModel
    {
        [BindProperty]
        public int Year { get; set; }
        public string Zodiac { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Image { get; set; }

        public void OnGet()
        {
            Year = 0;
        }
        public void OnPost()
        {
            if (Year < 1900 || Year > DateTime.Now.Year + 1)
            {
                IsError = true;
                Message = "Year must be between 1900 and next year. Please try again.";
                Image = "";
            }
            else
            {
                IsError = false;
                Zodiac = Utils.GetZodiac(Year);
                Message = "Your zodiac is";
                Image = Url.Content($"~/images/{Zodiac.ToLower()}.png");
            }
            Console.WriteLine(Image);
        }
    }
}
