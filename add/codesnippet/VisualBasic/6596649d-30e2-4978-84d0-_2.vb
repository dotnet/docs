    ' The AddClipMapping method adds a custom mapping 
    ' for the Clip property.
    Private Sub AddClipMapping()

        wfHost.PropertyMap.Add( _
            "Clip", _
            New PropertyTranslator(AddressOf OnClipChange))

    End Sub
    
    ' The OnClipChange method assigns an elliptical clipping 
    ' region to the hosted control's Region property.
    Private Sub OnClipChange( _
    ByVal h As Object, _
    ByVal propertyName As String, _
    ByVal value As Object)

        Dim host As WindowsFormsHost = h

        Dim cb As System.Windows.Forms.CheckBox = host.Child

        If cb IsNot Nothing Then
            cb.Region = Me.CreateClipRegion()
        End If

    End Sub
    
    ' The Window1_SizeChanged method handles the window's 
    ' SizeChanged event. It calls the OnClipChange method explicitly 
    ' to assign a new clipping region to the hosted control.
    Private Sub Window1_SizeChanged( _
    ByVal sender As Object, _
    ByVal e As SizeChangedEventArgs)

        Me.OnClipChange(wfHost, "Clip", Nothing)

    End Sub
    
    ' The CreateClipRegion method creates a Region from an
    ' elliptical GraphicsPath.
    Private Function CreateClipRegion() As [Region] 
        Dim path As New GraphicsPath()
        
        path.StartFigure()
        
        path.AddEllipse(New System.Drawing.Rectangle( _
            0, _
            0, _
            wfHost.ActualWidth, _
            wfHost.ActualHeight))
        
        path.CloseFigure()
        
        Return New [Region](path)
    
    End Function