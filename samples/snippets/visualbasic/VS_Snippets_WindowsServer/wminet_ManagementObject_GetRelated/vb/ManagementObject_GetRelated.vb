'<Snippet1>
Imports System
Imports System.Management


Class Sample_ManagementClass

    Public Overloads Shared Function Main( _
        ByVal args() As String) As Integer


        Dim o As New ManagementObject( _
        "Win32_Service=""Alerter""")

        Dim b As ManagementObject
        For Each b In o.GetRelated()
            Console.WriteLine( _
            "Object related to Alerter service : {0}", _
            b.ClassPath)
        Next b

        Return 0
    End Function

End Class
'</Snippet1>