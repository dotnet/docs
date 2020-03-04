//<Snippet1>
using System;
using System.Configuration;

namespace Microsoft.Samples.AspNet.Validators
{
  class UsingLongValidator
  {
    static void Main(string[] args)
    {
      // Display title.
      Console.WriteLine("ASP.NET Validators");
      Console.WriteLine();

      //<Snippet2>
      // Create Long and Validator.
      Int64 testLong =    17592186044416;
      Int64 minLongVal =  1099511627776;
      Int64 maxLongVal =  281474976710656;
      LongValidator myLongValidator = 
       new LongValidator(minLongVal, maxLongVal, false);
      //</Snippet2>

      //<Snippet3>
      // Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}",
        myLongValidator.CanValidate(testLong.GetType()));
      //</Snippet3>

      try
      {
        //<Snippet4>
        // Attempt validation.
        myLongValidator.Validate(testLong);
        //</Snippet4>
        Console.WriteLine("Validated.");
      }
      catch (ArgumentException e)
      {
        // Validation failed.
        Console.WriteLine("Error: {0}", e.Message.ToString());
      }

      // Display and wait
      Console.ReadLine();
    }
  }
}
// </Snippet1>