using System;

public class Person
{
   public string FirstName { get; set; }
   public  string MiddleName { get; set; }
   public  string LastName { get; set; }  
   public  string City { get; set; }
   public  string State { get; set; } 
   public DateTime DateOfBirth { get; set; }
   public Decimal AnnualIncome { get; set; }

   public void Deconstruct(out string fname, out string mname, out string lname, out int age)
   {
      fname = FirstName;
      mname = MiddleName;
      lname = LastName;
      age = DateTime.Now.Year - DateOfBirth.Year;

      if (DateTime.Now.DayOfYear - (new DateTime(DateTime.Now.Year, DateOfBirth.Month, DateOfBirth.Day)).DayOfYear < 0)
         age--;
   }

   public void Deconstruct(out string lname, out string fname, out string mname, decimal income)
   {
      fname = FirstName;
      mname = MiddleName;
      lname = LastName;
      income = AnnualIncome;
   }
}
