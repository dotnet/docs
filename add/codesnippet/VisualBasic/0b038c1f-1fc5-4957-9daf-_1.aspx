        serializer = New JavaScriptSerializer()
    
        ' Register the custom converter.
        serializer.RegisterConverters(New JavaScriptConverter() _
            {New System.Web.Script.Serialization.VB.ListItemCollectionConverter()})