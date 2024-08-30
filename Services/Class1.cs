using LibraryManagementIOCPoc.interfaces;
using LibraryManagementIOCPoc.models;

namespace LibraryManagementIOCPoc.Services
{
      
        public class UserService : IUserService
        {
            private readonly List<User> _users = new List<User>();
            private int _nextUserId = 1;

            public void RegisterUser(string name, string email, string password)
            {
                var user = new User(_nextUserId++, name, email, password); // Password is now being accepted and stored
                _users.Add(user);
                Console.WriteLine($"User {name} registered with email {email}");
            }

            public bool Login(string email, string password)
            {
                var user = _users.Find(u => u.Email == email && u.Password == password);
                if (user != null)
                {
                    Console.WriteLine($"User {user.Name} logged in.");
                    return true;
                }
                return false;
            }

            public User GetUserById(int userId)
            {
                return _users.Find(u => u.UserId == userId);
            }
        }
    



}
