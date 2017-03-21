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