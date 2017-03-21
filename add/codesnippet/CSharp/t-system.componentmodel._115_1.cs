            // Create a DesignerCollection using a constructor
            // that accepts an array of IDesignerHost objects with 
            // which to initialize the array.
            DesignerCollection collection = new DesignerCollection( 
                new IDesignerHost[] { designerhost1, designerhost2 } );