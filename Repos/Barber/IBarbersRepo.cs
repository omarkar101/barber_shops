using barber_shops.Models;
namespace barber_shops.Repos;

public interface IBarbersRepo
{
    IEnumerable<Barber> GetBarbers();
    List<Barber>? GetBarbersbyName(string name);
    Barber? GetBarberByID(int id);
    void AddBarber(Barber barber);
    void DeleteBarber(Barber barber);
    void UpdateBarber(int id, Barber barber);
}
