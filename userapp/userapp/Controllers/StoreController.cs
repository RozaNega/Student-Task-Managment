using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Storeman")]
public class StoreController : Controller
{
    public IActionResult StoreDashboard()
    {
        return Content("Welcome Storeman");
    }
}