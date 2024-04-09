using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IUserRepository
    {
        void DeleteUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserId(int userID);

        User GetUserByUsername(string username);
        void SaveUser(User user);
        void UpdateUser(User user);

        bool SaveAll();

    }
}