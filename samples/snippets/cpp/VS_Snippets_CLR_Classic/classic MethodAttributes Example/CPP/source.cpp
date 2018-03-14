
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

public ref class AttributesSample
{
public:
   void Mymethod( int int1m, [Out]interior_ptr<String^> str2m, interior_ptr<String^> str3m )
   {
       *str2m = "in Mymethod";
   }
};

void PrintAttributes( Type^ attribType, int iAttribValue )
{
   if (  !attribType->IsEnum )
   {
      Console::WriteLine( "This type is not an enum." );
      return;
   }

   array<FieldInfo^>^fields = attribType->GetFields( static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Static) );
   for ( int i = 0; i < fields->Length; i++ )
   {
      int fieldvalue = safe_cast<Int32>(fields[ i ]->GetValue( nullptr ));
      if ( (fieldvalue & iAttribValue) == fieldvalue )
      {
         Console::WriteLine( fields[ i ]->Name );
      }
   }
}

int main()
{
   Console::WriteLine( "Reflection.MethodBase.Attributes Sample" );

   // Get the type of the chosen class.
   Type^ MyType = Type::GetType( "AttributesSample" );

   // Get the method Mymethod on the type.
   MethodBase^ Mymethodbase = MyType->GetMethod( "Mymethod" );

   // Display the method name and signature.
   Console::WriteLine( "Mymethodbase = {0}", Mymethodbase );

   // Get the MethodAttribute enumerated value.
   MethodAttributes Myattributes = Mymethodbase->Attributes;

   // Display the flags that are set.
   PrintAttributes( System::Reflection::MethodAttributes::typeid, (int)Myattributes );
   return 0;
}
// </Snippet1>
