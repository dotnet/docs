using System;

namespace ExpressionBodiedMembers;

public class Person
{
   private string fname;
   private string lname;

   public Person(string firstName, string lastName)
   {
      // Add 'this' to each property for better clarification
      this.fname = firstName;
      this.lname = lastName;
   }

   // Add public properties

   public string FirstName
   {
      get => this.fname;

      private set
      {
         this.fname = value;
      }
   }

   public string LastName
   {
      get => this.lname;

      private set
      {
         this.lname = value;
      }
   }

   /// <summary>
   /// Add some changes in methods
   /// </summary>
   /// <returns></returns>

   public override string ToString() => $"{this.FirstName} {this.LastName}".Trim();
   public void DisplayName() => Console.WriteLine(ToString());
   
   // Expression-bodied methods with parameters
   public string GetFullName(string title) => $"{title} {this.FirstName} {this.LastName}";
   public int CalculateAge(int birthYear) => DateTime.Now.Year - birthYear;
   public bool IsOlderThan(int age) => CalculateAge(1990) > age;
   public string FormatName(string format) => format.Replace("{first}", this.FirstName).Replace("{last}", this.LastName);
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