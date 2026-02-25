using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Customer")]
public class CustomerController : Controller
{
    public IActionResult CustomerDashboard()
    {
        return Content("Welcome Customer");
    }
}