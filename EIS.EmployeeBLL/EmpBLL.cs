using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIS.EmployeeDAL;
using EIS.Entities;

namespace EIS.EmployeeBLL
{
    public class EmpBLL
    {
        EmpDAL empdal = new EmpDAL();

        private bool validateEmployee(Employee employee) 
        {
            bool status = true;
            StringBuilder sb = new StringBuilder();
            if (employee.EmpID <=0)  {
                status = false;
                sb.Append("\n Id must be greater than zero");
            }
            return status;
        }
        public bool addEmployee(Employee employee) 
        {
            bool status=false;
            try
            {
                if (validateEmployee(employee)) 
                {
                    status = empdal.AddEmployee(employee);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return status;
        } 
        public void getAllEmployees() 
        {
            try 
            {
                empdal.AllEmployees();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void SearchEmployee(int _emp)
        {
            try
            {
                empdal.SearchEmployeeDAL(_emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateEmpolyeeBLL(Employee em) 
        {
            bool status = false;
            try
            {
                empdal.UpdateEmployee(em);
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }
        public bool RemoveEmpolyeeBLL(int _empid)
        {
            bool status = false;
            try
            {
                empdal.RemoveEmployee(_empid);
                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }
    }
}
