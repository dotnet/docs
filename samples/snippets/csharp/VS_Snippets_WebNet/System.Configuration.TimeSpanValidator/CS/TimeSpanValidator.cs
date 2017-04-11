//<Snippet1>
using System;
using System.Configuration;

namespace Samples.AspNet
{
  class UsingTimeSpanValidator
  {
    static void Main(string[] args)
    {
      // Display title.
      Console.WriteLine("ASP.NET Validators");
      Console.WriteLine();

      //<Snippet2>
      // Create TimeSpan and Validator.
      TimeSpan testTimeSpan = new TimeSpan(0,1,05);
      TimeSpan minTimeSpan = new TimeSpan(0,1,0);
      TimeSpan maxTimeSpan = new TimeSpan(0,1,10);
      TimeSpanValidator myTimeSpanValidator = new TimeSpanValidator(minTimeSpan, maxTimeSpan, false, 65);
      //</Snippet2>

      //<Snippet3>
      // Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}",
        myTimeSpanValidator.CanValidate(testTimeSpan.GetType()));
      //</Snippet3>

      try
      {
        //<Snippet4>
        // Attempt validation.
        myTimeSpanValidator.Validate(testTimeSpan);
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