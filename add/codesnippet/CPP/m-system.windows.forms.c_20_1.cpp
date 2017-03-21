   // Displays the shortcut menu, offsetting its location 
   // from the upper-left corner of Button1 by 20 pixels in each direction. 
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      //Declare the menu items and the shortcut menu.
      array<MenuItem^>^menuItems = {gcnew MenuItem( "Some Button Info" ),gcnew MenuItem( "Some Other Button Info" ),gcnew MenuItem( "Exit" )};
      System::Windows::Forms::ContextMenu^ buttonMenu = gcnew System::Windows::Forms::ContextMenu( menuItems );
      buttonMenu->Show( Button1, System::Drawing::Point( 20, 20 ) );
   }