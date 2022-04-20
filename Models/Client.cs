using System.ComponentModel.DataAnnotations;

namespace barber_shops.Models;

public class Client
{

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string FirstName {get; set;} = null!;

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber {get;set;} = null!;

}
