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

        // Initializing properties with arguments' values.
        public override bool TryInvoke(
            InvokeBinder binder, object[] args, out object result)
        {
            // The invoke operation in this case takes two arguments.
            // The first one is integer and the second one is string.
            if ((args.Length == 2) &&
                (args[0].GetType() == typeof(int)) &&
                (args[1].GetType() == typeof(String)))
            {
                // If the property already exists, 
                // its value is changed.
                // Otherwise, a new property is created.
                if (dictionary.ContainsKey("Numeric"))
                    dictionary["Numeric"] = args[0];
                else
                    dictionary.Add("Numeric", args[0]);

                if (dictionary.ContainsKey("Textual"))
                    dictionary["Textual"] = args[1];
                else
                    dictionary.Add("Textual", args[1]);

                result = true;
                return true;
            }

            else
            {
                // If the number of arguments is wrong,
                // or if arguments are of the wrong type,
                // the method returns false.
                result = false;
                return false;
            }
        }
    }
    class Program
    {
        static void Test(string[] args)
        {
            // Creating a dynamic object.
            dynamic number = new DynamicNumber();

            // Adding and initializing properties.
            // The TrySetMember method is called.
            number.Numeric = 1;
            number.Textual = "One";

            // Printing out the result.
            // The TryGetMember method is called.
            Console.WriteLine(number.Numeric + " " + number.Textual);

            // Invoking an object.
            // The TryInvoke method is called.
            number(2, "Two");
            Console.WriteLine(number.Numeric + " " + number.Textual);

            // The following statement produces a run-time exception
            // because in this example the method invocation 
            // expects two arguments.
            // number(0);
        }
    }

    // This code example produces the following output:

    // 1 One
    // 2 Two