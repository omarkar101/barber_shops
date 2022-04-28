using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
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
    var model = new ProfileViewModel
    {
      Username = clientUsername,
      FirstName = client.FirstName,
      LastName = client.LastName,
      PhoneNumber = client.PhoneNumber,
      id=client.Id
    };
    return View(model);
  }

  [Authorize]
  [HttpPost]
  public IActionResult Profile(string id, ProfileViewModel model)
  {
    Console.WriteLine(id);
    ViewData["error"] = null;
    try
    {
      _clientsRepo.UpdateClient(id, new Client {FirstName=model.FirstName, LastName=model.LastName, PhoneNumber=model.PhoneNumber});
    }
    catch (Exception ex)
    {
      ViewData["error"] = ex.Data;
    }
    return RedirectToAction("Profile");
  }
}
