namespace TigerTix.Web.Data.Entities
{
    public class Event
    {
        public int Id {get;set;}                //Unique Event ID number
        public string eventName {get;set;}      //Name of the event
        public int numTickets {get;set;}        //Number of available tickets
        public string date {get;set;}           //Date of event
        public double pricePerTicket {get;set;} //Price per ticket being sold

        public string imageName {get;set;} //Name of image representing the event
    }
}
