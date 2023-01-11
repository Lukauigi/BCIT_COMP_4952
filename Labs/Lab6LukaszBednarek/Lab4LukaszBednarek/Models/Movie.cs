using System.ComponentModel.DataAnnotations;


namespace Lab4LukaszBednarek.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [Range(1900, 2100, ErrorMessage = "The earliest year is 1900")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please enter a movie category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
