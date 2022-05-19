using System.ComponentModel.DataAnnotations;
namespace WebChat.Models
//check
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }

        [Required]
        public string? Comment { get; set; }

        [DataType(DataType.Date)]
        public string? Date { get; set; }
    }
}
