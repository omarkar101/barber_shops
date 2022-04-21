using Microsoft.AspNetCore.Mvc;

namespace barber_shops.Controllers;
using barber_shops.Models;
public class BarberController : Controller {
    static List<Barber> barbers_list = new List<Barber>() {
        new Barber() 
        {
            Id = 1,
            FirstName = "Four Seasons",
            LastName = "wuefb",
            Location = "Beruit",
            PhoneNumber = "123321",
            Rating = 5,
            IMG = "https://pix10.agoda.net/hotelImages/4875372/0/d94a1a0632f10f0d4c1427de82f980d5.jpg?ca=22&ce=0&s=1024x768"
        },
        new Barber() 
        {
            Id = 1,
            FirstName = "Four Seasons",
            LastName = "wuefb",
            Location="Beruit",
            PhoneNumber = "123321",
            Rating = 5,
            IMG = "https://pix10.agoda.net/hotelImages/4875372/0/d94a1a0632f10f0d4c1427de82f980d5.jpg?ca=22&ce=0&s=1024x768"
        }
    };
}