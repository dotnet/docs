// <Snippet1>
using System;
using System.Reflection;
using System.Security;

public class MyFilterAttributeSample
{
    public static void Main()
    {
        try
        {
            MemberFilter myFilter = Type.FilterAttribute;
            Type myType = typeof(System.String);
            MemberInfo[] myMemberInfoArray = myType.FindMembers(MemberTypes.Constructor
                |MemberTypes.Method, BindingFlags.Public | BindingFlags.Static |
                BindingFlags.Instance, myFilter, MethodAttributes.SpecialName);
            foreach (MemberInfo myMemberinfo in myMemberInfoArray) 
            { 
                Console.Write ("\n" + myMemberinfo.Name);
                Console.Write (" is a " + myMemberinfo.MemberType.ToString()); 
            }
        }
        catch(ArgumentNullException e)
        {
            Console.Write("ArgumentNullException : " + e.Message); 
        }   
        catch(SecurityException e)
        {
            Console.Write("SecurityException : " + e.Message); 
        }   
        catch(Exception e)
        {
            Console.Write("Exception :" + e.Message); 
        } 
    }	
}
// </Snippet1>