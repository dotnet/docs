        ' Create a DesignerCollection using a constructor
        ' that accepts an array of IDesignerHost objects with
        ' which to initialize the collection.
        Dim collection As New DesignerCollection(New IDesignerHost() {designerhost1, designerhost2})