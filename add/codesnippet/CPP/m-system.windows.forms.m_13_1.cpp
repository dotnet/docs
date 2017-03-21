public:
   void CreateMyMenu()
   {
      // Create an empty menu item object.
      MenuItem^ menuItem1 = gcnew MenuItem;
      // Intialize the menu item using the parameterless version of the constructor.
      // Set the caption of the menu item.
      menuItem1->Text = "&File";
   }