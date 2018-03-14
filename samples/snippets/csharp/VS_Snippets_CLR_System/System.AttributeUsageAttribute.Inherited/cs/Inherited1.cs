// <Snippet2>
using System;
using System.Reflection;

[InheritedAttribute]
public class BaseA
{
   [InheritedAttribute] 
   public virtual void MethodA()   
   {}
}

public class DerivedA : BaseA
{
   public override void MethodA()
   {}
} 

[NotInheritedAttribute] 
public class BaseB
{
   [NotInheritedAttribute] 
   public virtual void MethodB()   
   {}
}

public class DerivedB : BaseB
{
   public override void MethodB()
   {}
}

public class Example
{
   public static void Main()
   {
      Type typeA = typeof(DerivedA);
      Console.WriteLine("DerivedA has Inherited attribute: {0}", 
                        typeA.GetCustomAttributes(typeof(InheritedAttribute), true).Length > 0); 
      MethodInfo memberA = typeA.GetMethod("MethodA");
      Console.WriteLine("DerivedA.MemberA has Inherited attribute: {0}\n", 
                        memberA.GetCustomAttributes(typeof(InheritedAttribute), true).Length > 0); 
      
      Type typeB = typeof(DerivedB);
      Console.WriteLine("DerivedB has Inherited attribute: {0}", 
                        typeB.GetCustomAttributes(typeof(InheritedAttribute), true).Length > 0); 
      MethodInfo memberB = typeB.GetMethod("MethodB");
      Console.WriteLine("DerivedB.MemberB has Inherited attribute: {0}", 
                        memberB.GetCustomAttributes(typeof(InheritedAttribute), true).Length > 0); 
   }
}
// The example displays the following output:
//       DerivedA has Inherited attribute: True
//       DerivedA.MemberA has Inherited attribute: True
//       
//       DerivedB has Inherited attribute: False
//       DerivedB.MemberB has Inherited attribute: False
// </Snippet2>

// <Snippet1>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |  
                AttributeTargets.Property | AttributeTargets.Field, 
                Inherited = true)]
public class InheritedAttribute : Attribute
{}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |
                AttributeTargets.Property | AttributeTargets.Field, 
                Inherited = false)]
public class NotInheritedAttribute : Attribute
{} 
// </Snippet1>