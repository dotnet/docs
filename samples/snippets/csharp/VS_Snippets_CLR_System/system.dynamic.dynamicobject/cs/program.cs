using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

// Class description, TrySetMember, TryGetMember
namespace Test1
{    
    //<Snippet1>
    // The class derived from DynamicObject.
    public class DynamicDictionary : DynamicObject
    {
        // The inner dictionary.
        Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        // This property returns the number of elements
        // in the inner dictionary.
        public int Count
        {
            get
            {
                return dictionary.Count;
            }
        }

        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return dictionary.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[binder.Name.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
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

            // Getting values of the dynamic properties.
            // The TryGetMember method is called.
            // Note that property names are case-insensitive.
            Console.WriteLine(person.firstname + " " + person.lastname);

            // Getting the value of the Count property.
            // The TryGetMember is not called, 
            // because the property is defined in the class.
            Console.WriteLine(
                "Number of dynamic properties:" + person.Count);

            // The following statement throws an exception at run time.
            // There is no "address" property,
            // so the TryGetMember method returns false and this causes a
            // RuntimeBinderException.
            // Console.WriteLine(person.address);
        }
    }

    // This example has the following output:
    // Ellen Adams
    // Number of dynamic properties: 2
    //</Snippet1>

}

// TryBinaryOperation
namespace N2
{
    //<Snippet2>
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
    //</Snippet2>
}

//TryConvert
namespace n3
{
    //<Snippet3>
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
    //</Snippet3>
}

//TryGetIndex and TrySetIndex
namespace N4
{
    //<Snippet4>
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
    //</Snippet4>
}

//TryInvoke
namespace N5
{
    //<Snippet5>
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
    //</Snippet5>
}

// TryInvokeMember
namespace N6
{
    //<Snippet6>
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
    //</Snippet6>
}

namespace n7
{
    //<Snippet7>
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
    //</Snippet7>

}



