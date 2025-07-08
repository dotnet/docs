using System;

namespace ExpressionBodiedMembers;

public class Person
{
   public Person(string firstName, string lastName)
   {
      fname = firstName;
      lname = lastName;
   }

   private string fname;
   private string lname;

   public override string ToString() => $"{fname} {lname}".Trim();
   public void DisplayName() => Console.WriteLine(ToString());
   
   // Expression-bodied methods with parameters
   public string GetFullName(string title) => $"{title} {fname} {lname}";
   public int CalculateAge(int birthYear) => DateTime.Now.Year - birthYear;
   public bool IsOlderThan(int age) => CalculateAge(1990) > age;
   public string FormatName(string format) => format.Replace("{first}", fname).Replace("{last}", lname);
}

class Example
{
   public static void Main()
   {
      Person p = new Person("Mandy", "Dejesus");
      Console.WriteLine(p);
      p.DisplayName();
      
      // Examples with parameters
      Console.WriteLine(p.GetFullName("Dr."));
      Console.WriteLine($"Age: {p.CalculateAge(1990)}");
      Console.WriteLine($"Is older than 25: {p.IsOlderThan(25)}");
      Console.WriteLine(p.FormatName("Last: {last}, First: {first}"));
   }
}
