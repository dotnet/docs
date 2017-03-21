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