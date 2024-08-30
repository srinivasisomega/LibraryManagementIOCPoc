using LibraryManagementIOCPoc.models;
namespace LibraryManagementIOCPoc.interfaces
{

    
        public interface IUserService
        {
            void RegisterUser(string name, string email, string password); // Updated to include password
            bool Login(string email, string password);
            User GetUserById(int userId);
        }
    



}
