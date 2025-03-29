using System.Threading.Tasks;
using Patinhas.Common.Models;

namespace Patinhas.API.Services;

public interface ICatService
{
    Task<IEnumerable<Cat>> GetAvailableCats();
    Task<Cat?> GetCatById(int id);
    Task<Cat> CreateCat(Cat cat);
    Task UpdateCat(Cat cat);
    Task DeleteCat(int id);
    Task<bool> AdoptCat(int catId, AdoptionRecord adoptionRecord);
    Task<IEnumerable<Cat>> SearchCats(string? name = null, int? minAge = null, int? maxAge = null, string? breed = null, string? color = null);
}