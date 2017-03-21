      // Create a third WebPermission instance via the logical intersection of the previous
      // two WebPermission instances.
      WebPermission^ myWebPermission3 = (WebPermission^)(myWebPermission1->Intersect( myWebPermission2 ));

      Console::WriteLine( "\nAttributes and Values of  the WebPermission instance after the Intersect are:\n" );
      Console::WriteLine( myWebPermission3->ToXml() );