    Private Function GetImageOfCustomControl(ByVal userControl As Control) As Image 
        Dim controlImage As Image = Nothing
        Dim attrCol As AttributeCollection = TypeDescriptor.GetAttributes(userControl)
        Dim imageAttr As ToolboxBitmapAttribute = _
            CType(attrCol(GetType(ToolboxBitmapAttribute)), ToolboxBitmapAttribute)
        If (imageAttr IsNot Nothing) Then
            controlImage = imageAttr.GetImage(userControl)
        End If
        
        Return controlImage
    
    End Function