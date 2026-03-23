namespace EquipmentRentalService.Models;

public class Rental
{
    public int Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }

    public bool IsReturned => ReturnDate.HasValue;
    public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;

    public Rental(int id, User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        Id = id;
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        DueDate = dueDate;
    }

    public override string ToString()
    {
        var status = IsReturned ? $"Returned: {ReturnDate:dd.MM.yyyy}" : "Not returned";
        return $"{Id}: {User.FullName} -> {Equipment.Name} | Due: {DueDate:dd.MM.yyyy} | {status} | Penalty: {Penalty}";
    }
}