// <Snippet1>
using System;
using System.Reflection;

// Define a custom attribute with one named parameter.
[AttributeUsage(AttributeTargets.Parameter)]
public class MyAttribute : Attribute
{
    private string myName;
    public MyAttribute(string name)
    {
        myName = name;
    }
    public string Name 
    {
        get 
        {
            return myName;
        }
    }
}

// Derive another custom attribute from MyAttribute
[AttributeUsage(AttributeTargets.Parameter)]
public class MyDerivedAttribute : MyAttribute
{
    public MyDerivedAttribute(string name) : base(name) {}
}

// Define a class with a method that has three parameters. Apply
// MyAttribute to one parameter, MyDerivedAttribute to another, and
// no attributes to the third. 
public class MyClass1
{
    public void MyMethod(
        [MyAttribute("This is an example parameter attribute")]
        int i,
        [MyDerivedAttribute("This is another parameter attribute")]
        int j,
        int k )
    {
        return;
    }
}

public class MemberInfo_GetCustomAttributes 
{
    public static void Main()
    {
        // Get the type of the class 'MyClass1'.
        Type myType = typeof(MyClass1);
        // Get the members associated with the class 'MyClass1'.
        MethodInfo[] myMethods = myType.GetMethods();

        // For each method of the class 'MyClass1', display all the parameters
        // to which MyAttribute or its derived types have been applied.
        foreach (MethodInfo mi in myMethods)
        {
            // Get the parameters for the method.
            ParameterInfo[] myParameters = mi.GetParameters();
            if (myParameters.Length > 0)
            {
                Console.WriteLine("\nThe following parameters of {0} have MyAttribute or a derived type: ", mi);
                foreach (ParameterInfo pi in myParameters)
                {
                    if (pi.IsDefined(typeof(MyAttribute), false))
                    {
                        Console.WriteLine("Parameter {0}, name = {1}, type = {2}", 
                            pi.Position, pi.Name, pi.ParameterType);
                    }
                }
            }
        }  
    }
}

/* This code example produces the following output:

The following parameters of Void MyMethod(Int32, Int32, Int32) have MyAttribute or a derived type:
Parameter 0, name = i, type = System.Int32
Parameter 1, name = j, type = System.Int32

The following parameters of Boolean Equals(System.Object) have MyAttribute or a derived type:
 */
// </Snippet1>

