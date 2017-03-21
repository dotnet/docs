public:
   void CloneMyMenu()
   {
      // Clone the existing MenuItem into the new MenuItem.
      MenuItem^ tempMenuItem = menuItem1->CloneMenu();
      
      // Assign the cloned MenuItem to the ContextMenu.
      contextMenu1->MenuItems->Add( tempMenuItem );
   }