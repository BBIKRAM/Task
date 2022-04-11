using System.ComponentModel.DataAnnotations;

namespace net.Models
{
    public class User
    {
      
            [Key]
            public int ID { get; set; }
            [Required(ErrorMessage = "UserName is required")]
            public string UserName { get; set; }


            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        }
    }

