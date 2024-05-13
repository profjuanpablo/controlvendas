using ControlVendas.Data;
using ControlVendas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ControlVendas.Services;

public class DepartmentService
{
    private readonly ControlVendasContext _context;

    public DepartmentService(ControlVendasContext context) {
        _context = context;
    }

    public async Task<List<Department>> FindAllAsync() { 
        return await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }
}
