'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace csTempWindowsApplication1

    Public Class Form1
        Inherits System.Windows.Forms.Form

        ' Constant value was found in the "windows.h" header file.
        Private Const WM_ACTIVATEAPP As Integer = &H1C
        Private appActive As Boolean = True

        <STAThread()> _
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub 'Main

        Public Sub New()
            MyBase.New()

            Me.Size = New System.Drawing.Size(300, 300)
            Me.Text = "Form1"
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

            ' Paint a string in different styles depending on whether the
            ' application is active.
            If (appActive) Then
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, 20, 20, 260, 50)
                e.Graphics.DrawString("Application is active", Me.Font, SystemBrushes.ActiveCaptionText, 20, 20)
            Else
                e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, 20, 20, 260, 50)
                e.Graphics.DrawString("Application is Inactive", Me.Font, SystemBrushes.ActiveCaptionText, 20, 20)
            End If
        End Sub
	<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub WndProc(ByRef m As Message)
            ' Listen for operating system messages
            Select Case (m.Msg)
                ' The WM_ACTIVATEAPP message occurs when the application
                ' becomes the active application or becomes inactive.
            Case WM_ACTIVATEAPP

                    ' The WParam value identifies what is occurring.
                    appActive = (m.WParam.ToInt32() <> 0)

                    ' Invalidate to get new text painted.
                    Me.Invalidate()

            End Select
            MyBase.WndProc(m)
        End Sub
    End Class
End Namespace
'</Snippet1>
