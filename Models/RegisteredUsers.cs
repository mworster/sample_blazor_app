using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockReader.Models
{
    public class RegisteredUser
    {
        [Key, Column("UserId")]
        public Guid Id { get; set; }
            
        public string UserName { get; set;}
        [Column("Password")]
        public string UserPassword { get; set;}    
    }
}
