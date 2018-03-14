//<Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Example
{
    private static int _staticProperty = 41;
    public static int StaticProperty    
    {
        get
        {
            return _staticProperty;
        }
        set
        {
            _staticProperty = value;
        }
    }

    private int _instanceProperty = 42;
    public int InstanceProperty    
    {
        get
        {
            return _instanceProperty;
        }
        set
        {
            _instanceProperty = value;
        }
    }

    private Dictionary<int, string> _indexedInstanceProperty = 
        new Dictionary<int, string>();
    // By default, the indexer is named Item, and that name must be used
    // to search for the property. In this example, the indexer is given
    // a different name by using the IndexerNameAttribute attribute.
    [IndexerNameAttribute("IndexedInstanceProperty")]
    public string this[int key]    
    {
        get
        {
            string returnValue = null;
            if (_indexedInstanceProperty.TryGetValue(key, out returnValue))
            {
                return returnValue;
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (value == null)
            {
                throw new ApplicationException("IndexedInstanceProperty value can be the empty string, but it cannot be Nothing.");
            }
            else
            {
                if (_indexedInstanceProperty.ContainsKey(key))
                {
                    _indexedInstanceProperty[key] = value;
                }
                else
                {
                    _indexedInstanceProperty.Add(key, value);
                }
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("Initial value of class-level property: {0}", 
            Example.StaticProperty);

        PropertyInfo piShared = typeof(Example).GetProperty("StaticProperty");
        piShared.SetValue(null, 76, null);
                 
        Console.WriteLine("Final value of class-level property: {0}", 
            Example.StaticProperty);


        Example exam = new Example();

        Console.WriteLine("\nInitial value of instance property: {0}", 
            exam.InstanceProperty);

        PropertyInfo piInstance = 
            typeof(Example).GetProperty("InstanceProperty");
        piInstance.SetValue(exam, 37, null);
                 
        Console.WriteLine("Final value of instance property: {0}", 
            exam.InstanceProperty);


        exam[17] = "String number 17";
        exam[46] = "String number 46";
        exam[9] = "String number 9";

        Console.WriteLine(
            "\nInitial value of indexed instance property(17): '{0}'", 
            exam[17]);

        // By default, the indexer is named Item, and that name must be used
        // to search for the property. In this example, the indexer is given
        // a different name by using the IndexerNameAttribute attribute.
        PropertyInfo piIndexedInstance = 
            typeof(Example).GetProperty("IndexedInstanceProperty");
        piIndexedInstance.SetValue(
            exam, 
            "New value for string number 17", 
            new object[] { (int) 17 });
                 
        Console.WriteLine(
            "Final value of indexed instance property(17): '{0}'", 
            exam[17]);       
    }
}

/* This example produces the following output:

Initial value of class-level property: 41
Final value of class-level property: 76

Initial value of instance property: 42
Final value of instance property: 37

Initial value of indexed instance property(17): 'String number 17'
Final value of indexed instance property(17): 'New value for string number 17'
 */
//</Snippet1>



