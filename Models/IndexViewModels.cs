using System.ComponentModel.DataAnnotations;

namespace TigerTix.Web.Models
{
    public class IndexViewModel
    {
        [Required]
        public string userName {get;set;}
    }
}