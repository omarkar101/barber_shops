using System.ComponentModel.DataAnnotations;

namespace barber_shops.Models;

public class ClientReservation {
  [Key]
  public string Id {get;set;}
  public string ClientEmail {get; set;}
  public string BarberEmail {get;set;}
  public string StartTime {get;set;}
  public string EndTime {get;set;}

  public bool Haircut {get;set;}
  public bool BearTrim {get;set;}
  public bool SkinCare {get;set;}
  public bool Wax {get;set;}
  public bool QuickShower {get;set;}
}
