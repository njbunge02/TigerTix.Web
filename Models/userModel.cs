using System.ComponentModel.DataAnnotations;

namespace TigerTix.Web.Models
{
    public class userModel
    {
        [Required]
        public string userName {get;set;}
        public string passWord {get; set;}
    }
}