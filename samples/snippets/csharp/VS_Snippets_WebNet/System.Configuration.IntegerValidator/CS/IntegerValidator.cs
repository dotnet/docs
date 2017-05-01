//<Snippet1>
using System;
using System.Configuration;

namespace Microsoft.Samples.AspNet.Validators
{
    class UsingIntegerValidator
    {
        static void Main(string[] args)
        {
            // Display title.
            Console.WriteLine("ASP.NET Validators");
            Console.WriteLine();

            Console.WriteLine(
                "Set mininum and maximum of 1 and 10 inclusive");

            //<Snippet2>
            // Create Validator for the range of 1 to 10 inclusive
            int minIntVal = 1;
            int maxIntVal = 10;
            bool exclusive = false;
            IntegerValidator integerValidator =
                new IntegerValidator(minIntVal, maxIntVal, exclusive);
            //</Snippet2>

            int testInt = 0;
            ValidateInteger(integerValidator, testInt);
            testInt = 1;
            ValidateInteger(integerValidator, testInt);
            testInt = 5;
            ValidateInteger(integerValidator, testInt);

            Console.WriteLine();
            Console.WriteLine(
                "Set mininum and maximum of 1 and 10 exclusive");

            // Create Validator for the range of 1 to 10 exclusive
            exclusive = true;
            integerValidator =
                new IntegerValidator(minIntVal, maxIntVal, exclusive);

            testInt = 0;
            ValidateInteger(integerValidator, testInt);
            testInt = 1;
            ValidateInteger(integerValidator, testInt);
            testInt = 5;
            ValidateInteger(integerValidator, testInt);

            Console.WriteLine();
            Console.WriteLine(
                "Determine if an object to validate can be validated.");

            object testObjectToValidate = "a";
            //<Snippet3>
            Console.WriteLine("Can validate object of type {0}: {1}",
                testObjectToValidate.GetType(),
                integerValidator.CanValidate(testObjectToValidate.GetType()));
            //</Snippet3>
            testObjectToValidate = new int();
            Console.WriteLine("Can validate object of type {0}: {1}",
                testObjectToValidate.GetType(),
                integerValidator.CanValidate(testObjectToValidate.GetType()));

            // Leave output on screen until enter is pressed.
            Console.ReadLine();
        }

        private static void ValidateInteger(IntegerValidator integerValidator, int valuetoValidate)
        {
            //<Snippet4>
            Console.Write("Validating integer value of {0}:  ", valuetoValidate);
            try
            {
                integerValidator.Validate(valuetoValidate);
                Console.WriteLine("Validated.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Failed validation.  Message: {0}", e.Message.ToString());
            }
            //</Snippet4>
        }
    }
}
// </Snippet1>