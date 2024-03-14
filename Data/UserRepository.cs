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
       }

       public void SaveUser(User user)
       {
            _context.Add(user);
            _context.SaveChanges();
       }

       public IEnumerable<User> GetAllUsers()
       {
            var usersList = from user in _context.Users
                            select user;

            return usersList.ToList();
       }

       public User GetUserId(int userID)
       {
            var user = (from u in _context.Users
                        where u.Id == userID 
                        select u).FirstOrDefault();

        return user;
       }

       public void UpdateUser(User user)
       {
            _context.Users.Add(user);
            _context.SaveChanges();
       }

       public void DeleteUser(User user)
       {
            _context.Remove(user);
            _context.SaveChanges();
       }

       public bool SaveAll()
       {
        return _context.SaveChanges() > 0;
       }

     
    }
}