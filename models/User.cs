namespace LibraryManagementIOCPoc.models
{


    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Password property

        public User(int userId, string name, string email, string password)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password; // Assign password in the constructor
        }
    }




}
