        serializer = new JavaScriptSerializer();
        
        // Register the custom converter.
        serializer.RegisterConverters(new JavaScriptConverter[] { 
            new System.Web.Script.Serialization.CS.ListItemCollectionConverter() });