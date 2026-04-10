using System;

namespace ExpressionBodiedMembers;

public class Person
{
   private string fname;
   private string lname;

   public Person(string firstName, string lastName)
   {
      fname = firstName;
      lname = lastName;
   }

   public string FirstName { get; private set }

   public string LastName { get; private set }

   /// <summary>
   /// Add some changes in methods
   /// </summary>
   /// <returns></returns>

   public override string ToString() => $"{FirstName} {LastName}".Trim();
   public void DisplayName() => Console.WriteLine(ToString());
   
   // Expression-bodied methods with parameters
   public string GetFullName(string title) => $"{title} {FirstName} {LastName}";
   public int CalculateAge(int birthYear) => DateTime.Now.Year - birthYear;
   public bool IsOlderThan(int age) => CalculateAge(1990) > age;
   public string FormatName(string format) => format.Replace("{first}", FirstName).Replace("{last}", LastName);
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
