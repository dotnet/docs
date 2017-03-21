   void DisableMyChildMenus()
   {
      
      // Determine if menuItem2 is a parent menu.
      if ( menuItem2->IsParent == true )
      {
         
         // Loop through all the submenus.
         for ( int i = 0; i < menuItem2->MenuItems->Count; i++ )
         {
            
            // Disable all of the submenus of menuItem2.
            menuItem2->MenuItems[ i ]->Enabled = false;

         }
      }
   }
