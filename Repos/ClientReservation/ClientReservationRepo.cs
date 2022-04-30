using barber_shops.Data;
using barber_shops.Models;
namespace barber_shops.Repos;

public class ClientReservationsRepo: IClientReservationsRepo
{
    private readonly AppDbContext _context;

    public ClientReservationsRepo(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<ClientReservation> GetClientReservations(string clientUsername) {
        return _context.ClientReservations.Where(c => c.ClientEmail == clientUsername).OrderBy(c => c.StartTime).ToList();
    }
    public IEnumerable<ClientReservation> GetBarberReservations(string barberEmail) {
        return _context.ClientReservations.Where(c => c.BarberEmail == barberEmail).ToList();
    }
    public ClientReservation? GetClientReservationByBarberAndClientEmails(string clientEmail, string barberEmail){
        return _context.ClientReservations.Where(c=>c.ClientEmail.Equals(clientEmail) && c.BarberEmail.Equals(barberEmail)).FirstOrDefault();
    }
    public bool CheckIfSlotAvailable(string barberEmail, DateTime dateTime) {
        var currentReservations = this.GetBarberReservations(barberEmail);
        foreach (var reservation in currentReservations)
        {
            if((dateTime >= reservation.StartTime && dateTime <= reservation.EndTime) ||
                (dateTime.AddMinutes(30) >= reservation.StartTime && dateTime.AddMinutes(30) <= reservation.EndTime)) {
                return false;
            }
        }
        return true;
    }
    public ClientReservation? GetClientReservationByID(int id){
        return _context.ClientReservations.Where(c=>c.Id==id).FirstOrDefault();
    }
    public void AddClientReservation(ClientReservation clientReservation){
        _context.ClientReservations.Add(clientReservation);
        _context.SaveChanges();
    }
    public void DeleteClientReservation(ClientReservation clientReservation){
        var clientToDelete = GetClientReservationByID(clientReservation.Id);
            if (clientToDelete != null)
            {
                _context.ClientReservations.Remove(clientReservation);
                _context.SaveChanges();
            }
    }
    public void UpdateClientReservation(int id,ClientReservation clientReservation){
        var clientToUpdate = GetClientReservationByID(id);
        if (clientToUpdate != null)
        {
            clientToUpdate.BarberEmail = clientReservation.BarberEmail;
            _context.SaveChanges();
        }
    }
}
