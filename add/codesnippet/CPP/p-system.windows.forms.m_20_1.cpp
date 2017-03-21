public:
   void CreateMyMenus()
   {
      // Create three top-level menu items.
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&Options" );
      MenuItem^ menuItem3 = gcnew MenuItem( "&Edit" );
      // Place the "Edit" menu on a new line in the menu bar.
      menuItem3->Break = true;
   }