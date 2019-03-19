using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorWebApp.Models;

namespace RazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        //Menggunakan dependency injection untuk menambah RazorWebAppContext
        //Semua Scaffolded Pages mengikuti pola ini
        private readonly RazorWebApp.Models.RazorWebAppContext _context;

        public IndexModel(RazorWebApp.Models.RazorWebAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]//Mengikat nilai di form dan string di query dengan nama yang sama seperti properti
        //SupportsGet =  true memungkinkan dilakukan pengikatan pada saat GET Request
        //Model binding dilakukan pada ASP.Net agar mengisi nilai SearchString di Class Index sesuai dengan queryString {?searchString=Ghost atau ./Movies/Ghost}
        public string SearchString { get; set; }//Berisi text yang user input di textbox
        
        public SelectList Genres { get; set; } // berisi genre dari seluruh film
        
        [BindProperty(SupportsGet = true)]
        public string MovieGenres { get; set; } //Berisi Genre yang user pilih

        //Pada saat permintaan page untuk muncul ada, maka method OnGetAsync 
        //Return daftar movies ke Razor Page
        //OnGetAsync or OnGet dipanggil untuk inisialisasi suatu halaman
        //Contoh dibawah ini maksudnya adalah mengambil daftar movie di database
        //dan menampilkanya
        //OnGet Return void OnGetAsync Return Task(no return method required)
        public async Task OnGetAsync()
        {
            //LINQ For Getting Movie Genre
            //Menngambil semua genre di DB
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;


            //linq query to select the movies
            //Mengambili semua movie di DB
            var movies = from m in _context.Movie
                         select m;
            //Condition if User Search The Title
            if (!string.IsNullOrEmpty(SearchString))
            {
                //FIltering sesuai dengan search
                //s = > s.Title.COntains(SearchString) merupakan ekspresi lambda digunakan di LINQ queries sebagai argument
                //menggunakan method where dan contain
                // LINQ query dieksekusi secara tertunda
                //Artinya expression di delayed sampai hasilnya di ulang atau method ToListAsync dipanggil
                movies = movies.Where(s => s.Title.Contains(SearchString)); // fungsi contains berjalan di SQL Server dan di petakan menjadi SQL LIKE query yang case insensitive
                //sementara kalau menggunakan SQLite maka SQL Like itu Case Sensitive

            }

            if (!string.IsNullOrEmpty(MovieGenres))
            {
                movies = movies.Where(x => x.Genre == MovieGenres);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
