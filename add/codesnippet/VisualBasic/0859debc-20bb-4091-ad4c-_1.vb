        ' Get the content string for the selected region. Called by the designer host?
        Public Overrides Function GetEditableDesignerRegionContent(ByVal region As EditableDesignerRegion) As String
            ' Get a reference to the designer host
            Dim host As IDesignerHost = CType(Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)

            If Not IsNothing(host) Then
                Dim template As ITemplate = myControl.View1
                If region.Name = "Content1" Then
                    template = myControl.View2
                End If

                ' Persist the template in the design host
                If Not IsNothing(template) Then
                    Return ControlPersister.PersistTemplate(template, host)
                End If
            End If

            Return String.Empty
        End Function