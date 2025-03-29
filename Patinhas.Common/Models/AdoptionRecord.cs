namespace Patinhas.Common.Models;

public class AdoptionRecord
{
    public int Id { get; set; }
    public int CatId { get; set; }
    public Cat Cat { get; set; } = null!;
    public DateTime AdoptionDate { get; set; }
    public string Notes { get; set; } = string.Empty;
}