'<snippet10>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports System.Windows.Forms.Integration

Public Class Form1
    Inherits Form

    '<snippet11>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create the ElementHost control for hosting the
        ' WPF UserControl.
        Dim host As New ElementHost()
        host.Dock = DockStyle.Fill

        ' Create the WPF UserControl.
        Dim uc As New HostingWpfUserControlInWf.UserControl1()

        ' Assign the WPF UserControl to the ElementHost control's
        ' Child property.
        host.Child = uc

        ' Add the ElementHost control to the form's
        ' collection of child controls.
        Me.Controls.Add(host)
    End Sub
    '</snippet11>

End Class
'</snippet10>
