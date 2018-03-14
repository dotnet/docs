'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim c As ManagementClass
        c = New ManagementClass("CIM_LogicalDisk")

        For Each r As ManagementClass In c.GetSubclasses()

            Console.WriteLine( _
                "Instances of {0} are sub-classes", _
                r("__CLASS"))
        Next

        For Each r As ManagementClass In c.GetRelationshipClasses()

            Console.WriteLine( _
                "{0} is a relationship class to " & _
                c.ClassPath.ClassName, _
                r("__CLASS"))

            For Each related As ManagementClass In c.GetRelatedClasses( _
                Nothing, r.ClassPath.ClassName, "Association", Nothing, _
                Nothing, Nothing, Nothing)

                Console.WriteLine( _
                    "{0} is related to " & c.ClassPath.ClassName, _
                    related.ClassPath.ClassName)
            Next
        Next


    End Function
End Class
'</Snippet1>