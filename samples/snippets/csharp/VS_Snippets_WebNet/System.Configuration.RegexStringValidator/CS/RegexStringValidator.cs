//<Snippet1>
using System;
using System.Configuration;

namespace Microsoft.Samples.AspNet.Validators
{
  class UsingRegexStringValidator
  {
    static void Main(string[] args)
    {
      // Display title.
      Console.WriteLine("ASP.NET Validators");
      Console.WriteLine();

      //<Snippet2>
      // Create RegexString and Validator.
      string testString = "someone@example.com";
      string regexString = 
       @"^[a-zA-Z\.\-_]+@([a-zA-Z\.\-_]+\.)+[a-zA-Z]{2,4}$";
      RegexStringValidator myRegexValidator = 
       new RegexStringValidator(regexString);
      //</Snippet2>

      //<Snippet3>
      // Determine if the object to validate can be validated.
      Console.WriteLine("CanValidate: {0}",
        myRegexValidator.CanValidate(testString.GetType()));
      //</Snippet3>

      try
      {
        //<Snippet4>
        // Attempt validation.
        myRegexValidator.Validate(testString);
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