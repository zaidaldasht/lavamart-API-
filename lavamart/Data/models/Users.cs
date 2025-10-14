using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace lavamart.Data.models
{
    public class Users : IdentityUser
    {
   
        [AllowNull]
        public DateTime Creatdate { get; set; } = DateTime.Now;



    }
}
