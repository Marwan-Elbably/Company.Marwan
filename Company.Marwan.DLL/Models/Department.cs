using Company.Marwan.BLL.Reposatires;
using Company.Marwan.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Marwan.BLL.Models
{
    public class Department : BaseEntity
    {

       
        public string code { get; set; }

        public string name { get; set; }

        public DateTime CreateAt { get; set; }

      
        public List<Employee>? Employees { get; set; }













    }
}
