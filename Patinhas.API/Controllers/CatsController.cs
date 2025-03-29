using Microsoft.AspNetCore.Mvc;
using Patinhas.API.Services;
using Patinhas.Common.Models;

namespace Patinhas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatsController : ControllerBase
{
    private readonly ICatService _catService;

    public CatsController(ICatService catService)
    {
        _catService = catService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cat>>> GetAvailableCats()
    {
        return Ok(await _catService.GetAvailableCats());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cat>> GetCat(int id)
    {
        var cat = await _catService.GetCatById(id);
        if (cat == null) return NotFound();
        return Ok(cat);
    }

    [HttpPost]
    public async Task<ActionResult<Cat>> CreateCat(Cat cat)
    {
        var createdCat = await _catService.CreateCat(cat);
        return CreatedAtAction(nameof(GetCat), new { id = createdCat.Id }, createdCat);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCat(int id, Cat cat)
    {
        if (id != cat.Id) return BadRequest();
        await _catService.UpdateCat(cat);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCat(int id)
    {
        await _catService.DeleteCat(id);
        return NoContent();
    }

    [HttpPut("{id}/adopt")]
    public async Task<ActionResult> AdoptCat(int id, [FromBody] AdoptionRecord adoptionRecord)
    {
        var result = await _catService.AdoptCat(id, adoptionRecord);
        if (!result) return NotFound();
        return NoContent();
    }
}