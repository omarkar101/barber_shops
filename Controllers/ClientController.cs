using Microsoft.AspNetCore.Mvc;
using barber_shops.Utils;
using barber_shops.Repos;
using barber_shops.Models;

namespace barber_shops.Controllers;

public class ClientController : Controller {
    private readonly IClientsRepo _clientsRepo;
    public ClientController(IClientsRepo clientsRepo) {
        _clientsRepo = clientsRepo;
    }
    public IActionResult SignUp() {
        return View();
    }

    public IActionResult Login() {
        return View();
    }

    [HttpPost]
    public IActionResult Login(Client client) {
        var clientFromDb = _clientsRepo.GetClientByEmail(client.Email);
        if(clientFromDb == null) {
            return RedirectToAction("SignUp");
        }
        if(!clientFromDb.Password.Equals(client.Password)) {
            return RedirectToAction("Login");
        }
        Response.Cookies.Append("email", client.Email);
        Response.Cookies.Append("password", client.Password);
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult SignUp(Client client) {
        var clientFromDb = _clientsRepo.GetClientByEmail(client.Email);
        if(clientFromDb != null) {
            return RedirectToAction("SignUp");
        }
        _clientsRepo.AddClient(client);
        return RedirectToAction("Login");
    }

    public IActionResult Profile() {
        string? email = Request.Cookies["email"];
        string? password = Request.Cookies["password"];
        if(!Credentials.verifyCredentials(email, password, _clientsRepo)) {
            return RedirectToAction("Login");
        }
        var client = _clientsRepo.GetClientByEmail(email);
        return View(client);
    }

    [HttpPost]
    public IActionResult Profile(int id, Client client)
    {
        ViewData["error"] = null;
        try {
            _clientsRepo.UpdateClient(id, client);
        } catch(Exception ex)
        {
            ViewData["error"] = ex.Data;
            return RedirectToAction("Profile");
        }
        return RedirectToAction("Profile");
    }
}
