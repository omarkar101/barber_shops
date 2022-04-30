using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using barber_shops.Repos;
using barber_shops.Models;

namespace barber_shops.Controllers
{
  public class ClientReservationController : Controller
  {
    private readonly IClientReservationsRepo _clientReservationsRepo;
    private UserManager<Client> _userManager;
  private SignInManager<Client> _signInManager;

    public ClientReservationController(IClientReservationsRepo clientReservationsRepo, UserManager<Client> userManager, SignInManager<Client> signInManager) {
      _clientReservationsRepo = clientReservationsRepo;
      _userManager = userManager;
    _signInManager = signInManager;
    }

    [Authorize]
    [HttpPost]
    public IActionResult Reserve(int barberId, string barberEmail, ClientReservationViewModel model)
    {
      // we need first to check if the slot for reservation is available
      if(!_clientReservationsRepo.CheckIfSlotAvailable(barberEmail, model.Date)) {
        return RedirectToAction("Index", "Barber", new {id=barberId, message="This slot is not available, please choose another time slot"});
      }
      var clientUsername = _userManager.GetUserName(User);
      var clientReservation = new ClientReservation {
        BarberEmail=barberEmail,
        BearTrim=model.BearTrim,
        ClientEmail=clientUsername,
        StartTime=model.Date,
        EndTime=model.Date.AddMinutes(30),
        Haircut=model.Haircut,
        QuickShower=model.QuickShower,
        SkinCare=model.SkinCare,
        Wax=model.Wax
      };
      _clientReservationsRepo.AddClientReservation(clientReservation);
      return RedirectToAction("Profile", "Client");
    }
  }
}
