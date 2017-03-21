   void CreateMyMainMenu()
   {
      // Create an empty MainMenu.
      MainMenu^ mainMenu1 = gcnew MainMenu;
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;
      menuItem1->Text = "File";
      menuItem2->Text = "Edit";

      // Add two MenuItem objects to the MainMenu.
      mainMenu1->MenuItems->Add( menuItem1 );
      mainMenu1->MenuItems->Add( menuItem2 );

      // Bind the MainMenu to Form1.
      Menu = mainMenu1;
   }