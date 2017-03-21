    <[Event](4, Opcode:=EventOpcode.Stop, Task:=Tasks.Page, Keywords:=Keywords.Page, Level:=EventLevel.Informational)> _
    Public Sub PageStop(ByVal ID As Integer)
        If IsEnabled() Then
            WriteEvent(4, ID)
        End If
    End Sub 'PageStop