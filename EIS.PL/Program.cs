using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIS.Entities;
using EIS.EmployeeBLL;
namespace EIS.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            EmpBLL empbll = new EmpBLL();
            Employee emp = new Employee();
            string ch = string.Empty;
            do {
                Console.WriteLine("***************************EIS********************************");
                Console.WriteLine(" 1. Add Employee");
                Console.WriteLine(" 2. View All Employees");
                Console.WriteLine(" 3. Search Employee");
                Console.WriteLine(" 4. Update Employee");
                Console.WriteLine(" 5. Remove Employee");
                Console.WriteLine("**************************************************************");
                Console.WriteLine("Enter your choice :: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        InsertEmp();
                        break;
                    case 2:
                        DisplayAllEmployee();
                        break;
                    case 3:
                        Console.WriteLine(" Enter Employee ID");
                        int _emp = int.Parse(Console.ReadLine());
                        FindEmployee(_emp);
                        break;
                    case 4:
                        UpdateEmployeePL();
                        break;
                    case 5:
                        Console.WriteLine(" Enter employee id to remove :: ");
                        int id = int.Parse(Console.ReadLine());
                        if (empbll.RemoveEmpolyeeBLL(id))
                        {
                            Console.WriteLine("Employee removed");
                        }
                        else
                        {
                            Console.WriteLine("Unbale to remove employee");
                        }
                        break;
                    default:
                        Console.WriteLine("\n Invalid choice");
                        break;
                }
                Console.WriteLine("Do you want to continue (YES/NO) ::");
                ch=Console.ReadLine().ToUpper();
            } while (ch!="NO");
            Console.WriteLine("Program exited");
            void InsertEmp() 
            {
                Console.WriteLine("Employee ID :: ");
                emp.EmpID = int.Parse(Console.ReadLine());
                Console.WriteLine("First Name :: ");
                emp.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name :: ");
                emp.LastName = Console.ReadLine();
                Console.WriteLine("City :: ");
                emp.City = Console.ReadLine();
                Console.WriteLine("Department :: ");
                emp.Department = Console.ReadLine();
                Console.WriteLine("Contact :: ");
                emp.Contact = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Salary :: ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());

                if (empbll.addEmployee(emp))
                {
                    Console.WriteLine("\n Employee Added");
                }
                else
                {
                    Console.WriteLine("\n Unbale to Add employee");
                }
            }
            void DisplayAllEmployee() 
            {
                empbll.getAllEmployees();   
            }
            void FindEmployee(int _emp) 
            {
                empbll.SearchEmployee(_emp);
            }
            void UpdateEmployeePL() 
            {
                Employee em = new Employee();

                Console.WriteLine("Employee ID :: ");
                em.EmpID = int.Parse(Console.ReadLine());
                Console.WriteLine("First Name :: ");
                em.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name :: ");
                em.LastName = Console.ReadLine();
                Console.WriteLine("City :: ");
                em.City = Console.ReadLine();
                Console.WriteLine("Department :: ");
                em.Department = Console.ReadLine();
                Console.WriteLine("Contact :: ");
                em.Contact = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Salary :: ");
                em.Salary = Convert.ToDouble(Console.ReadLine());

                bool result=empbll.UpdateEmpolyeeBLL(em);
                if (result) 
                {
                    Console.WriteLine("Record updated successfully");
                }
                else
                {
                    Console.WriteLine("unable to update record");
                }
            }
            Console.ReadLine();

        }

    }
}
