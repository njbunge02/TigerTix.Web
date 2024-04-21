using TigerTix.Web.Data.Entities;
using TigerTix.Web.Models;

namespace TigerTix.Web.Data
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly TigerTixContext _context;
        public DiscountRepository(TigerTixContext context) { _context = context; }

        /*Saves a discount to the context database
         *
         *@param selectedDiscount...Represents the Discount object being added to the database
         */
        public void SaveDiscount(Discount selectedDiscount)
        {
            _context.Add(selectedDiscount);
            _context.SaveChanges();
        }

        /*Provides all previously registered discounts on the site
         *
         *@return...A list containing every discount in the database
         */
        public IEnumerable<Discount> GetAllDiscounts()
        {
            //Store every discount in the context field and return them as a list
            var discountList = from selectedDiscount in _context.Discounts
                               select selectedDiscount;
            return discountList.ToList();
        }

        /*Provides all registerd discounts on the site that are applicable
         * to a specific type of user
         * 
         *@return...A List containing every discount applicable to a given user
         */
        public IEnumerable<Discount> GetApplicable(string userType)
        {
            var discountList = from d in _context.Discounts
                               where d.appliesTo == userType
                               select d;

            return discountList.ToList();
        }

		/*Provides a Discount object that is found by it's unique ID
         *
         *@param eventID...represents the unique ID of the discount being accessed
         *
         *@return...The Discount object being searched for
         */
		public Discount GetDiscountId(int discountID)
        {
            //Iterate through all discounts in the database, and if the ID matches
            //  then return it
            var selectedDiscount = (from d in _context.Discounts
                                    where d.Id == discountID
                                    select d).FirstOrDefault();
            return selectedDiscount;
        }

        /*Updates an discount in the database
         *
         *@param selectedDiscount represents the discount being modified
         *
         @return...None
         */
        public void UpdateDiscount(Discount selectedDiscount)
        {
            //Add the discount that matches and save the changes to the database
            _context.Discounts.Add(selectedDiscount);
            _context.SaveChanges();
        }

        /*Provides a Discount object that is found by it's name, if there are
         *  several events that share a name, the first one in the database
         *  will be selected
         *
         *@param name...represents the name of the discount being accessed
         *
         *@return...The DIscount object being searched for
         */
        public Discount GetDiscountByName(string name)
        {
            //Iterate through all discounts in the database, and if the name
            //  matches then return it
            var selectedDiscount = (from d in _context.Discounts
                                    where d.discountName == name
                                    select d).FirstOrDefault();
            
            return selectedDiscount;
        }

        /*Removes an event from the database
         *
         *@param selectedEvent...Represents the event to be deleted from the database
         *
         *@return...None
         */
        public void DeleteDiscount(Discount selectedDiscount)
        {
            _context.Remove(selectedDiscount);
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
