namespace Patinhas.Common.Models;

public class Cat
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Breed { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public DateTime ArrivalDate { get; set; }
    public DateTime? AdoptionDate { get; set; }
    public string? AdoptionNotes { get; set; }

    public ICollection<AdoptionRecord> AdoptionRecords { get; set; } = new List<AdoptionRecord>();
}