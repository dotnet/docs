// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      int dimension1 = 10;
      int dimension2 = -1;
      try {
         Array arr = Array.CreateInstance(typeof(String), 
                                          dimension1, dimension2);
      }
      catch (ArgumentOutOfRangeException e) {
         if (e.ActualValue != null)
            Console.WriteLine("{0} is an invalid value for {1}: ", e.ActualValue, e.ParamName);
         Console.WriteLine(e.Message);
      }
   }
}
// The example displays the following output:
//     Non-negative number required.
//     Parameter name: length2
// </Snippet1>

public class Example2
{
   public void MakeValid()
   {
      // <Snippet2>
      int dimension1 = 10;
      int dimension2 = 10;
      Array arr = Array.CreateInstance(typeof(String), 
                                       dimension1, dimension2);   
      // </Snippet2>
   }
   
   public void Validate()
   {
      int dimension1 = 10;
      int dimension2 = 10;
      Array arr;
      // <Snippet3>
      if (dimension1 < 0 || dimension2 < 0) {
         Console.WriteLine("Unable to create the array.");
         Console.WriteLine("Specify non-negative values for the two dimensions.");
      }   
      else {
         arr = Array.CreateInstance(typeof(String), 
                                    dimension1, dimension2);   
      }
      // </Snippet3>
   }
}

