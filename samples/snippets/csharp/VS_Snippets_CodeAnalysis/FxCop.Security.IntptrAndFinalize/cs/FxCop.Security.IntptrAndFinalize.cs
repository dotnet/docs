//<Snippet1>
using System;

namespace SecurityRulesLibrary
{
   class IntPtrFieldsAndFinalizeRequireGCKeepAlive
   {
      private IntPtr unmanagedResource;
      
      IntPtrFieldsAndFinalizeRequireGCKeepAlive()
      {
         GetUnmanagedResource (unmanagedResource);
      }

      // The finalizer frees the unmanaged resource.
      ~IntPtrFieldsAndFinalizeRequireGCKeepAlive()
      {
         FreeUnmanagedResource (unmanagedResource);
      }

      // Violates rule:CallGCKeepAliveWhenUsingNativeResources. 
      void BadMethod()
      {
         // Call some unmanaged code.
         CallUnmanagedCode(unmanagedResource);
      }

      // Satisfies the rule.
      void GoodMethod()
      {
         // Call some unmanaged code.
         CallUnmanagedCode(unmanagedResource);
         GC.KeepAlive(this);
      }

      // Methods that would typically make calls to unmanaged code.
      void GetUnmanagedResource(IntPtr p)
      {
        // Allocate the resource ...
      }
      void FreeUnmanagedResource(IntPtr p)
      {
        // Free the resource and set the pointer to null ...
      }
      void CallUnmanagedCode(IntPtr p)
      {
        // Use the resource in unmanaged code ...
      }
      
   }

}
//</Snippet1>
