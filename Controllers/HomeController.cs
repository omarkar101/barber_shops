using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using barber_shops.Models;
using barber_shops.Repos;

namespace barber_shops.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBarbersRepo _barbersRepo;

    public HomeController(ILogger<HomeController> logger, IBarbersRepo barbersRepo)
    {
        _logger = logger;
        _barbersRepo = barbersRepo;
    }


    public IActionResult Index()
    {
        var barbers = _barbersRepo.GetBarbers();
        return View(barbers);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpPost]
    public IActionResult Search(string name) {
        var allBarbers = _barbersRepo.GetBarbers();
        List<Barber> barbers = new List<Barber>();
        foreach (var barber in allBarbers)
        {
            if (barber.FirstName.Concat(barber.LastName).ToString().ToLower().StartsWith(name.ToLower()) || barber.FirstName.ToLower().StartsWith(name.ToLower()) || barber.LastName.ToLower().StartsWith(name.ToLower())) {
                barbers.Add(barber);
            }
        }
        return View(barbers);
    }

    
}
