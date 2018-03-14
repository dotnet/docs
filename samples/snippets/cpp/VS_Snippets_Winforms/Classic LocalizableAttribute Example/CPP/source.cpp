

#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
public ref class Class1
{
   // <Snippet1>
public:
   property int MyProperty 
   {
      [Localizable(true)]
      int get()
      {
         // Insert code here.
         return 0;
      }

      void set( int value )
      {
         // Insert code here.
      }
   }
   // </Snippet1>

   void Method1()
   {
      // <Snippet2>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the property needs to be localized.
      LocalizableAttribute^ myAttribute = dynamic_cast<LocalizableAttribute^>(attributes[ LocalizableAttribute::typeid ]);
      if ( myAttribute->IsLocalizable )
      {
         // Insert code here.
      }
      // </Snippet2>
   }
};
