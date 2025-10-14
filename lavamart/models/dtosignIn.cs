using System.ComponentModel.DataAnnotations;

namespace lavamart.models
{
    public class dtosignIn
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
