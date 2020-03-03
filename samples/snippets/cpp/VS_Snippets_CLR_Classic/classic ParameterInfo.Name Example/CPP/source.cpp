
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;
public ref class parminfo
{
public:
   static void mymethod( int int1m, [Out]interior_ptr<String^> str2m, interior_ptr<String^> str3m )
   {
       *str2m = "in mymethod";
   }

};

int main()
{
   Console::WriteLine( "\nReflection.Parameterinfo" );
   
   //Get the ParameterInfo parameter of a function.
   //Get the type.
   Type^ Mytype = Type::GetType( "parminfo" );
   
   //Get and display the method.
   MethodBase^ Mymethodbase = Mytype->GetMethod( "mymethod" );
   Console::Write( "\nMymethodbase = {0}", Mymethodbase );
   
   //Get the ParameterInfo array.
   array<ParameterInfo^>^Myarray = Mymethodbase->GetParameters();
   
   //Get and display the name of each parameter.
   System::Collections::IEnumerator^ enum0 = Myarray->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      ParameterInfo^ Myparam = safe_cast<ParameterInfo^>(enum0->Current);
      Console::Write( "\nFor parameter # {0}, the Name is - {1}", Myparam->Position, Myparam->Name );
   }

   return 0;
}

/*
This code produces the following output:

Reflection.ParameterInfo

Mymethodbase
= Void mymethod (Int32, System.String ByRef, System.String ByRef)
For parameter # 0, the Name is - int1m
For parameter # 1, the Name is - str2m
For parameter # 2, the Name is - str3m
*/
// </Snippet1>
