using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace barber_shops.Models;

public class Client
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string FirstName {get; set;} = null!;

    [Required]
    public string LastName {get;set;} = null!;

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber {get;set;} = null!;

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email {get;set;} = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password {get;set;} = null!;
}
