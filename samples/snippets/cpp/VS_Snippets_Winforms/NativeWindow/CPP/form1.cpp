

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

//<Snippet1>
using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Runtime::InteropServices;
ref class MyNativeWindowListener;
ref class MyNativeWindow;

// Summary description for Form1.
ref class Form1: public System::Windows::Forms::Form
{
private:
   MyNativeWindowListener^ nwl;
   MyNativeWindow^ nw;

internal:
   void ApplicationActived( bool ApplicationActivated )
   {
      // The application has been activated or deactivated
      #if defined(DEBUG)
      System::Diagnostics::Debug::WriteLine( "Application Active = {0}", ApplicationActivated.ToString() );
      #endif
   }


public:
   Form1();
};

//<Snippet2>
// NativeWindow class to listen to operating system messages.
ref class MyNativeWindowListener: public NativeWindow
{
private:

   // Constant value was found in the S"windows.h" header file.
   literal int WM_ACTIVATEAPP = 0x001C;
   Form1^ parent;

public:
   MyNativeWindowListener( Form1^ parent )
   {
      parent->HandleCreated += gcnew EventHandler( this, &MyNativeWindowListener::OnHandleCreated );
      parent->HandleDestroyed += gcnew EventHandler( this, &MyNativeWindowListener::OnHandleDestroyed );
      this->parent = parent;
   }

internal:

   // Listen for the control's window creation and then hook into it.
   void OnHandleCreated( Object^ sender, EventArgs^ /*e*/ )
   {
      // Window is now created, assign handle to NativeWindow.
      AssignHandle( (dynamic_cast<Form1^>(sender))->Handle );
   }

   void OnHandleDestroyed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Window was destroyed, release hook.
      ReleaseHandle();
   }

protected:

   virtual void WndProc( Message %m ) override
   {
      // Listen for operating system messages
      switch ( m.Msg )
      {
         case WM_ACTIVATEAPP:

            // Notify the form that this message was received.
            // Application is activated or deactivated,
            // based upon the WParam parameter.
            parent->ApplicationActived( ((int)m.WParam != 0) );
            break;
      }
      NativeWindow::WndProc( m );
   }

};
//</Snippet2>

//<Snippet3>
// MyNativeWindow class to create a window given a class name.
ref class MyNativeWindow: public NativeWindow
{
private:

   // Constant values were found in the S"windows.h" header file.
   literal int WS_CHILD = 0x40000000,WS_VISIBLE = 0x10000000,WM_ACTIVATEAPP = 0x001C;
   int windowHandle;

public:
   MyNativeWindow( Form^ parent )
   {
      CreateParams^ cp = gcnew CreateParams;

      // Fill in the CreateParams details.
      cp->Caption = "Click here";
      cp->ClassName = "Button";

      // Set the position on the form
      cp->X = 100;
      cp->Y = 100;
      cp->Height = 100;
      cp->Width = 100;

      // Specify the form as the parent.
      cp->Parent = parent->Handle;

      // Create as a child of the specified parent
      cp->Style = WS_CHILD | WS_VISIBLE;

      // Create the actual window
      this->CreateHandle( cp );
   }

protected:

   // Listen to when the handle changes to keep the variable in sync

   virtual void OnHandleChange() override
   {
      windowHandle = (int)this->Handle;
   }

   virtual void WndProc( Message % m ) override
   {
      // Listen for messages that are sent to the button window. Some messages are sent
      // to the parent window instead of the button's window.
      switch ( m.Msg )
      {
         case WM_ACTIVATEAPP:
            
            // Do something here in response to messages
            break;
      }
      NativeWindow::WndProc( m );
   }
};
//</Snippet3>

Form1::Form1()
{
   this->Size = System::Drawing::Size( 300, 300 );
   this->Text = "Form1";
   nwl = gcnew MyNativeWindowListener( this );
   nw = gcnew MyNativeWindow( this );
}

// The main entry point for the application.

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
