public:
   [STAThread]
   void AddContextmenu()
   {
      // Create a shortcut menu.
      System::Windows::Forms::ContextMenu^ m = gcnew System::Windows::Forms::ContextMenu;
      this->ContextMenu = m;

      // Create MenuItem objects.
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;

      // Set the Text property.
      menuItem1->Text = "New";
      menuItem2->Text = "Open";

      // Add menu items to the MenuItems collection.
      m->MenuItems->Add( menuItem1 );
      m->MenuItems->Add( menuItem2 );

      // Display the starting message.
      MessageBox::Show( "Right-click the form to display the shortcut menu items" );

      // Add functionality to the menu items. 
      menuItem1->Click += gcnew System::EventHandler( this, &Form1::menuItem1_Click );
      menuItem2->Click += gcnew System::EventHandler( this, &Form1::menuItem2_Click );
   }

private:
   void menuItem1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      String^ textReport = "You clicked the New menu item. \n"
      "It is contained in the following shortcut menu: \n\n";

      // Get information on the shortcut menu in which menuitem1 is contained.
      textReport = String::Concat( textReport, this->ContextMenu->GetContextMenu()->ToString() );

      // Display the shortcut menu information in a message box.
      MessageBox::Show( textReport, "The ContextMenu Information" );
   }

   void menuItem2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      String^ textReport = "You clicked the Open menu item. \n"
      "It is contained in the following shortcut menu: \n\n";

      // Get information on the shortcut menu in which menuitem1 is contained.
      textReport = String::Concat( textReport, this->ContextMenu->GetContextMenu()->ToString() );

      // Display the shortcut menu information in a message box.
      MessageBox::Show( textReport, "The ContextMenu Information" );
   }