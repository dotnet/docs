// Create the callee transient dynamic assembly.
TypeBuilder^ CreateCallee( AppDomain^ myDomain )
{
   AssemblyName^ myAssemblyName = gcnew AssemblyName;
   myAssemblyName->Name = "EmittedAssembly";
   
   // Create the callee dynamic assembly.
   AssemblyBuilder^ myAssembly = myDomain->DefineDynamicAssembly( myAssemblyName, AssemblyBuilderAccess::Run );
   
   // Create a dynamic module named "CalleeModule" in the callee assembly.
   ModuleBuilder^ myModule = myAssembly->DefineDynamicModule( "EmittedModule" );
   
   // Define a public class named "HelloWorld" in the assembly.
   TypeBuilder^ helloWorldClass = myModule->DefineType( "HelloWorld", TypeAttributes::Public );
   
   // Define a private String field named "Greeting" in the type.
   FieldBuilder^ greetingField = helloWorldClass->DefineField( "Greeting", String::typeid, FieldAttributes::Private );
   
   // Create the constructor.
   ConstructorBuilder^ constructor = helloWorldClass->DefineTypeInitializer();
   
   // Generate IL for the method. The constructor calls its base class
   // constructor. The constructor stores its argument in the private field.
   ILGenerator^ constructorIL = constructor->GetILGenerator();
   constructorIL->Emit( OpCodes::Ldarg_0 );
   ConstructorInfo^ superConstructor = Object::typeid->GetConstructor( gcnew array<Type^>(0) );
   constructorIL->Emit( OpCodes::Call, superConstructor );
   constructorIL->Emit( OpCodes::Ldarg_0 );
   constructorIL->Emit( OpCodes::Ldarg_1 );
   constructorIL->Emit( OpCodes::Stfld, greetingField );
   constructorIL->Emit( OpCodes::Ret );
   helloWorldClass->CreateType();
   return (helloWorldClass);
}

int main()
{
   // Create the "HelloWorld" class
   TypeBuilder^ helloWorldClass = CreateCallee( Thread::GetDomain() );
   Console::WriteLine( "Full Name : {0}", helloWorldClass->FullName );
   Console::WriteLine( "Constructors :" );
   array<ConstructorInfo^>^info = helloWorldClass->GetConstructors( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );
   for ( int index = 0; index < info->Length; index++ )
      Console::WriteLine( info[ index ] );
}