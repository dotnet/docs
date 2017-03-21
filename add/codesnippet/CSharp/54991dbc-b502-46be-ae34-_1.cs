    // The class derived from DynamicObject.
    public class DynamicNumber : DynamicObject
    {
        // The inner dictionary.
        Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        // Getting a property.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            return dictionary.TryGetValue(binder.Name, out result);
        }

        // Setting a property.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        // Converting an object to a specified type.
        public override bool TryConvert(
            ConvertBinder binder, out object result)
        {
            // Converting to string. 
            if (binder.Type == typeof(String))
            {
                result = dictionary["Textual"];
                return true;
            }

            // Converting to integer.
            if (binder.Type == typeof(int))
            {
                result = dictionary["Numeric"];
                return true;
            }

            // In case of any other type, the binder 
            // attempts to perform the conversion itself.
            // In most cases, a run-time exception is thrown.
            return base.TryConvert(binder, out result);
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

            // Implicit conversion to integer.
            int testImplicit = number;

            // Explicit conversion to string.
            string testExplicit = (String)number;

            Console.WriteLine(testImplicit);
            Console.WriteLine(testExplicit);

            // The following statement produces a run-time exception
            // because the conversion to double is not implemented.
            // double test = number;
        }
    }

    // This example has the following output:

    // 1
    // One