
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

void AddMethodDynamically( TypeBuilder^ myTypeBld, 
                           String^ mthdName, 
                           array<Type^>^ mthdParams, 
                           Type^ returnType, 
                           String^ mthdAction )
{
   MethodBuilder^ myMthdBld = myTypeBld->DefineMethod( mthdName, static_cast<MethodAttributes>(MethodAttributes::Public | MethodAttributes::Static), returnType, mthdParams );
   ILGenerator^ ILOut = myMthdBld->GetILGenerator();
   int numParams = mthdParams->Length;
   for ( Byte x = 0; x < numParams; x++ )
   {
      ILOut->Emit( OpCodes::Ldarg_S, x );

   }
   if ( numParams > 1 )
   {
      for ( int y = 0; y < (numParams - 1); y++ )
      {
         if ( mthdAction->Equals( "A" ) )
                  ILOut->Emit( OpCodes::Add );
         else
         if ( mthdAction->Equals( "M" ) )
                  ILOut->Emit( OpCodes::Mul );
         else
                  ILOut->Emit( OpCodes::Add );

      }
   }

   ILOut->Emit( OpCodes::Ret );
};

void main()
{
   AppDomain^ myDomain = AppDomain::CurrentDomain;
   AssemblyName^ asmName = gcnew AssemblyName;
   asmName->Name = "MyDynamicAsm";
   AssemblyBuilder^ myAsmBuilder = myDomain->DefineDynamicAssembly( asmName, 
                                                                    AssemblyBuilderAccess::RunAndSave );
   ModuleBuilder^ myModule = myAsmBuilder->DefineDynamicModule( "MyDynamicAsm", 
                                                                "MyDynamicAsm.dll" );
   TypeBuilder^ myTypeBld = myModule->DefineType( "MyDynamicType", 
                                                  TypeAttributes::Public );
   
   // Get info from the user to build the method dynamically.
   Console::WriteLine( "Let's build a simple method dynamically!" );
   Console::WriteLine( "Please enter a few numbers, separated by spaces." );
   String^ inputNums = Console::ReadLine();
   Console::Write( "Do you want to [A]dd (default) or [M]ultiply these numbers? " );
   String^ myMthdAction = Console::ReadLine()->ToUpper();
   Console::Write( "Lastly, what do you want to name your new dynamic method? " );
   String^ myMthdName = Console::ReadLine();
   
   // Process inputNums into an array and create a corresponding Type array
   int index = 0;
   array<String^>^inputNumsList = inputNums->Split();
   array<Type^>^myMthdParams = gcnew array<Type^>(inputNumsList->Length);
   array<Object^>^inputValsList = gcnew array<Object^>(inputNumsList->Length);
   for each (String^ inputNum in inputNumsList)
   {
      inputValsList[ index ] = Convert::ToInt32( inputNum );
      myMthdParams[ index ] = int::typeid;
      index++;
   }

   
   // Now, call the method building method with the parameters, passing the
   // TypeBuilder by reference.
   AddMethodDynamically( myTypeBld, 
                         myMthdName, 
                         myMthdParams, 
                         int::typeid, 
                         myMthdAction );
   Type^ myType = myTypeBld->CreateType();

   Console::WriteLine( "---" );
   Console::WriteLine( "The result of {0} the inputted values is: {1}", 
                       ((myMthdAction->Equals( "M" )) ? "multiplying" : "adding"), 
                       myType->InvokeMember( myMthdName, 
                                             BindingFlags::InvokeMethod | BindingFlags::Public | BindingFlags::Static, 
                       nullptr, 
                       nullptr, 
                       inputValsList ) );
   Console::WriteLine( "---" );
   
   // Let's take a look at the method we created.
   // If you are interested in seeing the MSIL generated dynamically for the method
   // your program generated, change to the directory where you ran the compiled
   // code sample and type "ildasm MyDynamicAsm.dll" at the prompt. When the list
   // of manifest contents appears, click on "MyDynamicType" and then on the name of
   // of the method you provided during execution.

   myAsmBuilder->Save( "MyDynamicAsm.dll" );

   MethodInfo^ myMthdInfo = myType->GetMethod( myMthdName );
   Console::WriteLine( "Your Dynamic Method: {0};", myMthdInfo );
}

// </Snippet1>
