

#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

// <Snippet1>
public ref class BooleanSwitchTest
{
private:

   /* Create a BooleanSwitch for data.*/
   static BooleanSwitch^ dataSwitch = gcnew BooleanSwitch( "Data","DataAccess module" );

public:
   static void MyMethod( String^ location )
   {
      
      //Insert code here to handle processing.
      if ( dataSwitch->Enabled )
            Console::WriteLine( "Error happened at {0}", location );
   }

};

int main()
{
   
   //Run the method which writes an error message specifying the location of the error.
   BooleanSwitchTest::MyMethod( "in main" );
}

// </Snippet1>
