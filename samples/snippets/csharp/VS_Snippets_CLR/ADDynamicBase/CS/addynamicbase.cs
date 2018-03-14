//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

public class Example : MarshalByRefObject
{
   static void Main()
   {
      // Prepare to create a new application domain.
      AppDomainSetup setup = new AppDomainSetup();
   
      // Set the application name before setting the dynamic base.
      setup.ApplicationName = "Example";
   
      // Set the location of the base directory where assembly resolution 
      // probes for dynamic assemblies. Note that the hash code of the 
      // application name is concatenated to the base directory name you 
      // supply. 
      setup.DynamicBase = "C:\\DynamicAssemblyDir";
      Console.WriteLine("DynamicBase is set to '{0}'.", setup.DynamicBase);

      AppDomain ad = AppDomain.CreateDomain("MyDomain", null, setup);
   
      // The dynamic directory name is the dynamic base concatenated with
      // the application name: <DynamicBase>\<hash code>\<ApplicationName>
      string dynamicDir = ad.DynamicDirectory;
      Console.WriteLine("Dynamic directory is '{0}'.", dynamicDir);

      // The AssemblyBuilder won't create this directory automatically.
      if (!System.IO.Directory.Exists(dynamicDir))
      {
         Console.WriteLine("Creating the dynamic directory.");
         System.IO.Directory.CreateDirectory(dynamicDir);
      }

      // Generate a dynamic assembly and store it in the dynamic 
      // directory.
      GenerateDynamicAssembly(dynamicDir);

      // Create an instance of the Example class in the application domain,
      // and call its Test method to load the dynamic assembly and use it.
      Example ex = (Example) ad.CreateInstanceAndUnwrap(
         typeof(Example).Assembly.FullName, "Example");
      ex.Test();
   }

   public void Test()
   {
      Assembly dynAssem = Assembly.Load(
         "DynamicHelloWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

      Type myType = dynAssem.GetType("HelloWorld");
      myType.InvokeMember("HelloFromAD", BindingFlags.Public | 
         BindingFlags.Static | BindingFlags.InvokeMethod, 
         Type.DefaultBinder, null, null);
   }


   private static void GenerateDynamicAssembly(string location)
   {
      // Define the dynamic assembly and the module. There is only one
      // module in this assembly. Note that the call to DefineDynamicAssembly 
      // specifies the location where the assembly will be saved. The 
      // assembly version is 1.0.0.0.
      //
      AssemblyName asmName = new AssemblyName("DynamicHelloWorld");
      asmName.Version = new Version("1.0.0.0");

      AssemblyBuilder ab = 
         AppDomain.CurrentDomain.DefineDynamicAssembly( 
            asmName, AssemblyBuilderAccess.Save, location);

      String moduleName = asmName.Name + ".exe";
      ModuleBuilder mb = ab.DefineDynamicModule(asmName.Name, moduleName);
      
      // Define the "HelloWorld" type, with one static method.
      TypeBuilder tb = mb.DefineType("HelloWorld", TypeAttributes.Public);
      MethodBuilder hello = tb.DefineMethod("HelloFromAD", 
         MethodAttributes.Public | MethodAttributes.Static, null, null);

      // The method displays a message that contains the name of the application
      // domain where the method is executed.
      ILGenerator il = hello.GetILGenerator();
      il.Emit(OpCodes.Ldstr, "Hello from '{0}'!");
      il.Emit(OpCodes.Call, typeof(AppDomain).GetProperty("CurrentDomain").GetGetMethod());
      il.Emit(OpCodes.Call, typeof(AppDomain).GetProperty("FriendlyName").GetGetMethod());
      il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", 
                             new Type[] { typeof(String), typeof(String) }));
      il.Emit(OpCodes.Ret);

      // Complete the HelloWorld type and save the assembly. The assembly
      // is placed in the location specified by DefineDynamicAssembly.
      Type myType = tb.CreateType();
      ab.Save(moduleName);
   }
}

/* This example produces output similar to the following:

DynamicBase is set to 'C:\DynamicAssemblyDir\5e4a7545'.
Dynamic directory is 'C:\DynamicAssemblyDir\5e4a7545\Example'.
Creating the dynamic directory.
Hello from 'MyDomain'!
 */
//</Snippet1>
