// System.Reflection.Emit.FieldBuilder.SetOffset
// System.Reflection.Emit.FieldBuilder.SetMarshal

/*
   The following program demonstrates 'SetOffset' and 'SetMarshal' 
   methods of 'FieldBuilder' class.A new Class is defined and a 
   'PInvoke' method 'OpenFile' method of 'Kernel32.dll' is defined 
   in the class.Instance of the class is created and the method is invoked.
   To execute this program, make sure a file named 'MyFile.txt' should be there 
   in the current directory.
*/

// <Snippet1>
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Runtime.CompilerServices;

public class FieldBuilder_Sample
{
   public static Type CreateType(AppDomain currentDomain)
   {
      // Create an assembly.
      AssemblyName myAssemblyName = new AssemblyName();
      myAssemblyName.Name = "DynamicAssembly";
      AssemblyBuilder myAssembly =
         currentDomain.DefineDynamicAssembly(myAssemblyName,AssemblyBuilderAccess.RunAndSave);
      // Create a dynamic module in Dynamic Assembly.
      ModuleBuilder myModuleBuilder=myAssembly.DefineDynamicModule("MyModule","MyModule.mod");
      // Define a public class named "MyClass" in the assembly.
      TypeBuilder myTypeBuilder= myModuleBuilder.DefineType("MyClass",TypeAttributes.Public);
      TypeBuilder myTypeBuilder2 = myModuleBuilder.DefineType("MyClass2",
         TypeAttributes.Public|TypeAttributes.BeforeFieldInit|TypeAttributes.SequentialLayout|TypeAttributes.AnsiClass|TypeAttributes.Sealed);
      FieldBuilder myFieldBuilder1= myTypeBuilder2.DefineField("myBytes1",
                                    typeof(byte),FieldAttributes.Public);
      FieldBuilder myFieldBuilder2= myTypeBuilder2.DefineField("myBytes2",
                                    typeof(byte),FieldAttributes.Public);
      FieldBuilder myFieldBuilder3= myTypeBuilder2.DefineField("myErrorCode",
                                    typeof(short),FieldAttributes.Public);
      FieldBuilder myFieldBuilder4= myTypeBuilder2.DefineField("myReserved1",
                                    typeof(short),FieldAttributes.Public);
      FieldBuilder myFieldBuilder5= myTypeBuilder2.DefineField("myReserved2",
                                    typeof(short),FieldAttributes.Public);
      FieldBuilder myFieldBuilder6= myTypeBuilder2.DefineField("myPathName",
                                    typeof(char[]),FieldAttributes.Public);
      myFieldBuilder6.SetMarshal(UnmanagedMarshal.DefineByValArray(128)); 
      myFieldBuilder6.SetOffset(4);
      Type myType1 = myTypeBuilder2.CreateType();  
      // Create the PInvoke method for 'OpenFile' method of 'Kernel32.dll'.
      Type[] myParameters={ typeof(string), myType1 ,typeof(uint)}; 
      MethodBuilder myMethodBuilder= myTypeBuilder.DefinePInvokeMethod("OpenFile",
                                     "kernel32.dll",MethodAttributes.Public|MethodAttributes.Static|MethodAttributes.HideBySig,
                                       CallingConventions.Standard,typeof(IntPtr),
                                       myParameters,CallingConvention.Winapi,CharSet.None);
      Type myAttributeType = typeof(MethodImplAttribute);
      ConstructorInfo myConstructorInfo = 
         myAttributeType.GetConstructor(new Type[1]{typeof(MethodImplOptions)});
      CustomAttributeBuilder myAttributeBuilder = new CustomAttributeBuilder(myConstructorInfo,
                                                   new object[1]{MethodImplOptions.PreserveSig});
      myMethodBuilder.SetCustomAttribute(myAttributeBuilder);
      ParameterBuilder myParameterBuilder2=myMethodBuilder.DefineParameter(2,
                                            ParameterAttributes.Out,"myClass2");
      Type myType=myTypeBuilder.CreateType();
      myAssembly.Save("EmittedAssembly.dll");
      return myType;
   }

   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   public static void Main()
   {
      try
      {
         Type myType = CreateType(Thread.GetDomain());
         Type myClass2 = myType.Module.GetType("MyClass2"); 
         object myParam2 = Activator.CreateInstance(myClass2);
         uint myUint=0x00000800;
         object[] myArgs= {"MyFile.Txt",myParam2,myUint};
         Object myObject  = myType.InvokeMember("OpenFile",BindingFlags.Public | 
            BindingFlags.InvokeMethod | BindingFlags.Static,null,null,myArgs);
         Console.WriteLine("MyClass.OpenFile method returned: \"{0}\"", myObject);
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception Caught "+e.Message);
      }
   }

}
// </Snippet1>
