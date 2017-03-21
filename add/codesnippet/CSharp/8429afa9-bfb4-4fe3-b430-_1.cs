    // Add using System.Linq.Expressions;
    // to the beginning of the file

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

        // Perform the unary operation. 
        public override bool TryUnaryOperation(
            UnaryOperationBinder binder, out object result)
        {
            // The Textual property contains 
            // the name of the unary operation in addition 
            // to the textual representaion of the number.
            string resultTextual =
                 binder.Operation + " " +
                 dictionary["Textual"].ToString();
            int resultNumeric;

            // Determining what type of operation is being performed.
            switch (binder.Operation)
            {
                case ExpressionType.Negate:
                    resultNumeric =
                         -(int)dictionary["Numeric"];
                    break;
                default:
                    // In case of any other unary operation,
                    // print out the type of operation and return false,
                    // which means that the language should determine 
                    // what to do.
                    // (Usually the language just throws an exception.)            
                    Console.WriteLine(
                        binder.Operation +
                        ": This unary operation is not implemented");
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
            dynamic number = new DynamicNumber();

            // Creating properties and setting their values
            // for the dynamic number.
            // The TrySetMember method is called.
            number.Textual = "One";
            number.Numeric = 1;

            // Printing out properties. The TryGetMember method is called.
            Console.WriteLine(
                number.Textual + " " + number.Numeric);

            dynamic negativeNumber = new DynamicNumber();

            // Performing a mathematical negation.
            // TryUnaryOperation is called.
            negativeNumber = -number;

            Console.WriteLine(
                negativeNumber.Textual + " " + negativeNumber.Numeric);

            // The following statement produces a run-time exception
            // because the unary plus operation is not implemented.
            // negativeNumber = +number;
        }
    }

    // This code example produces the following output:

    // One 1
    // Negate One -1