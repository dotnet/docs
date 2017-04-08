Imports System
Imports System.Drawing
Imports System.Windows.Forms

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
        InitializeMyMenu()
    End Sub
    ' <snippet1>
    Public Sub InitializeMyMenu()
        ' Create the MainMenu object.
        Dim myMainMenu As New MainMenu()

        ' Create the MenuItem objects.
        Dim fileMenu As New MenuItem("&File")
        Dim editMenu As New MenuItem("&Edit")
        Dim newFile As New MenuItem("&New")
        Dim openFile As New MenuItem("&Open")
        Dim exitProgram As New MenuItem("E&xit")

        ' Add the MenuItem objects to myMainMenu.
        myMainMenu.MenuItems.Add(fileMenu)
        myMainMenu.MenuItems.Add(editMenu)

        ' Add three submenus to the File menu.
        fileMenu.MenuItems.Add(newFile)
        fileMenu.MenuItems.Add(openFile)
        fileMenu.MenuItems.Add(exitProgram)

        ' Assign myMainMenu to the form.
        Menu = myMainMenu

        ' Remove the item "Open" from the File menu.
        fileMenu.MenuItems.Remove(openFile)
    End Sub 'InitializeMyMenu
    ' </snippet1>
End Class
