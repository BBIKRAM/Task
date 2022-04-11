using System.ComponentModel.DataAnnotations;

namespace net.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; } 
        [Required]  
        public string ItemName { get; set; } 
        [Required]
        public int ItemPrice { get; set; } 
    }
}