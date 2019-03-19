using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorWebApp.Models
{
    public class RazorWebAppContext : DbContext
    {
        public RazorWebAppContext (
            //Nama Connection String dibawa dengan memanggil method pada DbContextOptions
            //Jika untuk pemasangan lokal ASP.NET config sys memanggil dari appsetings.json
            DbContextOptions<RazorWebAppContext> options)
            : base(options)
        {
        }
        // Membuat DBSet<sesuai dengan Model> Dalam framework entity 
        // entity Set Maksudnya adalah tabel database
        // Sementara Sebuah Entity --> Baris Tabel
        public DbSet<RazorWebApp.Models.Movie> Movie { get; set; }
    }
}
