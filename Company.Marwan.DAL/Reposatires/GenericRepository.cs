using Company.Marwan.BLL.Interfaces;
using Company.Marwan.DAL.Data.contexts;
using Company.Marwan.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Reposatires
{
    public class GenericRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbcontext _context;
        public GenericRepository(CompanyDbcontext context) { 
            _context = context;
        
        }
        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) _context.employees.Include(E=>E.Department).ToList();

            }
           return _context.Set<T>().ToList();

        }
        public T? Get(int Id)
        {
            if (typeof(T) == typeof(Employee))
            {
                return _context.employees.Include(E => E.Department).FirstOrDefault(E=>E.Id==Id) as T;

            }
            return _context.Set<T>().Find(Id);
        }

        public int Add(T model)
        {
            _context.Set<T>().Add(model);
            return _context.SaveChanges();
        }

        public int delete(T model)
        {
            _context.Set<T>().Remove(model);
            return _context.SaveChanges();
        }

       
       
        public int Update(T model)
        {
            _context.Set<T>().Update(model);
            return _context.SaveChanges();
        }
    }

}
