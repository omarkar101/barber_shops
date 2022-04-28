using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using barber_shops.Repos;
using barber_shops.Models;

namespace barber_shops.Controllers;

public class AccountController : Controller
{
  private readonly IClientsRepo _clientsRepo;
  private UserManager<Client> _userManager;
  private SignInManager<Client> _signInManager;
  public AccountController(IClientsRepo clientsRepo, UserManager<Client> userManager, SignInManager<Client> signInManager)
  {
    _clientsRepo = clientsRepo;
    _userManager = userManager;
    _signInManager = signInManager;
  }
  public IActionResult SignUp()
  {
    return View();
  }

  public IActionResult Login(string returnUrl = "")
  {
    var model = new LoginViewModel { ReturnUrl = returnUrl };
    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> LogIn(LoginViewModel model)
  {
    if (ModelState.IsValid)
    {
      var result = await _signInManager.PasswordSignInAsync(
      model.Username, model.Password,
      isPersistent: true,
      lockoutOnFailure: false);
      if (result.Succeeded)
      {
        if (!string.IsNullOrEmpty(model.ReturnUrl) &&
        Url.IsLocalUrl(model.ReturnUrl))
        {
          return Redirect(model.ReturnUrl);
        }
        else
        {
          return RedirectToAction("Index", "Home");
        }
      }
    }
    ModelState.AddModelError("", "Invalid username/password.");
    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> SignUp(SignUpViewModel model)
  {
    if (ModelState.IsValid)
    {
      var client = new Client
      {
        UserName = model.Username,
        FirstName = model.FirstName,
        LastName = model.LastName,
        PhoneNumber = model.PhoneNumber
      };
      var result = await _userManager.CreateAsync(client, model.Password);
      if (result.Succeeded)
      {
        await _signInManager.SignInAsync(client, isPersistent: false);
        return RedirectToAction("Index", "Home");
      }
      else
      {
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
      }
    }
    else
    {
    }
    return View(model);
  }
  public async Task<IActionResult> LogOut()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }
}
