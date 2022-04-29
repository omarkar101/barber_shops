using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using barber_shops.Repos;
using barber_shops.Models;

namespace barber_shops.Controllers
{
    public class ClientReservationController : Controller
    {
        public IActionResult Reserve(){
            return View();
        }
    }
}