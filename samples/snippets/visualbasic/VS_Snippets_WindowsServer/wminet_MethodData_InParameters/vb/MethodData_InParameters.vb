'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim processClass As ManagementClass = _
            New ManagementClass("Win32_Process")
        processClass.Options.UseAmendedQualifiers = True

        ' Get the methods in the class
        Dim methods As MethodDataCollection = _
            processClass.Methods

        ' display the method names
        Console.WriteLine("Method Name: ")
        For Each method As MethodData In methods

            If (method.Name.Equals("Create")) Then

                Console.WriteLine(method.Name)
                Console.WriteLine("Description: " & _
                    method.Qualifiers("Description").Value)
                Console.WriteLine()

                Console.WriteLine("In-parameters: ")
                For Each i As PropertyData In _
                    method.InParameters.Properties

                    Console.WriteLine(i.Name)
                Next
                Console.WriteLine()

                Console.WriteLine("Out-parameters: ")
                For Each o As PropertyData In _
                    method.OutParameters.Properties

                    Console.WriteLine(o.Name)
                Next
                Console.WriteLine()

                Console.WriteLine("Qualifiers: ")
                For Each q As QualifierData In _
                    method.Qualifiers

                    Console.WriteLine(q.Name)
                Next
                Console.WriteLine()

            End If
        Next

    End Function 'Main
End Class 'Sample
'</Snippet1>