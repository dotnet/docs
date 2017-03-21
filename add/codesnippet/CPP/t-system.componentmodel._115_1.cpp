      // Create a DesignerCollection using a constructor
      // that accepts an array of IDesignerHost objects with 
      // which to initialize the array.
      array<IDesignerHost^>^temp0 = {designerhost1,designerhost2};
      DesignerCollection^ collection = gcnew DesignerCollection( temp0 );