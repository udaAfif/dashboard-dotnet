using Microsoft.AspNetCore.Mvc;
using dotNetDashboard.Data;
using dotNetDashboard.Models;

namespace dotNetDashboard.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _db;

    public AccountController(AppDbContext db) => _db = db;

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);
            HttpContext.Session.SetString("Email", user.Email);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }


    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(string username, string password)
    {
        if (_db.Users.Any(u => u.Username == username))
        {
            ViewBag.Error = "Username sudah terdaftar";
            return View();
        }

        _db.Users.Add(new User { Username = username, Password = password, Role = "Standard" });
        _db.SaveChanges();
        return RedirectToAction("Login");
    }

    public IActionResult ForgotPassword() => View();

    [HttpPost]
    public IActionResult ForgotPassword(string username, string newPassword)
    {
        var user = _db.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            ViewBag.Error = "Username tidak ditemukan";
            return View();
        }

        user.Password = newPassword;
        _db.SaveChanges();
        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
