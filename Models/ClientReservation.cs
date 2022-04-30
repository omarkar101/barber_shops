using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace barber_shops.Models;

public class ClientReservation {
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id {get;set;}
  public string ClientEmail {get; set;}
  public string BarberEmail {get;set;}
  public DateTime StartTime {get;set;}
  public DateTime EndTime {get;set;}

  public bool Haircut {get;set;}
  public bool BearTrim {get;set;}
  public bool SkinCare {get;set;}
  public bool Wax {get;set;}
  public bool QuickShower {get;set;}
}
