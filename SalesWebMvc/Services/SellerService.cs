using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _contex;

        public SellerService(SalesWebMvcContext context)
        {
            _contex = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _contex.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _contex.Add(obj);
            await _contex.SaveChangesAsync();
        }
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _contex.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);

            //.Include faz o Join para o department
        }
        public async Task RemoveAsync(int id)
        {

            try
            {

            var obj = _contex.Seller.Find(id);
            _contex.Seller.Remove(obj);
            await _contex.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new IntegrityException("Can't delete seller because he has sales");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _contex.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) //(any) se existe algum obj no banco de dados 
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _contex.Update(obj);
                await _contex.SaveChangesAsync();

            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
