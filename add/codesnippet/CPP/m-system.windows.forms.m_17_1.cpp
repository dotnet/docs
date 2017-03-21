public:
   void CreateMyMenu()
   {
      // Create a main menu objects.
      MainMenu^ mainMenu1 = gcnew MainMenu;

      // Create empty menu item objects.
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;

      // Set the caption of the menu items.
      menuItem1->Text = "&File";
      menuItem2->Text = "&Edit";

      // Add the menu items to the main menu.
      mainMenu1->MenuItems->Add( menuItem1 );
      mainMenu1->MenuItems->Add( menuItem2 );

      // Add functionality to the menu items.
      menuItem1->Select += gcnew System::EventHandler( this, &Form1::menuItem1_Select );
      menuItem2->Select += gcnew System::EventHandler( this, &Form1::menuItem2_Select );

      // Assign mainMenu1 to the form.
      this->Menu = mainMenu1;

      // Select the File menu item.
      menuItem1->PerformSelect();
   }

private:
   void menuItem1_Select( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "You selected the File menu.", "The Event Information" );
   }

   void menuItem2_Select( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "You selected the Edit menu.", "The Event Information" );
   }