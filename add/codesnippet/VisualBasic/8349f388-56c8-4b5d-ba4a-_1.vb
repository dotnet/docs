' Creates a message filter.
<SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.UnmanagedCode)> _
Public Class TestMessageFilter
    Implements IMessageFilter

    <SecurityPermission(SecurityAction.Demand)> _
    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) _
    As Boolean Implements IMessageFilter.PreFilterMessage
        ' Blocks all the messages relating to the left mouse button.
        If ((m.Msg >= 513) And (m.Msg <= 515)) Then
            Console.WriteLine("Processing the messages : " & m.Msg)
            Return True
        End If
        Return False
    End Function
End Class
