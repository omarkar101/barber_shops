using System.ComponentModel.DataAnnotations;
namespace barber_shops.Models;

public class ProfileViewModel
{
  public string id;
  [Required(ErrorMessage = "Please enter a username.")]
  [StringLength(255)]
  public string Username { get; set; }

  [Required(ErrorMessage = "Please enter a First Name.")]
  [StringLength(255)]
  public string FirstName { get; set; }


  [Required(ErrorMessage = "Please enter a Last Name.")]
  [StringLength(255)]
  public string LastName { get; set; }

  [Required(ErrorMessage = "Please enter a Last Name.")]
  [DataType(DataType.PhoneNumber)]
  public string PhoneNumber { get; set; }
}
