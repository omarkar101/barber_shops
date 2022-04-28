using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using barber_shops.Utils;
using Microsoft.AspNetCore.Authorization;
using barber_shops.Repos;
using barber_shops.Models;

namespace barber_shops.Controllers;

public class ClientController : Controller
{
  private readonly IClientsRepo _clientsRepo;
  private UserManager<Client> _userManager;
  private SignInManager<Client> _signInManager;
  public ClientController(IClientsRepo clientsRepo, UserManager<Client> userManager, SignInManager<Client> signInManager)
  {
    _clientsRepo = clientsRepo;
    _userManager = userManager;
    _signInManager = signInManager;
  }

  [Authorize]
  public IActionResult Profile()
  {
    var clientUsername = _userManager.GetUserName(User);
    var client = _clientsRepo.GetClientByEmail(clientUsername);
    return View(client);
  }

  public IActionResult Edit(int id)
  {
    var client = _clientsRepo.GetClientByID(id);
    return View(client);
  }

  [HttpPost]
  public IActionResult edit(int id, Client client)
  {
    ViewData["error"] = null;
    try
    {
      _clientsRepo.UpdateClient(id, client);
    }
    catch (Exception ex)
    {
      ViewData["error"] = ex.Data;
      return RedirectToAction("edit", new { Id = id });
    }
    return RedirectToAction("Profile");
  }
}
