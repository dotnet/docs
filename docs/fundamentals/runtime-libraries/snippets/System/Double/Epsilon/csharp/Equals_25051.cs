using System;

public class Class1
{
   public static void Main()
   {
      CompareUsingEquals();
      Console.WriteLine();
      CompareApproximateValues();
      Console.WriteLine();
      CompareObjectsUsingEquals();
      Console.WriteLine();
      CompareApproximateObjectValues();
   }

   private static void CompareUsingEquals()
   {
      // <Snippet1>
      // Initialize two doubles with apparently identical values
      double double1 = .33333;
      double double2 = (double) 1/3;
      // Compare them for equality
      Console.WriteLine(double1.Equals(double2));    // displays false
      // </Snippet1>
   }

   private static void CompareApproximateValues()
   {
      Console.WriteLine("Snippet2");
      // <Snippet2>
      // Initialize two doubles with apparently identical values
      double double1 = .333333;
      double double2 = (double) 1/3;
      // Define the tolerance for variation in their values
      double difference = Math.Abs(double1 * .00001);

      // Compare the values
      // The output to the console indicates that the two values are equal
      if (Math.Abs(double1 - double2) <= difference)
         Console.WriteLine("double1 and double2 are equal.");
      else
         Console.WriteLine("double1 and double2 are unequal.");
      // </Snippet2>
   }

   private static void CompareObjectsUsingEquals()
   {
      // <Snippet3>
      // Initialize two doubles with apparently identical values
      double double1 = .33333;
      object double2 = (double) 1/3;
      // Compare them for equality
      Console.WriteLine(double1.Equals(double2));    // displays false
      // </Snippet3>
   }

   private static void CompareApproximateObjectValues()
   {
      // <Snippet4>
      // Initialize two doubles with apparently identical values
      double double1 = .33333;
      object double2 = (double) 1/3;
      // Define the tolerance for variation in their values
      double difference = Math.Abs(double1 * .0001);

      // Compare the values
      // The output to the console indicates that the two values are equal
      if (Math.Abs(double1 - (double) double2) <= difference)
         Console.WriteLine("double1 and double2 are equal.");
      else
         Console.WriteLine("double1 and double2 are unequal.");
      // </Snippet4>
   }
}
