using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IDiscountRepository
    {
        /*Saves an event to the context database
         *
         *@param selectedEvent...Represents the Event object being added to the database
         */
        void SaveDiscount(Discount selectedDiscount);
        
        /*Provides all previously registered events on the site
         *
         *@return...A list containing every event in the database
         */
        IEnumerable<Discount> GetAllDiscounts();

        /*Provides all registerd discounts on the site that are applicable
         * to a specific type of user
         * 
         *@return...A List containing every discount applicable to a given user
         */
        IEnumerable<Discount> GetApplicable(string userType);

        /*Provides an Event object that is found by it's unique ID
         *
         *@param eventID...represents the unique ID of the event being accessed
         *
         *@return...The Event object being searched for
         */
        Discount GetDiscountId(int discountID);

        /*Updates an event in the database
         *
         *@param selectedEvent represents the event being modified
         *
         @return...None
         */
        void UpdateDiscount(Discount selectedDiscount);

        /*Provides an Event object that is found by it's name, if there are
         *  several events that share a name, the first one in the database
         *  will be selected
         *
         *@param name...represents the name of the event being accessed
         *
         *@return...The Event object being searched for
         */
        Discount GetDiscountByName(string name);

        /*Removes an event from the database
         *
         *@param selectedEvent...Represents the event to be deleted from the database
         *
         *@return...None
         */
        void DeleteDiscount(Discount selectedDiscount);

        /*Saves all changes made to the database
         *
         *@return...true IFF any changes to the database have been successfully saved
         *          OTHERWISE false
         */
        bool SaveAll();

    }
}
