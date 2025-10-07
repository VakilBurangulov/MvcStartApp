using System.Threading.Tasks;

public interface IRequestRepository
{
    Task AddRequest(Request request);
    
    Task<Request[]> GetRequests();
}