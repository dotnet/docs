// REDMOND\glennha
//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

public class Example
{
    public static void Main()
    {
        AppDomain myDomain = AppDomain.CurrentDomain;
        AssemblyName myAsmName = new AssemblyName("EmitMarshalAs");

        AssemblyBuilder myAssembly = 
            myDomain.DefineDynamicAssembly(myAsmName, 
                AssemblyBuilderAccess.RunAndSave);

        ModuleBuilder myModule = 
            myAssembly.DefineDynamicModule(myAsmName.Name, 
               myAsmName.Name + ".dll");

        TypeBuilder myType = 
            myModule.DefineType("Sample", TypeAttributes.Public);

        MethodBuilder myMethod = 
            myType.DefineMethod("Test", MethodAttributes.Public,
                null, new Type[] { typeof(string) });


        // Get a parameter builder for the parameter that needs the 
        // attribute, using the HasFieldMarshal attribute. In this
        // example, the parameter is at position 0 and has the name
        // "arg".
        ParameterBuilder pb = 
            myMethod.DefineParameter(0, 
               ParameterAttributes.HasFieldMarshal, "arg");

        // Get the MarshalAsAttribute constructor that takes an
        // argument of type UnmanagedType.
        //
        ConstructorInfo ci = 
            typeof(MarshalAsAttribute).GetConstructor(
                new Type[] { typeof(UnmanagedType) });

        // Create a CustomAttributeBuilder representing the attribute,
        // specifying the necessary unmanaged type. In this case, 
        // UnmanagedType.BStr is specified.
        //
        CustomAttributeBuilder cabuilder = 
            new CustomAttributeBuilder(
                ci, new object[] { UnmanagedType.BStr });

        // Apply the attribute to the parameter.
        //
        pb.SetCustomAttribute(cabuilder);


        // Emit a dummy method body.
        ILGenerator il = myMethod.GetILGenerator();
        il.Emit(OpCodes.Ret);

        Type finished = myType.CreateType();
        myAssembly.Save(myAsmName.Name + ".dll");
    }
}
//</Snippet1>