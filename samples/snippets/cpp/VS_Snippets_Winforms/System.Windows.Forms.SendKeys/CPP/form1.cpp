

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

//The following code example shows the use of the 
// SendKeys.Send method.
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
      //Add any initialization after the InitializeComponent() call
   }

protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::Label ^ Label1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 96, 72 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 0;
      this->Button1->Text = "&Click";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //Label1
      //
      this->Label1->Location = System::Drawing::Point( 80, 16 );
      this->Label1->Name = "Label1";
      this->Label1->Size = System::Drawing::Size( 128, 32 );
      this->Label1->TabIndex = 1;
      this->Label1->Text = "Double-clicking form, clicks the button";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
      this->DoubleClick += gcnew System::EventHandler( this, &Form1::Form1_DoubleClick );
   }

   //<snippet1>
private:
   // Clicking Button1 causes a message box to appear.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "Click here!" );
   }

   // Use the SendKeys.Send method to raise the Button1 click event 
   // and display the message box.
   void Form1_DoubleClick( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Send the enter key; since the tab stop of Button1 is 0, this
      // will trigger the click event.
      SendKeys::Send( "{ENTER}" );
   }
   //</snippet1>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
