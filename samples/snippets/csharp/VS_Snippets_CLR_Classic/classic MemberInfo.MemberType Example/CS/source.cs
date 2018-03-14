// <Snippet1>
using System;
using System.Reflection;
 
class Mymemberinfo
{
    public static int Main()
    {
        Console.WriteLine ("\nReflection.MemberInfo");
       
        // Get the Type and MemberInfo.
        Type MyType = Type.GetType("System.Reflection.PropertyInfo");
        MemberInfo[] Mymemberinfoarray = MyType.GetMembers();
  
        // Get the MemberType method and display the elements.
        Console.Write("\nThere are {0} members in ", Mymemberinfoarray.GetLength(0));
        Console.Write("{0}.", MyType.FullName);
  
        for (int counter = 0; counter < Mymemberinfoarray.Length; counter++)
        {
            Console.Write("\n" + counter + ". " 
                + Mymemberinfoarray[counter].Name
                + " Member type - " +
                Mymemberinfoarray[counter].MemberType.ToString());
        }
        return 0;
    }
}

// </Snippet1>

