
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