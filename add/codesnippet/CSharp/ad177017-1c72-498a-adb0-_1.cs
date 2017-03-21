    // Add using System.Reflection;
    // to the beginning of the file.

    // The class derived from DynamicObject.
    public class DynamicDictionary : DynamicObject
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

        // Calling a method.
        public override bool TryInvokeMember(
            InvokeMemberBinder binder, object[] args, out object result)
        {
            Type dictType = typeof(Dictionary<string, object>);
            try
            {
                result = dictType.InvokeMember(
                             binder.Name,
                             BindingFlags.InvokeMethod,
                             null, dictionary, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        // This methods prints out dictionary elements.
        public void Print()
        {
            foreach (var pair in dictionary)
                Console.WriteLine(pair.Key + " " + pair.Value);
            if (dictionary.Count == 0)
                Console.WriteLine("No elements in the dictionary.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating a dynamic dictionary.
            dynamic person = new DynamicDictionary();

            // Adding new dynamic properties.
            // The TrySetMember method is called.
            person.FirstName = "Ellen";
            person.LastName = "Adams";

            // Calling a method defined in the DynmaicDictionary class.
            // The Print method is called.
            person.Print();

            Console.WriteLine(
                "Removing all the elements from the dictionary.");

            // Calling a method that is not defined in the DynamicDictionary class.
            // The TryInvokeMember method is called.
            person.Clear();

            // Calling the Print method again.
            person.Print();

            // The following statement throws an exception at run time.
            // There is no Sample method 
            // in the dictionary or in the DynamicDictionary class.
            // person.Sample();        
        }
    }

    // This example has the following output:

    // FirstName Ellen 
    // LastName Adams
    // Removing all the elements from the dictionary.
    // No elements in the dictionary.