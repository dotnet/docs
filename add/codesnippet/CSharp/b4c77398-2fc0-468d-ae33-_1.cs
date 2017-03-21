    // The class derived from DynamicObject.
    public class SampleDynamicObject : DynamicObject
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

        // Set the property value by index.
        public override bool TrySetIndex(
            SetIndexBinder binder, object[] indexes, object value)
        {
            int index = (int)indexes[0];

            // If a corresponding property already exists, set the value.
            if (dictionary.ContainsKey("Property" + index))
                dictionary["Property" + index] = value;
            else
                // If a corresponding property does not exist, create it.
                dictionary.Add("Property" + index, value);
            return true;
        }

        // Get the property value by index.
        public override bool TryGetIndex(
            GetIndexBinder binder, object[] indexes, out object result)
        {

            int index = (int)indexes[0];
            return dictionary.TryGetValue("Property" + index, out result);
        }
    }

    class Program
    {
        static void Test(string[] args)
        {
            // Creating a dynamic object.
            dynamic sampleObject = new SampleDynamicObject();

            // Creating Property0. 
            // The TrySetMember method is called.
            sampleObject.Property0 = "Zero";

            // Getting the value by index.
            // The TryGetIndex method is called.
            Console.WriteLine(sampleObject[0]);

            // Setting the property value by index.
            // The TrySetIndex method is called.
            // (This method also creates Property1.)
            sampleObject[1] = 1;

            // Getting the Property1 value.
            // The TryGetMember method is called.
            Console.WriteLine(sampleObject.Property1);

            // The following statement produces a run-time exception
            // because there is no corresponding property.
            //Console.WriteLine(sampleObject[2]);
        }
    }

    // This code example produces the following output:

    // Zero
    // 1