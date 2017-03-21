        ' Create a template from the content string and put it 
        ' in the selected view. Called by the designer host?
        Public Overrides Sub SetEditableDesignerRegionContent(ByVal region As EditableDesignerRegion, ByVal content As String)
            If IsNothing(content) Then
                Return
            End If

            ' Get a reference to the designer host
            Dim host As IDesignerHost = CType(Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)
            If Not IsNothing(host) Then
                ' Create a template from the content string
                Dim template As ITemplate = ControlParser.ParseTemplate(host, content)

                ' Determine which region should get the template
                If region.Name.EndsWith("0") Then
                    myControl.View1 = template
                ElseIf region.Name.EndsWith("1") Then
                    myControl.View2 = template
                End If

            End If
        End Sub