'<Snippet1>
Imports System
Imports System.Management


Public Class EventSample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim query As New WqlEventQuery
        query.EventClassName = "__InstanceCreationEvent"
        query.Condition = "TargetInstance ISA 'Win32_NTLogEvent'"
        query.GroupWithinInterval = New TimeSpan(0, 0, 10)
        Dim collection As New System.Collections.Specialized. _
            StringCollection
        collection.Add("TargetInstance.SourceName")
        query.GroupByPropertyList = collection
        query.HavingCondition = "NumberOfEvents > 25"

        MessageBox.Show(query.QueryString)

    End Function 'Main
End Class 'EventSample
'</Snippet1>