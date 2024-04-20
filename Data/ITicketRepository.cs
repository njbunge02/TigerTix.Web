using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface ITicketRepository
    {
        public void SaveTicket(Ticket selectedTicket);

        public IEnumerable<Ticket> GetAllTickets();

        public Ticket GetTicketId(int ticketID);

        public void UpdateTicket(Ticket selectedTicket);

        public void DeleteTicket(Ticket selectedTicket);

        public bool SaveAll();
    }
}
