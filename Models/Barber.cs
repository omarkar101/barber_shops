using System.ComponentModel.DataAnnotations;

namespace barber_shops.Models;

public class Barber
{

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName {get; set;} = null!;

    [Required]
    public string LastName {get;set;} = null!;

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber {get;set;} = null!;

}
