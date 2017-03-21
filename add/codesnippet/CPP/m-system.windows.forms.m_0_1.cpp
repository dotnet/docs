public:
   void CreateMyMenu()
   {
      // Create a main menu object.
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
      menuItem1->Click += gcnew System::EventHandler( this, &Form1::menuItem1_Click );
      menuItem2->Click += gcnew System::EventHandler( this, &Form1::menuItem2_Click );

      // Assign mainMenu1 to the form.
      this->Menu = mainMenu1;

      // Perform a click on the File menu item.
      menuItem1->PerformClick();
   }

private:
   void menuItem1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "You clicked the File menu.", "The Event Information" );
   }

   void menuItem2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "You clicked the Edit menu.", "The Event Information" );
   }