'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim osClass As ManagementClass = _
            New ManagementClass("Win32_OperatingSystem")

        osClass.Options.UseAmendedQualifiers = True

        ' Get the Properties in the class
        Dim properties As PropertyDataCollection = _
            osClass.Properties

        ' display the Property names
        Console.WriteLine("Property Name: ")
        For Each p As PropertyData In properties

            Console.WriteLine( _
                "---------------------------------------")
            Console.WriteLine(p.Name)
            Console.WriteLine("Description: " & _
                p.Qualifiers("Description").Value)
            Console.WriteLine()

            Console.WriteLine("Type: ")
            Console.WriteLine(p.Type)

            Console.WriteLine()

            Console.WriteLine("Qualifiers: ")
            For Each q As QualifierData In _
                p.Qualifiers

                Console.WriteLine(q.Name)
            Next
            Console.WriteLine()

            For Each c As ManagementObject In osClass.GetInstances()

                Console.WriteLine("Value: ")
                Console.WriteLine( _
                    c.Properties(p.Name.ToString()).Value)

                Console.WriteLine()
            Next
        Next

    End Function
End Class
'</Snippet1>