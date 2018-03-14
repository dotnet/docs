'<Snippet1>
Imports System
Imports System.Management


Public Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        ' Get the WMI class
        Dim mClass As ManagementClass = _
            New ManagementClass("Win32_Service")

        mClass.Options.UseAmendedQualifiers = True

        ' Get the Qualifiers for the class
        Dim qualifiers As QualifierDataCollection = _
            mClass.Qualifiers()

        ' display the Qualifier names
        Console.WriteLine(mClass.ClassPath.ClassName & _
            " Qualifiers: ")
        For Each q As QualifierData In qualifiers
            Console.WriteLine(q.Name)
        Next

        Console.WriteLine()

        Console.WriteLine("Class Description: ")
        Console.WriteLine( _
            mClass.Qualifiers("Description").Value)


    End Function
End Class
'</Snippet1>