'<Snippet1>
Imports System
Imports System.Management

' This sample demonstrates how to
' enumerate all properties in a
' ManagementObject using
' PropertyDataEnumerator object.
Class Sample_PropertyDataEnumerator
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer
        Dim disk As New ManagementObject( _
            "Win32_LogicalDisk.DeviceID='C:'")
        Dim propertyEnumerator As _
          PropertyDataCollection.PropertyDataEnumerator _
              = disk.Properties.GetEnumerator()
        While propertyEnumerator.MoveNext()
            Dim p As PropertyData = _
                CType(propertyEnumerator.Current, PropertyData)
            Console.WriteLine("Property found: " & p.Name)
        End While
        Return 0
    End Function
End Class
'</Snippet1>