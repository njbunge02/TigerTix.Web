using Microsoft.EntityFrameworkCore;
using TigerTix.Web.Data.Entities;
using TigerTix.Web.Models;


namespace TigerTix.Web.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly TigerTixContext _context;
        public UserRepository(TigerTixContext context)
        {
            _context = context;
            //uncomment to remove all events and users from databases 
            /*_context.Database.ExecuteSqlRaw("TRUNCATE TABLE Events");
            _context.Database.ExecuteSqlRaw("TRUNCATE TABLE Users");*/
        }

        /*Saves a user to the database
         *
         *@param user...Represents the User object being saved to the database
         *
         *@return...None
         */
        public void SaveUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

         /*Accesses all users registered in the database
         *
         *@return...A list of User objects made up of every User
         *          previously registered in the database
         */
        public IEnumerable<User> GetAllUsers()
        {
            //Iterate through each user in the database, adding each one to the
            //  'usersList' variable before converting it to a list and returning
            var usersList = from user in _context.Users
                            select user;
            return usersList.ToList();
        }

        /*Access a user by their unique userID number
         *
         *@param userID...Represents the id number of the user being searched for
         *
         *@return...The User object with matching userID to the one specified
         */
        public User GetUserId(int userID)
        {
            //Iterate through each user in the database, and return the first User
            //  object with a matching userID
            var user = (from u in _context.Users
                        where u.Id == userID 
                        select u).FirstOrDefault();

            return user;
        }

       public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

       public void UpdateUser(User user)
       {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /*Removes a user from the database
         *
         *@param user...represents the User object to be removed from the database
         *
         *@return...none
         */
        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        /*Saves all changes made to the database
         *
         *@return...true IFF any changes were successfully saved to the database,
         *          OTHERWISE false
         */
        public bool SaveAll() { return _context.SaveChanges() > 0; }
        
    }
}
