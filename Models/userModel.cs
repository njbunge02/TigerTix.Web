using System.ComponentModel.DataAnnotations;


namespace TigerTix.Web.Models
{
    public class userModel
    {
        [Required(ErrorMessage = "First name is required")]
       public string? firstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
       public string? lastName { get; set;}

         [Required(ErrorMessage = "Account type is required")]
       public string? account_type { get; set; }
       
        [Required(ErrorMessage = "Username is required")]
        public string userName {get;set;}

        [ComplexPassword(ErrorMessage = "Password must contain at least one uppercase letter, one digit, one special character, and be at least 7 characters long")]
        public string passWord {get; set;}

        
        
    }
}