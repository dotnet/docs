'<Snippet1>
Imports System
Imports System.Management

' This sample demonstrates how to
' enumerate all logical disks
' using ManagementObjectEnumerator object.
Class Sample_ManagementObjectEnumerator
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer
        Dim diskClass As New _
            ManagementClass("Win32_LogicalDisk")
        Dim disks As ManagementObjectCollection = _
            diskClass.GetInstances()
        Dim disksEnumerator As _
        ManagementObjectCollection. _
            ManagementObjectEnumerator = _
            disks.GetEnumerator()
        While disksEnumerator.MoveNext()
            Dim disk As ManagementObject = _
            CType(disksEnumerator.Current, _
                ManagementObject)
            Console.WriteLine("Disk found: " & disk("deviceid"))
        End While
        Return 0
    End Function
End Class
'</Snippet1>