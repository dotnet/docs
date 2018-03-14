' <snippet1>
Public Class Form1

    Public Sub New()
        InitializeComponent()
        ' Form that has a button on it
        AddHandler Button1.PreviewKeyDown, AddressOf Me.button1_PreviewKeyDown
        AddHandler Button1.KeyDown, AddressOf Me.button1_KeyDown
        Button1.ContextMenuStrip = New ContextMenuStrip
        ' Add items to ContextMenuStrip
        Button1.ContextMenuStrip.Items.Add("One")
        Button1.ContextMenuStrip.Items.Add("Two")
        Button1.ContextMenuStrip.Items.Add("Three")
    End Sub

    ' By default, KeyDown does not fire for the ARROW keys
    Private Sub button1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Select Case (e.KeyCode)
            Case Keys.Down, Keys.Up
                If (Not (Button1.ContextMenuStrip) Is Nothing) Then
                    Button1.ContextMenuStrip.Show(Button1, _
                        New Point(0, Button1.Height), ToolStripDropDownDirection.BelowRight)
                End If
        End Select
    End Sub

    ' PreviewKeyDown is where you preview the key.
    ' Do not put any logic here, instead use the
    ' KeyDown event after setting IsInputKey to true.
    Private Sub button1_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        Select Case (e.KeyCode)
            Case Keys.Down, Keys.Up
                e.IsInputKey = True
        End Select
    End Sub

End Class
' </snippet1>
