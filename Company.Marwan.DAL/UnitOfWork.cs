using Company.Marwan.BLL.Interfaces;
using Company.Marwan.BLL.Reposatires;
using Company.Marwan.DAL.Data.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbcontext _context;

        public IDepartmentRepository DepartmentRepository { get;  } // Null

        public IEmployeeRepository EmployeeRepository {  get; } // Null

        public UnitOfWork(CompanyDbcontext context) { 

            _context = context;

            DepartmentRepository = new DepartmentRepository(_context);
            EmployeeRepository = new EmployeeRepositry(_context);

        }
    }
}
