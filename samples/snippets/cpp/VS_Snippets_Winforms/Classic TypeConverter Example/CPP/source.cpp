#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;

public ref class Sample
{
public:
   enum class MyPropertyEnum
   {
      option1, option2, option3
   };

   ref class MyClassConverter
   {
   };

   // <Snippet1>
public:
   [TypeConverter(Sample::MyClassConverter::typeid)]
   ref class MyClass
   {
      // Insert code here.
   };
   // </Snippet1>

   // <Snippet2>
public:
   property MyPropertyEnum MyProperty 
   {
      void set( MyPropertyEnum value )
      {
         // Checks to see if the value passed is valid.
         if ( !TypeDescriptor::GetConverter( MyPropertyEnum::typeid )->IsValid( value ) )
         {
            throw gcnew ArgumentException;
         }
         // The value is valid. Insert code to set the property.
      }
   }
   // </Snippet2>

   void Method1()
   {
      // <Snippet3>
      Color c = Color::Red;
      Console::WriteLine( TypeDescriptor::GetConverter( c )->ConvertToString( c ) );
      // </Snippet3>
   }

   void Method2()
   {
      // <Snippet4>
      Color c =  (Color)(TypeDescriptor::GetConverter( Color::typeid )->ConvertFromString( "Red" ));
      // </Snippet4>
   }

   void Method3()
   {
      // <Snippet5>
      for each ( Color c in TypeDescriptor::GetConverter( Color::typeid )->GetStandardValues() )
      {
         Console::WriteLine( TypeDescriptor::GetConverter( c )->ConvertToString( c ) );
      }
      // </Snippet5>
   }
};
