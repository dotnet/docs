 ' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing
' </snippet1>

Public Class Program

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()

        'Application.Run(New Form1())
        'Application.Run(New Form2())
        Application.Run(New Form3())
        'Application.Run(New Form4())
        'Application.Run(New Form5())
        'Application.Run(New Form6())
    End Sub
End Class

' <snippet10>
' This code example demonstrates how to use ToolStripPanel
' controls with a multiple document interface (MDI).
Public Class Form1
   Inherits Form
   
   Public Sub New()
      ' Make the Form an MDI parent.
      Me.IsMdiContainer = True
      
      ' <snippet11>
      ' Create ToolStripPanel controls.
      Dim tspTop As New ToolStripPanel()
      Dim tspBottom As New ToolStripPanel()
      Dim tspLeft As New ToolStripPanel()
      Dim tspRight As New ToolStripPanel()
      
      ' Dock the ToolStripPanel controls to the edges of the form.
      tspTop.Dock = DockStyle.Top
      tspBottom.Dock = DockStyle.Bottom
      tspLeft.Dock = DockStyle.Left
      tspRight.Dock = DockStyle.Right
      
      ' Create ToolStrip controls to move among the 
      ' ToolStripPanel controls.
      ' Create the "Top" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsTop As New ToolStrip()
      tsTop.Items.Add("Top")
      tspTop.Join(tsTop)
      
      ' Create the "Bottom" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsBottom As New ToolStrip()
      tsBottom.Items.Add("Bottom")
      tspBottom.Join(tsBottom)
      
      ' Create the "Right" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsRight As New ToolStrip()
      tsRight.Items.Add("Right")
      tspRight.Join(tsRight)
      
      ' Create the "Left" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsLeft As New ToolStrip()
      tsLeft.Items.Add("Left")
      tspLeft.Join(tsLeft)
        ' </snippet11>

      ' <snippet12>
      ' Create a MenuStrip control with a new window.
      Dim ms As New MenuStrip()
      Dim windowMenu As New ToolStripMenuItem("Window")
      Dim windowNewMenu As New ToolStripMenuItem("New", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
      windowMenu.DropDownItems.Add(windowNewMenu)
      CType(windowMenu.DropDown, ToolStripDropDownMenu).ShowImageMargin = False
      CType(windowMenu.DropDown, ToolStripDropDownMenu).ShowCheckMargin = True
      
      ' Assign the ToolStripMenuItem that displays 
      ' the list of child forms.
      ms.MdiWindowListItem = windowMenu
      
      ' Add the window ToolStripMenuItem to the MenuStrip.
      ms.Items.Add(windowMenu)
      
      ' Dock the MenuStrip to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' The Form.MainMenuStrip property determines the merge target.
      Me.MainMenuStrip = ms
        ' </snippet12>
      
      ' Add the ToolStripPanels to the form in reverse order.
      Me.Controls.Add(tspRight)
      Me.Controls.Add(tspLeft)
      Me.Controls.Add(tspBottom)
      Me.Controls.Add(tspTop)
      
      ' Add the MenuStrip last.
      ' This is important for correct placement in the z-order.
      Me.Controls.Add(ms)
    End Sub
   
   ' This event handler is invoked when 
   ' the "New" ToolStripMenuItem is clicked.
   ' It creates a new Form and sets its MdiParent 
   ' property to the main form.
    Private Sub windowNewMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim f As New Form()
        f.MdiParent = Me
        f.Text = "Form - " + Me.MdiChildren.Length.ToString()
        f.Show()
    End Sub
End Class
' </snippet10>

' <snippet20>
' This code example demonstrates how to use a ProfessionalRenderer
' to define custom professional colors at runtime.
' <snippet21>
Class Form2
   Inherits Form
   
   Public Sub New()
      ' Create a new ToolStrip control.
      Dim ts As New ToolStrip()
      
      ' Populate the ToolStrip control.
      ts.Items.Add("Apples")
      ts.Items.Add("Oranges")
      ts.Items.Add("Pears")
      ts.Items.Add("Change Colors", Nothing, New EventHandler(AddressOf ChangeColors_Click))
      
      ' Create a new MenuStrip.
      Dim ms As New MenuStrip()

      ' Dock the MenuStrip control to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' Add the top-level menu items.
      ms.Items.Add("File")
      ms.Items.Add("Edit")
      ms.Items.Add("View")
      ms.Items.Add("Window")
      
      ' <snippet23>
      ' Add the ToolStrip to Controls collection.
      Me.Controls.Add(ts)
      
      ' Add the MenuStrip control last.
      ' This is important for correct placement in the z-order.
      Me.Controls.Add(ms)
      ' </snippet23>
    End Sub
   
   ' <snippet22>
   ' This event handler is invoked when the "Change colors"
   ' ToolStripItem is clicked. It assigns the Renderer
   ' property for the ToolStrip control.
    Sub ChangeColors_Click(ByVal sender As Object, ByVal e As EventArgs)
        ToolStripManager.Renderer = New ToolStripProfessionalRenderer(New CustomProfessionalColors())
    End Sub
    ' </snippet22>
End Class
' </snippet21>

' <snippet30>
' This class defines the gradient colors for 
' the MenuStrip and the ToolStrip.
Class CustomProfessionalColors
   Inherits ProfessionalColorTable
   
   Public Overrides ReadOnly Property ToolStripGradientBegin() As Color
      Get
         Return Color.BlueViolet
      End Get 
   End Property
   
   Public Overrides ReadOnly Property ToolStripGradientMiddle() As Color
      Get
         Return Color.CadetBlue
      End Get 
   End Property
   
   Public Overrides ReadOnly Property ToolStripGradientEnd() As Color
      Get
         Return Color.CornflowerBlue
      End Get 
   End Property
   
   Public Overrides ReadOnly Property MenuStripGradientBegin() As Color
      Get
         Return Color.Salmon
      End Get 
   End Property
   
   Public Overrides ReadOnly Property MenuStripGradientEnd() As Color
      Get
         Return Color.OrangeRed
      End Get
    End Property

End Class
' </snippet30>
' </snippet20>

' <snippet40>
' This code example demonstrates how to handle the Opening event.
' It also demonstrates dynamic item addition and dynamic 
' SourceControl determination with reuse.
Class Form3
    Inherits Form

   ' Declare the ContextMenuStrip control.
   Private fruitContextMenuStrip As ContextMenuStrip
   
   
   Public Sub New()
      ' Create a new ContextMenuStrip control.
      fruitContextMenuStrip = New ContextMenuStrip()
      
      ' Attach an event handler for the 
      ' ContextMenuStrip control's Opening event.
      AddHandler fruitContextMenuStrip.Opening, AddressOf cms_Opening
      
      ' Create a new ToolStrip control.
      Dim ts As New ToolStrip()
      
      ' Create a ToolStripDropDownButton control and add it
      ' to the ToolStrip control's Items collections.
      Dim fruitToolStripDropDownButton As New ToolStripDropDownButton("Fruit", Nothing, Nothing, "Fruit")
      ts.Items.Add(fruitToolStripDropDownButton)
      
      ' Dock the ToolStrip control to the top of the form.
      ts.Dock = DockStyle.Top
      
      ' Assign the ContextMenuStrip control as the 
      ' ToolStripDropDownButton control's DropDown menu.
      fruitToolStripDropDownButton.DropDown = fruitContextMenuStrip
      
      ' Create a new MenuStrip control and add a ToolStripMenuItem.
      Dim ms As New MenuStrip()
      Dim fruitToolStripMenuItem As New ToolStripMenuItem("Fruit", Nothing, Nothing, "Fruit")
      ms.Items.Add(fruitToolStripMenuItem)
      
      ' Dock the MenuStrip control to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' Assign the MenuStrip control as the 
      ' ToolStripMenuItem's DropDown menu.
      fruitToolStripMenuItem.DropDown = fruitContextMenuStrip
      
      ' Assign the ContextMenuStrip to the form's 
      ' ContextMenuStrip property.
      Me.ContextMenuStrip = fruitContextMenuStrip
      
      ' Add the ToolStrip control to the Controls collection.
        Me.Controls.Add(ts)

        'Add a button to the form and assign its ContextMenuStrip.
        Dim b As New Button()
        b.Location = New System.Drawing.Point(60, 60)
        Me.Controls.Add(b)
        b.ContextMenuStrip = fruitContextMenuStrip
      
      ' Add the MenuStrip control last.
      ' This is important for correct placement in the z-order.
      Me.Controls.Add(ms)
    End Sub
   
   ' <snippet42>
   ' This event handler is invoked when the ContextMenuStrip
   ' control's Opening event is raised. It demonstrates
   ' dynamic item addition and dynamic SourceControl 
   ' determination with reuse.
    Sub cms_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        ' Acquire references to the owning control and item.
        Dim c As Control = fruitContextMenuStrip.SourceControl
        Dim tsi As ToolStripDropDownItem = fruitContextMenuStrip.OwnerItem 

        ' Clear the ContextMenuStrip control's 
        ' Items collection.
        fruitContextMenuStrip.Items.Clear()

        ' Check the source control first.
        If (c IsNot Nothing) Then
            ' Add custom item (Form)
            fruitContextMenuStrip.Items.Add(("Source: " + c.GetType().ToString()))
        ElseIf (tsi IsNot Nothing) Then
            ' Add custom item (ToolStripDropDownButton or ToolStripMenuItem)
            fruitContextMenuStrip.Items.Add(("Source: " + tsi.GetType().ToString()))
        End If

        ' Populate the ContextMenuStrip control with its default items.
        fruitContextMenuStrip.Items.Add("-")
        fruitContextMenuStrip.Items.Add("Apples")
        fruitContextMenuStrip.Items.Add("Oranges")
        fruitContextMenuStrip.Items.Add("Pears")

        ' Set Cancel to false. 
        ' It is optimized to true based on empty entry.
        e.Cancel = False
    End Sub
    ' </snippet42>
End Class
' </snippet40>

' <snippet50>
' This code example demonstrates using the Spring property 
' to interactively center a ToolStripStatusLabel in a StatusStrip.
Class Form4
    Inherits Form

   ' Declare the ToolStripStatusLabel.
   Private middleLabel As ToolStripStatusLabel
   
   
   Public Sub New()
      ' Create a new StatusStrip control.
      Dim ss As New StatusStrip()
      
      ' Add the leftmost label.
      ss.Items.Add("Left")
      
      ' Handle middle label separately -- action will occur
      ' when the label is clicked.
      middleLabel = New ToolStripStatusLabel("Middle (Spring)")
      AddHandler middleLabel.Click, AddressOf middleLabel_Click
      ss.Items.Add(middleLabel)
      
      ' Add the rightmost label
      ss.Items.Add("Right")
      
      ' Add the StatusStrip control to the controls collection.
      Me.Controls.Add(ss)
    End Sub
   
   ' <snippet51>
   ' This event hadler is invoked when the 
   ' middleLabel control is clicked. It toggles
   ' the value of the Spring property.
    Sub middleLabel_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Toggle the value of the Spring property.
        middleLabel.Spring = middleLabel.Spring Xor True

        ' Set the Text property according to the
        ' value of the Spring property. 
        middleLabel.Text = IIf(middleLabel.Spring, _
        "Middle (Spring - True)", "Middle (Spring - False)")
    End Sub
    ' </snippet51>
End Class
' </snippet50>

' <snippet60>
' This code example demonstrates how to set the check
' and image margins for a ToolStripMenuItem.
Class Form5
   Inherits Form
   
   ' <snippet61>
   Public Sub New()
      ' Size the form to show three wide menu items.
      Me.Width = 500
      Me.Text = "ToolStripContextMenuStrip: Image and Check Margins"
      
      ' Create a new MenuStrip control.
      Dim ms As New MenuStrip()
      
      ' Create the ToolStripMenuItems for the MenuStrip control.
      Dim bothMargins As New ToolStripMenuItem("BothMargins")
      Dim imageMarginOnly As New ToolStripMenuItem("ImageMargin")
      Dim checkMarginOnly As New ToolStripMenuItem("CheckMargin")
      Dim noMargins As New ToolStripMenuItem("NoMargins")
      
      ' Customize the DropDowns menus.
      ' This ToolStripMenuItem has an image margin 
      ' and a check margin.
      bothMargins.DropDown = CreateCheckImageContextMenuStrip()
      CType(bothMargins.DropDown, ContextMenuStrip).ShowImageMargin = True
      CType(bothMargins.DropDown, ContextMenuStrip).ShowCheckMargin = True
      
      ' This ToolStripMenuItem has only an image margin.
      imageMarginOnly.DropDown = CreateCheckImageContextMenuStrip()
      CType(imageMarginOnly.DropDown, ContextMenuStrip).ShowImageMargin = True
      CType(imageMarginOnly.DropDown, ContextMenuStrip).ShowCheckMargin = False
      
      ' This ToolStripMenuItem has only a check margin.
      checkMarginOnly.DropDown = CreateCheckImageContextMenuStrip()
      CType(checkMarginOnly.DropDown, ContextMenuStrip).ShowImageMargin = False
      CType(checkMarginOnly.DropDown, ContextMenuStrip).ShowCheckMargin = True
      
      ' This ToolStripMenuItem has no image and no check margin.
      noMargins.DropDown = CreateCheckImageContextMenuStrip()
      CType(noMargins.DropDown, ContextMenuStrip).ShowImageMargin = False
      CType(noMargins.DropDown, ContextMenuStrip).ShowCheckMargin = False
      
      ' Populate the MenuStrip control with the ToolStripMenuItems.
      ms.Items.Add(bothMargins)
      ms.Items.Add(imageMarginOnly)
      ms.Items.Add(checkMarginOnly)
      ms.Items.Add(noMargins)
      
      ' Dock the MenuStrip control to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' Add the MenuStrip control to the controls collection last.
      ' This is important for correct placement in the z-order.
      Me.Controls.Add(ms)
    End Sub
    ' </snippet61>

   ' This utility method creates a Bitmap for use in 
   ' a ToolStripMenuItem's image margin.
    Friend Function CreateSampleBitmap() As Bitmap

        ' The Bitmap is a smiley face.
        Dim sampleBitmap As New Bitmap(32, 32)
        Dim g As Graphics = Graphics.FromImage(sampleBitmap)

        Dim p As New Pen(ProfessionalColors.ButtonPressedBorder)
        Try
            ' Set the Pen width.
            p.Width = 4

            ' Set up the mouth geometry.
            Dim curvePoints() As Point = _
            {New Point(4, 14), New Point(16, 24), New Point(28, 14)}

            ' Draw the mouth.
            g.DrawCurve(p, curvePoints)

            ' Draw the eyes.
            g.DrawEllipse(p, New Rectangle(New Point(7, 4), New Size(3, 3)))
            g.DrawEllipse(p, New Rectangle(New Point(22, 4), New Size(3, 3)))
        Finally
            p.Dispose()
        End Try

        Return sampleBitmap
    End Function
   
   ' <snippet62>
   ' This utility method creates a ContextMenuStrip control
   ' that has four ToolStripMenuItems showing the four 
   ' possible combinations of image and check margins.
   Friend Function CreateCheckImageContextMenuStrip() As ContextMenuStrip
      ' Create a new ContextMenuStrip control.
      Dim checkImageContextMenuStrip As New ContextMenuStrip()
      
      ' Create a ToolStripMenuItem with a
      ' check margin and an image margin.
      Dim yesCheckYesImage As New ToolStripMenuItem("Check, Image")
      yesCheckYesImage.Checked = True
      yesCheckYesImage.Image = CreateSampleBitmap()
      
      ' Create a ToolStripMenuItem with no
      ' check margin and with an image margin.
      Dim noCheckYesImage As New ToolStripMenuItem("No Check, Image")
      noCheckYesImage.Checked = False
      noCheckYesImage.Image = CreateSampleBitmap()
      
      ' Create a ToolStripMenuItem with a
      ' check margin and without an image margin.
      Dim yesCheckNoImage As New ToolStripMenuItem("Check, No Image")
      yesCheckNoImage.Checked = True
      
      ' Create a ToolStripMenuItem with no
      ' check margin and no image margin.
      Dim noCheckNoImage As New ToolStripMenuItem("No Check, No Image")
      noCheckNoImage.Checked = False
      
      ' Add the ToolStripMenuItems to the ContextMenuStrip control.
      checkImageContextMenuStrip.Items.Add(yesCheckYesImage)
      checkImageContextMenuStrip.Items.Add(noCheckYesImage)
      checkImageContextMenuStrip.Items.Add(yesCheckNoImage)
      checkImageContextMenuStrip.Items.Add(noCheckNoImage)
      
      Return checkImageContextMenuStrip
    End Function
    ' </snippet62>
End Class
' </snippet60>

' <snippet70>
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
   
    ' <snippet80>
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
    ' </snippet80>
End Class

' <snippet100>
' This type demonstrates a custom renderer. It overrides the
' OnRenderMenuItemBackground and OnRenderButtonBackground methods
' to customize the backgrounds of MenuStrip items and ToolStrip buttons.
Class CustomProfessionalRenderer
   Inherits ToolStripProfessionalRenderer
   
   ' <snippet101>
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
    ' </snippet101>

   ' <snippet102>
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
    ' </snippet102>
End Class
' </snippet100>
' </snippet70>
