using Dashboard.Data;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Services;

public class AiUsageService
{
    private readonly DataContext _context;

    public AiUsageService(DataContext context)
    {
        _context = context; 
    }

    public async Task<List<AiUsage>> GetAllAiUsage()
    {
        return await _context.AiUsages.AsNoTracking().ToListAsync();
    }
}

