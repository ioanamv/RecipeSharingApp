namespace RecipeSharingApp.Data
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public static class UsersAvailable
    {
        public static List<User> Users = new List<User>
        {
            new User{Email="user1@mail.com", Password="1111", Role="regular"},
            new User{Email="user2@mail.com", Password="2222", Role="regular"},
            new User{Email="admin@mail.com", Password="admin", Role="admin"}
        };
    }
}
