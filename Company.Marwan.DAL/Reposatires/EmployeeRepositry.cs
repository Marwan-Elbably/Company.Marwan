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
    internal class EmployeeRepositry : GenericRepository<Employee> , IEmployeeRepository
    {
       
    }
}
