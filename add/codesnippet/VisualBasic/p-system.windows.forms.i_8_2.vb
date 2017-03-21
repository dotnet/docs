    ' The ExtendBackgroundMapping method adds a property
    ' translator if a mapping already exists.
    Private Sub ExtendBackgroundMapping() 
        If wfHost.PropertyMap("Background") IsNot Nothing Then

            wfHost.PropertyMap("Background") = PropertyTranslator.Combine( _
            wfHost.PropertyMap("Background"), _
            PropertyTranslator.CreateDelegate( _
                GetType(PropertyTranslator), _
                Me, _
                "OnBackgroundChange"))
        End If
    
    End Sub
    
    
    ' The OnBackgroundChange method assigns a specific image 
    ' to the hosted control's BackgroundImage property.
    Private Sub OnBackgroundChange(ByVal h As Object, ByVal propertyName As String, ByVal value As Object) 
        Dim host As WindowsFormsHost = h 
        Dim cb As System.Windows.Forms.CheckBox = host.Child 
        Dim b As ImageBrush = value 
        
        If Not (b Is Nothing) Then
            cb.BackgroundImage = New System.Drawing.Bitmap("C:\WINDOWS\Santa Fe Stucco.bmp")
        End If
    
    End Sub