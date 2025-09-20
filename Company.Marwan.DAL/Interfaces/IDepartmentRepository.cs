using Company.Marwan.BLL.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Interfaces
{
    public interface IDepartmentRepository
    {

       IEnumerable<Department> GetAll(); // get all department

        Department? Get(int Id); // get spical department

        int Add(Department model);
        int delete(Department model);
        int Update(Department model);



    }
}
