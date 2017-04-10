Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Data
Imports System.Xml

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
        CreateMyMenu()
    End Sub
    ' <snippet1>
    Public Sub CreateMyMenu()
        ' Create a main menu object.
        Dim mainMenu1 As New MainMenu()

        ' Create empty menu item objects.
        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()

        ' Set the caption of the menu items.
        menuItem1.Text = "&File"
        menuItem2.Text = "&Edit"

        ' Add the menu items to the main menu.
        mainMenu1.MenuItems.Add(menuItem1)
        mainMenu1.MenuItems.Add(menuItem2)

        ' Add functionality to the menu items. 
        AddHandler menuItem1.Click, AddressOf Me.menuItem1_Click
        AddHandler menuItem2.Click, AddressOf Me.menuItem2_Click

        ' Assign mainMenu1 to the form.
        Me.Menu = mainMenu1

        ' Perform a click on the File menu item.
        menuItem1.PerformClick()
    End Sub 'CreateMyMenu


    Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MessageBox.Show("You clicked the File menu.", "The Event Information")
    End Sub 'menuItem1_Click


    Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MessageBox.Show("You clicked the Edit menu.", "The Event Information")
    End Sub 'menuItem2_Click
    ' </snippet1>
End Class
