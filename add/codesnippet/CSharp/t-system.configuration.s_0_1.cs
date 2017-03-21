using System;
using System.Configuration;

namespace Samples.AspNet
{
  class UsingStringValidator
  {
    static void Main(string[] args)
    {
      // Display title.
      Console.WriteLine("ASP.NET Validators");
      Console.WriteLine();

      // Create string and validator.
      string testVal = "filename";
      StringValidator myStrValidator = new StringValidator(1,8,"$%^");

      // Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}",
        myStrValidator.CanValidate(testVal.GetType()));

      try
      {
        // Attempt validation.
        myStrValidator.Validate(testVal);
        Console.WriteLine("Validated.");
      }
      catch (ArgumentException e)
      {
        // Validation failed.
        Console.WriteLine("Error: {0}", e.Message.ToString());
      }

      // Display and wait.
      Console.ReadLine();
    }
  }
}