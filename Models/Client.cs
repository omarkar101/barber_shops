using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace barber_shops.Models;

public class Client : IdentityUser
{
    [Required]
    public string FirstName {get; set;} = null!;

    [Required]
    public string LastName {get;set;} = null!;
}
