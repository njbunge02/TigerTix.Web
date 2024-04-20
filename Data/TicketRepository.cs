using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TigerTixContext _context;

        public TicketRepository(TigerTixContext context) { _context = context; }

        public void SaveTicket(Ticket selectedTicket)
        {
            _context.Add(selectedTicket);
            _context.SaveChanges();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            var ticketsList = from selectedTicket in _context.Tickets
                              select selectedTicket;
            return ticketsList.ToList();
        }

        public Ticket GetTicketId(int ticketID)
        {
            var selectedTicket = (from t in _context.Tickets
                                  where t.Id == ticketID
                                  select t).FirstOrDefault();
            return selectedTicket;
        }

        public void UpdateTicket(Ticket selectedTicket)
        {
            _context.Tickets.Add(selectedTicket);
            _context.SaveChanges();
        }

        public void DeleteTicket(Ticket selectedTicket)
        {
            _context.Remove(selectedTicket);
            _context.SaveChanges();
        }

        public bool SaveAll() { return _context.SaveChanges() > 0; }
    }
}
