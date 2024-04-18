using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TigerTix.Web.Data.Entities
{
    public class Ticket
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string NameOnCard { get; set; }

        [Required]
        public int CardNumber { get; set; }

        [Required]
        public int ExpiryMo { get; set; }

        [Required]
        public int ExpiryYr { get; set; }

        [Required]
        public int CVV { get; set; }

        [Required]
        public int TicketHolder { get; set; }

        [Required]
        public double TicketPrice { get; set; }

        [Required]
        public int PurchaseID { get; set; }
    }

    public class Purchase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TicketHolder { get; set; }

        [Required]
        public IEnumerable<Ticket> PurchaseList { get; set; }

        [Required]
        public double DiscountApplied { get; set; }

        [Required]
        public double TotalCost { get; set; }

        public void addTicket(Ticket ticket)
        {
            this.PurchaseList.Append(ticket);
        }
    }
}
