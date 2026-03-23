namespace EquipmentRentalService.Models;

public abstract class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected User(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName => $"{FirstName} {LastName}";

    public abstract int RentalLimit { get; }

    public override string ToString()
    {
        return $"{Id}: {FullName}";
    }
}