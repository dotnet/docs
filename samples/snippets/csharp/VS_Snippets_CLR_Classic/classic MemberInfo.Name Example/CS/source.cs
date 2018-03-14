// <Snippet1>
using System;
using System.Reflection;
 
class Example
{
    public static void Main()
    {
        // Get the Type and MemberInfo.
        Type t = Type.GetType("System.Empty");
        MemberInfo[] memberArray = t.GetMembers();
  
        // Get and display the type that declares the member.
        Console.WriteLine("There are {0} members in {1}",
                          memberArray.Length, t.FullName);
  
        foreach (var member in memberArray) {
            Console.WriteLine("Member {0} declared by {1}", 
                              member.Name, member.DeclaringType);
        }
    }
}
// The example displays the following output:
//       There are 6 members in System.Empty
//       Member ToString declared by System.Empty
//       Member GetObjectData declared by System.Empty
//       Member Equals declared by System.Object
//       Member GetHashCode declared by System.Object
//       Member GetType declared by System.Object
//       Member Value declared by System.Empty
// </Snippet1>

