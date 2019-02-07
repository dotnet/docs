        public class Employee
        {
            public int Salary;

            public Employee(int annualSalary)
            {
                Salary = annualSalary;
            }

            public Employee(int weeklySalary, int numberOfWeeks)
            {
                Salary = weeklySalary * numberOfWeeks;
            }
        }