namespace TigerTix.Web.Data.Entities
{
	public class Discount
	{
		public double percentOff { get; set; }

		public string discountName { get; set; }

		public int Id { get; set; }

		public string appliesTo { get; set; }
	}
}
