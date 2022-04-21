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
    public IActionResult Index(int id) {
        var barber = _barbersRepo.GetBarberByID(id);
        return View(barber);
    }
}
