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
      Console.WriteLine();
   }

   private static void CompareUsingEquals()
   {
      // <Snippet1>
      // Initialize two floats with apparently identical values
      float float1 = .33333f;
      float float2 = 1/3;
      // Compare them for equality
      Console.WriteLine(float1.Equals(float2));    // displays false
      // </Snippet1>   
   }
   
   private static void CompareApproximateValues()
   {
      // <Snippet2> 
      // Initialize two floats with apparently identical values
      float float1 = .33333f;
      float float2 = (float) 1/3;
      // Define the tolerance for variation in their values
      float difference = Math.Abs(float1 * .0001f);

      // Compare the values
      // The output to the console indicates that the two values are equal
      if (Math.Abs(float1 - float2) <= difference)
         Console.WriteLine("float1 and float2 are equal.");
      else
         Console.WriteLine("float1 and float2 are unequal.");
      // </Snippet2>
   }   

   private static void CompareObjectsUsingEquals()
   {
      // <Snippet3>
      // Initialize two floats with apparently identical values
      float float1 = .33333f;
      object float2 = 1/3;
      // Compare them for equality
      Console.WriteLine(float1.Equals(float2));    // displays false
      // </Snippet3>   
   }
   
   private static void CompareApproximateObjectValues()
   {
      // <Snippet4> 
      // Initialize two floats with apparently identical values
      float float1 = .33333f;
      object float2 = (float) 1/3;
      // Define the tolerance for variation in their values
      float difference = Math.Abs(float1 * .0001f);

      // Compare the values
      // The output to the console indicates that the two values are equal
      if (Math.Abs(float1 - (float) float2) <= difference)
         Console.WriteLine("float1 and float2 are equal.");
      else
         Console.WriteLine("float1 and float2 are unequal.");
      // </Snippet4>
   }   
}
