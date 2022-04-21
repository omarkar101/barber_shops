using System.ComponentModel.DataAnnotations;

namespace barber_shops.Models;

public class Barber
{

    [Key]
    [Required]
    public int Id {get; set;} = 0;

    [Required]
    public string FirstName {get; set;} = null!;

    [Required]
    public string LastName {get;set;} = null!;

    [Required]
    public string Location {get; set;} = null!;

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber {get;set;} = null!;

    [Required]
    public string IMG {get; set;} = null!;

    [Required]
    public int averagePrice {get; set;} = 0;

    [Required]
    public int Rating {get; set;} = 0;

}
