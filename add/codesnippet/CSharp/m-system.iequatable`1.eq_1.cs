using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Person : IEquatable<Person>
{
   private string uniqueSsn;
   private string lName;

   public Person(string lastName, string ssn)
   {
      if (Regex.IsMatch(ssn, @"\d{9}"))
         uniqueSsn = String.Format("{0}-(1}-{2}", ssn.Substring(0, 3),
                                                  ssn.Substring(3, 2),
                                                  ssn.Substring(5, 4));
      else if (Regex.IsMatch(ssn, @"\d{3}-\d{2}-\d{4}"))
         uniqueSsn = ssn;
      else
         throw new FormatException("The social security number has an invalid format.");

      uniqueSsn = ssn;
      this.LastName = lastName;
   }

   public string SSN
   {
      get { return this.uniqueSsn; }
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