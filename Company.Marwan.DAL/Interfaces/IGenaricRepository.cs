using Company.Marwan.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Interfaces
{
    public interface IGenaricRepository<T> where T : class
    {


        IEnumerable<T> GetAll(); // get all department

        T? Get(int Id); // get spical department

        int Add(T model);
        int delete(T model);
        int Update(T model);


    }
}
