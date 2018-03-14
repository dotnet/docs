'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace SimpleControlRenderingSample

    Class Form1
        Inherits Form

        Public Sub New()
            Me.Size = New Size(300, 300)
            Dim ComboBox1 As New CustomComboBoxArrow()
            Controls.Add(ComboBox1)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomComboBoxArrow
        Inherits Control

        Public Sub New()
            Me.Location = New Point(50, 50)
            Me.Size = New Size(40, 40)
        End Sub 'New

        '<Snippet10>
        ' Render the drop-down arrow with or without visual styles.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            If Not ComboBoxRenderer.IsSupported Then
                ControlPaint.DrawComboButton(e.Graphics, _
                    Me.ClientRectangle, ButtonState.Normal)
            Else
                ComboBoxRenderer.DrawDropDownButton(e.Graphics, _
                    Me.ClientRectangle, ComboBoxState.Normal)
            End If
        End Sub
        '</Snippet10>

    End Class
End Namespace
'</Snippet0>