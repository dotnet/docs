// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;


// We will apply this custom attribute to our dynamic type.
public class ClassCreator: Attribute

{
   private string creator;
   public string Creator 
   {
	get
	{
	   return creator;
	}
   }	

   public ClassCreator(string name)
   {
      this.creator = name;
   }

}

// We will apply this dynamic attribute to our dynamic method.
public class DateLastUpdated: Attribute

{
   private string dateUpdated;
   public string DateUpdated
   {
   	get
	{
	   return dateUpdated;
	}
   }

   public DateLastUpdated(string theDate)
   {
	this.dateUpdated = theDate;
   } 

}

class MethodBuilderCustomAttributesDemo

{

   public static Type BuildTypeWithCustomAttributesOnMethod()
   {
	
	AppDomain currentDomain = Thread.GetDomain();
	
	AssemblyName myAsmName = new AssemblyName();
	myAsmName.Name = "MyAssembly";

	AssemblyBuilder myAsmBuilder = currentDomain.DefineDynamicAssembly(
				       myAsmName, AssemblyBuilderAccess.Run);

	ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule("MyModule");

	// First, we'll build a type with a custom attribute attached.

	TypeBuilder myTypeBuilder = myModBuilder.DefineType("MyType",
						TypeAttributes.Public);
	
	Type[] ctorParams = new Type[] { typeof(string) };
	ConstructorInfo classCtorInfo = typeof(ClassCreator).GetConstructor(ctorParams);

	CustomAttributeBuilder myCABuilder = new CustomAttributeBuilder(
						classCtorInfo,
						new object[] { "Joe Programmer" });

	myTypeBuilder.SetCustomAttribute(myCABuilder);

	// Now, let's build a method and add a custom attribute to it.

	MethodBuilder myMethodBuilder = myTypeBuilder.DefineMethod("HelloWorld",
					MethodAttributes.Public,
					null,
					new Type[] { });

	ctorParams = new Type[] { typeof(string) };
	classCtorInfo = typeof(DateLastUpdated).GetConstructor(ctorParams);

	CustomAttributeBuilder myCABuilder2 = new CustomAttributeBuilder(
						classCtorInfo,
						new object[] { DateTime.Now.ToString() });

	myMethodBuilder.SetCustomAttribute(myCABuilder2);

	ILGenerator myIL = myMethodBuilder.GetILGenerator();

	myIL.EmitWriteLine("Hello, world!");
	myIL.Emit(OpCodes.Ret);

	return myTypeBuilder.CreateType();
	
   }

   public static void Main() 
   {

	Type myType = BuildTypeWithCustomAttributesOnMethod();

	object myInstance = Activator.CreateInstance(myType);

	object[] customAttrs = myType.GetCustomAttributes(true);

	Console.WriteLine("Custom Attributes for Type 'MyType':");

	object attrVal = null;

	foreach (object customAttr in customAttrs) 
   	{
	   attrVal = typeof(ClassCreator).InvokeMember("Creator", 
					  BindingFlags.GetProperty,
					  null, customAttr, new object[] { });
	   Console.WriteLine("-- Attribute: [{0} = \"{1}\"]", customAttr, attrVal);
        }

	Console.WriteLine("Custom Attributes for Method 'HelloWorld()' in 'MyType':");

	customAttrs = myType.GetMember("HelloWorld")[0].GetCustomAttributes(true);	

	foreach (object customAttr in customAttrs) 
   	{
	   attrVal = typeof(DateLastUpdated).InvokeMember("DateUpdated", 
					  BindingFlags.GetProperty,
					  null, customAttr, new object[] { });
	   Console.WriteLine("-- Attribute: [{0} = \"{1}\"]", customAttr, attrVal);
        }

	Console.WriteLine("---");

	Console.WriteLine(myType.InvokeMember("HelloWorld",
			  BindingFlags.InvokeMethod,
			  null, myInstance, new object[] { }));
						   
	
   }

}

// </Snippet1>
