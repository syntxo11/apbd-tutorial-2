namespace EquipmentRentalService.Models;

public class Student : User
{
    public string StudentNumber { get; set; }
    public override int RentalLimit => 2;

    public Student(int id, string firstName, string lastName, string studentNumber) : base(id, firstName, lastName)
    {
        StudentNumber = studentNumber;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Student No: {StudentNumber} | Limit: {RentalLimit}";
    }
}