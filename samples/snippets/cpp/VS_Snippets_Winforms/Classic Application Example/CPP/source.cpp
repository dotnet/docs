

#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

/// <summary> 
/// Summary for Form1
///
/// WARNING: If you change the name of this class, you will need to change the 
///          'Resource File Name' property for the managed resource compiler tool 
///          associated with all .resx files this class depends on.  Otherwise,
///          the designers will not be able to interact properly with localized
///          resources associated with this form.
/// </summary>
//<Snippet1>
public ref class Form1: public System::Windows::Forms::Form
{
private:
   Button^ button1;
   ListBox^ listBox1;

public:
   Form1()
   {
      button1 = gcnew Button;
      button1->Left = 200;
      button1->Text =  "Exit";
      button1->Click += gcnew EventHandler( this, &Form1::button1_Click );
      listBox1 = gcnew ListBox;
      this->Controls->Add( button1 );
      this->Controls->Add( listBox1 );
   }

private:
   void Form1::button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      int count = 1;
      
      // Check to see whether the user wants to exit 
      // the application. If not, add a number to the list box.
      while ( MessageBox::Show(  "Exit application?",  "", MessageBoxButtons::YesNo ) == ::DialogResult::No )
      {
         listBox1->Items->Add( count );
         count += 1;
      }

      
      // The user wants to exit the application. 
      // Close everything down.
      Application::Exit();
   }

};

int main()
{
   
   // Starts the application.
   Application::Run( gcnew Form1 );
}

//</Snippet1>
