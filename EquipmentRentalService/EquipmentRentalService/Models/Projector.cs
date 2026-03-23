namespace EquipmentRentalService.Models;

public class Projector : Equipment
{
    public string Resolution { get; set; }
    public int BrightnessLumens { get; set; }

    public Projector(int id, string name, string resolution, int brightnessLumens) : base(id, name)
    {
        Resolution = resolution;
        BrightnessLumens = brightnessLumens;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Resolution: {Resolution} | Brightness: {BrightnessLumens} lm";
    }
}