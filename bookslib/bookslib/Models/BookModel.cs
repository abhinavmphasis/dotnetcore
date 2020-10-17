using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using bookslib.Enums;
using bookslib.Helpers;
using Microsoft.AspNetCore.Http;

namespace bookslib.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        //[StringLength(100, MinimumLength =5)]
        //[Required(ErrorMessage ="Please enter the title of the book")]
        [MyCustomValidation("Azure")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the Author of the book")]
        public string Author { get; set; }
        [StringLength(500)]

        public string Description { get; set; }
        public string Category { get; set; }
        //[Required(ErrorMessage = "Please enter the language of your choice")]

        public int LanguageId { get; set; }
        public string  Language { get; set; }

        //[Required(ErrorMessage = "Please enter the total pages of the book")]
        //[Display(Name ="Total Pages of book")]
        public int? TotalPages { get; set; }
        [Required]
        [Display(Name = "Please choose the cover page of your book")]
        public IFormFile  CoverPhoto { get; set; }
        public string  CoverImageUrl { get; set; }
    }
}
