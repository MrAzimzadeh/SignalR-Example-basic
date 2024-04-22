using Microsoft.AspNetCore.Mvc;
using SignalR_ServerClient.Business;

namespace SignalR_ServerClient.Controllers;
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly MyBusiness _business;

    public HomeController(MyBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string Message)
    {
        await _business.SendMessageAsync(Message);
        return Ok();
    }
}
