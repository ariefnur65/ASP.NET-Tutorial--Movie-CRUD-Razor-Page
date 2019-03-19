using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorWebApp.Models;

namespace RazorWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly RazorWebApp.Models.RazorWebAppContext _context;

        public CreateModel(RazorWebApp.Models.RazorWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //Page() membuat PageResult yang merender Create.cshtml
            //
            return Page();
        }

        [BindProperty]//Digunakan oleh Movie agar dapat digunakan pada model binding
        public Movie Movie { get; set; } // Saat create form mengirim nilai form, ASP.net core 
        //runtime mengisi nilai yang dikirim kedalam objet Movie ini

        public async Task<IActionResult> OnPostAsync()//Run ketika halaman mengirim form datanya
        {
            if (!ModelState.IsValid)//Jika terjadi Model error maka form akan di tampilkan ulang
            {//Model error contohnya adalah kesalahan input tanggal yang tidak bisa di convert menjadi tanggal
                //kebanyakan model error dapat di deteksi pada client-side
                return Page();
            }
            //jika tidak ada model error datanya akan disimpan
            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}