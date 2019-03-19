using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorWebApp.Models
{
    public class Movie
    {
         
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 3)]//Validation
        [Required]//Validation
        public string Title { get; set; }
        
        [Display(Name = "Release Date")]//Nama dikolom di override
        [DataType(DataType.Date)] // Memastikan tipenya date, sehingga time data di simpan tidak di tampilkan
        public DateTime ReleaseDate { get; set; } //DateTime inherently required jadi gk perlu required lagi

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")] // Price di map ke dalam data type decimal
        public decimal Price { get; set; } //Decimal inherently Required jadi gk perlu ada required lagi

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}
