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
        Me.TestHTMLThrowButton = New System.Windows.Forms.Button
        Me.TestDomainButton = New System.Windows.Forms.Button
        Me.TestForwardNegButton = New System.Windows.Forms.Button
        Me.InnerTextButton = New System.Windows.Forms.Button
        Me.EnableAllElementsButton = New System.Windows.Forms.Button
        Me.GetLastModifiedDateButton = New System.Windows.Forms.Button
        Me.ResetFormsButton = New System.Windows.Forms.Button
        Me.GetTableRowCountButton = New System.Windows.Forms.Button
        Me.DisplayMetaButton = New System.Windows.Forms.Button
        Me.GetImgUrlsButton = New System.Windows.Forms.Button
        Me.InvokeTestMethodButton = New System.Windows.Forms.Button
        Me.WriteNewDocumentButton = New System.Windows.Forms.Button
        Me.InvokeScriptButton = New System.Windows.Forms.Button
        Me.AppendTextButton = New System.Windows.Forms.Button
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.ExportUrlsButton = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.TestHTMLThrowButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.TestDomainButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.TestForwardNegButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.InnerTextButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.EnableAllElementsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.GetLastModifiedDateButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ResetFormsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.GetTableRowCountButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.DisplayMetaButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.GetImgUrlsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.InvokeTestMethodButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.WriteNewDocumentButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.InvokeScriptButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.AppendTextButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ExportUrlsButton)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(861, 144)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'TestHTMLThrowButton
        '
        Me.TestHTMLThrowButton.Location = New System.Drawing.Point(3, 3)
        Me.TestHTMLThrowButton.Name = "TestHTMLThrowButton"
        Me.TestHTMLThrowButton.Size = New System.Drawing.Size(215, 23)
        Me.TestHTMLThrowButton.TabIndex = 0
        Me.TestHTMLThrowButton.Text = "Test Inner HTML Throw"
        '
        'TestDomainButton
        '
        Me.TestDomainButton.Location = New System.Drawing.Point(224, 3)
        Me.TestDomainButton.Name = "TestDomainButton"
        Me.TestDomainButton.Size = New System.Drawing.Size(145, 23)
        Me.TestDomainButton.TabIndex = 1
        Me.TestDomainButton.Text = "TestDomain"
        '
        'TestForwardNegButton
        '
        Me.TestForwardNegButton.Location = New System.Drawing.Point(375, 3)
        Me.TestForwardNegButton.Name = "TestForwardNegButton"
        Me.TestForwardNegButton.Size = New System.Drawing.Size(172, 23)
        Me.TestForwardNegButton.TabIndex = 2
        Me.TestForwardNegButton.Text = "Test Forward Neg"
        '
        'InnerTextButton
        '
        Me.InnerTextButton.Location = New System.Drawing.Point(553, 3)
        Me.InnerTextButton.Name = "InnerTextButton"
        Me.InnerTextButton.Size = New System.Drawing.Size(177, 23)
        Me.InnerTextButton.TabIndex = 3
        Me.InnerTextButton.Text = "Test InnterText on SCRIPT"
        '
        'EnableAllElementsButton
        '
        Me.EnableAllElementsButton.Location = New System.Drawing.Point(3, 32)
        Me.EnableAllElementsButton.Name = "EnableAllElementsButton"
        Me.EnableAllElementsButton.Size = New System.Drawing.Size(146, 23)
        Me.EnableAllElementsButton.TabIndex = 4
        Me.EnableAllElementsButton.Text = "Enable All Elements"
        '
        'GetLastModifiedDateButton
        '
        Me.GetLastModifiedDateButton.Location = New System.Drawing.Point(155, 32)
        Me.GetLastModifiedDateButton.Name = "GetLastModifiedDateButton"
        Me.GetLastModifiedDateButton.Size = New System.Drawing.Size(159, 23)
        Me.GetLastModifiedDateButton.TabIndex = 5
        Me.GetLastModifiedDateButton.Text = "Get Last Modified Date"
        '
        'ResetFormsButton
        '
        Me.ResetFormsButton.Location = New System.Drawing.Point(320, 32)
        Me.ResetFormsButton.Name = "ResetFormsButton"
        Me.ResetFormsButton.Size = New System.Drawing.Size(155, 23)
        Me.ResetFormsButton.TabIndex = 6
        Me.ResetFormsButton.Text = "Reset Forms"
        '
        'GetTableRowCountButton
        '
        Me.GetTableRowCountButton.Location = New System.Drawing.Point(481, 32)
        Me.GetTableRowCountButton.Name = "GetTableRowCountButton"
        Me.GetTableRowCountButton.Size = New System.Drawing.Size(167, 23)
        Me.GetTableRowCountButton.TabIndex = 7
        Me.GetTableRowCountButton.Text = "Get Table Row Count"
        '
        'DisplayMetaButton
        '
        Me.DisplayMetaButton.Location = New System.Drawing.Point(3, 61)
        Me.DisplayMetaButton.Name = "DisplayMetaButton"
        Me.DisplayMetaButton.Size = New System.Drawing.Size(207, 23)
        Me.DisplayMetaButton.TabIndex = 8
        Me.DisplayMetaButton.Text = "Display META Description"
        '
        'GetImgUrlsButton
        '
        Me.GetImgUrlsButton.Location = New System.Drawing.Point(216, 61)
        Me.GetImgUrlsButton.Name = "GetImgUrlsButton"
        Me.GetImgUrlsButton.Size = New System.Drawing.Size(177, 23)
        Me.GetImgUrlsButton.TabIndex = 9
        Me.GetImgUrlsButton.Text = "Get IMG Urls"
        '
        'InvokeTestMethodButton
        '
        Me.InvokeTestMethodButton.Location = New System.Drawing.Point(399, 61)
        Me.InvokeTestMethodButton.Name = "InvokeTestMethodButton"
        Me.InvokeTestMethodButton.Size = New System.Drawing.Size(207, 23)
        Me.InvokeTestMethodButton.TabIndex = 10
        Me.InvokeTestMethodButton.Text = "InvokeTestMethod"
        '
        'WriteNewDocumentButton
        '
        Me.WriteNewDocumentButton.Location = New System.Drawing.Point(612, 61)
        Me.WriteNewDocumentButton.Name = "WriteNewDocumentButton"
        Me.WriteNewDocumentButton.Size = New System.Drawing.Size(175, 23)
        Me.WriteNewDocumentButton.TabIndex = 11
        Me.WriteNewDocumentButton.Text = "Write New Document"
        '
        'InvokeScriptButton
        '
        Me.InvokeScriptButton.Location = New System.Drawing.Point(3, 90)
        Me.InvokeScriptButton.Name = "InvokeScriptButton"
        Me.InvokeScriptButton.Size = New System.Drawing.Size(159, 23)
        Me.InvokeScriptButton.TabIndex = 12
        Me.InvokeScriptButton.Text = "Invoke Script"
        '
        'AppendTextButton
        '
        Me.AppendTextButton.Location = New System.Drawing.Point(168, 90)
        Me.AppendTextButton.Name = "AppendTextButton"
        Me.AppendTextButton.Size = New System.Drawing.Size(158, 23)
        Me.AppendTextButton.TabIndex = 13
        Me.AppendTextButton.Text = "Append Text"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 163)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(861, 383)
        '
        'ExportUrlsButton
        '
        Me.ExportUrlsButton.Location = New System.Drawing.Point(332, 90)
        Me.ExportUrlsButton.Name = "ExportUrlsButton"
        Me.ExportUrlsButton.Size = New System.Drawing.Size(127, 23)
        Me.ExportUrlsButton.TabIndex = 14
        Me.ExportUrlsButton.Text = "Export URLs"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(885, 590)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents TestHTMLThrowButton As System.Windows.Forms.Button
    Friend WithEvents TestDomainButton As System.Windows.Forms.Button
    Friend WithEvents TestForwardNegButton As System.Windows.Forms.Button
    Friend WithEvents InnerTextButton As System.Windows.Forms.Button
    Friend WithEvents EnableAllElementsButton As System.Windows.Forms.Button
    Friend WithEvents GetLastModifiedDateButton As System.Windows.Forms.Button
    Friend WithEvents ResetFormsButton As System.Windows.Forms.Button
    Friend WithEvents GetTableRowCountButton As System.Windows.Forms.Button
    Friend WithEvents DisplayMetaButton As System.Windows.Forms.Button
    Friend WithEvents GetImgUrlsButton As System.Windows.Forms.Button
    Friend WithEvents InvokeTestMethodButton As System.Windows.Forms.Button
    Friend WithEvents WriteNewDocumentButton As System.Windows.Forms.Button
    Friend WithEvents InvokeScriptButton As System.Windows.Forms.Button
    Friend WithEvents AppendTextButton As System.Windows.Forms.Button
    Friend WithEvents ExportUrlsButton As System.Windows.Forms.Button

End Class
