using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class UsersController : Controller
{
    private readonly IBlogRepository _repo;
      
    public UsersController(IBlogRepository repo)
    {
        _repo = repo;
    }
      
    public async Task <IActionResult> Index()
    {
        var authors = await _repo.GetUsers();
        return View("UsersIndex.cshtml", authors);
    }
    
    
    [HttpGet]
    public async Task <IActionResult> Register()
    {
        return View("Register.cshtml");
    }
    
    [HttpPost]
    public async Task <IActionResult> Register (User newUser)
    {
        await _repo.AddUser(newUser);
        return View("Register.cshtml", newUser);
    }
}