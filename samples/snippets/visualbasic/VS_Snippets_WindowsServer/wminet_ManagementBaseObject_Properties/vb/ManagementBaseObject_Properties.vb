'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim processClass As New ManagementClass( _
            "Win32_Process")
        processClass.Options.UseAmendedQualifiers = True

        ' Get the properties in the class
        Dim properties As PropertyDataCollection
        properties = processClass.Properties

        ' display the properties
        Console.WriteLine("Win32_Process Property Names: ")

        For Each p As PropertyData In properties

            Console.WriteLine(p.Name)

            For Each q As QualifierData In p.Qualifiers

                If (q.Name.Equals("Description")) Then

                    Console.WriteLine( _
                        processClass.GetPropertyQualifierValue( _
                            p.Name, q.Name))
                End If

            Next
            Console.WriteLine()

        Next
    End Function
End Class
'</Snippet1>