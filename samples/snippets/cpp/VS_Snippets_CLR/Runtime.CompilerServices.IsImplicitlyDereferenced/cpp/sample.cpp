//<SNIPPET1>


#using <mscorlib.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::CompilerServices;
using namespace System::Threading;


ref class CodeEmitter
{
private:
    AssemblyBuilder^ asmBuilder;
    String^ asmName;
    ModuleBuilder^ modBuilder;


    void prepareAssembly(String^ name){
        
        // Check the input.
        if(!name){
        
            throw gcnew ArgumentNullException("AssemblyName");
        }

        asmName = name;

        // Create an AssemblyName object and set the name.
        AssemblyName^ asmName = gcnew AssemblyName();

        asmName->Name = name;

        // Use the AppDomain class to create an AssemblyBuilder instance.

        AppDomain^ currentDomain = Thread::GetDomain();

        asmBuilder = currentDomain->DefineDynamicAssembly(asmName,AssemblyBuilderAccess::RunAndSave);

        // Create a dynamic module.
        modBuilder = asmBuilder->DefineDynamicModule(name);
    }


public:

    // Constructor.
    CodeEmitter(String ^ AssemblyName){

        prepareAssembly(AssemblyName);
    }

    // Create a new type.
    TypeBuilder^ CreateType(String^ name){
       
        // Check the input.
        if(!name){
        
            throw gcnew ArgumentNullException("AssemblyName");
        }

        return modBuilder->DefineType( name );
    }

    // Write the assembly.
    void WriteAssembly(MethodBuilder^ entryPoint){
    
        // Check the input.
        if(!entryPoint){
        
            throw gcnew ArgumentNullException("entryPoint");
        }

        asmBuilder->SetEntryPoint( entryPoint );
        asmBuilder->Save( asmName );
    }

};

void main()
{

    // Create a CodeEmitter to handle assembly creation.
    CodeEmitter ^ e = gcnew CodeEmitter("program.exe");

    // Create a new type.
    TypeBuilder^ mainClass = e->CreateType("MainClass");
    
    // Create a new method.
    MethodBuilder^ mBuilder = mainClass->DefineMethod("mainMethod", MethodAttributes::Static);

    // Create an ILGenerator and emit IL for 
    // a simple "Hello World." program.
    ILGenerator^ ilGen = mBuilder->GetILGenerator();

    ilGen->Emit(OpCodes::Ldstr, "Hello World");

    array<Type^>^mType = {String::typeid};

    MethodInfo^ writeMI = Console::typeid->GetMethod( "WriteLine", mType );

    ilGen->EmitCall(OpCodes::Call, writeMI, nullptr );

    ilGen->Emit( OpCodes::Ret );

    /////////////////////////////////////////////////
    /////////////////////////////////////////////////
    // Apply a required custom modifier
    // to a field.
    /////////////////////////////////////////////////
    /////////////////////////////////////////////////

    array<Type^>^fType = {IsImplicitlyDereferenced::typeid};

    mainClass->DefineField("modifiedInteger", Type::GetType("System.IntPtr"), fType, nullptr, FieldAttributes::Private);

    // Create the type.
    mainClass->CreateType();

    // Write the assembly using a reference to 
    // the entry point.
    e->WriteAssembly(mBuilder);

    Console::WriteLine(L"Assembly created.");
}
//</SNIPPET1>
