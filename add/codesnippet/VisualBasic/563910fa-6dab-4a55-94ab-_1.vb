    Protected Overrides Function CreateComponentsCore( _
        ByVal host As System.ComponentModel.Design.IDesignerHost, _
        ByVal defaultValues As System.Collections.IDictionary) _
        As IComponent()
        ' Get the string we want to fill in the custom
        ' user control.  If the user cancels out of the dialog,
        ' return null or an empty array to signify that the 
        ' tool creation was canceled.
        Using d As New ToolboxItemDialog()
            If d.ShowDialog() = DialogResult.OK Then
                Dim [text] As String = d.CreationText
                Dim comps As IComponent() = _
                    MyBase.CreateComponentsCore(host, defaultValues)
                ' comps will have a single component: our data type.
                CType(comps(0), UserControl1).LabelText = [text]
                Return comps
            Else
                Return Nothing
            End If
        End Using
    End Function