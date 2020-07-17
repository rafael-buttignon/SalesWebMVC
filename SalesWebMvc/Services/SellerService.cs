using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<Seller> FindAll()
        {
            return _contex.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _contex.Add(obj);
            _contex.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _contex.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);

            //.Include faz o Join para o department
        }
        public void Remove(int id)
        {
            var obj = _contex.Seller.Find(id);
            _contex.Seller.Remove(obj);
            _contex.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_contex.Seller.Any(x => x.Id == obj.Id)) //(any) se existe algum obj no banco de dados 
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _contex.Update(obj);
                _contex.SaveChanges();

            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
