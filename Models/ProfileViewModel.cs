using System.ComponentModel.DataAnnotations;
namespace barber_shops.Models;

public class ProfileViewModel
{
  public string id =null!;
  [Required(ErrorMessage = "Please enter a username.")]
  [StringLength(255)]
  public string Username { get; set; }=null!;

  [Required(ErrorMessage = "Please enter a First Name.")]
  [StringLength(255)]
  public string FirstName { get; set; }=null!;


  [Required(ErrorMessage = "Please enter a Last Name.")]
  [StringLength(255)]
  public string LastName { get; set; }=null!;

  [Required(ErrorMessage = "Please enter a Last Name.")]
  [DataType(DataType.PhoneNumber)]
  public string PhoneNumber { get; set; }=null!;
  public IEnumerable <ClientReservation> ReservationList=null!;
  
  }
