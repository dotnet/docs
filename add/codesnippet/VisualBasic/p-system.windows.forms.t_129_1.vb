' This example demonstrates how to apply a 
' custom professional renderer to an individual
' ToolStrip or to the application as a whole.
Class Form6
   Inherits Form
   Private targetComboBox As New ComboBox()
   
   
    Public Sub New()

        ' Alter the renderer at the top level.
        ' Create and populate a new ToolStrip control.
        Dim ts As New ToolStrip()
        ts.Name = "ToolStrip"
        ts.Items.Add("Apples")
        ts.Items.Add("Oranges")
        ts.Items.Add("Pears")

        ' Create a new menustrip with a new window.
        Dim ms As New MenuStrip()
        ms.Name = "MenuStrip"
        ms.Dock = DockStyle.Top

        ' add top level items
        Dim fileMenuItem As New ToolStripMenuItem("File")
        ms.Items.Add(fileMenuItem)
        ms.Items.Add("Edit")
        ms.Items.Add("View")
        ms.Items.Add("Window")

        ' Add subitems to the "File" menu.
        fileMenuItem.DropDownItems.Add("Open")
        fileMenuItem.DropDownItems.Add("Save")
        fileMenuItem.DropDownItems.Add("Save As...")
        fileMenuItem.DropDownItems.Add("-")
        fileMenuItem.DropDownItems.Add("Exit")

        ' Add a Button control to apply renderers.
        Dim applyButton As New Button()
        applyButton.Text = "Apply Custom Renderer"
        AddHandler applyButton.Click, AddressOf applyButton_Click

        ' Add the ComboBox control for choosing how
        ' to apply the renderers.
        targetComboBox.Items.Add("All")
        targetComboBox.Items.Add("MenuStrip")
        targetComboBox.Items.Add("ToolStrip")
        targetComboBox.Items.Add("Reset")

        ' Create and set up a TableLayoutPanel control.
        Dim tlp As New TableLayoutPanel()
        tlp.Dock = DockStyle.Fill
        tlp.RowCount = 1
        tlp.ColumnCount = 2
        tlp.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        tlp.ColumnStyles.Add(New ColumnStyle(SizeType.Percent))
        tlp.Controls.Add(applyButton)
        tlp.Controls.Add(targetComboBox)

        ' Create a GroupBox for the TableLayoutPanel control.
        Dim gb As New GroupBox()
        gb.Text = "Apply Renderers"
        gb.Dock = DockStyle.Fill
        gb.Controls.Add(tlp)

        ' Add the GroupBox to the form.
        Me.Controls.Add(gb)

        ' Add the ToolStrip to the form's Controls collection.
        Me.Controls.Add(ts)

        ' Add the MenuStrip control last.
        ' This is important for correct placement in the z-order.
        Me.Controls.Add(ms)
    End Sub
   
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
End Class

' This type demonstrates a custom renderer. It overrides the
' OnRenderMenuItemBackground and OnRenderButtonBackground methods
' to customize the backgrounds of MenuStrip items and ToolStrip buttons.
Class CustomProfessionalRenderer
   Inherits ToolStripProfessionalRenderer
   
   Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
      If e.Item.Selected Then
         Dim b = New SolidBrush(ProfessionalColors.SeparatorLight)
         Try
            e.Graphics.FillEllipse(b, e.Item.ContentRectangle)
         Finally
            b.Dispose()
         End Try
      Else
         Dim p As New Pen(ProfessionalColors.SeparatorLight)
         Try
            e.Graphics.DrawEllipse(p, e.Item.ContentRectangle)
         Finally
            p.Dispose()
         End Try
      End If
    End Sub

   Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
      Dim r As Rectangle = Rectangle.Inflate(e.Item.ContentRectangle, - 2, - 2)
      
      If e.Item.Selected Then
         Dim b = New SolidBrush(ProfessionalColors.SeparatorLight)
         Try
            e.Graphics.FillRectangle(b, r)
         Finally
            b.Dispose()
         End Try
      Else
         Dim p As New Pen(ProfessionalColors.SeparatorLight)
         Try
            e.Graphics.DrawRectangle(p, r)
         Finally
            p.Dispose()
         End Try
      End If
    End Sub
End Class