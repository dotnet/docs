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

public class MemberInfo_GetCustomAttributes
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
                Object[] myAttributes = myMembers[i].GetCustomAttributes(true);
                if(myAttributes.Length > 0)
                {
                    Console.WriteLine("\nThe attributes for the member {0} are: \n", myMembers[i]);
                    for(int j = 0; j < myAttributes.Length; j++)
                        Console.WriteLine("The type of the attribute is {0}.", myAttributes[j]);
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