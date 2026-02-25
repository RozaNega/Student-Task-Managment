using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Employee")]
public class EmployeeController : Controller
{
    public IActionResult EmployeeDashboard()
    {
        return Content("Welcome Employee");
    }
}