using UFO_Webapplikasjon.Model;

namespace UFO_Webapplikasjon.DAL
{
    public interface InUserRepository
    {
        // Users/Admin
        Task<bool> CreateUser(User innUser);
        Task<List<User>> ReadAllUsers();
        Task<User> ReadLatestUser();
        Task<bool> DeleteUser(int id);
        Task<User> ReadOneUser(int id);
        Task<bool> UpdateUser(User updateUser);
        Task<bool> LogIn(User user);
    }
}