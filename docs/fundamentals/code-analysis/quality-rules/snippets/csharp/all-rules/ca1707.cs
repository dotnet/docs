using System;

// <Snippet1>
namespace ca_1707
{
    public interface IUser_Service
    {
        void Add_User(User_Model user_Model);
    }

    public class User_Service : IUser_Service
    {
        public const string Admin_Name = "admin";
        public event EventHandler? User_Added;

        public void Add_User(User_Model user_Model)
        {
            // ...
        }
    }

    public struct User_Model
    {
        public int User_Id { get; set; }
    }

    public enum User_Type
    {
        Client_User = 0,
        Manager_Admin = 1,
        Syper_Admin = 3,
    }
}
// </Snippet1>
