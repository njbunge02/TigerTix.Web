using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly TigerTixContext _context;
        public PurchaseRepository(TigerTixContext context) { _context = context; }

        /*Saves a purchase to the context database
         * 
         *@param selectedPurchase...Represents the purchase
         *       object being saved to the database
         */
        public void SavePurchase(Purchase selectedPurchase)
        {
            //Add the purchase to the database, and save
            _context.Add(selectedPurchase);
            _context.SaveChanges();
        }

        /*Provides all previosuly registered purchase on the site
         * 
         *@return...A List containing every purchase in the database
         */
        public IEnumerable<Purchase> GetAllPurchases()
        {
            //Store every event in the context field, and return them as a list
            var purchaseList = from selectedPurchase in _context.Purchases
                               select selectedPurchase;
            return purchaseList.ToList();
        }

        /*Provides a purchase object that is retrieved by its unique ID
         * 
         *@param PurchaseID...represents the unique ID of the purchase being accessed
         *
         *@return...The Purchase ovject being searched for
         */
        public Purchase GetPurchaseByID(int PurchaseID)
        {
            //Iterate through all purchases in the dtabase, and if the ID
            //  matches, return it
            var selectedPurchase = (from p in _context.Purchases
                                    where p.Id == PurchaseID
                                    select p).FirstOrDefault();
            return selectedPurchase;
        }

        /*Updates a purcahse in the database
         * 
         *@param selectedPurchase represents the purchase being modified
         */
        public void UpdatePurchase(Purchase selectedPurchase)
        {
            //Add the event that matches and save the changes to the database
            _context.Purchases.Add(selectedPurchase);
            _context.SaveChanges();
        }

        /*Removes a purchase from the database
         * 
         *@param selectedPurchase...Represents the purchase being deleted
         */
        public void DeletePurcahse(Purchase selectedPurchase)
        {
            //Remove the purchase object passed in and save the changes
            _context.Remove(selectedPurchase);
            _context.SaveChanges();
        }

        /*Saves all changes made to the database
         * 
         *@return...true IFF any changes to the database have been successfully saved
         *          false OW
         */
        public bool SaveAll() { return _context.SaveChanges() > 0; }

    }
}
