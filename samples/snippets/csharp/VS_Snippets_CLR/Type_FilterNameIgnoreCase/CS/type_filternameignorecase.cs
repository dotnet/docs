// <Snippet1>
using System;
using System.Reflection;
using System.Security;
public class MyFilterNameIgnoreCaseSample
{
    public static void Main()
    {
        try
        {		
            MemberFilter myFilter = Type.FilterNameIgnoreCase;
            Type myType = typeof(System.String);
            MemberInfo[] myMemberinfo1 = myType.FindMembers(MemberTypes.Constructor
                |MemberTypes.Method, BindingFlags.Public | BindingFlags.Static |
                BindingFlags.Instance, myFilter, "C*");
            foreach (MemberInfo myMemberinfo2 in myMemberinfo1) 
            { 
                Console.Write("\n" + myMemberinfo2.Name);
                MemberTypes Mymembertypes = myMemberinfo2.MemberType; 
                Console.WriteLine(" is a " + Mymembertypes.ToString()); 
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
            Console.Write("Exception : " + e.Message); 
        }
    }
}
// </Snippet1>