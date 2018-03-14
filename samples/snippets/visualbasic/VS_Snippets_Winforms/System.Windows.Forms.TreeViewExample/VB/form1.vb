' This snippet shows the use of some TreeView properties.
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeTreeView()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region
    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>

    ' Declare the TreeView control.
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView

    ' Initialize the TreeView to blend with the form, giving it the 
    ' same color as the form and no border.
    Private Sub InitializeTreeView()

        ' Create a new TreeView control and set the location and size.
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.TreeView1.Location = New System.Drawing.Point(72, 48)
        Me.TreeView1.Size = New System.Drawing.Size(200, 200)

        ' Set the BorderStyle property to none, the BackColor property to  
        ' the form's backcolor, and the Scrollable property to false.  
        ' This allows the TreeView to blend in form.
        Me.TreeView1.BorderStyle = BorderStyle.None
        Me.TreeView1.BackColor = Me.BackColor
        Me.TreeView1.Scrollable = False

        
        ' Set the ShowRootLines and ShowLines properties to false to 
        ' give the TreeView a list-like appearance.
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.ShowLines = False

        ' Add the nodes.
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode("Features", _
            New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode("Full Color"), _
            New System.Windows.Forms.TreeNode("Project Wizards"), _
            New System.Windows.Forms.TreeNode("Visual C# and Visual Basic Support")}), _
            New System.Windows.Forms.TreeNode("System Requirements", _
            New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode _
            ("Pentium 133 MHz or faster processor "), _
            New System.Windows.Forms.TreeNode("Windows 98 or later"), _
            New System.Windows.Forms.TreeNode("100 MB Disk space")})})

        ' Set the tab index and add the TreeView to the form.
        Me.TreeView1.TabIndex = 0
        Me.Controls.Add(Me.TreeView1)
    End Sub
    '</snippet1>

'<snippet2>

    ' Declare the TreeView control.
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView

    ' Initialize the TreeView to blend with the form, giving it the 
    ' same color as the form and no border.
    Private Sub InitializeSelectedTreeView()

        ' Create a new TreeView control and set the location and size.
        Me.TreeView2 = New System.Windows.Forms.TreeView
        Me.TreeView2.Location = New System.Drawing.Point(72, 48)
        Me.TreeView2.Size = New System.Drawing.Size(200, 200)
        Me.TreeView2.BorderStyle = BorderStyle.Fixed3D
       
        ' Set the HideSelection property to false to keep the 
        ' selection highlighted when the user leaves the control. 
        Me.TreeView2.HideSelection = False

        ' Add the nodes.
        Me.TreeView2.Nodes.AddRange(New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode("Features", _
            New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode("Full Color"), _
            New System.Windows.Forms.TreeNode("Project Wizards"), _
            New System.Windows.Forms.TreeNode("Visual C# and Visual Basic Support")}), _
            New System.Windows.Forms.TreeNode("System Requirements", _
            New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode _
            ("Pentium 133 MHz or faster processor "), _
            New System.Windows.Forms.TreeNode("Windows 98 or later"), _
            New System.Windows.Forms.TreeNode("100 MB Disk space")})})

        ' Set the tab index and add the TreeView to the form.
        Me.TreeView2.TabIndex = 0
        Me.Controls.Add(Me.TreeView2)
    End Sub
    '</snippet2>


End Class
