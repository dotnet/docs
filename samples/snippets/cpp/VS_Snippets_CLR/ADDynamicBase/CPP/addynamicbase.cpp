//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

public ref class Example : MarshalByRefObject
{
public:
   void Test()
   {
      Assembly^ dynAssem = Assembly::Load(
         "DynamicHelloWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

      Type^ myType = dynAssem->GetType("HelloWorld");
      myType->InvokeMember("HelloFromAD", BindingFlags::Public | 
         BindingFlags::Static | BindingFlags::InvokeMethod, 
         Type::DefaultBinder, nullptr, nullptr);
   }
};


static void GenerateDynamicAssembly(String^ location)
{
   // Define the dynamic assembly and the module. There is only one
   // module in this assembly. Note that the call to DefineDynamicAssembly 
   // specifies the location where the assembly will be saved. The 
   // assembly version is 1.0.0.0.
   //
   AssemblyName^ asmName = gcnew AssemblyName("DynamicHelloWorld");
   asmName->Version = gcnew Version("1.0.0.0");

   AssemblyBuilder^ ab = 
      AppDomain::CurrentDomain->DefineDynamicAssembly( 
         asmName, AssemblyBuilderAccess::Save, location);

   String^ moduleName = asmName->Name + ".exe";
   ModuleBuilder^ mb = ab->DefineDynamicModule(asmName->Name, moduleName);
   
   // Define the "HelloWorld" type, with one static method.
   TypeBuilder^ tb = mb->DefineType("HelloWorld", TypeAttributes::Public);
   MethodBuilder^ hello = tb->DefineMethod("HelloFromAD", 
      MethodAttributes::Public | MethodAttributes::Static, nullptr, nullptr);

   // The method displays a message that contains the name of the application
   // domain where the method is executed.
   ILGenerator^ il = hello->GetILGenerator();
   il->Emit(OpCodes::Ldstr, "Hello from '{0}'!");
   il->Emit(OpCodes::Call, AppDomain::typeid->GetProperty("CurrentDomain")->GetGetMethod());
   il->Emit(OpCodes::Call, AppDomain::typeid->GetProperty("FriendlyName")->GetGetMethod());
   il->Emit(OpCodes::Call, Console::typeid->GetMethod("WriteLine", 
                            gcnew array<Type^> { String::typeid, String::typeid }));
   il->Emit(OpCodes::Ret);

   // Complete the HelloWorld type and save the assembly. The assembly
   // is placed in the location specified by DefineDynamicAssembly.
   Type^ myType = tb->CreateType();
   ab->Save(moduleName);
};

void main()
{
   // Prepare to create a new application domain.
   AppDomainSetup^ setup = gcnew AppDomainSetup();

   // Set the application name before setting the dynamic base.
   setup->ApplicationName = "Example";
   
   // Set the location of the base directory where assembly resolution 
   // probes for dynamic assemblies. Note that the hash code of the 
   // application name is concatenated to the base directory name you 
   // supply. 
   setup->DynamicBase = "C:\\DynamicAssemblyDir";
   Console::WriteLine("DynamicBase is set to '{0}'.", setup->DynamicBase);

   AppDomain^ ad = AppDomain::CreateDomain("MyDomain", nullptr, setup);
   
   // The dynamic directory name is the dynamic base concatenated with
   // the application name: <DynamicBase>\<hash code>\<ApplicationName>
   String^ dynamicDir = ad->DynamicDirectory;
   Console::WriteLine("Dynamic directory is '{0}'.", dynamicDir);

   // The AssemblyBuilder won't create this directory automatically.
   if (!System::IO::Directory::Exists(dynamicDir))
   {
      Console::WriteLine("Creating the dynamic directory.");
      System::IO::Directory::CreateDirectory(dynamicDir);
   }

   // Generate a dynamic assembly and store it in the dynamic 
   // directory.
   GenerateDynamicAssembly(dynamicDir);

   // Create an instance of the Example class in the application domain,
   // and call its Test method to load the dynamic assembly and use it.
   Example^ ex = (Example^) ad->CreateInstanceAndUnwrap( 
         Example::typeid->Assembly->FullName, "Example");
   ex->Test();
}

/* This example produces output similar to the following:

DynamicBase is set to 'C:\DynamicAssemblyDir\5e4a7545'.
Dynamic directory is 'C:\DynamicAssemblyDir\5e4a7545\Example'.
Creating the dynamic directory.
Hello from 'MyDomain'!
 */
//</Snippet1>
