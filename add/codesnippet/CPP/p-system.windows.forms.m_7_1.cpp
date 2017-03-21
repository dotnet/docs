public:
   void CreateMyMenus()
   {
      // Create three top-level menu items.
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&New" );
      MenuItem^ menuItem3 = gcnew MenuItem( "&Open" );
      // Set the BarBreak property to display horizontally.
      menuItem2->BarBreak = true;
      menuItem3->BarBreak = true;
      // Add menuItem2 and menuItem3 to the menuItem1's list of menu items.
      menuItem1->MenuItems->Add( menuItem2 );
      menuItem1->MenuItems->Add( menuItem3 );
   }