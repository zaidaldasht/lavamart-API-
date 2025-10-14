using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.models
{
    public class dtoUsers
    {
      

        [Required(ErrorMessage = "please enter your name")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Phone]
        [Required(ErrorMessage = "please enter your phone number")]
        public string PhoneNumber { get; set; }

        [AllowNull]
        public DateTime Creatdate { get; set; } = DateTime.Now;
    }
}
