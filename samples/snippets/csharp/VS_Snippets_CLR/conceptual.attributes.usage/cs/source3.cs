//<snippet18>
using System;
using System.Reflection;
using CustomCodeAttributes;

[Developer("Joan Smith", "42", Reviewed = true)]
class MainApp
{
    public static void Main()
    {
        // Call function to get and display the attribute.
        GetAttribute(typeof(MainApp));
    }

    public static void GetAttribute(Type t)
    {
        // Get instance of the attribute.
        DeveloperAttribute MyAttribute =
            (DeveloperAttribute) Attribute.GetCustomAttribute(t, typeof (DeveloperAttribute));

        if (MyAttribute == null)
        {
            Console.WriteLine("The attribute was not found.");
        }
        else
        {
            // Get the Name value.
            Console.WriteLine($"The Name Attribute is: {MyAttribute.Name}.");
            // Get the Level value.
            Console.WriteLine($"The Level Attribute is: {MyAttribute.Level}.");
            // Get the Reviewed value.
            Console.WriteLine($"The Reviewed Attribute is: {MyAttribute.Reviewed}.");
        }
    }
}
//</snippet18>

class GetAttribTest1
{
    //<snippet19>
    public static void GetAttribute(Type t)
    {
        DeveloperAttribute[] MyAttributes =
            (DeveloperAttribute[]) Attribute.GetCustomAttributes(t, typeof (DeveloperAttribute));

        if (MyAttributes.Length == 0)
        {
            Console.WriteLine("The attribute was not found.");
        }
        else
        {
            for (int i = 0 ; i < MyAttributes.Length ; i++)
            {
                // Get the Name value.
                Console.WriteLine($"The Name Attribute is: {MyAttributes[i].Name}.");
                // Get the Level value.
                Console.WriteLine($"The Level Attribute is: {MyAttributes[i].Level}.");
                // Get the Reviewed value.
                Console.WriteLine($"The Reviewed Attribute is: {MyAttributes[i].Reviewed}.");
            }
        }
    }
    //</snippet19>
}

class GetAttribTest2
{
    //<snippet20>
    public static void GetAttribute(Type t)
    {
        DeveloperAttribute att;

        // Get the class-level attributes.

        // Put the instance of the attribute on the class level in the att object.
        att = (DeveloperAttribute) Attribute.GetCustomAttribute (t, typeof (DeveloperAttribute));

        if (att == null)
        {
            Console.WriteLine("No attribute in class {0}.\n", t.ToString());
        }
        else
        {
            Console.WriteLine($"The Name Attribute on the class level is: {att.Name}.");
            Console.WriteLine($"The Level Attribute on the class level is: {att.Level}.");
            Console.WriteLine($"The Reviewed Attribute on the class level is: {att.Reviewed}.\n");
        }

        // Get the method-level attributes.

        // Get all methods in this class, and put them
        // in an array of System.Reflection.MemberInfo objects.
        MemberInfo[] MyMemberInfo = t.GetMethods();

        // Loop through all methods in this class that are in the
        // MyMemberInfo array.
        for (int i = 0; i < MyMemberInfo.Length; i++)
        {
            att = (DeveloperAttribute) Attribute.GetCustomAttribute(MyMemberInfo[i], typeof (DeveloperAttribute));
            if (att == null)
            {
                Console.WriteLine("No attribute in member function {0}.\n" , MyMemberInfo[i].ToString());
            }
            else
            {
                Console.WriteLine("The Name Attribute for the {0} member is: {1}.",
                    MyMemberInfo[i].ToString(), att.Name);
                Console.WriteLine("The Level Attribute for the {0} member is: {1}.",
                    MyMemberInfo[i].ToString(), att.Level);
                Console.WriteLine("The Reviewed Attribute for the {0} member is: {1}.\n",
                    MyMemberInfo[i].ToString(), att.Reviewed);
            }
        }
    }
    //</snippet20>
}
