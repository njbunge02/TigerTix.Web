using TigerTix.Web.Data.Entities;
using TigerTix.Web.Models;

namespace TigerTix.Web.Data
{
    public class EventRepository: IEventRepository
    {
        private readonly TigerTixContext _context;
        public EventRepository(TigerTixContext context) { _context = context; }

        /*Saves an event to the context database
         *
         *@param selectedEvent...Represents the Event object being added to the database
         */
        public void SaveEvent(Event selectedEvent)
        {
            _context.Add(selectedEvent);
            _context.SaveChanges();
        }

        /*Provides all previously registered events on the site
         *
         *@return...A list containing every event in the database
         */
        public IEnumerable<Event> GetAllEvents()
        {
            //Store every event in the context field and return them as a list
            var eventsList = from selectedEvent in _context.Events
                             select selectedEvent;
            return eventsList.ToList();
        }

        /*Provides an Event object that is found by it's unique ID
         *
         *@param eventID...represents the unique ID of the event being accessed
         *
         *@return...The Eveng object being searched for
         */
        public Event GetEventId(int eventID)
        {
            //Iterate through all events in the database, and if the ID matches
            //  then return it
            var selectedEvent = (from u in _context.Events
                        where u.Id == eventID
                        select u).FirstOrDefault();
            return selectedEvent;
        }

        /*Updates an event in the database
         *
         *@param selectedEvent represents the event being modified
         *
         @return...None
         */
        public void UpdateEvent(Event selectedEvent)
        {
            //Add the event that matches and save the changes to the database
            _context.Events.Add(selectedEvent);
            _context.SaveChanges();
        }

        /*Provides an Event object that is found by it's name, if there are
         *  several events that share a name, the first one in the database
         *  will be selected
         *
         *@param name...represents the name of the event being accessed
         *
         *@return...The Event object being searched for
         */
        public Event GetEventByName(string name)
        {
            //Iterate through all events in teh database, and if the name
            //  matches then return it
            var selectedEvent = (from u in _context.Events
                              where u.eventName == name
                              select u).FirstOrDefault();
            
            return selectedEvent;
        }

        /*Removes an event from the database
         *
         *@param selectedEvent...Represents the event to be deleted from the database
         *
         *@return...None
         */
        public void DeleteEvent(Event selectedEvent)
        {
            _context.Remove(selectedEvent);
            _context.SaveChanges();
        }

        /*Saves all changes made to the database
         *
         *@return...true IFF any changes to the database have been successfully saved
         *          OTHERWISE false
         */
        public bool SaveAll() { return _context.SaveChanges() > 0; }
        
    }
}
