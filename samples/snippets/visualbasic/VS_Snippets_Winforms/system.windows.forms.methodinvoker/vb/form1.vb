Imports System
Imports System.Windows.Forms

'<Snippet1>
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        ' Create a timer that will call the ShowTime method every second.
        Dim timer As System.Threading.Timer = _
            New System.Threading.Timer(AddressOf ShowTime, Nothing, 0, 1000)
    End Sub

    Sub ShowTime(ByVal x As Object)
        ' Don't do anything if the form's handle hasn't been created 
        ' or the form has been disposed.
        If (Not Me.IsHandleCreated And Not Me.IsDisposed) Then Return

        ' Create the method invoker.
        ' The method body shows the current time in the forms title bar.
        Dim mi As MethodInvoker = AddressOf UpdateFormText

        Me.Invoke(mi)
    End Sub

    Sub UpdateFormText()
        Me.Text = DateTime.Now.ToLongTimeString()
    End Sub
End Class
'</Snippet1>
