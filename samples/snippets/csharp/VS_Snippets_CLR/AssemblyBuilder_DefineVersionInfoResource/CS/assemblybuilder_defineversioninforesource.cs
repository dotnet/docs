// Rewritten Aug 2005 REDMOND\glennha
// System.Reflection.Emit.AssemblyBuilder.DefineVersionInfoResource()

// This code example shows how to use the AssemblyBuilder.DefineVersionInfoResource method
// to add Windows version information to a dynamic assembly. The code example builds an 
// assembly with one module and no types. Several attributes are applied to the assembly, 
// DefineVersionInfoResource is used to create the Windows version information resource,
// and then the assembly is saved as EmittedAssembly.exe. The Windows Explorer can be used
// to examine the version information for the assembly.

// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class Example
{
   public static void Main()
   {
      AssemblyName assemName = new AssemblyName();
      assemName.Name = "EmittedAssembly";

      // Create a dynamic assembly in the current application domain,
      // specifying that the assembly is to be saved.
      //
      AssemblyBuilder myAssembly = 
         AppDomain.CurrentDomain.DefineDynamicAssembly(assemName, 
            AssemblyBuilderAccess.Save);


      // To apply an attribute to a dynamic assembly, first get the 
      // attribute type. The AssemblyFileVersionAttribute sets the 
      // File Version field on the Version tab of the Windows file
      // properties dialog.
      //
      Type attributeType = typeof(AssemblyFileVersionAttribute);

      // To identify the constructor, use an array of types representing
      // the constructor's parameter types. This ctor takes a string.
      //
      Type[] ctorParameters = { typeof(string) };

      // Get the constructor for the attribute.
      //
      ConstructorInfo ctor = attributeType.GetConstructor(ctorParameters);

      // Pass the constructor and an array of arguments (in this case,
      // an array containing a single string) to the 
      // CustomAttributeBuilder constructor.
      //
      object[] ctorArgs = { "2.0.3033.0" };
      CustomAttributeBuilder attribute = 
         new CustomAttributeBuilder(ctor, ctorArgs);

      // Finally, apply the attribute to the assembly.
      //
      myAssembly.SetCustomAttribute(attribute);


      // The pattern described above is used to create and apply
      // several more attributes. As it happens, all these attributes
      // have a constructor that takes a string, so the same ctorArgs
      // variable works for all of them.
      

      // The AssemblyTitleAttribute sets the Description field on
      // the General tab and the Version tab of the Windows file 
      // properties dialog.
      //
      attributeType = typeof(AssemblyTitleAttribute);
      ctor = attributeType.GetConstructor(ctorParameters);
      ctorArgs = new object[] { "The Application Title" };
      attribute = new CustomAttributeBuilder(ctor, ctorArgs);
      myAssembly.SetCustomAttribute(attribute);

      // The AssemblyCopyrightAttribute sets the Copyright field on
      // the Version tab.
      //
      attributeType = typeof(AssemblyCopyrightAttribute);
      ctor = attributeType.GetConstructor(ctorParameters);
      ctorArgs = new object[] { "© My Example Company 1991-2005" };
      attribute = new CustomAttributeBuilder(ctor, ctorArgs);
      myAssembly.SetCustomAttribute(attribute);

      // The AssemblyDescriptionAttribute sets the Comment item.
      //
      attributeType = typeof(AssemblyDescriptionAttribute);
      ctor = attributeType.GetConstructor(ctorParameters);
      attribute = new CustomAttributeBuilder(ctor, 
         new object[] { "This is a comment." });
      myAssembly.SetCustomAttribute(attribute);

      // The AssemblyCompanyAttribute sets the Company item.
      //
      attributeType = typeof(AssemblyCompanyAttribute);
      ctor = attributeType.GetConstructor(ctorParameters);
      attribute = new CustomAttributeBuilder(ctor, 
         new object[] { "My Example Company" });
      myAssembly.SetCustomAttribute(attribute);

      // The AssemblyProductAttribute sets the Product Name item.
      //
      attributeType = typeof(AssemblyProductAttribute);
      ctor = attributeType.GetConstructor(ctorParameters);
      attribute = new CustomAttributeBuilder(ctor, 
         new object[] { "My Product Name" });
      myAssembly.SetCustomAttribute(attribute);


      // Define the assembly's only module. For a single-file assembly,
      // the module name is the assembly name.
      //
      ModuleBuilder myModule = 
         myAssembly.DefineDynamicModule(assemName.Name, 
            assemName.Name + ".exe");

      // No types or methods are created for this example.


      // Define the unmanaged version information resource, which
      // contains the attribute informaion applied earlier, and save
      // the assembly. Use the Windows Explorer to examine the properties
      // of the .exe file.
      //
      myAssembly.DefineVersionInfoResource();
      myAssembly.Save(assemName.Name + ".exe");

   }
}
// </Snippet1>


