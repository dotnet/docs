// <Snippet2>
using System;
using System.Reflection;

interface IValue 
{
   int GetValue() ;
};
 
class A : IValue 
{
   public virtual int GetValue() 
   { 
      return 0; 
   }
};
 
class B : A 
{
   public new int GetValue() 
   { 
      return 0; 
   }
};
 
class C : A 
{ };

class D : A
{
   public override int GetValue()
   {
      return 0;
   }
}

public class Example
{
   public static void Main()
   {
      // Get members of IValue interface.
      ShowMembersAndDeclaringTypes(typeof(IValue));
      Console.WriteLine();
      ShowMembersAndDeclaringTypes(typeof(A));
      Console.WriteLine();
      ShowMembersAndDeclaringTypes(typeof(B));
      Console.WriteLine();
      ShowMembersAndDeclaringTypes(typeof(C));
      Console.WriteLine();
      ShowMembersAndDeclaringTypes(typeof(D));
      Console.WriteLine();
   }

   private static void ShowMembersAndDeclaringTypes(Type t)
   {
      MemberInfo[] members = t.GetMembers();
      Console.WriteLine("{0} Members: ", t.Name);
      foreach (var member in members)
         Console.WriteLine("   {0}, Declaring type: {1}", 
                           member.Name, member.DeclaringType.Name); 
   }
}
// The example displays the following output:
//       IValue Members:
//          GetValue, Declaring type: IValue
//       
//       A Members:
//          GetValue, Declaring type: A
//          ToString, Declaring type: Object
//          Equals, Declaring type: Object
//          GetHashCode, Declaring type: Object
//          GetType, Declaring type: Object
//          .ctor, Declaring type: A
//       
//       B Members:
//          GetValue, Declaring type: B
//          GetValue, Declaring type: A
//          ToString, Declaring type: Object
//          Equals, Declaring type: Object
//          GetHashCode, Declaring type: Object
//          GetType, Declaring type: Object
//          .ctor, Declaring type: B
//       
//       C Members:
//          GetValue, Declaring type: A
//          ToString, Declaring type: Object
//          Equals, Declaring type: Object
//          GetHashCode, Declaring type: Object
//          GetType, Declaring type: Object
//          .ctor, Declaring type: C
//       
//       D Members:
//          GetValue, Declaring type: D
//          ToString, Declaring type: Object
//          Equals, Declaring type: Object
//          GetHashCode, Declaring type: Object
//          GetType, Declaring type: Object
//          .ctor, Declaring type: D
// </Snippet2>