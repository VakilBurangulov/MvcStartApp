using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class RequestRepository: IRequestRepository
{
    private readonly BlogContext _context;
    private IRequestRepository _requestRepositoryImplementation;

    public RequestRepository(BlogContext context)
    {
        _context = context;
    }
    
    public async Task AddRequest(Request request)
    {
        // Добавление запроса
        var entry = _context.Entry(request);
        if (entry.State == EntityState.Detached)
            await _context.Requests.AddAsync(request);
      
        // Сохранение изменений
        await _context.SaveChangesAsync();
    }
    
    public async Task<Request[]> GetRequests()
    {
        // Получим всех активных пользователей
        return await _context.Requests.ToArrayAsync();
    }
}