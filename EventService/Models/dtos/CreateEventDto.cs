using System.ComponentModel.DataAnnotations;
namespace EventService.Models.dtos
{
    public class CreateEventDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1")]
        public int Capacity { get; set; }
    }
}