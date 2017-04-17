Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic.Constants

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
        AddContextmenu()
    End Sub

    ' <snippet1>
    Public Sub AddContextmenu()
        ' Create a shortcut menu.
        Dim m As New ContextMenu()
        Me.ContextMenu = m

        ' Create MenuItem objects.
        Dim menuItem1 As New MenuItem()
        Dim menuItem2 As New MenuItem()

        ' Set the Text property.
        menuItem1.Text = "New"
        menuItem2.Text = "Open"

        ' Add menu items to the MenuItems collection.
        m.MenuItems.Add(menuItem1)
        m.MenuItems.Add(menuItem2)

        ' Display the starting message.
        MessageBox.Show("Right-click the form to display the shortcut menu items")

        ' Add functionality to the menu items. 
        AddHandler menuItem1.Click, AddressOf Me.menuItem1_Click
        AddHandler menuItem2.Click, AddressOf Me.menuItem2_Click

    End Sub 'AddContextmenu


    Private Sub menuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim textReport As String = "You clicked the New menu item. " + vbCr + "It is contained in the following shortcut menu: " + vbCr + vbCr

        ' Get information on the shortcut menu in which menuitem1 is contained.
        textReport += ContextMenu.GetContextMenu().ToString()

        ' Display the shortcut menu information in a message box.
        MessageBox.Show(textReport, "The ContextMenu Information")
    End Sub 'menuItem1_Click


    Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim textReport As String = "You clicked the Open menu item. " + vbCr + "It is contained in the following shortcut menu: " + vbCr + vbCr

        ' Get information on the shortcut menu in which menuitem1 is contained.
        textReport += ContextMenu.GetContextMenu().ToString()

        ' Display the shortcut menu information in a message box.
        MessageBox.Show(textReport, "The ContextMenu Information")
    End Sub 'menuItem2_Click
    ' </snippet1>


End Class
