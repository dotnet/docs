Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Diagnostics.Tracing


Class Program
    Public Shared Sub Main(args As String())
    End Sub

    '<snippet1>
    <EventSource(Name:="Litware-ProductName-ComponentName")> _
    Public NotInheritable Class LitwareComponentNameEventSource
        Inherits EventSource
        <[Event](1, Task:=Tasks.Request, Opcode:=EventOpcode.Send)> _
        Public Sub RequestStart(relatedActivityId As Guid, reqId As Integer, url As String)
            WriteEventWithRelatedActivityId(1, relatedActivityId, reqId, url)
        End Sub

    End Class

    '</snippet1>
    '<snippet5>
    <EventSource(Name:="Litware-ProductName-ComponentName")> _
    Public NotInheritable Class LitwareComponentNameEventSource
        Inherits EventSource
        <[Event](1, Task:=Tasks.Request, Opcode:=EventOpcode.Send)> _
        Public Sub RequestStart(relatedActivityId As Guid, reqId As Integer, url As String)
            WriteEventWithRelatedActivityIdCore(1, relatedActivityId, reqId, url)
        End Sub

    End Class

    '</snippet5>
    

    '<snippet3>
#Region "Keywords / Task / Opcodes"
    Public NotInheritable Class Tasks
        Private Sub New()
        End Sub
        Public Const Request As EventTask = DirectCast(&H1, EventTask)
    End Class
#End Region
    '</snippet3>

    '<snippet4>
    <[Event](2, Level:=EventLevel.Informational)> _
    Public Sub Info1(arg1 As String)
        MyBase.WriteEvent(2, arg1)
    End Sub

    '</snippet4>

End Class



