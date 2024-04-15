using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Models
{
	public class EventSignModel
	{
		public bool signedIn { get; set; }
		public User currUser { get; set; }
		public Event currEvent { get; set; }
	}
}
