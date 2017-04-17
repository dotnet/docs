// <Snippet1>         

using System;
using System.Reflection;
public class MyClass 
{
    public class NestClass 
    {
        public static int myPublicInt=0;
    }
    public struct NestStruct
    {
        public static int myPublicInt=0;
    }
}

public class MyMainClass 
{
    public static void Main() 
    {
        try
        {
            // Get the Type object corresponding to MyClass.
            Type myType=typeof(MyClass);
            // Get an array of nested type objects in MyClass. 
            Type[] nestType=myType.GetNestedTypes();
            Console.WriteLine("The number of nested types is {0}.", nestType.Length);
            foreach(Type t in nestType)
                Console.WriteLine("Nested type is {0}.", t.ToString());
        }
        catch(Exception e)
        {
            Console.WriteLine("Error"+e.Message);  
        }         
    }
}
// </Snippet1>
