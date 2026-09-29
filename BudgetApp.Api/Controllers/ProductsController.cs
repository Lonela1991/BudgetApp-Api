using BudgetApp.Api.Dtos;
using BudgetApp.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly BudgetDbContext db;

    public ProductsController(BudgetDbContext db) => this.db = db;

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll()
    {
        var products = await this.db.Products
            .AsNoTracking()
            .Select(p => new ProductDto(p.ProductId, p.Name, p.DepartmentId, p.ProductGroupId, p.ProductCategoryId))
            .ToListAsync();

        return products;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(string id)
    {
        var p = await this.db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == id);
        if (p is null)
        {
            return this.NotFound();
        }

        return new ProductDto(p.ProductId, p.Name, p.DepartmentId, p.ProductGroupId, p.ProductCategoryId);
    }
}