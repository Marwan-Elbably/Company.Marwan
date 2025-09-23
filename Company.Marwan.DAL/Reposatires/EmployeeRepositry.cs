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
    internal class EmployeeRepositry : IEmployeeRepository
    {
        private readonly CompanyDbcontext _context;
        public EmployeeRepositry(CompanyDbcontext context ) { 
        
            _context = context;
        
        }

        public IEnumerable<Employee> GetAll()
        {
           return _context.employees.ToList();
        }
        
        public Employee? Get(int Id)
        {
            return _context.employees.Find(Id);
        }

        public int Add(Employee model)
        {
             _context.employees.Add(model);
            return _context.SaveChanges();
        }


        public int Update(Employee model)
        {

            _context.employees.Update(model);
            return _context.SaveChanges();
        }

        public int delete(Employee model)
        {

            _context.employees.Remove(model);
            return _context.SaveChanges();
        }

        
       

    }
}
