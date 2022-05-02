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

    public IActionResult Search(List<Barber> listOfBarbers) {
        
        return View(listOfBarbers);
    }

    [HttpPost]
    public IActionResult Search(string name) {
        var barbers = _barbersRepo.GetBarbers();
        List<Barber> SearchedBarbers = new List<Barber>();
        foreach (Barber barber in barbers)
        {
            if (barber.FirstName == name || barber.LastName == name)
            {
                SearchedBarbers.Add(barber);
            }
        }

        return RedirectToAction("Search", SearchedBarbers);
    }
}
