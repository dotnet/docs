// <Snippet1>

using System;
using System.Reflection;
using System.IO;

[DefaultMemberAttribute("Age")]   
public class MyClass
{
    public void Name(String s) {}
    public int Age
    {
        get
        {
            return 20;
        }
    }
    public static void Main()
    {
        try
        {
            Type  myType = typeof(MyClass);
            MemberInfo[] memberInfoArray = myType.GetDefaultMembers();
            if (memberInfoArray.Length > 0)
            {
                foreach(MemberInfo memberInfoObj in memberInfoArray)
                {
                    Console.WriteLine("The default member name is: " + memberInfoObj.ToString());
                }
            }
            else
            {
                Console.WriteLine("No default members are available."); 
            }
        }
        catch(InvalidOperationException e)
        {
            Console.WriteLine("InvalidOperationException: " + e.Message);
        }
        catch(IOException e)
        {
            Console.WriteLine("IOException: " + e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}
// </Snippet1>