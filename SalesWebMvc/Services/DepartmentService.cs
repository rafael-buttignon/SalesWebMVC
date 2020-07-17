using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _contex;

        public DepartmentService(SalesWebMvcContext context)
        {
            _contex = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _contex.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
