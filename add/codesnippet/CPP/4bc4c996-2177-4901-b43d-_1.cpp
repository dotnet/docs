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