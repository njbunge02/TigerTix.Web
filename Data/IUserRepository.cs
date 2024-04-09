using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IUserRepository
    {
        /*Removes a user from the database
         *
         *@param user...represents the User object to be removed from the database
         *
         *@return...none
         */
        void DeleteUser(User user);

        /*Accesses all users registered in the database
         *
         *@return...A list of User objects made up of every User
         *          previously registered in the database
         */
        IEnumerable<User> GetAllUsers();

        /*Access a user by their unique userID number
         *
         *@param userID...Represents the id number of the user being searched for
         *
         *@return...The User object with matching userID to the one specified
         */
        User GetUserId(int userID);

        User GetUserByUsername(string username);
        void SaveUser(User user);

        /*Updates the information of a User within the database
         *
         *@param user...Represents the User object being updated in the system
         *
         *@return...None
         */
        void UpdateUser(User user);

        /*Saves all changes made to the database
         *
         *@return...true IFF any changes were successfully saved to the database,
         *          OTHERWISE false
         */
        bool SaveAll();

    }
}
