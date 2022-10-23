using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EIS.Entities;
namespace EIS.EmployeeDAL
{
    public class EmpDAL
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter reader;
        SqlDataReader sdr;
        public EmpDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Empconn"].ConnectionString);
        }
        public bool AddEmployee(Employee employee)  
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_AddEmployee";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid",employee.EmpID);
                cmd.Parameters.AddWithValue("@firstname", employee.FirstName);
                cmd.Parameters.AddWithValue("@lastname", employee.LastName);
                cmd.Parameters.AddWithValue("@city", employee.City);
                cmd.Parameters.AddWithValue("@contact", employee.Contact);
                cmd.Parameters.AddWithValue("@department", employee.Department);
                cmd.Parameters.AddWithValue("@salary", employee.Salary);

                conn.Open();

                int result = cmd.ExecuteNonQuery();
                if (result>0) 
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }
        public void AllEmployees() 
        {
            try 
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_AllEmployees";
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                sdr=cmd.ExecuteReader();
           
                while (sdr.Read()) 
                {
                    Console.WriteLine(sdr.GetValue(0)+" "+ sdr.GetValue(1)+" "+ sdr.GetValue(2)+" " + sdr.GetValue(3)+" " 
                        + sdr.GetValue(4) + sdr.GetValue(5)+" "+sdr.GetValue(6));
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public void SearchEmployeeDAL(int _emp) 
        {
            try 
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_getEmployeeByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", _emp);

                conn.Open();
                sdr=cmd.ExecuteReader();

                while (sdr.Read()) 
                {
                    Console.WriteLine(sdr.GetValue(0) + " " + sdr.GetValue(1) + " " + sdr.GetValue(2) + " " + sdr.GetValue(3) + " "
                        + sdr.GetValue(4) + sdr.GetValue(5) + " " + sdr.GetValue(6));
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally 
            {
                conn.Close();
            }
        }
        public bool UpdateEmployee(Employee em) 
        {
            bool status = false;
            try 
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_UpdateEmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@empid", em.EmpID);
                cmd.Parameters.AddWithValue("@firstname", em.FirstName);
                cmd.Parameters.AddWithValue("@lastname", em.LastName);
                cmd.Parameters.AddWithValue("@city", em.City);
                cmd.Parameters.AddWithValue("@contact", em.Contact);
                cmd.Parameters.AddWithValue("@department", em.Department);
                cmd.Parameters.AddWithValue("@salary", em.Salary);
                
                conn.Open();

                int result=cmd.ExecuteNonQuery();
                if ( result > 0 ) 
                {
                    status = true;
                }
                return status;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool RemoveEmployee(int _empid)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "sp_DeleteEmployee";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid",_empid);
  
                conn.Open();

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    status = true;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
