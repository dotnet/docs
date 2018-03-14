Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data



Class Form1
    Inherits System.Windows.Forms.Form
    
    Private components As System.ComponentModel.IContainer = Nothing
    
    
    Public Sub New() 
        
        InitializeComponent()
        
        InitializeMovingToolStrip()
        InitializeBoldButton()
        InitializeToolStripStatusLabels()
        InitializeDropDownButton()
    End Sub 

    Private Sub InitializeComponent()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.movingToolStrip = New System.Windows.Forms.ToolStrip()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.components = New System.ComponentModel.Container()
      
        Me.SuspendLayout()
        ' 
        ' statusStrip1
        ' 
        Me.statusStrip1.CanOverflow = False
        Me.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.statusStrip1.Location = New System.Drawing.Point(9, 233)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(274, 24)
        Me.statusStrip1.TabIndex = 4
        Me.statusStrip1.Text = "statusStrip1"
        Me.statusStrip1.Visible = True
        ' 
        ' movingToolStrip
        ' 
        Me.movingToolStrip.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.movingToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.movingToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.movingToolStrip.Name = "movingToolStrip"
        Me.movingToolStrip.TabIndex = 2
        Me.movingToolStrip.Text = "toolStrip2"
        Me.movingToolStrip.Visible = True
        ' 
        ' toolStrip1
        ' 
        Me.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(0, 25)
        Me.toolStrip1.TabIndex = 1
        Me.toolStrip1.Text = "toolStrip1"
        Me.toolStrip1.Visible = True
        
        ' 
        ' Form1
        ' 
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(toolStrip1)
        Me.Controls.Add(statusStrip1)
        Me.Controls.Add(toolStripContainer1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub

    Private statusStrip1 As System.Windows.Forms.StatusStrip
    Private toolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Private toolStrip1 As System.Windows.Forms.ToolStrip
    Private movingToolStrip As System.Windows.Forms.ToolStrip
  
    ' The following example demonstrates setting the drop-down property
    ' for a ToolStripDropDownItem.
    '<snippet5>
    ' Declare the drop-down button and the items it will contain.
    Friend WithEvents dropDownButton1 As ToolStripDropDownButton
    Friend WithEvents dropDown As ToolStripDropDown
    Friend WithEvents buttonRed As ToolStripButton
    Friend WithEvents buttonBlue As ToolStripButton
    Friend WithEvents buttonYellow As ToolStripButton
    
    Private Sub InitializeDropDownButton() 
        dropDownButton1 = New ToolStripDropDownButton()
        dropDown = New ToolStripDropDown()
        dropDownButton1.Text = "A"
        
        ' Set the drop-down on the ToolStripDropDownButton.
        dropDownButton1.DropDown = dropDown

        ' Set the drop-down direction.
        dropDownButton1.DropDownDirection = ToolStripDropDownDirection.Left

        ' Do not show a drop-down arrow.
        dropDownButton1.ShowDropDownArrow = False

        ' Declare three buttons, set their foreground color and text, 
        ' and add the buttons to the drop-down.
        buttonRed = New ToolStripButton()
        buttonRed.ForeColor = Color.Red
        buttonRed.Text = "A"
        
        buttonBlue = New ToolStripButton()
        buttonBlue.ForeColor = Color.Blue
        buttonBlue.Text = "A"
        
        buttonYellow = New ToolStripButton()
        buttonYellow.ForeColor = Color.Yellow
        buttonYellow.Text = "A"
        
        dropDown.Items.AddRange(New ToolStripItem() {buttonRed, buttonBlue, buttonYellow})
        toolStrip1.Items.Add(dropDownButton1)
    End Sub
    
    ' Handle the buttons' click event by setting the foreground color of the
    ' form to the foreground color of the button that is clicked.
    Public Sub colorButtonsClick(ByVal sender As [Object], ByVal e As EventArgs) _
        Handles buttonRed.Click, buttonBlue.Click, buttonYellow.Click
        Dim senderButton As ToolStripButton = CType(sender, ToolStripButton)
        Me.ForeColor = senderButton.ForeColor

    End Sub
    '</snippet5>


    'Sample for ToolStripButton, ToolStripButton.CheckOnClick, 
    'ToolStripButton.CheckedChanged, and ToolStripButton.Checked.
    '<snippet50>
    Friend WithEvents boldButton As ToolStripButton

    Private Sub InitializeBoldButton()
        boldButton = New ToolStripButton()
        boldButton.Text = "B"
        boldButton.CheckOnClick = True
        toolStrip1.Items.Add(boldButton)

    End Sub

    Private Sub boldButton_CheckedChanged(ByVal sender As [Object], _
        ByVal e As EventArgs) Handles boldButton.CheckedChanged
        If boldButton.Checked Then
            Me.Font = New Font(Me.Font, FontStyle.Bold)
        Else
            Me.Font = New Font(Me.Font, FontStyle.Regular)
        End If

    End Sub

    '</snippet50>
    ' The following snippet demonstrates ToolStripItem.Image, 
    ' ToolStripItem.ImageAlign, ToolStripItemImageScaling, 
    ' ToolStripItem.ImageTransparentColor, ToolStripItem.ToolTipText,
    ' ToolStripItem.AutoToolTip, and ToolStrip.ShowItemToolTips.
    '<snippet20>
    Friend WithEvents imageButton As ToolStripButton

    Private Sub InitializeImageButtonWithToolTip()

        ' Construct the button and set the image-related properties.
        imageButton = New ToolStripButton()
        imageButton.Image = New Bitmap(GetType(Timer), "Timer.bmp")
        imageButton.ImageScaling = ToolStripItemImageScaling.SizeToFit

        ' Set the background color of the image to be transparent.
        imageButton.ImageTransparentColor = Color.FromArgb(0, 255, 0)

        ' Show ToolTip text, set custom ToolTip text, and turn
        ' off the automatic ToolTips.
        toolStrip1.ShowItemToolTips = True
        imageButton.ToolTipText = "Click for the current time"
        imageButton.AutoToolTip = False

        ' Add the button to the ToolStrip.
        toolStrip1.Items.Add(imageButton)

    End Sub
    '</snippet20>

    ' The following snippet demonstrates the ToolStrip.AutoSize,
    ' ToolStrip.RenderMode, ToolStripItem.TextDirection, 
    ' and ToolStripItem.TextAlign properties.
    '<snippet4>
    Friend WithEvents changeDirectionButton As ToolStripButton

    Private Sub InitializeMovingToolStrip()
        changeDirectionButton = New ToolStripButton()

        movingToolStrip.AutoSize = True
        movingToolStrip.RenderMode = ToolStripRenderMode.System

        changeDirectionButton.TextDirection = ToolStripTextDirection.Vertical270
        changeDirectionButton.Overflow = ToolStripItemOverflow.Never
        changeDirectionButton.Text = "Change Alignment"
        movingToolStrip.Items.Add(changeDirectionButton)
    End Sub


    Public Sub changeDirectionButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles changeDirectionButton.Click

        Dim item As ToolStripItem = CType(sender, ToolStripItem)

        If item.TextDirection = ToolStripTextDirection.Vertical270 _
            OrElse item.TextDirection = ToolStripTextDirection.Vertical90 Then

            item.TextDirection = ToolStripTextDirection.Horizontal
            movingToolStrip.Dock = System.Windows.Forms.DockStyle.Top
        Else
            item.TextDirection = ToolStripTextDirection.Vertical270
            movingToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        End If

    End Sub

    '</snippet4>


    ' This demonstrates ToolStripStatusLabel.BorderSides 
    ' and ToolStripStatusLabel.BorderStyle.
    '<snippet40>
    Private Sub InitializeToolStripStatusLabels()

        ' Create two ToolStripStatusLabel objects to display in the
        ' StatusStrip.
        Dim panel1 As New ToolStripStatusLabel()
        Dim panel2 As New ToolStripStatusLabel()

        ' Display the first panel with a sunken border style on all
        ' sides.
        panel1.BorderSides = ToolStripStatusLabelBorderSides.All
        panel1.BorderStyle = Border3DStyle.Sunken

        ' Display the second panel with a raised border style on the
        ' left side only.
        panel2.BorderSides = Border3DSide.Left
        panel2.BorderStyle = Border3DStyle.Bump

        ' Initialize the text of the panel.
        panel1.Text = "Ready..."

        ' Set the text of the panel to the current date.
        panel2.Text = System.DateTime.Today.ToLongDateString()

        ' Add both panels to the StatusStripPanel collection of the
        ' StatusStrip.
        statusStrip1.Items.AddRange(New ToolStripItem() {panel1, panel2})

    End Sub

    '</snippet40>
    Private Sub SetCustomRenderer()
        '<snippet7>
        toolStrip1.Renderer = New RedTextRenderer()
        '</snippet7>
    End Sub


    Private Sub SetCustomerRenderInManagerMode()
        '<snippet8>
        toolStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode
        ToolStripManager.Renderer = New RedTextRenderer()
        '</snippet8>
    End Sub

End Class


'<snippet1>
' Extend the ToolStripRenderer class.

Public Class RedTextRenderer
    Inherits System.Windows.Forms.ToolStripRenderer
    
    ' Override methods to render items as desired.
    Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs) 
        e.TextColor = Color.Red
        e.TextFont = New Font("Helvetica", 7, FontStyle.Bold)
        MyBase.OnRenderItemText(e)
    
    End Sub
End Class

'</snippet1>