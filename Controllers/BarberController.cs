using Microsoft.AspNetCore.Mvc;
using barber_shops.Repos;
namespace barber_shops.Controllers;
using barber_shops.Models;
public class BarberController : Controller {
    private readonly IBarbersRepo _barbersRepo;

    public BarberController(IBarbersRepo barbersRepo)
    {
        _barbersRepo = barbersRepo;
    }
    public IActionResult Index(int id, string? message) {
        var barber = _barbersRepo.GetBarberByID(id);
        var model = new ClientReservationViewModel {
            BarberDescription=barber.Description,
            BarberId=barber.Id,
            BarberEmail=barber.Username,
            BarberExperience=barber.Experience,
            BarberFirstName=barber.FirstName,
            BarberLastName=barber.LastName,
            BarberLocation=barber.Location
        };
        ViewData["message"] = message;
        return View(model);
    }
}
