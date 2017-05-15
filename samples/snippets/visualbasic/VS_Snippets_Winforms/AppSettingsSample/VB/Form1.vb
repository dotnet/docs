'<SNIPPET1>
Imports System.Configuration
Imports System.ComponentModel

Public Class Form1

    Private WithEvents frmSettings1 As New FormSettings

    '<SNIPPET2>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
            Handles MyBase.Load
        '<SNIPPET11>
        'Settings property event handlers are associated through WithEvents 
        '  and Handles combination.
        '</SNIPPET11>

        '<SNIPPET12>
        'Data bind settings properties with straightforward associations.
        Dim bndBackColor As New Binding("BackColor", frmSettings1, "FormBackColor", _
                True, DataSourceUpdateMode.OnPropertyChanged)
        Me.DataBindings.Add(bndBackColor)
        Dim bndLocation As New Binding("Location", frmSettings1, "FormLocation", _
                True, DataSourceUpdateMode.OnPropertyChanged)
        Me.DataBindings.Add(bndLocation)

        ' Assign Size property, since databinding to Size doesn't work well.
        Me.Size = frmSettings1.FormSize

        'For more complex associations, manually assign associations.
        Dim savedText As String = frmSettings1.FormText
        'Since there is no default value for FormText.
        If (savedText IsNot Nothing) Then
            Me.Text = savedText
        End If
        '</SNIPPET12>
    End Sub
    '</SNIPPET2>

    '<SNIPPET3>
    Private Sub Form1_FormClosing_1(ByVal sender As Object, ByVal e As _
            FormClosingEventArgs) Handles MyBase.FormClosing
        'Synchronize manual associations first.
        frmSettings1.FormText = Me.Text + "."c

        ' Save size settings manually.
        frmSettings1.FormSize = Me.Size

        frmSettings1.Save()
    End Sub
    '</SNIPPET3>

    '<SNIPPET4>
    Private Sub btnBackColor_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles btnBackColor.Click
        If System.Windows.Forms.DialogResult.OK = colorDialog1.ShowDialog() Then
            Dim c As Color = colorDialog1.Color
            Me.BackColor = c
        End If
    End Sub
    '</SNIPPET4>

    '<SNIPPET5>
    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles btnReset.Click
        frmSettings1.Reset()
        Me.BackColor = SystemColors.Control
    End Sub
    '</SNIPPET5>

    '<SNIPPET6>
    Private Sub btnReload_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles btnReload.Click
        frmSettings1.Reload()
    End Sub
    '</SNIPPET6>

    '<SNIPPET7>
    Private Sub frmSettings1_SettingChanging(ByVal sender As Object, ByVal e As _
            SettingChangingEventArgs) Handles frmSettings1.SettingChanging
        tbStatus.Text = e.SettingName & ": " & e.NewValue.ToString
    End Sub
    '</SNIPPET7>

    '<SNIPPET8>
    Private Sub frmSettings1_SettingsSaving(ByVal sender As Object, ByVal e As _
            CancelEventArgs) Handles frmSettings1.SettingsSaving
        'Should check for settings changes first.
        Dim dr As DialogResult = MessageBox.Show( _
            "Save current values for application settings?", "Save Settings", _
            MessageBoxButtons.YesNo)
        If (System.Windows.Forms.DialogResult.No = dr) Then
            e.Cancel = True
        End If
    End Sub
    '</SNIPPET8>
End Class

'<SNIPPET9>
'Application settings wrapper class. This class defines the settings we intend to use in our application.
NotInheritable Class FormSettings
    Inherits ApplicationSettingsBase

    <UserScopedSettingAttribute()> _
    Public Property FormText() As String
        Get
            Return CStr(Me("FormText"))
        End Get
        Set(ByVal value As String)
            Me("FormText") = value
        End Set
    End Property

    '<SNIPPET10>
    <UserScopedSettingAttribute(), DefaultSettingValueAttribute("0, 0")> _
    Public Property FormLocation() As Point
        Get
            Return CType(Me("FormLocation"), Point)
        End Get
        Set(ByVal value As Point)
            Me("FormLocation") = value
        End Set
    End Property
    '</SNIPPET10>

    <UserScopedSettingAttribute(), DefaultSettingValueAttribute("225, 200")> _
    Public Property FormSize() As Size
        Get
            Return CType(Me("FormSize"), Size)
        End Get
        Set(ByVal value As Size)
            Me("FormSize") = value
        End Set
    End Property

    <UserScopedSettingAttribute(), DefaultSettingValueAttribute("LightGray")> _
    Public Property FormBackColor() As Color
        Get
            Return CType(Me("FormBackColor"), Color)
        End Get
        Set(ByVal value As Color)
            Me("FormBackColor") = value
        End Set
    End Property
End Class
'</SNIPPET9>

'</SNIPPET1>