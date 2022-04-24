using Microsoft.AspNetCore.Mvc;
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
}
