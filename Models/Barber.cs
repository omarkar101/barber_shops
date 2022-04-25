using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace barber_shops.Models;

public class Barber
{

    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    [Required]
    public string Description {get;set;}=null!;
    [Required]
    public string Skills {get;set;}=null!;
    [Required]
    public string Experience {get;set;}=null!;
    [Required]
    public string Accomplishments {get;set;}=null!;
    [Required]
    public string Products {get;set;}=null!;
}
