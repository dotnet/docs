Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeContextMenu()

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
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = SystemIcons.Asterisk
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
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

    ' <snippet1>
    ' Initalize the NofifyIcon object's shortcut menu.
    Private Sub InitializeContextMenu()
        Dim menuList() As MenuItem = New MenuItem() _
                    {New MenuItem("Sign In"), New MenuItem("Get Help"), _
                    New MenuItem("Open")}
        Dim clickMenu As New ContextMenu(menuList)
        NotifyIcon1.ContextMenu = clickMenu
    End Sub


    ' When user clicks the left mouse button display the shortcut menu.  
    ' Use the SystemInformation.PrimaryMonitorMaximizedWindowSize property
    ' to place the menu at the lower corner of the screen.
    Private Sub NotifyIcon1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles NotifyIcon1.Click

        Dim windowSize As System.Drawing.Size = _
            SystemInformation.PrimaryMonitorMaximizedWindowSize
        Dim menuPoint As System.Drawing.Point = New System.Drawing.Point _
            (windowSize.Width - 180, windowSize.Height - 5)
        menuPoint = Me.PointToClient(menuPoint)

        NotifyIcon1.ContextMenu.Show(Me, menuPoint)
    End Sub
    ' </snippet1>

End Class
