using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TigerTix.Web.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

         [Required]
       public string firstName { get; set; }
        
        [Required]
       public string lastName { get; set;}

        [Required]
       public string account_type { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Salt { get; set; }
    }
}
