
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;
public ref class paramatt
{
public:
   static void mymethod( String^ str1, [Out]interior_ptr<String^> str2, interior_ptr<String^> str3 )
   {
       *str2 = "string";
   }

};

int main()
{
   Console::WriteLine( "\nReflection.ParameterAttributes" );
   
   // Get the Type and the method.
   Type^ Mytype = Type::GetType( "paramatt" );
   MethodBase^ Mymethodbase = Mytype->GetMethod( "mymethod" );
   
   // Display the method.
   Console::Write( "\nMymethodbase = {0}", Mymethodbase );
   
   // Get the ParameterInfo array.
   array<ParameterInfo^>^Myarray = Mymethodbase->GetParameters();
   
   // Get and display the attributes for the second parameter.
   ParameterAttributes Myparamattributes = Myarray[ 1 ]->Attributes;
   Console::Write( "\nFor the second parameter:\nMyparamattributes = {0}, which is an {1}", (int)Myparamattributes, Myparamattributes );
   return 0;
}

// </Snippet1>
