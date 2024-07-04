using Dashboard.Data;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Services;

public class EmployeeService
{
    private readonly DataContext _context;
    //DataContext dataContext = new DataContext();

    public EmployeeService(DataContext context) 
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _context.Employees.AsNoTracking().ToListAsync();
    }
}
