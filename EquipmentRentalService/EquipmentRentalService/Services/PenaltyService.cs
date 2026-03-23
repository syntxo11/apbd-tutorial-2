namespace EquipmentRentalService.Services;

public class PenaltyService
{
    public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
            return 0;

        var lateDays = (returnDate.Date - dueDate.Date).Days;
        return lateDays * 10;
    }
}