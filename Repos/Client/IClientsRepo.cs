using barber_shops.Models;
namespace barber_shops.Repos;

public interface IClientsRepo
{
    IEnumerable<Client> GetClients();
    Client? GetClientByID(string id);
    Client? GetClientByEmail(string email);
    void AddClient(Client client);
    void DeleteClient(Client client);
    void UpdateClient(string id, Client client);
}
