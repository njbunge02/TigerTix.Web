using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IPurchaseRepository
    {
        /*Saves a purchase to the context database
         * 
         *@param selectedPurchase...Represents the purchase
         *       object being saved to the database
         */
        void SavePurchase(Purchase selectedPurchase);

        /*Provides all previosuly registered purchase on the site
         * 
         *@return...A List containing every purchase in the database
         */
        IEnumerable<Purchase> GetAllPurchases();

        /*Provides a list of purchases made by the user
         * 
         *@param userID...Represents the unique ID of the user that made the purchase
         *
         *@return...A List containing every purchase made by the user matching the
         * provided userID
         */
        IEnumerable<Purchase> GetPurchaseHistory(string username);

        /*Provides a purchase object that is retrieved by its unique ID
         * 
         *@param PurchaseID...represents the unique ID of the purchase being accessed
         *
         *@return...The Purchase ovject being searched for
         */
        Purchase GetPurchaseByID(int PurchaseID);

        /*Updates a purcahse in the database
         * 
         *@param selectedPurchase represents the purchase being modified
         */
        void UpdatePurchase(Purchase selectedPurchase);

        /*Removes a purchase from the database
         * 
         *@param selectedPurchase...Represents the purchase being deleted
         */
        void DeletePurcahse(Purchase selectedPurchase);

        /*Saves all changes made to the database
         * 
         *@return...true IFF any changes to the database have been successfully saved
         *          false OW
         */
        bool SaveAll();

    }
}
