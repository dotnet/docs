

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
   // <Snippet1>
private:
   bool myVal;

public:
   [DefaultValue(false)]
   property bool MyProperty 
   {
      bool get()
      {
         return myVal;
      }

      void set( bool value )
      {
         myVal = value;
      }
   }
   // </Snippet1>

protected:
   void Method()
   {
      // <Snippet2>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      /* Prints the default value by retrieving the DefaultValueAttribute 
            * from the AttributeCollection. */
      DefaultValueAttribute^ myAttribute = dynamic_cast<DefaultValueAttribute^>(attributes[ DefaultValueAttribute::typeid ]);
      Console::WriteLine( "The default value is: {0}", myAttribute->Value );
      // </Snippet2>
   }
};
