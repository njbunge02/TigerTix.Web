namespace TigerTix.Web.Data.Entities
{
    public class User
    {
        public int Id {get;set;}           //The User's unique ID number
        public string userName {get;set;}  //The display name of the user
        public string firstName {get;set;} //User's first name
        public string lastName {get;set;}  //User's last name
    }
}
