      // Create another WebPermission that is the Union of previous two WebPermission
      // instances.
      WebPermission^ myWebPermission3 = (WebPermission^)(myWebPermission1->Union( myWebPermission2 ));
      Console::WriteLine( "\nAttributes and values of the WebPermission after the Union are : " );
      // Display the attributes, values and children.
      Console::WriteLine( myWebPermission3->ToXml() );