// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class PropertyBuilderDemo

{

   public static Type BuildDynamicTypeWithProperties() 
   {
        AppDomain myDomain = Thread.GetDomain();
        AssemblyName myAsmName = new AssemblyName();
        myAsmName.Name = "MyDynamicAssembly";

        // To generate a persistable assembly, specify AssemblyBuilderAccess.RunAndSave.
        AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName,
                                                        AssemblyBuilderAccess.RunAndSave);
        // Generate a persistable single-module assembly.
        ModuleBuilder myModBuilder = 
            myAsmBuilder.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");

        TypeBuilder myTypeBuilder = myModBuilder.DefineType("CustomerData", 
                                                        TypeAttributes.Public);

        FieldBuilder customerNameBldr = myTypeBuilder.DefineField("customerName",
                                                        typeof(string),
                                                        FieldAttributes.Private);

        // The last argument of DefineProperty is null, because the
        // property has no parameters. (If you don't specify null, you must
        // specify an array of Type objects. For a parameterless property,
        // use an array with no elements: new Type[] {})
        PropertyBuilder custNamePropBldr = myTypeBuilder.DefineProperty("CustomerName",
                                                         PropertyAttributes.HasDefault,
                                                         typeof(string),
                                                         null);

        // The property set and property get methods require a special
        // set of attributes.
        MethodAttributes getSetAttr = 
            MethodAttributes.Public | MethodAttributes.SpecialName |
                MethodAttributes.HideBySig;

        // Define the "get" accessor method for CustomerName.
        MethodBuilder custNameGetPropMthdBldr = 
            myTypeBuilder.DefineMethod("get_CustomerName",
                                       getSetAttr,        
                                       typeof(string),
                                       Type.EmptyTypes);

        ILGenerator custNameGetIL = custNameGetPropMthdBldr.GetILGenerator();

        custNameGetIL.Emit(OpCodes.Ldarg_0);
        custNameGetIL.Emit(OpCodes.Ldfld, customerNameBldr);
        custNameGetIL.Emit(OpCodes.Ret);

        // Define the "set" accessor method for CustomerName.
        MethodBuilder custNameSetPropMthdBldr = 
            myTypeBuilder.DefineMethod("set_CustomerName",
                                       getSetAttr,     
                                       null,
                                       new Type[] { typeof(string) });

        ILGenerator custNameSetIL = custNameSetPropMthdBldr.GetILGenerator();

        custNameSetIL.Emit(OpCodes.Ldarg_0);
        custNameSetIL.Emit(OpCodes.Ldarg_1);
        custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr);
        custNameSetIL.Emit(OpCodes.Ret);

        // Last, we must map the two methods created above to our PropertyBuilder to 
        // their corresponding behaviors, "get" and "set" respectively. 
        custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr);
        custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr);


        Type retval = myTypeBuilder.CreateType();

        // Save the assembly so it can be examined with Ildasm.exe,
        // or referenced by a test program.
        myAsmBuilder.Save(myAsmName.Name + ".dll");
        return retval;
   }

   public static void Main() 
   {
        Type custDataType = BuildDynamicTypeWithProperties();
        
        PropertyInfo[] custDataPropInfo = custDataType.GetProperties();
        foreach (PropertyInfo pInfo in custDataPropInfo) {
           Console.WriteLine("Property '{0}' created!", pInfo.ToString());
        }

        Console.WriteLine("---");
        // Note that when invoking a property, you need to use the proper BindingFlags -
        // BindingFlags.SetProperty when you invoke the "set" behavior, and 
        // BindingFlags.GetProperty when you invoke the "get" behavior. Also note that
        // we invoke them based on the name we gave the property, as expected, and not
        // the name of the methods we bound to the specific property behaviors.

        object custData = Activator.CreateInstance(custDataType);
        custDataType.InvokeMember("CustomerName", BindingFlags.SetProperty,
                                      null, custData, new object[]{ "Joe User" });

        Console.WriteLine("The customerName field of instance custData has been set to '{0}'.",
                           custDataType.InvokeMember("CustomerName", BindingFlags.GetProperty,
                                                      null, custData, new object[]{ }));
   }

}

// --- O U T P U T ---
// The output should be as follows:
// -------------------
// Property 'System.String CustomerName [System.String]' created!
// ---
// The customerName field of instance custData has been set to 'Joe User'.
// -------------------

// </Snippet1>



