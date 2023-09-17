using System.ComponentModel.DataAnnotations;
namespace music_albumApp.Models
{
    public class Allbum
    {
        [Key]
        [RegularExpression(@"\d{3,4}")]
        public int id { get; set; }
        [Required, StringLength(100, ErrorMessage = "Length be between 5 and 100", MinimumLength = 5)]
        public string AllbumTittle { get; set; }
        public string Genre { get; set; }
        [Required, RegularExpression(@"[A-Za-z]{3,20}\s\w{3,25}")]
        public string Artist { get; set; }

        [RegularExpression(".{3,100}")]
        public string AllbumIamge { get; set; }

        [Range(1.0,1000)]
        public decimal Price { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string Material { get; set; }
        public bool Particpiate { get; set; }
        [RegularExpression("[0-9]{4}")]
        public int Year { get; set; }
    }
}
