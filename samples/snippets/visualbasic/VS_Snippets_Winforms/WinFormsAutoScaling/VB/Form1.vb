'<SNIPPET1>
'<SNIPPET2>
Imports Microsoft.Win32
'</SNIPPET2>

Public Class Form1
    '<SNIPPET3>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler SystemEvents.UserPreferenceChanged, New UserPreferenceChangedEventHandler(AddressOf SystemEvents_UserPreferenceChangesEventHandler)
    End Sub
    '</SNIPPET3>

    '<SNIPPET4>
    Private Sub SystemEvents_UserPreferenceChangesEventHandler(ByVal sender As Object, ByVal e As UserPreferenceChangedEventArgs)
        If (e.Category = UserPreferenceCategory.Window) Then
            Me.Font = SystemFonts.IconTitleFont
        End If
    End Sub
    '</SNIPPET4>

    '<SNIPPET5>
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler SystemEvents.UserPreferenceChanged, New UserPreferenceChangedEventHandler(AddressOf SystemEvents_UserPreferenceChangesEventHandler)
    End Sub
    '</SNIPPET5>
End Class
'</SNIPPET1>