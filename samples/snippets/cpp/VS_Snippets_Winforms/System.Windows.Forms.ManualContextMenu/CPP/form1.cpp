

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following code example demonstrates using the 
// ContextMenu.Show() method.
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

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 104, 80 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 80, 80 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Click To See Context Menu";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // Displays the shortcut menu, offsetting its location 
   // from the upper-left corner of Button1 by 20 pixels in each direction. 
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      //Declare the menu items and the shortcut menu.
      array<MenuItem^>^menuItems = {gcnew MenuItem( "Some Button Info" ),gcnew MenuItem( "Some Other Button Info" ),gcnew MenuItem( "Exit" )};
      System::Windows::Forms::ContextMenu^ buttonMenu = gcnew System::Windows::Forms::ContextMenu( menuItems );
      buttonMenu->Show( Button1, System::Drawing::Point( 20, 20 ) );
   }
   //</snippet1>
};


[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
