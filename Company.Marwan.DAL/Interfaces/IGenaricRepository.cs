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


        Task<IEnumerable<T>> GetAllAsync(); // get all department

       Task<T?> GetAsync(int Id); // get spical department

        Task<int> AddAsync(T model);
        int delete(T model);
        int Update(T model);


    }
}
