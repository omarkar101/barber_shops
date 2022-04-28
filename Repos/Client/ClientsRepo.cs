using barber_shops.Data;
using barber_shops.Models;

namespace barber_shops.Repos;

public class ClientsRepo : IClientsRepo
{
    private readonly AppDbContext _context;

    public ClientsRepo(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Client> GetClients()
    {
        return _context.Clients.OrderBy(c => c.Id).ToList();
    }

    public Client? GetClientByID(int id)
    {
        // return _context.Clients.Where(c => c.Id == id).FirstOrDefault();
        return null;
    }

    public Client? GetClientByEmail(string email)
    {
        return _context.Clients.Where(c => c.UserName.Equals(email)).FirstOrDefault();
    }

    public void AddClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void DeleteClient(Client client)
    {
        // var clientToDelete = GetClientByID(client.Id);
        // if (clientToDelete != null)
        // {
        //     _context.Clients.Remove(client);
        //     _context.SaveChanges();
        // }
    }

    public void UpdateClient(int id, Client client)
    {
        var clientToUpdate = GetClientByID(id);
        if (clientToUpdate != null)
        {
            clientToUpdate.FirstName = client.FirstName;
            clientToUpdate.LastName = client.LastName;
            clientToUpdate.Email = client.Email;
            clientToUpdate.PhoneNumber = client.PhoneNumber;
            _context.SaveChanges();
        }
    }
}
