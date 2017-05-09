

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
protected:
   TextBox^ textBox1;

public:

   // <Snippet1>
   void DisableActiveFormControls()
   {
      
      // Create an instance of a form and assign it the currently active form.
      Form^ currentForm = Form::ActiveForm;
      
      // Loop through all the controls on the active form.
      for ( int i = 0; i < currentForm->Controls->Count; i++ )
      {
         
         // Disable each control in the active form's control collection.
         currentForm->Controls[ i ]->Enabled = false;

      }
   }

   // </Snippet1>
};
