using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route(" + ""api/[controller]"" + ")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;
    public ProductsController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        => await _db.Products.Include(p => p.Category).AsNoTracking().ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var prod = await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        return prod is null ? NotFound() : prod;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product input)
    {
        _db.Products.Add(input);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = input.Id }, input);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Product input)
    {
        if (id != input.Id) return BadRequest();
        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var prod = await _db.Products.FindAsync(id);
        if (prod is null) return NotFound();
        _db.Products.Remove(prod);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
