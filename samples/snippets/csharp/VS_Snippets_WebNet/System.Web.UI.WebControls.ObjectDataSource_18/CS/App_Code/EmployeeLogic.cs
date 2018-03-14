namespace Samples.AspNet.CS
{

    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
   
    // <Snippet5>
    public class EmployeeLogic
    {
        public static Array GetFullNamesAndIDs()
        {
            NorthwindDataContext ndc = new NorthwindDataContext();

            var employeeQuery =
                from e in ndc.Employees
                orderby e.LastName
                select new { FullName = e.FirstName + " " + e.LastName, EmployeeID = e.EmployeeID };

            return employeeQuery.ToArray();
        }

        public static Employee GetEmployee(int empID)
        {
            if (empID < 0)
            {
                return null;
            }
            else
            {
                NorthwindDataContext ndc = new NorthwindDataContext();
                var employeeQuery =
                    from e in ndc.Employees
                    where e.EmployeeID == empID
                    select e;

                return employeeQuery.Single();
            }
        }
     
        public static void UpdateEmployeeAddress(Employee originalEmployee, string address, string city, string postalcode)
        {
            NorthwindDataContext ndc = new NorthwindDataContext();
            ndc.Employees.Attach(originalEmployee, false);
            originalEmployee.Address = address;
            originalEmployee.City = city;
            originalEmployee.PostalCode = postalcode;
            ndc.SubmitChanges();
        }
    }
    // </Snippet5>
    
}