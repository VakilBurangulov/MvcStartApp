using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class LogsController: Controller
{
    private readonly IRequestRepository _repo;

    public LogsController(IRequestRepository repo)
    {
        _repo = repo;
    }
    
    public async Task <IActionResult> Index()
    {
        var requests = await _repo.GetRequests();
        return View("Index", requests);
    }
}
