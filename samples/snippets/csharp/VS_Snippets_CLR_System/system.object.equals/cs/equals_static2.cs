// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Dog m1 = new Dog("Alaskan Malamute");
      Dog m2 = new Dog("Alaskan Malamute");
      Dog g1 = new Dog("Great Pyrenees");
      Dog g2 = g1;
      Dog d1 = new Dog("Dalmation");
      Dog n1 = null;
      Dog n2 = null;
      
      Console.WriteLine("null = null: {0}", Object.Equals(n1, n2));
      Console.WriteLine("null Reference Equals null: {0}\n", Object.ReferenceEquals(n1, n2));
      
      Console.WriteLine("{0} = {1}: {2}", g1, g2, Object.Equals(g1, g2));
      Console.WriteLine("{0} Reference Equals {1}: {2}\n", g1, g2, Object.ReferenceEquals(g1, g2));
      
      Console.WriteLine("{0} = {1}: {2}", m1, m2, Object.Equals(m1, m2));
      Console.WriteLine("{0} Reference Equals {1}: {2}\n", m1, m2, Object.ReferenceEquals(m1, m2));
      
      Console.WriteLine("{0} = {1}: {2}", m1, d1, Object.Equals(m1, d1));  
      Console.WriteLine("{0} Reference Equals {1}: {2}", m1, d1, Object.ReferenceEquals(m1, d1));  
   }
}

public class Dog
{
   // Public field.
   public string Breed;
   
   // Class constructor.
   public Dog(string dogBreed)
   {
      this.Breed = dogBreed;
   }

   public override bool Equals(Object obj)
   {
      if (obj == null || !(obj is Dog))
         return false;
      else
         return this.Breed == ((Dog) obj).Breed;
   }
   
   public override int GetHashCode()
   {
      return this.Breed.GetHashCode();
   }
   
   public override string ToString()
   {
      return this.Breed;
   }
}
// The example displays the following output:
//       null = null: True
//       null Reference Equals null: True
//       
//       Great Pyrenees = Great Pyrenees: True
//       Great Pyrenees Reference Equals Great Pyrenees: True
//       
//       Alaskan Malamute = Alaskan Malamute: True
//       Alaskan Malamute Reference Equals Alaskan Malamute: False
//       
//       Alaskan Malamute = Dalmation: False
//       Alaskan Malamute Reference Equals Dalmation: False
// </Snippet1>
