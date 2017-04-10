#using <system.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   bool myDataIsSaved;

   // <Snippet1>
private:
   // Call this method from the InitializeComponent() method of your form
   void OtherInitialize()
   {
      this->Closing += gcnew CancelEventHandler( this, &Form1::Form1_Cancel );
      this->myDataIsSaved = true;
   }

   void Form1_Cancel( Object^ /*sender*/, CancelEventArgs^ e )
   {
      if ( !myDataIsSaved )
      {
         e->Cancel = true;
         MessageBox::Show( "You must save first." );
      }
      else
      {
         e->Cancel = false;
         MessageBox::Show( "Goodbye." );
      }
   }
   // </Snippet1>
};
