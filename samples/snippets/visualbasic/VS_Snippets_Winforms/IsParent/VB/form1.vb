Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 276)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateMyMainMenu()
    End Sub
    '<snippet1>
    Public Sub CreateMyMainMenu()
        ' Create two MenuItem objects and assign to array.
        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()

        menuItem1.Text = "&File"
        menuItem2.Text = "&Edit"

        ' Create a MainMenu and assign MenuItem objects.
        Dim mainMenu1 As New MainMenu(New MenuItem() {menuItem1, menuItem2})

        ' Determine if mainMenu1 is currently hosted on the form.
        If (mainMenu1.IsParent) Then
            ' Set the RightToLeft property for mainMenu1.
            mainMenu1.RightToLeft = RightToLeft.Yes
            ' Bind the MainMenu to Form1.
            Menu = mainMenu1
        End If

    End Sub
    '</snippet1>

    Public Shared Sub Main()
      Application.Run(new Form1())
    End Sub

End Class
