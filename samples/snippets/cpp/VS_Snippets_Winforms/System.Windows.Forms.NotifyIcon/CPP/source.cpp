

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::NotifyIcon^ notifyIcon1;
   System::Windows::Forms::ContextMenu^ contextMenu1;
   System::Windows::Forms::MenuItem^ menuItem1;
   System::ComponentModel::IContainer^ components;

public:
   Form1()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->contextMenu1 = gcnew System::Windows::Forms::ContextMenu;
      this->menuItem1 = gcnew System::Windows::Forms::MenuItem;
      
      // Initialize contextMenu1
      array<System::Windows::Forms::MenuItem^>^temp0 = {this->menuItem1};
      this->contextMenu1->MenuItems->AddRange( temp0 );
      
      // Initialize menuItem1
      this->menuItem1->Index = 0;
      this->menuItem1->Text = "E&xit";
      this->menuItem1->Click += gcnew System::EventHandler( this, &Form1::menuItem1_Click );
      
      // Set up how the form should be displayed.
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Text = "Notify Icon Example";
      
      // Create the NotifyIcon.
      this->notifyIcon1 = gcnew System::Windows::Forms::NotifyIcon( this->components );
      
      // The Icon property sets the icon that will appear
      // in the systray for this application.
      notifyIcon1->Icon = gcnew System::Drawing::Icon( "appicon.ico" );
      
      // The ContextMenu property sets the menu that will
      // appear when the systray icon is right clicked.
      notifyIcon1->ContextMenu = this->contextMenu1;
      
      // The Text property sets the text that will be displayed,
      // in a tooltip, when the mouse hovers over the systray icon.
      notifyIcon1->Text = "Form1 (NotifyIcon example)";
      notifyIcon1->Visible = true;
      
      // Handle the DoubleClick event to activate the form.
      notifyIcon1->DoubleClick += gcnew System::EventHandler( this, &Form1::notifyIcon1_DoubleClick );
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
   void notifyIcon1_DoubleClick( Object^ /*Sender*/, EventArgs^ /*e*/ )
   {
      
      // Show the form when the user double clicks on the notify icon.
      // Set the WindowState to normal if the form is minimized.
      if ( this->WindowState == FormWindowState::Minimized )
            this->WindowState = FormWindowState::Normal;
      
      // Activate the form.
      this->Activate();
   }

   void menuItem1_Click( Object^ /*Sender*/, EventArgs^ /*e*/ )
   {
      
      // Close the form, which closes the application.
      this->Close();
   }

};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
