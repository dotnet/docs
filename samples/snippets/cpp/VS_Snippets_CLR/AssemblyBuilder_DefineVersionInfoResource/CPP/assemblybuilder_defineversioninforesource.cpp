// Rewritten Aug 2005 REDMOND\glennha
// System::Reflection::Emit::AssemblyBuilder.DefineVersionInfoResource()

// This code example shows how to use the AssemblyBuilder::DefineVersionInfoResource method
// to add Windows version information to a dynamic assembly. The code example builds an 
// assembly with one module and no types. Several attributes are applied to the assembly, 
// DefineVersionInfoResource is used to create the Windows version information resource,
// and then the assembly is saved as EmittedAssembly.exe. The Windows Explorer can be used
// to examine the version information for the assembly.

// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;


/*
// Create the callee transient dynamic assembly.
static Type^ CreateAssembly( AppDomain^ myDomain )
{
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "MyEmittedAssembly";
   AssemblyBuilder^ myAssembly = myDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Save );
   
   // Set Company Attribute to the assembly.
   Type^ companyAttribute = AssemblyCompanyAttribute::typeid;
   array<Type^>^types1 = {String::typeid};
   ConstructorInfo^ myConstructorInfo1 = companyAttribute->GetConstructor( types1 );
   array<Object^>^obj1 = {"Microsoft Corporation"};
   CustomAttributeBuilder^ attributeBuilder1 = gcnew CustomAttributeBuilder( myConstructorInfo1,obj1 );
   myAssembly->SetCustomAttribute( attributeBuilder1 );
   
   // Set Copyright Attribute to the assembly.
   Type^ copyrightAttribute = AssemblyCopyrightAttribute::typeid;
   array<Type^>^types2 = {String::typeid};
   ConstructorInfo^ myConstructorInfo2 = copyrightAttribute->GetConstructor( types2 );
   array<Object^>^obj2 = {"@Copyright Microsoft Corp. 1990-2001"};
   CustomAttributeBuilder^ attributeBuilder2 = gcnew CustomAttributeBuilder( myConstructorInfo2,obj2 );
   myAssembly->SetCustomAttribute( attributeBuilder2 );
   ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( "EmittedModule", "EmittedModule.mod" );
   
   // Define a public class named S"HelloWorld" in the assembly.
   TypeBuilder^ helloWorldClass = myModule->DefineType( "HelloWorld", TypeAttributes::Public );
   
   // Define the Display method.
   MethodBuilder^ myMethod = helloWorldClass->DefineMethod( "Display", MethodAttributes::Public, String::typeid, nullptr );
   
   // Generate IL for GetGreeting.
   ILGenerator^ methodIL = myMethod->GetILGenerator();
   methodIL->Emit( OpCodes::Ldstr, "Display method get called." );
   methodIL->Emit( OpCodes::Ret );
   
   // Returns the type HelloWorld.
   return (helloWorldClass->CreateType());
}
*/

int main()
{
   AssemblyName^ assemName = gcnew AssemblyName();
   assemName->Name = "EmittedAssembly";

   // Create a dynamic assembly in the current application domain,
   // specifying that the assembly is to be saved.
   //
   AssemblyBuilder^ myAssembly = 
      AppDomain::CurrentDomain->DefineDynamicAssembly(assemName, 
         AssemblyBuilderAccess::Save);


   // To apply an attribute to a dynamic assembly, first get the 
   // attribute type. The AssemblyFileVersionAttribute sets the 
   // File Version field on the Version tab of the Windows file
   // properties dialog.
   //
   Type^ attributeType = AssemblyFileVersionAttribute::typeid;

   // To identify the constructor, use an array of types representing
   // the constructor's parameter types. This ctor takes a string.
   //
   array<Type^>^ ctorParameters = { String::typeid };

   // Get the constructor for the attribute.
   //
   ConstructorInfo^ ctor = attributeType->GetConstructor(ctorParameters);

   // Pass the constructor and an array of arguments (in this case,
   // an array containing a single string) to the 
   // CustomAttributeBuilder constructor.
   //
   array<Object^>^ ctorArgs = { "2.0.3033.0" };
   CustomAttributeBuilder^ attribute = 
      gcnew CustomAttributeBuilder(ctor, ctorArgs);

   // Finally, apply the attribute to the assembly.
   //
   myAssembly->SetCustomAttribute(attribute);


   // The pattern described above is used to create and apply
   // several more attributes. As it happens, all these attributes
   // have a constructor that takes a string, so the same ctorArgs
   // variable works for all of them.
    

   // The AssemblyTitleAttribute sets the Description field on
   // the General tab and the Version tab of the Windows file 
   // properties dialog.
   //
   attributeType = AssemblyTitleAttribute::typeid;
   ctor = attributeType->GetConstructor(ctorParameters);
   ctorArgs = gcnew array<Object^> { "The Application Title" };
   attribute = gcnew CustomAttributeBuilder(ctor, ctorArgs);
   myAssembly->SetCustomAttribute(attribute);

   // The AssemblyCopyrightAttribute sets the Copyright field on
   // the Version tab.
   //
   attributeType = AssemblyCopyrightAttribute::typeid;
   ctor = attributeType->GetConstructor(ctorParameters);
   ctorArgs = gcnew array<Object^> { "© My Example Company 1991-2005" };
   attribute = gcnew CustomAttributeBuilder(ctor, ctorArgs);
   myAssembly->SetCustomAttribute(attribute);

   // The AssemblyDescriptionAttribute sets the Comment item.
   //
   attributeType = AssemblyDescriptionAttribute::typeid;
   ctor = attributeType->GetConstructor(ctorParameters);
   attribute = gcnew CustomAttributeBuilder(ctor, 
      gcnew array<Object^> { "This is a comment." });
   myAssembly->SetCustomAttribute(attribute);

   // The AssemblyCompanyAttribute sets the Company item.
   //
   attributeType = AssemblyCompanyAttribute::typeid;
   ctor = attributeType->GetConstructor(ctorParameters);
   attribute = gcnew CustomAttributeBuilder(ctor, 
      gcnew array<Object^> { "My Example Company" });
   myAssembly->SetCustomAttribute(attribute);

   // The AssemblyProductAttribute sets the Product Name item.
   //
   attributeType = AssemblyProductAttribute::typeid;
   ctor = attributeType->GetConstructor(ctorParameters);
   attribute = gcnew CustomAttributeBuilder(ctor, 
      gcnew array<Object^> { "My Product Name" });
   myAssembly->SetCustomAttribute(attribute);


   // Define the assembly's only module. For a single-file assembly,
   // the module name is the assembly name.
   //
   ModuleBuilder^ myModule = 
      myAssembly->DefineDynamicModule(assemName->Name, 
         assemName->Name + ".exe");

   // No types or methods are created for this example.


   // Define the unmanaged version information resource, which
   // contains the attribute informaion applied earlier, and save
   // the assembly. Use the Windows Explorer to examine the properties
   // of the .exe file.
   //
   myAssembly->DefineVersionInfoResource();
   myAssembly->Save(assemName->Name + ".exe");
}
// </Snippet1>
