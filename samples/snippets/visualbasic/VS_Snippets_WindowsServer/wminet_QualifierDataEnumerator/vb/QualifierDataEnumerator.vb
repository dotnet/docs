'<Snippet1>
Imports System
Imports System.Management

' This sample demonstrates how to
' enumerate qualifiers of a ManagementClass
' using QualifierDataEnumerator object.
Class Sample_QualifierDataEnumerator
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer
        Dim diskClass As New _
            ManagementClass("win32_logicaldisk")
        diskClass.Options.UseAmendedQualifiers = True
        Dim diskQualifier As _
            QualifierDataCollection = diskClass.Qualifiers
        Dim qualifierEnumerator As _
            QualifierDataCollection.QualifierDataEnumerator = _
                diskQualifier.GetEnumerator()
        While qualifierEnumerator.MoveNext()
            Console.WriteLine( _
                qualifierEnumerator.Current.Name & _
                " = " & qualifierEnumerator.Current.Value)
        End While
        Return 0
    End Function
End Class
'</Snippet1>