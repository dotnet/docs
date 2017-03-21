      // Create  a WebPermission without permission on the protected resource
      WebPermission^ myWebPermission1 = gcnew WebPermission( PermissionState::None );
      
      // Create a SecurityElement by calling the ToXml method on the WebPermission
      // instance and display its attributes (which hold the XML encoding of
      // the WebPermission).
      Console::WriteLine( "Attributes and Values of the WebPermission are:" );
      myWebPermission1->ToXml();
      
      // Create another WebPermission with no permission on the protected resource
      WebPermission^ myWebPermission2 = gcnew WebPermission( PermissionState::None );
      
      //Converts the new WebPermission from XML using myWebPermission1.
      myWebPermission2->FromXml( myWebPermission1->ToXml() );