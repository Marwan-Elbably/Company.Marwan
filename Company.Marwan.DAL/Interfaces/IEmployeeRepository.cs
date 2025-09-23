using Company.Marwan.BLL.Models;
using Company.Marwan.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Interfaces
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetAll(); // get all department

        Employee? Get(int Id); // get spical department

        int Add(Employee model);
        int delete(Employee model);
        int Update(Employee model);











    }
}
