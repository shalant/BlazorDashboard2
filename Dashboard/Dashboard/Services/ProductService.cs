using Dashboard.Data;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Services;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context; 
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }
}
