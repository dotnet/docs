// <Snippet1>

using System;
using System.Security;
using System.Reflection;

public class MyMemberSample 
{
    public static void Main()
    {
        MyMemberSample myClass = new MyMemberSample();
        try
        {
            myClass.GetMemberInfo();
            myClass.GetPublicStaticMemberInfo();	
            myClass.GetPublicInstanceMethodMemberInfo();	
        }      
        catch(ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException occurred.");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }
        catch(NotSupportedException e)
        {
            Console.WriteLine("NotSupportedException occurred.");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }
        catch(SecurityException e)
        {
            Console.WriteLine("SecurityException occurred.");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception occurred.");
            Console.WriteLine("Source: " + e.Source);
            Console.WriteLine("Message: " + e.Message);
        }
    }

    public void GetMemberInfo()
    {
        String myString = "GetMember_String";

        Type myType = myString.GetType();
        // Get the members for myString starting with the letter C.
        MemberInfo[] myMembers = myType.GetMember("C*");
        if(myMembers.Length > 0)
        {
            Console.WriteLine("\nThe member(s) starting with the letter C for type {0}:", myType);
            for(int index=0; index < myMembers.Length; index++)
                Console.WriteLine("Member {0}: {1}", index + 1, myMembers[index].ToString());
        }
        else
            Console.WriteLine("No members match the search criteria.");    
    }
    // </Snippet1>

    // <Snippet2>
    public void GetPublicStaticMemberInfo()
    {
        String myString = "GetMember_String_BindingFlag";
        Type myType = myString.GetType();
        // Get the public static members for the class myString starting with the letter C.
        MemberInfo[] myMembers = myType.GetMember("C*",
            BindingFlags.Public |BindingFlags.Static);
        if(myMembers.Length > 0)
        {
            Console.WriteLine("\nThe public static member(s) starting with the letter C for type {0}:", myType);
            for(int index=0; index < myMembers.Length; index++)
                Console.WriteLine("Member {0}: {1}", index + 1, myMembers[index].ToString());
        }
        else
            Console.WriteLine("No members match the search criteria.");    
    }
    // </Snippet2>

    // <Snippet3>
    public void GetPublicInstanceMethodMemberInfo()
    {
        String myString = "GetMember_String_MemberType_BindingFlag";
        Type myType = myString.GetType();
        // Get the public instance methods for myString starting with the letter C.
        MemberInfo[] myMembers = myType.GetMember("C*", MemberTypes.Method, 
            BindingFlags.Public | BindingFlags.Instance);
        if(myMembers.Length > 0)
        {
            Console.WriteLine("\nThe public instance method(s) starting with the letter C for type {0}:", myType);
            for(int index=0; index < myMembers.Length; index++)
                Console.WriteLine("Member {0}: {1}", index + 1, myMembers[index].ToString());
        }
        else
            Console.WriteLine("No members match the search criteria.");    
    }
}
// </Snippet3>