using Company.Marwan.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Reposatires
{
    public class GenericRepository<T> : IGenaricRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        public T? Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Add(T model)
        {
            throw new NotImplementedException();
        }

        public int delete(T model)
        {
            throw new NotImplementedException();
        }

       
       
        public int Update(T model)
        {
            throw new NotImplementedException();
        }
    }

}
