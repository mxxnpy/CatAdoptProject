using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patinhas.API.Data;
using Patinhas.Common.Models;

namespace Patinhas.API.Data.Repository;

public class CatRepository
{
    private readonly ApplicationDbContext _context;

    public CatRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cat>> GetAllCats()
    {
        return await _context.Cats.ToListAsync();
    }

    public async Task<Cat?> GetCatById(int id)
    {
        return await _context.Cats.FindAsync(id);
    }

    public async Task AddCat(Cat cat)
    {
        await _context.Cats.AddAsync(cat);
        await _context.SaveChangesAsync();
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
            query = query.Where(c => c.Breed.Contains(breed, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(color))
            query = query.Where(c => c.Color.Contains(color, StringComparison.OrdinalIgnoreCase));

        return await query.ToListAsync();
    }
}