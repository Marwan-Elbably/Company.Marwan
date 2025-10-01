using Company.Marwan.BLL.Interfaces;
using Company.Marwan.DAL.Data.contexts;
using Company.Marwan.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Reposatires
{
    public class EmployeeRepositry : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbcontext _context;

        public EmployeeRepositry(CompanyDbcontext context) : base(context)
        {
            _context = context;
        }

        public List<Employee> GetByName(string name)
        {
           return _context.employees.Where(E=>E.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
