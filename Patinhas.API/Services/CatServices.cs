using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patinhas.API.Data;
using Patinhas.Common.Models;

namespace Patinhas.API.Services;

public class CatService : ICatService
{
    private readonly ApplicationDbContext _context;

    public CatService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cat>> GetAvailableCats()
    {
        return await _context.Cats
            .Where(c => c.IsAvailable)
            .ToListAsync();
    }

    public async Task<Cat?> GetCatById(int id)
    {
        return await _context.Cats.FindAsync(id);
    }

    public async Task<Cat> CreateCat(Cat cat)
    {
        _context.Cats.Add(cat);
        await _context.SaveChangesAsync();
        return cat;
    }

    public async Task UpdateCat(Cat cat)
    {
        _context.Entry(cat).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCat(int id)
    {
        var cat = await _context.Cats.FindAsync(id);
        if (cat != null)
        {
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> AdoptCat(int catId, AdoptionRecord adoptionRecord)
    {
        var cat = await _context.Cats.FindAsync(catId);
        if (cat == null || !cat.IsAvailable) return false;

        cat.IsAvailable = false;
        cat.AdoptionDate = adoptionRecord.AdoptionDate;
        cat.AdoptionNotes = adoptionRecord.Notes;

        adoptionRecord.CatId = catId;
        _context.AdoptionRecords.Add(adoptionRecord);

        await _context.SaveChangesAsync();
        return true;
    }

public async Task<IEnumerable<Cat>> SearchCats(string? name = null, int? minAge = null, int? maxAge = null, string? breed = null, string? color = null)
{
    var query = _context.Cats.AsQueryable();

    if (!string.IsNullOrEmpty(name))
        query = query.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

    if (minAge.HasValue)
        query = query.Where(c => c.Age >= minAge.Value);

    if (maxAge.HasValue)
        query = query.Where(c => c.Age <= maxAge.Value);

    if (!string.IsNullOrEmpty(breed))
    {
        query = query.Where(c => c.Breed.Contains(breed, StringComparison.OrdinalIgnoreCase));
    }

    if (!string.IsNullOrEmpty(color))
    {
        query = query.Where(c => c.Color.Contains(color, StringComparison.OrdinalIgnoreCase));
    }

    return await query.ToListAsync();
 }
}