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

    public async Task InsertAsync(Seller obj) { 
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<Seller> FindByIdAsync(int id)
    {
        return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);


    }

    public async Task RemoveAsync(int id) {
        try
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
           // throw new IntegrityException("Can't delete seller because he/she has sales");
        }

    }





}
