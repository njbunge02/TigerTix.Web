using System.ComponentModel.DataAnnotations;


namespace TigerTix.Web.Models
{
    public class userModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string userName {get;set;}

        [ComplexPassword(ErrorMessage = "Password must contain at least one uppercase letter, one digit, one special character, and be at least 7 characters long")]
        public string passWord {get; set;}

        
        
    }
}