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

// Define a class which has a custom attribute associated with one of the 
// parameters of a method. 
public class MyClass1
{
    public void MyMethod(
        [MyAttribute("This is an example parameter attribute")]
        int i)
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

        // Display the attributes for each of the parameters of each method of the class 'MyClass1'.
        for(int i = 0; i < myMethods.Length; i++)
        {
            // Get the parameters for the method.
            ParameterInfo[] myParameters = myMethods[i].GetParameters();

            if (myParameters.Length > 0)
            {
                Console.WriteLine("\nThe parameters for the method {0} that have custom attributes are :", myMethods[i]);
                for(int j = 0; j < myParameters.Length; j++)
                {
                    // Get the attributes of type 'MyAttribute' for each parameter.
                    Object[] myAttributes = myParameters[j].GetCustomAttributes(typeof(MyAttribute), false);
 
                    if (myAttributes.Length > 0)
                    {
                        Console.WriteLine("Parameter {0}, name = {1}, type = {2} has attributes: ", 
                            myParameters[j].Position, myParameters[j].Name, myParameters[j].ParameterType);
                        for(int k = 0; k < myAttributes.Length; k++)
                        {
                            Console.WriteLine("\t{0}", myAttributes[k]);
                        }
                    }
                }
            }
        }  
    }
}
/* This code example produces the following output:

The parameters for the method Void MyMethod(Int32) that have custom attributes are :
Parameter 0, name = i, type = System.Int32 has attributes:
        MyAttribute

The parameters for the method Boolean Equals(System.Object) that have custom attributes are :
 */
// </Snippet1>

