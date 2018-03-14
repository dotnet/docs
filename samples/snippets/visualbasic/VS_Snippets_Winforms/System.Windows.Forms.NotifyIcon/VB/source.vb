' <Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

    Private contextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents menuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents notifyIcon1 As System.Windows.Forms.NotifyIcon
    Private components As System.ComponentModel.IContainer

    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub 'Main

    Public Sub New()

        Me.components = New System.ComponentModel.Container
        Me.contextMenu1 = New System.Windows.Forms.ContextMenu
        Me.menuItem1 = New System.Windows.Forms.MenuItem

        ' Initialize contextMenu1
        Me.contextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
                            {Me.menuItem1})

        ' Initialize menuItem1
        Me.menuItem1.Index = 0
        Me.menuItem1.Text = "E&xit"

        ' Set up how the form should be displayed.
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Text = "Notify Icon Example"

        ' Create the NotifyIcon.
        Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)

        ' The Icon property sets the icon that will appear
        ' in the systray for this application.
        notifyIcon1.Icon = New Icon("appicon.ico")

        ' The ContextMenu property sets the menu that will
        ' appear when the systray icon is right clicked.
        notifyIcon1.ContextMenu = Me.contextMenu1

        ' The Text property sets the text that will be displayed,
        ' in a tooltip, when the mouse hovers over the systray icon.
        notifyIcon1.Text = "Form1 (NotifyIcon example)"
        notifyIcon1.Visible = True
    End Sub 'New
    
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        ' Clean up any components being used.
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose

    Private Sub notifyIcon1_DoubleClick(Sender as object, e as EventArgs) handles notifyIcon1.DoubleClick
        ' Show the form when the user double clicks on the notify icon.

        ' Set the WindowState to normal if the form is minimized.
        if (me.WindowState = FormWindowState.Minimized) then _
            me.WindowState = FormWindowState.Normal

        ' Activate the form.
        me.Activate()
    end sub

    Private Sub menuItem1_Click(Sender as object, e as EventArgs) handles menuItem1.Click
        ' Close the form, which closes the application.
        me.Close()
    end sub

End Class 'Form1
' </Snippet1>
