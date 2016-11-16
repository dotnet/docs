        ' Attribute for the user-scope settings.
        Dim userAttr As New System.Configuration.UserScopedSettingAttribute
        Dim attrs As New System.ComponentModel.AttributeCollection(userAttr)
        PropertyGrid1.BrowsableAttributes = attrs