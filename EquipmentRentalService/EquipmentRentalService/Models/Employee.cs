namespace EquipmentRentalService.Models;

public class Employee : User
{
    public string Department { get; set; }
    public override int RentalLimit => 5;

    public Employee(int id, string firstName, string lastName, string department) : base(id, firstName, lastName)
    {
        Department = department;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Department: {Department} | Limit: {RentalLimit}";
    }
}