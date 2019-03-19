using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace RazorWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorWebAppContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<RazorWebAppContext>>()))
            {
                //Ada movie atau tidak
                if (context.Movie.Any())
                {
                    //jika sudah isi maka berhenti
                    return;
                }

                context.Movie.AddRange(
                    new Movie {
                        Title = "Sulaiman Tetapi Diangkasa",
                        ReleaseDate = DateTime.Parse("1999-3-11"),
                        Genre = "Comedy",
                        Price = 8.5M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "M"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "PG-13"
                    }
                    );
                context.SaveChanges(); //Push ke database
            }
        }
    }
}
