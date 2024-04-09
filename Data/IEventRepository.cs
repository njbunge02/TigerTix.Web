using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IEventRepository
    {
        /*Saves an event to the context database
         *
         *@param selectedEvent...Represents the Event object being added to the database
         */
        void SaveEvent(Event selectedEvent);
        
        /*Provides all previously registered events on the site
         *
         *@return...A list containing every event in the database
         */
        IEnumerable<Event> GetAllEvents();

        /*Provides an Event object that is found by it's unique ID
         *
         *@param eventID...represents the unique ID of the event being accessed
         *
         *@return...The Eveng object being searched for
         */
        Event GetEventId(int eventID);

        /*Updates an event in the database
         *
         *@param selectedEvent represents the event being modified
         *
         @return...None
         */
        void UpdateEvent(Event selectedEvent);

        /*Provides an Event object that is found by it's name, if there are
         *  several events that share a name, the first one in the database
         *  will be selected
         *
         *@param name...represents the name of the event being accessed
         *
         *@return...The Event object being searched for
         */
        Event GetEventByName(string name);

        /*Removes an event from the database
         *
         *@param selectedEvent...Represents the event to be deleted from the database
         *
         *@return...None
         */
        void DeleteEvent(Event selectedEvent);

        /*Saves all changes made to the database
         *
         *@return...true IFF any changes to the database have been successfully saved
         *          OTHERWISE false
         */
        bool SaveAll();

    }
}
