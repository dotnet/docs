// <snippet1>
using System;
using System.Reflection;

public class Example
{
    static void Main()
    {
        MemberInfo m1 = typeof(Object).GetMethod("ToString");
        MemberInfo m2 = typeof(MemberInfo).GetMethod("ToString");

        Console.WriteLine("m1.DeclaringType: {0}", m1.DeclaringType);
        Console.WriteLine("m1.ReflectedType: {0}", m1.ReflectedType);
        Console.WriteLine();
        Console.WriteLine("m2.DeclaringType: {0}", m2.DeclaringType);
        Console.WriteLine("m2.ReflectedType: {0}", m2.ReflectedType);

        //Console.ReadLine();
    }
}

/* This code example produces the following output:

m1.DeclaringType: System.Object
m1.ReflectedType: System.Object

m2.DeclaringType: System.Object
m2.ReflectedType: System.Reflection.MemberInfo
 */
// </snippet1>

