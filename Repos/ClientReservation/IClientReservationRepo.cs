using barber_shops.Models;
namespace barber_shops.Repos;

public interface IClientReservationsRepo
{
    IEnumerable<ClientReservation> GetClientReservations(string clientUsername);
    ClientReservation? GetClientReservationByID(int id);
    IEnumerable<ClientReservation> GetBarberReservations(string barberEmail);
    ClientReservation? GetClientReservationByBarberAndClientEmails(string clientEmail, string BarberEmail);
    bool CheckIfSlotAvailable(string barberEmail, DateTime dateTime);
    void AddClientReservation(ClientReservation ClientReservation);
    void DeleteClientReservation(ClientReservation ClientReservation);
    void UpdateClientReservation(int id, ClientReservation ClientReservation);
}
