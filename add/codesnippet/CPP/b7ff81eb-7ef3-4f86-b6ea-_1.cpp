private:
   void InitializeMyMainMenu()
   {
      // Create the MainMenu and the MenuItem to add.
      MainMenu^ mainMenu1 = gcnew MainMenu;
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      
      /* Use the MenuItems property to call the Add method
         to add the MenuItem to mainMenu1 at specific index. */
      mainMenu1->MenuItems->Add( 0, menuItem1 );
      
      // Assign mainMenu1 to the form.
      this->Menu = mainMenu1;
   }