Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Public NotInheritable Class Form1
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
    Friend WithEvents Label1 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 64)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 276)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1})
        Me.Name = "Form1"
        Me.Text = "My Form"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeMyMainMenu()
    End Sub

    '<snippet1>
    Private Sub InitializeMyMainMenu()
        ' Create the MainMenu and the menu items to add.
        Dim mainMenu1 As New MainMenu()

        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()
        Dim menuItem3 As New MenuItem()
        Dim menuItem4 As New MenuItem()


        ' Set the caption for the menu items.
        menuItem1.Text = "File"
        menuItem2.Text = "Edit"
        menuItem3.Text = "View"

        ' Add 3 menu items to the MainMenu for displaying.
        mainMenu1.MenuItems.Add(menuItem1)
        mainMenu1.MenuItems.Add(menuItem2)
        mainMenu1.MenuItems.Add(menuItem3)

        ' Assign mainMenu1 to the form.
        Menu = mainMenu1

        ' Determine whether menuItem3 is currently being used.
        If (menuItem3.GetMainMenu() IsNot Nothing) Then
            ' Display the name of the form in which it is located.
            Label1.Text = menuItem3.GetMainMenu().GetForm().ToString()
        End If
    End Sub 'InitializeMyMainMenu 
    '</snippet1>

   Public Shared Sub Main()
      Application.Run(new Form1())
   End Sub
   
End Class
