using barber_shops.Data;
using barber_shops.Models;

namespace barber_shops.Repos;

public class BarbersRepo : IBarbersRepo
{
    private readonly AppDbContext _context;

    public BarbersRepo(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Barber> GetBarbers()
    {
        return _context.Barbers.OrderBy(c => c.Id).ToList();
    }

    public Barber? GetBarberByID(int id)
    {
        return _context.Barbers.Where(c => c.Id == id).FirstOrDefault();
    }
    

    public Barber? GetBarberByID(string email){
        return _context.Barbers.Where(c => c.Username.Equals(email)).FirstOrDefault();
    }
    public List<Barber>? GetBarbersbyName(string name){
        return _context.Barbers.Where(c=>c.FirstName==name || c.LastName==name || (c.FirstName+" "+c.LastName)==name).OrderBy(m=>m.Id).ToList();
    }


    public void AddBarber(Barber barber)
    {
        _context.Barbers.Add(barber);
        _context.SaveChanges();
    }

    public void DeleteBarber(Barber barber)
    {
        var barberToDelete = GetBarberByID(barber.Id);
        if (barberToDelete != null)
        {
            _context.Barbers.Remove(barber);
            _context.SaveChanges();
        }
    }

    public void UpdateBarber(int id, Barber barber)
    {
        var barberToUpdate = GetBarberByID(id);
        if (barberToUpdate != null)
        {
            barberToUpdate.FirstName = barber.FirstName;
            _context.SaveChanges();
        }
    }
}