using System.ComponentModel.DataAnnotations;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Models
{
    public class PurchaseModel
    {
        public List<Ticket> Cart;

        public void addTicket(Ticket ticket) { Cart.Add(ticket); }

        public User Holder { get; set; }

        public Event currentEvent { get; set; }

        public int cardNum { get; set; }
        public int cardExpiryYr { get; set; }
        public int cardExpiryMo { get; set; }
        public int cardCVV { get; set; }

        public PurchaseModel() {
            Cart = new List<Ticket>();
        }

        public Purchase MakePurchase(double subtotal, double markdown)
        {
            var finalPurchase = new Purchase();
            finalPurchase.cardNum = cardNum;
            //finalPurchase.TicketHolder = Holder.UserName;
            finalPurchase.eventName = currentEvent.eventName;
            finalPurchase.subtotal = subtotal;
            finalPurchase.DiscountApplied = markdown;
            finalPurchase.TotalCost = subtotal - markdown;
            finalPurchase.PurchaseList = Cart;

            return finalPurchase;
        }
    }
}
