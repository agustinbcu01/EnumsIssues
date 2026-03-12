using EnumsIssues.Services;
using EnumsIssues.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EnumsIssues.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
          "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };

    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
      _logger = logger;
      _userService = userService;  
    }

    [HttpGet(Name = "Get-ActiveUsers")]
    public IEnumerable<UserModel> GetActives()
    {
      return _userService.GetAllActive();
    }

    [HttpPost(Name = "Create-User")]
    public int Create(UserModel model)
    {
      return _userService.Create(model);
    }
  }
}
