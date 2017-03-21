public:
   void CreateMyMenuItem()
   {
      // submenu item array.
      array<MenuItem^>^ subMenus = gcnew array<MenuItem^>(3);
      // Create three menu items to add to the submenu item array.
      MenuItem^ subMenuItem1 = gcnew MenuItem( "Red" );
      MenuItem^ subMenuItem2 = gcnew MenuItem( "Blue" );
      MenuItem^ subMenuItem3 = gcnew MenuItem( "Green" );
      // Add the submenu items to the array.
      subMenus[ 0 ] = subMenuItem1;
      subMenus[ 1 ] = subMenuItem2;
      subMenus[ 2 ] = subMenuItem3;
      // Create an instance of a MenuItem with caption and an array of submenu
      // items specified.
      MenuItem^ MenuItem1 = gcnew MenuItem( "&Colors",subMenus );
   }