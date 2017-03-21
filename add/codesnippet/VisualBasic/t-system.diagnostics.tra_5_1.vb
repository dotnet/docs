    <[Event](3, Message:="loading page {1} activityID={0}", Opcode:=EventOpcode.Start, Task:=Tasks.Page, Keywords:=Keywords.Page, Level:=EventLevel.Informational)> _
    Public Sub PageStart(ByVal ID As Integer, ByVal url As String)
        If IsEnabled() Then
            WriteEvent(3, ID, url)
        End If
    End Sub 'PageStart