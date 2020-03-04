

// <snippet1>
#include <windows.h>

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Runtime::InteropServices;
using namespace System::Diagnostics;
using namespace System::IO;

public ref class MyIconButton: public Button
{
private:
   Icon^ icon;

public:
   MyIconButton()
   {
      
      // Set the button's FlatStyle property.
      FlatStyle = ::FlatStyle::System;
   }

   MyIconButton( Icon^ ButtonIcon )
   {
      
      // Set the button's FlatStyle property.
      FlatStyle = ::FlatStyle::System;
      
      // Assign the icon to the private field.
      this->icon = ButtonIcon;
      
      // Size the button to 4 pixels larger than the icon.
      this->Height = icon->Height + 4;
      this->Width = icon->Width + 4;
   }


protected:

   property System::Windows::Forms::CreateParams^ CreateParams 
   {

      //<snippet3>
      virtual System::Windows::Forms::CreateParams^ get() override
      {
         
         // Extend the CreateParams property of the Button class.
         System::Windows::Forms::CreateParams^ cp = __super::CreateParams;

         // Update the button Style.
         cp->Style |= 0x00000040; // BS_ICON value
         return cp;
      }
      //</snippet3>
   }

public:
   property System::Drawing::Icon^ Icon
   {
      System::Drawing::Icon^ get()
      {
         return icon;
      }
      void set(System::Drawing::Icon^ value)
      {
         icon = value;
         UpdateIcon();
         this->Height = icon->Height + 4;
         this->Width = icon->Width + 4;
      }
   }

protected:
   virtual void OnHandleCreated( EventArgs^ e ) override
   {
      Button::OnHandleCreated( e );
      
      // Update the icon on the button if there is currently an icon assigned to the icon field.
      if ( icon != nullptr )
      {
         UpdateIcon();
      }
   }


private:
   void UpdateIcon()
   {
      IntPtr iconHandle = IntPtr::Zero;
      
      // Get the icon's handle.
      if ( icon != nullptr )
      {
         iconHandle = icon->Handle;
      }

      
      // Send Windows the message to update the button.
      SendMessage( (HWND)Handle.ToPointer(), 0x00F7, 1, (int)iconHandle );
      
      /*BM_SETIMAGE value*/
      /*IMAGE_ICON value*/
   }

   public:
	[DllImport("user32.dll")]
	static LRESULT SendMessage(HWND hWnd, int msg, int wParam, int lParam);

};


// </snippet1>
// <snippet2>
public ref class MyApplication: public Form
{
private:
   MyIconButton^ myIconButton;
   Button^ stdButton;
   OpenFileDialog^ openDlg;

public:
   MyApplication()
   {
      try
      {
         
         // Create the button with the default icon.
         myIconButton = gcnew MyIconButton( gcnew System::Drawing::Icon( String::Concat( Application::StartupPath, "\\Default.ico" ) ) );
      }
      catch ( Exception^ ex ) 
      {
         
         // If the default icon does not exist, create the button without an icon.
         myIconButton = gcnew MyIconButton;
         #if defined(DEBUG)
         Debug::WriteLine( ex );
         #endif
      }
      finally
      {
         stdButton = gcnew Button;
         
         // Add the Click event handlers.
         myIconButton->Click += gcnew EventHandler( this, &MyApplication::myIconButton_Click );
         stdButton->Click += gcnew EventHandler( this, &MyApplication::stdButton_Click );
         
         // Set the location, text and width of the standard button.
         stdButton->Location = Point(myIconButton->Location.X,myIconButton->Location.Y + myIconButton->Height + 20);
         stdButton->Text = "Change Icon";
         stdButton->Width = 100;
         
         // Add the buttons to the Form.
         this->Controls->Add( stdButton );
         this->Controls->Add( myIconButton );
      }

   }


private:
   void myIconButton_Click( Object^ /*Sender*/, EventArgs^ /*e*/ )
   {
      
#undef MessageBox 
      
      // Make sure MyIconButton works.
      MessageBox::Show( "MyIconButton was clicked!" );
   }

   void stdButton_Click( Object^ /*Sender*/, EventArgs^ /*e*/ )
   {
      
      // Use an OpenFileDialog to allow the user to assign a new image to the derived button.
      openDlg = gcnew OpenFileDialog;
      openDlg->InitialDirectory = Application::StartupPath;
      openDlg->Filter = "Icon files (*.ico)|*.ico";
      openDlg->Multiselect = false;
      openDlg->ShowDialog();
      if (  !openDlg->FileName->Equals( "" ) )
      {
         myIconButton->Icon = gcnew System::Drawing::Icon( openDlg->FileName );
      }
   }

};

int main()
{
   Application::Run( gcnew MyApplication );
}

// </snippet2>
