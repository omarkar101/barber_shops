using barber_shops.Models;
namespace barber_shops.Repos;

public interface IBarbersRepo
{
    IEnumerable<Barber> GetBarbers();
    Barber? GetBarberByID(int id);
    Barber? GetBarberByID(string email);
    void AddBarber(Barber barber);
    void DeleteBarber(Barber barber);
    void UpdateBarber(int id, Barber barber);
}
