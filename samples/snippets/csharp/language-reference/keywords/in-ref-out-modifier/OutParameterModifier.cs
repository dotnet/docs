using System;

namespace InRefOutModifier
{
    public static class OutParameterModifier
    {
        public static void Examples()
        {
            FirstOutExample();
            MultipleOutParameters();
            SeparateDeclaration();
            DeclareAtCallsite();
            UseImplicitOutArgument();
        }

        private static void FirstOutExample()
        {
            // <Snippet1>
            int initializeInMethod;
            OutArgExample(out initializeInMethod);
            Console.WriteLine(initializeInMethod);     // value is now 44

            void OutArgExample(out int number)
            {
                number = 44;
            }
            // </Snippet1>
        }

        private static void MultipleOutParameters()
        {
            // <Snippet3>
            void Method(out int answer, out string message, out string? stillNull)
            {
                answer = 44;
                message = "I've been returned";
                stillNull = null;
            }

            int argNumber;
            string argMessage;
            string? argDefault;
            Method(out argNumber, out argMessage, out argDefault);
            Console.WriteLine(argNumber);
            Console.WriteLine(argMessage);
            Console.WriteLine(argDefault == null);

            // The example displays the following output:
            //      44
            //      I've been returned
            //      True

            // </Snippet3>
        }

        private static void SeparateDeclaration()
        {
            // <Snippet4>
            string numberAsString = "1640";

            int number;
            if (Int32.TryParse(numberAsString, out number))
                Console.WriteLine($"Converted '{numberAsString}' to {number}");
            else
                Console.WriteLine($"Unable to convert '{numberAsString}'");
            // The example displays the following output:
            //       Converted '1640' to 1640
            // </Snippet4>
        }

        private static void DeclareAtCallsite()
        {
            // <Snippet5>
            string numberAsString = "1640";

            if (Int32.TryParse(numberAsString, out int number))
                Console.WriteLine($"Converted '{numberAsString}' to {number}");
            else
                Console.WriteLine($"Unable to convert '{numberAsString}'");
            // The example displays the following output:
            //       Converted '1640' to 1640
            // </Snippet5>
        }

        private static void UseImplicitOutArgument()
        {
            // <Snippet6>
            string numberAsString = "1640";

            if (Int32.TryParse(numberAsString, out var number))
                Console.WriteLine($"Converted '{numberAsString}' to {number}");
            else
                Console.WriteLine($"Unable to convert '{numberAsString}'");
            // The example displays the following output:
            //       Converted '1640' to 1640
            // </Snippet6>
        }
    }

    // <Snippet2>
    class OutOverloadExample
    {
        public void SampleMethod(int i) { }
        public void SampleMethod(out int i) => i = 5;
    }
    // </Snippet2>
}
