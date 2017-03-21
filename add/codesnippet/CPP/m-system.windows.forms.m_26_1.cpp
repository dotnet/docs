   void CreateMyMainMenu()
   {
      // Create two MenuItem objects and assign to array.
      MenuItem^ menuItem1 = gcnew MenuItem;
      MenuItem^ menuItem2 = gcnew MenuItem;
      menuItem1->Text = "&File";
      menuItem2->Text = "&Edit";

      // Create a MainMenu and assign MenuItem objects.
      array<MenuItem^>^temp2 = {menuItem1,menuItem2};
      MainMenu^ mainMenu1 = gcnew MainMenu( temp2 );

      // Bind the MainMenu to Form1.
      Menu = mainMenu1;
   }