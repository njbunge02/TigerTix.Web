namespace TigerTix.Web.Data.Entities
{
    public class Event
    {
        public int Id {get;set;}
        public string eventName {get;set;}
        public int numTickets {get;set;}
        public string date {get;set;}
        public double pricePerTicket {get;set;}

        public string imageName {get;set;}
        

    }
}