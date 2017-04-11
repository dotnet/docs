Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

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
    Private components As System.ComponentModel.IContainer

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
        CreateMyMenuItems()
    End Sub
    ' <snippet1>
    Public Sub CreateMyMenuItems()
        ' Craete a main menu object.
        Dim mainMenu1 As New MainMenu()

        ' Create three top-level menu items.
        Dim menuItem1 As New MenuItem("&File")
        Dim menuItem2 As New MenuItem("&New")
        Dim menuItem3 As New MenuItem("&Open")

        ' Add menuItem1 to the main menu.
        mainMenu1.MenuItems.Add(menuItem1)

        ' Add menuItem2 and menuItem3 to menuItem1.
        menuItem1.MenuItems.Add(menuItem2)
        menuItem1.MenuItems.Add(menuItem3)

        ' Check to see if menuItem3 has a parent menu.
        If (menuItem3.Parent IsNot Nothing) Then
            MessageBox.Show(menuItem3.Parent.ToString() + ".", "Parent Menu Information of menuItem3")
        Else
            MessageBox.Show("No parent menu.")
        End If
        ' Assign mainMenu1 to the form.
        Me.Menu = mainMenu1
    End Sub 'CreateMyMenuItems
    ' </snippet1>
End Class
