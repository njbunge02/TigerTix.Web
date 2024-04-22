using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TigerTix.Web.Data.Entities
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TicketHolder { get; set; }

        [Required]
        public double TicketPrice { get; set; }

        [Required]
        public int eventID;

        public string FormatPrice() { return TicketPrice.ToString("##########.00"); }
    }

    public class Purchase
    {
        public Purchase() { PurchaseList = new List<Ticket>(); }


        [Required]
        public string eventName { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string TicketHolder { get; set; }

        public IEnumerable<Ticket>? PurchaseList { get; set; }

        [Required]
        public int numtickets { get; set; }

        [Required]
        public double subtotal { get; set; }

        [Required]
        public double DiscountApplied { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public int cardNum { get; set; }
    }
}
