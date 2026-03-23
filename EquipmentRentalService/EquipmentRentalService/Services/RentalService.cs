using EquipmentRentalService.Models;

namespace EquipmentRentalService.Services;

public class RentalService
{
    private readonly List<Equipment> _equipment = new();
    private readonly List<User> _users = new();
    private readonly List<Rental> _rentals = new();
    private readonly PenaltyService _penaltyService = new();
    private int _nextRentalId = 1;

    public List<Equipment> EquipmentList => _equipment;
    public List<User> Users => _users;
    public List<Rental> Rentals => _rentals;

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void MarkEquipmentUnavailable(int equipmentId)
    {
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);
        if (equipment == null)
        {
            Console.WriteLine("Equipment not found.");
            return;
        }

        equipment.IsMarkedUnavailable = true;
        equipment.IsAvailable = false;
        Console.WriteLine("Equipment marked as unavailable.");
    }

    public void RentEquipment(int userId, int equipmentId, DateTime rentalDate, DateTime dueDate)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        if (equipment == null)
        {
            Console.WriteLine("Equipment not found.");
            return;
        }

        if (!equipment.IsAvailable || equipment.IsMarkedUnavailable)
        {
            Console.WriteLine("Equipment is not available.");
            return;
        }

        var activeRentalsCount = _rentals.Count(r => r.User.Id == userId && !r.IsReturned);
        if (activeRentalsCount >= user.RentalLimit)
        {
            Console.WriteLine("User reached rental limit.");
            return;
        }

        var rental = new Rental(_nextRentalId++, user, equipment, rentalDate, dueDate);
        _rentals.Add(rental);
        equipment.IsAvailable = false;

        Console.WriteLine("Rental created.");
    }

    public void ReturnEquipment(int rentalId, DateTime returnDate)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
        {
            Console.WriteLine("Rental not found.");
            return;
        }

        if (rental.IsReturned)
        {
            Console.WriteLine("Equipment already returned.");
            return;
        }

        rental.ReturnDate = returnDate;
        rental.Penalty = _penaltyService.CalculatePenalty(rental.DueDate, returnDate);
        rental.Equipment.IsAvailable = !rental.Equipment.IsMarkedUnavailable;

        Console.WriteLine($"Equipment returned. Penalty: {rental.Penalty}");
    }

    public List<Rental> GetUserActiveRentals(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && !r.IsReturned).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => r.IsOverdue).ToList();
    }
}