public:
   void CreateMyMenus()
   {
      MenuItem^ menuItem1 = gcnew MenuItem( "&File" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&New" );
      MenuItem^ menuItem3 = gcnew MenuItem( "&Open" );
      // Make menuItem2 the default menu item.
      menuItem2->DefaultItem = true;
   }