using EquipmentRentalService.Models;
using EquipmentRentalService.Services;

var rentalService = new RentalService();
var reportService = new ReportService();

var laptop = new Laptop(1, "Dell Latitude", 16, "Intel i7");
var camera = new Camera(2, "Canon EOS", 24, "Zoom");
var projector = new Projector(3, "Epson X500", "1920x1080", 3500);

rentalService.AddEquipment(laptop);
rentalService.AddEquipment(camera);
rentalService.AddEquipment(projector);

var student = new Student(1, "Nazar", "Koval", "s12345");
var employee = new Employee(2, "Oleh", "Petrenko", "IT");

rentalService.AddUser(student);
rentalService.AddUser(employee);

reportService.PrintAllEquipment(rentalService.EquipmentList);
Console.WriteLine();

rentalService.RentEquipment(1, 1, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(5));
rentalService.RentEquipment(1, 2, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-3));
rentalService.RentEquipment(1, 3, DateTime.Now, DateTime.Now.AddDays(7));
Console.WriteLine();

reportService.PrintAvailableEquipment(rentalService.EquipmentList);
Console.WriteLine();

reportService.PrintActiveRentals(rentalService.Rentals);
Console.WriteLine();

rentalService.ReturnEquipment(1, DateTime.Now);
rentalService.ReturnEquipment(2, DateTime.Now);
Console.WriteLine();

rentalService.MarkEquipmentUnavailable(3);
Console.WriteLine();

reportService.PrintAllEquipment(rentalService.EquipmentList);
Console.WriteLine();

reportService.PrintOverdueRentals(rentalService.Rentals);
Console.WriteLine();

Console.WriteLine("Student active rentals:");
foreach (var rental in rentalService.GetUserActiveRentals(1))
{
    Console.WriteLine(rental);
}