// <Snippet1>
using System;
using System.Reflection;
 
public abstract class dtype 
{
    
    public abstract class MyClassA 
    {
        public abstract int m(); 
    }
    
    public abstract class MyClassB : MyClassA 
    {
    }
  
    public static void Main(string[] args) 
    { 
        Console.WriteLine("The declaring type of m is {0}.",
            typeof(MyClassB).GetMethod("m").DeclaringType);
    }
}
// </Snippet1>
