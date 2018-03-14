

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeContextMenu();
      
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
   System::Windows::Forms::NotifyIcon^ NotifyIcon1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      System::Resources::ResourceManager^ resources = gcnew System::Resources::ResourceManager( Form1::typeid );
      this->NotifyIcon1 = gcnew System::Windows::Forms::NotifyIcon( this->components );
      
      //
      //NotifyIcon1
      //
      this->NotifyIcon1->Icon = System::Drawing::SystemIcons::Asterisk;
      this->NotifyIcon1->Text = "NotifyIcon1";
      this->NotifyIcon1->Visible = true;
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
   }

   // <snippet1>
   // Initalize the NofifyIcon object's shortcut menu.
   void InitializeContextMenu()
   {
      array<MenuItem^>^menuList = {gcnew MenuItem( "Sign In" ),gcnew MenuItem( "Get Help" ),gcnew MenuItem( "Open" )};
      System::Windows::Forms::ContextMenu^ clickMenu = gcnew System::Windows::Forms::ContextMenu( menuList );
      NotifyIcon1->ContextMenu = clickMenu;
      
      // Associate the event-handling method with 
      // the NotifyIcon object's click event.
      NotifyIcon1->Click += gcnew System::EventHandler( this, &Form1::NotifyIcon1_Click );
   }

   // When user clicks the left mouse button display the shortcut menu.  
   // Use the SystemInformation.PrimaryMonitorMaximizedWindowSize property
   // to place the menu at the lower corner of the screen.
   void NotifyIcon1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      System::Drawing::Size windowSize = SystemInformation::PrimaryMonitorMaximizedWindowSize;
      System::Drawing::Point menuPoint = System::Drawing::Point( windowSize.Width - 180, windowSize.Height - 5 );
      menuPoint = this->PointToClient( menuPoint );
      NotifyIcon1->ContextMenu->Show( this, menuPoint );
   }
   // </snippet1>
};


[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
