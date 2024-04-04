using TigerTix.Web.Data.Entities;
using TigerTix.Web.Models;

namespace TigerTix.Web.Data
{
    public class EventRepository: IEventRepository
    {
       private readonly TigerTixContext _context;

       public EventRepository(TigerTixContext context)
       {
            _context = context;
       }

       public void SaveEvent(Event selectedEvent)
       {
            _context.Add(selectedEvent);
            _context.SaveChanges();
       }

       public IEnumerable<Event> GetAllEvents()
       {
            var eventsList = from selectedEvent in _context.Events
                            select selectedEvent;

            return eventsList.ToList();
       }

       public Event GetEventId(int eventID)
       {
            var selectedEvent = (from u in _context.Events
                        where u.Id == eventID
                        select u).FirstOrDefault();

            return selectedEvent;
       }

       public void UpdateEvent(Event selectedEvent)
       {
            _context.Events.Add(selectedEvent);
            _context.SaveChanges();
       }

       public Event GetEventByName(string name)
        {
            var selectedEvent = (from u in _context.Events
                              where u.eventName == name
                              select u).FirstOrDefault();
            
            return selectedEvent;
        }

       public void DeleteEvent(Event selectedEvent)
       {
            _context.Remove(selectedEvent);
            _context.SaveChanges();
       }

       public bool SaveAll()
       {
        return _context.SaveChanges() > 0;
       }

     
    }
}