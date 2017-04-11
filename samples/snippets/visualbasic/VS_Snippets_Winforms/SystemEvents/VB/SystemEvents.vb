'<snippet1>
Imports System
Imports Microsoft.Win32
Imports System.Windows.Forms

Friend Class Form1
    Inherits System.Windows.Forms.Form


    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        '<snippet2>
        'Set the SystemEvents class to receive event notification 
        'when a user preference changes, the palette changes, or 
        'when display settings change.
        AddHandler SystemEvents.UserPreferenceChanging, _
        AddressOf SystemEvents_UserPreferenceChanging

        AddHandler SystemEvents.PaletteChanged, _
        AddressOf SystemEvents_PaletteChanged

        AddHandler SystemEvents.DisplaySettingsChanged, _
        AddressOf SystemEvents_DisplaySettingsChanged
        '</snippet2>

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


    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        Me.SuspendLayout()

        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(648, 398)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub


    ' This method is called when a user preference changes.
    Private Sub SystemEvents_UserPreferenceChanging( _
    ByVal sender As Object, _
    ByVal e As UserPreferenceChangingEventArgs)

        MessageBox.Show("UserPreferenceChanging: " & _
        e.Category.ToString())
    End Sub


    ' This method is called when the palette changes.
    Private Sub SystemEvents_PaletteChanged( _
    ByVal sender As Object, _
    ByVal e As EventArgs)

        MessageBox.Show("PaletteChanged")

    End Sub


    ' This method is called when the display settings change.
    Private Sub SystemEvents_DisplaySettingsChanged( _
    ByVal sender As Object, _
    ByVal e As EventArgs)

        MessageBox.Show("The display settings changed.")

    End Sub

End Class
'</snippet1>