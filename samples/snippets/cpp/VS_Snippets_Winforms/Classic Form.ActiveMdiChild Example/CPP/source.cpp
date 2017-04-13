

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

   // <Snippet1>
public:
   void ClearAllChildFormText()
   {
      
      // Obtain a reference to the currently active MDI child form.
      Form^ tempChild = this->ActiveMdiChild;
      
      // Loop through all controls on the child form.
      for ( int i = 0; i < tempChild->Controls->Count; i++ )
      {
         
         // Determine if the current control on the child form is a TextBox.
         if ( dynamic_cast<TextBox^>(tempChild->Controls[ i ]) )
         {
            
            // Clear the contents of the control since it is a TextBox.
            tempChild->Controls[ i ]->Text = "";
         }

      }
   }

   // </Snippet1>
};
