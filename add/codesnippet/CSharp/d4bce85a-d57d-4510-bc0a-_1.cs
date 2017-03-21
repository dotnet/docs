    // Add using System.Linq.Expressions;
    // to the beginning of the file.

    // The class derived from DynamicObject.
    public class DynamicNumber : DynamicObject
    {
        // The inner dictionary to store field names and values.
        Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        // Get the property value.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            return dictionary.TryGetValue(binder.Name, out result);
        }

        // Set the property value.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        // Perform the binary operation. 
        public override bool TryBinaryOperation(
            BinaryOperationBinder binder, object arg, out object result)
        {
            // The Textual property contains the textual representaion 
            // of two numbers, in addition to the name 
            // of the binary operation.
            string resultTextual =
                dictionary["Textual"].ToString() + " "
                + binder.Operation + " " +
                ((DynamicNumber)arg).dictionary["Textual"].ToString();

            int resultNumeric;

            // Checking what type of operation is being performed.
            switch (binder.Operation)
            {
                // Proccessing mathematical addition (a + b).
                case ExpressionType.Add:
                    resultNumeric =
                        (int)dictionary["Numeric"] +
                        (int)((DynamicNumber)arg).dictionary["Numeric"];
                    break;

                // Processing mathematical substraction (a - b).
                case ExpressionType.Subtract:
                    resultNumeric =
                        (int)dictionary["Numeric"] -
                        (int)((DynamicNumber)arg).dictionary["Numeric"];
                    break;

                // In case of any other binary operation,
                // print out the type of operation and return false,
                // which means that the language should determine 
                // what to do.
                // (Usually the language just throws an exception.)
                default:
                    Console.WriteLine(
                        binder.Operation +
                        ": This binary operation is not implemented");
                    result = null;
                    return false;
            }

            dynamic finalResult = new DynamicNumber();
            finalResult.Textual = resultTextual;
            finalResult.Numeric = resultNumeric;
            result = finalResult;
            return true;
        }
    }

    class Program
    {
        static void Test(string[] args)
        {
            // Creating the first dynamic number.
            dynamic firstNumber = new DynamicNumber();

            // Creating properties and setting their values
            // for the first dynamic number.
            // The TrySetMember method is called.
            firstNumber.Textual = "One";
            firstNumber.Numeric = 1;

            // Printing out properties. The TryGetMember method is called.
            Console.WriteLine(
                firstNumber.Textual + " " + firstNumber.Numeric);

            // Creating the second dynamic number.
            dynamic secondNumber = new DynamicNumber();
            secondNumber.Textual = "Two";
            secondNumber.Numeric = 2;
            Console.WriteLine(
                secondNumber.Textual + " " + secondNumber.Numeric);


            dynamic resultNumber = new DynamicNumber();

            // Adding two numbers. The TryBinaryOperation is called.
            resultNumber = firstNumber + secondNumber;

            Console.WriteLine(
                resultNumber.Textual + " " + resultNumber.Numeric);

            // Subtracting two numbers. TryBinaryOperation is called.
            resultNumber = firstNumber - secondNumber;

            Console.WriteLine(
                resultNumber.Textual + " " + resultNumber.Numeric);

            // The following statement produces a run-time exception
            // because the multiplication operation is not implemented.
            // resultNumber = firstNumber * secondNumber;
        }
    }

    // This code example produces the following output:

    // One 1
    // Two 2
    // One Add Two 3
    // One Subtract Two -1