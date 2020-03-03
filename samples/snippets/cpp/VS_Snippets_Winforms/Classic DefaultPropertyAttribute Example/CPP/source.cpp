

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
public:

   // <Snippet1>
   [DefaultProperty("MyProperty")]
   ref class MyControl: public Control
   {
   public:

      property int MyProperty 
      {
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
      // Insert any additional code.
   };
   // </Snippet1>
};


// <Snippet2>
int main()
{
   // Creates a new control.
   Form1::MyControl^ myNewControl = gcnew Form1::MyControl;

   // Gets the attributes for the collection.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewControl );

   /* Prints the name of the default property by retrieving the 
       * DefaultPropertyAttribute from the AttributeCollection. */
   DefaultPropertyAttribute^ myAttribute = dynamic_cast<DefaultPropertyAttribute^>(attributes[ DefaultPropertyAttribute::typeid ]);
   Console::WriteLine( "The default property is: {0}", myAttribute->Name );
   return 0;
}
// </Snippet2>
