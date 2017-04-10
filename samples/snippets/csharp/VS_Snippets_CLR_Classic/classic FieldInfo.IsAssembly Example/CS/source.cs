// Completely rewrote sample 2/15/06 GlennHa
// <Snippet1>
using System;
using System.Reflection;

public class Example
{
    public int f_public;
    internal int f_internal;
    protected int f_protected;
    protected internal int f_protected_public;

    public static void Main()
    {
        Console.WriteLine("\n{0,-30}{1,-18}{2}", "", "IsAssembly", "IsFamilyOrAssembly"); 
        Console.WriteLine("{0,-21}{1,-18}{2,-18}{3}\n", 
            "", "IsPublic", "IsFamily", "IsFamilyAndAssembly");
   
        foreach (FieldInfo f in typeof(Example).GetFields(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            Console.WriteLine("{0,-21}{1,-9}{2,-9}{3,-9}{4,-9}{5,-9}", 
                f.Name,
                f.IsPublic,
                f.IsAssembly,
                f.IsFamily,
                f.IsFamilyOrAssembly,
                f.IsFamilyAndAssembly
            );
        }
    }
}

/* This code example produces output similar to the following:

                              IsAssembly        IsFamilyOrAssembly
                     IsPublic          IsFamily          IsFamilyAndAssembly

f_public             True     False    False    False    False
f_internal           False    True     False    False    False
f_protected          False    False    True     False    False
f_protected_public   False    False    False    True     False
 */
// </Snippet1>

