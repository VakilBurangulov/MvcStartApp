using System.Threading.Tasks;

public interface IBlogRepository
{
    Task AddUser(User user);
    
    Task<User []> GetUsers();
}