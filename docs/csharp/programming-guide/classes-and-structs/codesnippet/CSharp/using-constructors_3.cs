        public class Employee
        {
            public int salary;

            public Employee(int annualSalary)
            {
                salary = annualSalary;
            }

            public Employee(int weeklySalary, int numberOfWeeks)
            {
                salary = weeklySalary * numberOfWeeks;
            }
        }