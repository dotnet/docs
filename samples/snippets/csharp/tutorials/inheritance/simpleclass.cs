// <Snippet2>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Type t = typeof(SimpleClass);
      BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
      MemberInfo[] members = t.GetMembers(flags);
      Console.WriteLine("Type {0} has {1} members: ", t.Name, members.Length);
      foreach (var member in members)
         Console.WriteLine("   {0} ({1}): Declared by {2}", 
                           member.Name, member.MemberType, 
                           member.DeclaringType);
   }
}
// The example displays the following output:
//      Type SimpleClass has 5 members:
//         ToString (Method): Declared by System.Object
//         Equals (Method): Declared by System.Object
//         GetHashCode (Method): Declared by System.Object
//         GetType (Method): Declared by System.Object
//         .ctor (Constructor): Declared by SimpleClass
// </Snippet2>

// <Snippet1>
public class SimpleClass
{}
// </Snippet1>

