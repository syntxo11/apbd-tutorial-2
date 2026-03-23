using EquipmentRentalService.Models;

namespace EquipmentRentalService.Services;

public class ReportService
{
    Console.WriteLine("-----");
    public void PrintAllEquipment(List<Equipment> equipmentList)
    {
        Console.WriteLine("All equipment:");
        foreach (var equipment in equipmentList)
        {
            Console.WriteLine(equipment);
        }
    }

    public void PrintAvailableEquipment(List<Equipment> equipmentList)
    {
        Console.WriteLine("Available equipment:");
        foreach (var equipment in equipmentList.Where(e => e.IsAvailable && !e.IsMarkedUnavailable))
        {
            Console.WriteLine(equipment);
        }
    }

    public void PrintActiveRentals(List<Rental> rentals)
    {
        Console.WriteLine("Active rentals:");
        foreach (var rental in rentals.Where(r => !r.IsReturned))
        {
            Console.WriteLine(rental);
        }
    }

    public void PrintOverdueRentals(List<Rental> rentals)
    {
        Console.WriteLine("Overdue rentals:");
        foreach (var rental in rentals.Where(r => r.IsOverdue))
        {
            Console.WriteLine(rental);
        }
    }
}