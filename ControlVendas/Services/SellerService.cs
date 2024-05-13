using ControlVendas.Data;
using ControlVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlVendas.Services;

public class SellerService
{
    private readonly ControlVendasContext _context;

    public SellerService(ControlVendasContext context) {
        _context = context;
    }

    public async Task<List<Seller>> FindAll(){
        return await _context.Seller.ToListAsync();
    }



}
