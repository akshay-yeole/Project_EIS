using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS.Entities
{
    public class Employee
    {
        private int empid;
        private long contact;
        private string firstname, lastname, city, department;
        private double salary;

        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public long Contact { get; set; }
        public double Salary { get; set; } 
    }
}
