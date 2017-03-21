public:
   void CreateMyMenuItems()
   {
      // Craete a main menu object.
      MainMenu^ mainMenu1 = gcnew MainMenu;

      // Create three top-level menu items.
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&New" );
      MenuItem^ menuItem3 = gcnew MenuItem( "&Open" );

      // Add menuItem1 to the main menu.
      mainMenu1->MenuItems->Add( menuItem1 );

      // Add menuItem2 and menuItem3 to menuItem1.
      menuItem1->MenuItems->Add( menuItem2 );
      menuItem1->MenuItems->Add( menuItem3 );

      // Check to see if menuItem3 has a parent menu.
      if ( menuItem3->Parent != nullptr )
            MessageBox::Show( String::Concat( menuItem3->Parent, "." ), "Parent Menu Information of menuItem3" );
      else
            MessageBox::Show( "No parent menu." );

      // Assign mainMenu1 to the form.
      this->Menu = mainMenu1;
   }