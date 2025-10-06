using System.ComponentModel.DataAnnotations;

namespace EventService.Models
{
    public class Guest
    {
        public Guid id { get; set; }

        [Required, StringLength(100)]

        public string Fullname { get; set; } = string.Empty;

        public bool Confirmed { get; set; }

    }
}
