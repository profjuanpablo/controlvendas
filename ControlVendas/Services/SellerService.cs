﻿using ControlVendas.Data;
using ControlVendas.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

    public async Task UpdateAsync(Seller obj)
    {
        bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
        if (!hasAny)
        {
            throw new Exception("Id not found");
        }
        try
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            //throw new DbConcurrencyException(e.Message);
        }
    }





}
