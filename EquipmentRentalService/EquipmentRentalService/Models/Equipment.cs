namespace EquipmentRentalService.Models;

public abstract class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public bool IsMarkedUnavailable { get; set; } = false;

    protected Equipment(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Id}: {Name} | Available: {IsAvailable}";
    }
}