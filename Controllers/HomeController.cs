
using Microsoft.AspNetCore.Mvc;

namespace dotNetDashboard.Controllers;


public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Username") == null)
            return RedirectToAction("Login", "Account");

        ViewBag.Username = HttpContext.Session.GetString("Username");
        ViewBag.Role = HttpContext.Session.GetString("Role");
        ViewBag.Email = HttpContext.Session.GetString("Email");
        return View();
    }
}
