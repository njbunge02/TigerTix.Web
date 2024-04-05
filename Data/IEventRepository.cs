using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IEventRepository
    {
        void DeleteEvent(Event selectedEvent);

        IEnumerable<Event> GetAllEvents();
        Event GetEventId(int eventID);
        void SaveEvent(Event selectedEvent);
        void UpdateEvent(Event selectedEvent);
        Event GetEventByName(string name);
        bool SaveAll();

    }
}