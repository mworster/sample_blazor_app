using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// This was part of the DB schema I setup to work with users.
// Due to lack of DB support, this code isn't used. 
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
