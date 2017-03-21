    ' This event handler is invoked when 
    ' the "Apply Renderers" button is clicked.
    ' Depending on the value selected in a ComboBox 
    ' control, it applies a custom renderer selectively
    ' to individual MenuStrip or ToolStrip controls,
    ' or it applies a custom renderer to the 
    ' application as a whole.
    Sub applyButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim ms As ToolStrip = ToolStripManager.FindToolStrip("MenuStrip")
        Dim ts As ToolStrip = ToolStripManager.FindToolStrip("ToolStrip")

        If targetComboBox.SelectedItem IsNot Nothing Then

            Select Case targetComboBox.SelectedItem.ToString()
                Case "Reset"
                    ms.RenderMode = ToolStripRenderMode.ManagerRenderMode
                    ts.RenderMode = ToolStripRenderMode.ManagerRenderMode

                    ' Set the default RenderMode to Professional.
                    ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional

                    Exit Select

                Case "All"
                    ms.RenderMode = ToolStripRenderMode.ManagerRenderMode
                    ts.RenderMode = ToolStripRenderMode.ManagerRenderMode

                    ' Assign the custom renderer at the application level.
                    ToolStripManager.Renderer = New CustomProfessionalRenderer()

                    Exit Select

                Case "MenuStrip"
                    ' Assign the custom renderer to the MenuStrip control only.
                    ms.Renderer = New CustomProfessionalRenderer()

                    Exit Select

                Case "ToolStrip"
                    ' Assign the custom renderer to the ToolStrip control only.
                    ts.Renderer = New CustomProfessionalRenderer()

                    Exit Select
            End Select

        End If
    End Sub