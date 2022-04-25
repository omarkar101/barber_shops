using barber_shops.Repos;
namespace barber_shops.Utils;

public static class Credentials {
  public static bool verifyCredentials(string email, string password, IClientsRepo clientsRepo) {
    var client = clientsRepo.GetClientByEmail(email);
    if(client == null) {
      return false;
    }
    if(!client.Password.Equals(password)) {
      return false;
    }
    return true;
  }
}