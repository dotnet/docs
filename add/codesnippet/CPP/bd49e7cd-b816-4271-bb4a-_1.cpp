   private:
      // Defines the constants for Windows messages.
      literal int WM_SETFOCUS = 0x0007;
      literal int WM_INITDIALOG = 0x0110;
      literal int WM_LBUTTONDOWN = 0x0201;
      literal int WM_RBUTTONDOWN = 0x0204;
      literal int WM_MOVE = 0x0003;

   protected:
      // Overrides the base class hook procedure...
      [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)] 
      virtual IntPtr HookProc( IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam ) override
      {
         // Evaluates the message parameter to determine the user action.
         #if defined(TRACE)
         switch ( msg )
         {
            case WM_INITDIALOG:
               System::Diagnostics::Trace::Write( "The WM_INITDIALOG message was received." );
               break;
            case WM_SETFOCUS:
               System::Diagnostics::Trace::Write( "The WM_SETFOCUS message was received." );
               break;
            case WM_LBUTTONDOWN:
               System::Diagnostics::Trace::Write( "The WM_LBUTTONDOWN message was received." );
               break;
            case WM_RBUTTONDOWN:
               System::Diagnostics::Trace::Write( "The WM_RBUTTONDOWN message was received." );
               break;
            case WM_MOVE:
               System::Diagnostics::Trace::Write( "The WM_MOVE message was received." );
               break;
         }
         #endif
        
         // Always call the base class hook procedure.
         return FontDialog::HookProc( hWnd, msg, wParam, lParam );
      }