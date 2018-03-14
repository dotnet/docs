using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Person : IEquatable<Person>
{
   private string uniqueSsn;
   private string lName;

   public Person(string lastName, string ssn)
   {
      this.SSN = ssn;
      this.LastName = lastName;
   }

   public string SSN
   {
      get { return this.uniqueSsn; }
      set {
         if (Regex.IsMatch(value, @"\d{9}"))
            uniqueSsn = String.Format("{0}-(1}-{2}", value.Substring(0, 3),
                                                     value.Substring(3, 2),
                                                     value.Substring(5, 4));
         else if (Regex.IsMatch(value, @"\d{3}-\d{2}-\d{4}"))
            uniqueSsn = value;
         else
            throw new FormatException("The social security number has an invalid format.");
      }
   }

   public string LastName
   {
      get { return this.lName; }
      set {
         if (String.IsNullOrEmpty(value))
            throw new ArgumentException("The last name cannot be null or empty.");
         else
            this.lName = value;
      }
   }

   public bool Equals(Person other)
   {
      if (other == null)
         return false;

      if (this.uniqueSsn == other.uniqueSsn)
         return true;
      else
         return false;
   }

   public override bool Equals(Object obj)
   {
      if (obj == null)
         return false;

      Person personObj = obj as Person;
      if (personObj == null)
         return false;
      else
         return Equals(personObj);
   }

   public override int GetHashCode()
   {
      return this.SSN.GetHashCode();
   }

   public static bool operator == (Person person1, Person person2)
   {
      if (((object)person1) == null || ((object)person2) == null)
         return Object.Equals(person1, person2);

      return person1.Equals(person2);
   }

   public static bool operator != (Person person1, Person person2)
   {
      if (((object)person1) == null || ((object)person2) == null)
         return ! Object.Equals(person1, person2);

      return ! (person1.Equals(person2));
   }
}

// <Snippet12>
public class TestIEquatable
{
   public static void Main()
   {
      // Create a Person object for each job applicant.
      Person applicant1 = new Person("Jones", "099-29-4999");
      Person applicant2 = new Person("Jones", "199-29-3999");
      Person applicant3 = new Person("Jones", "299-49-6999");

      // Add applicants to a List object.
      List<Person> applicants = new List<Person>();
      applicants.Add(applicant1);
      applicants.Add(applicant2);
      applicants.Add(applicant3);

       // Create a Person object for the final candidate.
       Person candidate = new Person("Jones", "199-29-3999");
       if (applicants.Contains(candidate))
          Console.WriteLine("Found {0} (SSN {1}).", 
                             candidate.LastName, candidate.SSN);
      else
         Console.WriteLine("Applicant {0} not found.", candidate.SSN);

      // Call the shared inherited Equals(Object, Object) method.
      // It will in turn call the IEquatable(Of T).Equals implementation.
      Console.WriteLine("{0}({1}) already on file: {2}.",  
                        applicant2.LastName, 
                        applicant2.SSN, 
                        Person.Equals(applicant2, candidate)); 
   }
}
// The example displays the following output:
//       Found Jones (SSN 199-29-3999).
//       Jones(199-29-3999) already on file: True.
// </Snippet12>

// This tests the handling of null values, but does not appear in the documentation.
//
//public class Example
//{
//   public static void Main()
//   {
//      var p1 = new Person("Joe", "613-24-0068");
//      Person p2 = null;
//
//      Console.WriteLine(p1 == p2);
//   }
//}

