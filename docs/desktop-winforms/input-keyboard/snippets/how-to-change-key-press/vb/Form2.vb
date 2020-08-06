Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form2

    Public Sub New()
        InitializeComponent()

        AddHandler Button1.Click, AddressOf Button1_Click

    End Sub

    '<Calculator>
    <Runtime.InteropServices.DllImport("USER32.DLL", CharSet:=Runtime.InteropServices.CharSet.Unicode)>
    Public Shared Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr : End Function

    <Runtime.InteropServices.DllImport("USER32.DLL")>
    Public Shared Function SetForegroundWindow(hWnd As IntPtr) As Boolean : End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim hCalcWindow As IntPtr = FindWindow(Nothing, "Calculator")

        If SetForegroundWindow(hCalcWindow) Then
            SendKeys.Send("10{+}10=")
        End If
    End Sub
    '</Calculator>
End Class