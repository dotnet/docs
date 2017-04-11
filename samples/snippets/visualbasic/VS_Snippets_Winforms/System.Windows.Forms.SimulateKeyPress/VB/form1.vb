' <Snippet0>
Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Windows.Forms

Namespace SimulateKeyPress

    Class Form1
        Inherits Form
        Private WithEvents button1 As New Button()

        <STAThread()> _
        Public Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            button1.Location = New Point(10, 10)
            button1.TabIndex = 0
            button1.Text = "Click to automate Calculator"
            button1.AutoSize = True
            Me.Controls.Add(button1)
        End Sub

        ' <Snippet5>
        ' Get a handle to an application window.
        Declare Auto Function FindWindow Lib "USER32.DLL" ( _
            ByVal lpClassName As String, _
            ByVal lpWindowName As String) As IntPtr

        ' Activate an application window.
        Declare Auto Function SetForegroundWindow Lib "USER32.DLL" _
            (ByVal hWnd As IntPtr) As Boolean

        ' Send a series of key presses to the Calculator application.
        Private Sub button1_Click(ByVal sender As Object, _
            ByVal e As EventArgs) Handles button1.Click

            ' Get a handle to the Calculator application. The window class
            ' and window name were obtained using the Spy++ tool.
            Dim calculatorHandle As IntPtr = FindWindow("CalcFrame", "Calculator")

            ' Verify that Calculator is a running process.
            If calculatorHandle = IntPtr.Zero Then
                MsgBox("Calculator is not running.")
                Return
            End If

            ' Make Calculator the foreground application and send it 
            ' a set of calculations.
            SetForegroundWindow(calculatorHandle)
            SendKeys.SendWait("111")
            SendKeys.SendWait("*")
            SendKeys.SendWait("11")
            SendKeys.SendWait("=")
        End Sub
        ' </Snippet5>

        ' <Snippet10>
        ' Send a key to the button when the user double-clicks anywhere 
        ' on the form.
        Private Sub Form1_DoubleClick(ByVal sender As Object, _
            ByVal e As EventArgs) Handles Me.DoubleClick

            ' Send the enter key to the button, which raises the click 
            ' event for the button. This works because the tab stop of 
            ' the button is 0.
            SendKeys.Send("{ENTER}")
        End Sub
        ' </Snippet10>

    End Class
End Namespace
' </Snippet0>