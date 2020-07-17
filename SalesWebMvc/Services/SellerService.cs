using SalesWebMvc.Data;
using SalesWebMvc.Models;
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
    }
}
