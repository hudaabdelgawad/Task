using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Task;
using Task.Controllers;
using Task.Models;
using Task.Resource;


public class AccountController : BaseController
{
    private readonly InvoiceDbContext _context;
   

    public AccountController(InvoiceDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Register(string username, string password)
    {
        if (ModelState.IsValid)
        {
            var encryptedPassword = EncryptionHelper.Encrypt(password);
            var user = new User
            {
                Username = username,
                Password = encryptedPassword
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");

        }

        return View();
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        var encryptedPassword = EncryptionHelper.Encrypt(password);
        var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == encryptedPassword);

        if (user != null)
        {
            var sessionToken = Guid.NewGuid().ToString();
            user.SessionToken = sessionToken;
            user.SessionExpiry = DateTime.Now.AddHours(3);
            _context.SaveChanges();

            HttpCookie authCookie = new HttpCookie("AuthToken", sessionToken);
            authCookie.Expires = DateTime.Now.AddHours(3);
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Index", "Home");

        }

        ModelState.AddModelError("", Resource.Invalid);
       
        return View();
    }

    [HttpGet]
    public ActionResult Logout()
    {
       
        Session.Abandon();
        return RedirectToAction("Login", "Account");
    }

    //[HttpPost]
    //public ActionResult Logout()
    //{
    //    var authCookie = Request.Cookies["AuthToken"];
    //    if (authCookie != null)
    //    {
    //        authCookie.Expires = DateTime.Now.AddDays(-1);
    //        Response.Cookies.Add(authCookie);
    //    }
    //    Session.Abandon();
    //    return RedirectToAction("Login");
    //}
}
          