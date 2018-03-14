// <Snippet1>

using System;
using System.Reflection;

// Define a custom attribute with one named parameter.
[AttributeUsage(AttributeTargets.All)]
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

// Define a class that has the custom attribute associated with one of its members.
public class MyClass1
{
    [MyAttribute("This is an example attribute.")]
    public void MyMethod(int i)
    {
        return;
    }
}

public class MemberInfo_GetCustomAttributes_IsDefined
{
    public static void Main()
    {
        try
        {
            // Get the type of MyClass1.
            Type myType = typeof(MyClass1);
            // Get the members associated with MyClass1.
            MemberInfo[] myMembers = myType.GetMembers();

            // Display the attributes for each of the members of MyClass1.
            for(int i = 0; i < myMembers.Length; i++)
            {
                // Display the attribute if it is of type MyAttribute.
                if(myMembers[i].IsDefined(typeof(MyAttribute), false))
                {
                    Object[] myAttributes = myMembers[i].GetCustomAttributes(typeof(MyAttribute), false);
                    Console.WriteLine("\nThe attributes of type MyAttribute for the member {0} are: \n",
                        myMembers[i]);
                    for(int j = 0; j < myAttributes.Length; j++)
                        // Display the value associated with the attribute.
                        Console.WriteLine("The value of the attribute is : \"{0}\"",
                            ((MyAttribute)myAttributes[j]).Name);
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("An exception occurred: {0}", e.Message);
        }
    }
}
// </Snippet1>

