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