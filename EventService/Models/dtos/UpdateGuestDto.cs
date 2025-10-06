using System.ComponentModel.DataAnnotations;

namespace EventService.Models.dtos
{
    public class UpdateGuestDto
    {
        public Guid id { get; init; }

        [Required, StringLength(100)]
        public string Fullname { get; init; } = string.Empty;

        [Required]
        public bool Confirmed { get; init; }
    }
}
