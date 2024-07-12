using Dashboard.Data;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;
using static MudBlazor.Icons;

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

    public void DeleteAiUsage(int id)
    {
        var aiUsage = _context.AiUsages.FirstOrDefault(x => x.Id == id);
        if (aiUsage != null)
        {
            _context.AiUsages.Remove(aiUsage);
            _context.SaveChanges();
        }
    }

    public AiUsage GetAiUsageById(int id)
    {
        var aiUsage = _context.AiUsages.SingleOrDefault(x => x.Id == id);
        return aiUsage;
    }

    public void SaveAiUsage(AiUsage aiUsage)
    {
        if (aiUsage.Id == 0) _context.AiUsages.Add(aiUsage);
        else _context.AiUsages.Update(aiUsage);
        _context.SaveChanges();
    }
}

