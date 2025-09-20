using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Models;
using Company.Marwan.DAL.Data.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Reposatires
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyDbcontext _context;
        public DepartmentRepository()
        {
            _context = new CompanyDbcontext();  
        }
        public IEnumerable<Department> GetAll()
        {
            return _context.departments.ToList();
        }

        public Department? Get(int Id)
        {
           
            return _context.departments.Find(Id);
        }

        public int Add(Department model)
        {
           
            _context.departments.Add(model); 
           return _context.SaveChanges();
        }

        public int delete(Department model)
        {
           
            _context.departments.Remove(model);
            return _context.SaveChanges();
        }

        public int Update(Department model)
        {
            
            _context.departments.Update(model);
            return _context.SaveChanges();
        }


    }
}
