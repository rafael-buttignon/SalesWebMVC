using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _contex;

        public DepartmentService(SalesWebMvcContext context)
        {
            _contex = context;
        }

        public List<Department> FindAll()
        {
            return _contex.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
