'<Snippet1>
Imports System
Imports System.Management
' This sample demonstrates how to
' enumerate all methods in
' Win32_LogicalDisk class using
' MethodDataEnumerator object.
Class Sample_MethodDataEnumerator
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer
        Dim diskClass As New _
            ManagementClass("win32_logicaldisk")
        Dim diskEnumerator As _
             MethodDataCollection.MethodDataEnumerator = _
            diskClass.Methods.GetEnumerator()
        While diskEnumerator.MoveNext()
            Dim method As MethodData = _
                diskEnumerator.Current
            Console.WriteLine("Method = " & method.Name)
        End While
        Return 0
    End Function
End Class
'</Snippet1>