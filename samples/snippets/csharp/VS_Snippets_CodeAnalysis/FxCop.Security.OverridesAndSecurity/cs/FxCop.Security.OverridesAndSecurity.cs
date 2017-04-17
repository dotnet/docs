//<Snippet1>
using System.Security;
using System.Security.Permissions;
using System;

namespace SecurityRulesLibrary
{
   public interface ITestOverrides
   {  
      [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
      Object GetFormat(Type formatType);
   }

   public class OverridesAndSecurity : ITestOverrides
   {
      // Rule violation: The interface has security, and this implementation does not.
      object ITestOverrides.GetFormat(Type formatType)
      {
         return (formatType == typeof(OverridesAndSecurity) ? this : null);
      }

      // These two methods are overridden by DerivedClass and DoublyDerivedClass.
      [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
      public virtual void DoSomething()
      {
         Console.WriteLine("Doing something.");
      }

      public virtual void DoSomethingElse()
      {
         Console.WriteLine("Doing some other thing.");
      }
   }

   public class DerivedClass : OverridesAndSecurity, ITestOverrides
   {
      //  Rule violation: The interface has security, and this implementation does not.
      public object GetFormat(Type formatType)
      {
         return (formatType == typeof(OverridesAndSecurity) ? this : null);
      }

      // Rule violation: This does not have security, but the base class version does.
      public override void DoSomething()
      {
         Console.WriteLine("Doing some derived thing.");
      }

      // Rule violation: This has security, but the base class version does not.
      [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
      public override void DoSomethingElse()
      {
         Console.WriteLine("Doing some other derived thing.");
      }
   }

   public class DoublyDerivedClass : DerivedClass
   {
      // The OverridesAndSecurity version of this method does not have security. 
      // Base class DerivedClass's version does. 
      // The DoublyDerivedClass version does not violate the rule, but the 
      // DerivedClass version does violate the rule.
      public override void DoSomethingElse()
      {
         Console.WriteLine("Doing some other derived thing.");
      }
   }
}
//</Snippet1>
