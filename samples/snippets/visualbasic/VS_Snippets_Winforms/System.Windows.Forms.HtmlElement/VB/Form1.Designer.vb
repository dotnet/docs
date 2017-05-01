Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.PrintDOMButton = New System.Windows.Forms.Button
        Me.EnableElementMoveButton = New System.Windows.Forms.Button
        Me.EnableEditingButton = New System.Windows.Forms.Button
        Me.CreateHTMLMenuButton = New System.Windows.Forms.Button
        Me.GetOffsetsButton = New System.Windows.Forms.Button
        Me.AddURLToTooltipButton = New System.Windows.Forms.Button
        Me.AddlinkToPageButton = New System.Windows.Forms.Button
        Me.AddDIVMessageButton = New System.Windows.Forms.Button
        Me.HandleFormSubmitButton = New System.Windows.Forms.Button
        Me.ShiftRowsButton = New System.Windows.Forms.Button
        Me.ScrollToElementButton = New System.Windows.Forms.Button
        Me.InsertImageFooterButton = New System.Windows.Forms.Button
        Me.HandleBodyErrorButton = New System.Windows.Forms.Button
        Me.HandleFormFocusButton = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.BrowserStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.PrintDOMButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.EnableElementMoveButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.EnableEditingButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.CreateHTMLMenuButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.GetOffsetsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.AddURLToTooltipButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.AddlinkToPageButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.AddDIVMessageButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.HandleFormSubmitButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ShiftRowsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ScrollToElementButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.InsertImageFooterButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.HandleBodyErrorButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.HandleFormFocusButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(656, 152)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'PrintDOMButton
        '
        Me.PrintDOMButton.Location = New System.Drawing.Point(3, 3)
        Me.PrintDOMButton.Name = "PrintDOMButton"
        Me.PrintDOMButton.Size = New System.Drawing.Size(155, 23)
        Me.PrintDOMButton.TabIndex = 0
        Me.PrintDOMButton.Text = "Print DOM"
        '
        'EnableElementMoveButton
        '
        Me.EnableElementMoveButton.Location = New System.Drawing.Point(164, 3)
        Me.EnableElementMoveButton.Name = "EnableElementMoveButton"
        Me.EnableElementMoveButton.Size = New System.Drawing.Size(206, 23)
        Me.EnableElementMoveButton.TabIndex = 1
        Me.EnableElementMoveButton.Text = "Enable Element Move"
        '
        'EnableEditingButton
        '
        Me.EnableEditingButton.Location = New System.Drawing.Point(376, 3)
        Me.EnableEditingButton.Name = "EnableEditingButton"
        Me.EnableEditingButton.Size = New System.Drawing.Size(159, 23)
        Me.EnableEditingButton.TabIndex = 2
        Me.EnableEditingButton.Text = "Enable Editing"
        '
        'CreateHTMLMenuButton
        '
        Me.CreateHTMLMenuButton.Location = New System.Drawing.Point(3, 32)
        Me.CreateHTMLMenuButton.Name = "CreateHTMLMenuButton"
        Me.CreateHTMLMenuButton.Size = New System.Drawing.Size(170, 23)
        Me.CreateHTMLMenuButton.TabIndex = 3
        Me.CreateHTMLMenuButton.Text = "Create HTML Menu"
        '
        'GetOffsetsButton
        '
        Me.GetOffsetsButton.Location = New System.Drawing.Point(179, 32)
        Me.GetOffsetsButton.Name = "GetOffsetsButton"
        Me.GetOffsetsButton.Size = New System.Drawing.Size(138, 23)
        Me.GetOffsetsButton.TabIndex = 4
        Me.GetOffsetsButton.Text = "Get Offsets"
        '
        'AddURLToTooltipButton
        '
        Me.AddURLToTooltipButton.Location = New System.Drawing.Point(323, 32)
        Me.AddURLToTooltipButton.Name = "AddURLToTooltipButton"
        Me.AddURLToTooltipButton.Size = New System.Drawing.Size(181, 23)
        Me.AddURLToTooltipButton.TabIndex = 5
        Me.AddURLToTooltipButton.Text = "Add URL to Tooltip"
        '
        'AddlinkToPageButton
        '
        Me.AddlinkToPageButton.Location = New System.Drawing.Point(3, 61)
        Me.AddlinkToPageButton.Name = "AddlinkToPageButton"
        Me.AddlinkToPageButton.Size = New System.Drawing.Size(146, 23)
        Me.AddlinkToPageButton.TabIndex = 6
        Me.AddlinkToPageButton.Text = "Add Link to Page"
        '
        'AddDIVMessageButton
        '
        Me.AddDIVMessageButton.Location = New System.Drawing.Point(155, 61)
        Me.AddDIVMessageButton.Name = "AddDIVMessageButton"
        Me.AddDIVMessageButton.Size = New System.Drawing.Size(162, 23)
        Me.AddDIVMessageButton.TabIndex = 7
        Me.AddDIVMessageButton.Text = "Add DIV Message"
        '
        'HandleFormSubmitButton
        '
        Me.HandleFormSubmitButton.Location = New System.Drawing.Point(323, 61)
        Me.HandleFormSubmitButton.Name = "HandleFormSubmitButton"
        Me.HandleFormSubmitButton.Size = New System.Drawing.Size(181, 23)
        Me.HandleFormSubmitButton.TabIndex = 8
        Me.HandleFormSubmitButton.Text = "Handle Form Submit"
        '
        'ShiftRowsButton
        '
        Me.ShiftRowsButton.Location = New System.Drawing.Point(3, 90)
        Me.ShiftRowsButton.Name = "ShiftRowsButton"
        Me.ShiftRowsButton.Size = New System.Drawing.Size(146, 23)
        Me.ShiftRowsButton.TabIndex = 9
        Me.ShiftRowsButton.Text = "Shift Rows"
        '
        'ScrollToElementButton
        '
        Me.ScrollToElementButton.Location = New System.Drawing.Point(155, 90)
        Me.ScrollToElementButton.Name = "ScrollToElementButton"
        Me.ScrollToElementButton.Size = New System.Drawing.Size(162, 23)
        Me.ScrollToElementButton.TabIndex = 10
        Me.ScrollToElementButton.Text = "Scroll to Element"
        '
        'InsertImageFooterButton
        '
        Me.InsertImageFooterButton.Location = New System.Drawing.Point(323, 90)
        Me.InsertImageFooterButton.Name = "InsertImageFooterButton"
        Me.InsertImageFooterButton.Size = New System.Drawing.Size(181, 23)
        Me.InsertImageFooterButton.TabIndex = 11
        Me.InsertImageFooterButton.Text = "Insert Image Footer"
        '
        'HandleBodyErrorButton
        '
        Me.HandleBodyErrorButton.Location = New System.Drawing.Point(510, 90)
        Me.HandleBodyErrorButton.Name = "HandleBodyErrorButton"
        Me.HandleBodyErrorButton.Size = New System.Drawing.Size(134, 23)
        Me.HandleBodyErrorButton.TabIndex = 12
        Me.HandleBodyErrorButton.Text = "Handle Body Error"
        '
        'HandleFormFocusButton
        '
        Me.HandleFormFocusButton.Location = New System.Drawing.Point(3, 119)
        Me.HandleFormFocusButton.Name = "HandleFormFocusButton"
        Me.HandleFormFocusButton.Size = New System.Drawing.Size(155, 23)
        Me.HandleFormFocusButton.TabIndex = 13
        Me.HandleFormFocusButton.Text = "Handle Form Focus"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(164, 119)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(206, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Attach Event Handler"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 152)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(656, 273)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("c:\userfiles\jayallen\HtmlElementProject\TestAEH.htm", System.UriKind.Absolute)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowserStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 425)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(656, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BrowserStatus
        '
        Me.BrowserStatus.Name = "BrowserStatus"
        Me.BrowserStatus.Size = New System.Drawing.Size(0, 17)
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(656, 447)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PrintDOMButton As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents EnableElementMoveButton As System.Windows.Forms.Button
    Friend WithEvents EnableEditingButton As System.Windows.Forms.Button
    Friend WithEvents CreateHTMLMenuButton As System.Windows.Forms.Button
    Friend WithEvents GetOffsetsButton As System.Windows.Forms.Button
    Friend WithEvents AddURLToTooltipButton As System.Windows.Forms.Button
    Friend WithEvents AddlinkToPageButton As System.Windows.Forms.Button
    Friend WithEvents AddDIVMessageButton As System.Windows.Forms.Button
    Friend WithEvents HandleFormSubmitButton As System.Windows.Forms.Button
    Friend WithEvents ShiftRowsButton As System.Windows.Forms.Button
    Friend WithEvents ScrollToElementButton As System.Windows.Forms.Button
    Friend WithEvents InsertImageFooterButton As System.Windows.Forms.Button
    Friend WithEvents HandleBodyErrorButton As System.Windows.Forms.Button
    Friend WithEvents HandleFormFocusButton As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents BrowserStatus As System.Windows.Forms.ToolStripStatusLabel

End Class
