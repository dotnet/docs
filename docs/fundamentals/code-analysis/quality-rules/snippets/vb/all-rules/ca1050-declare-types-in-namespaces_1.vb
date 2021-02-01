Imports System

'<snippet1>
' Violates rule: DeclareTypesInNamespaces.
Public Class Test     

    Public Overrides Function ToString() As String        
        Return "Test does not live in a namespace!"    
    End Function 
    
End Class

Namespace ca1050

    Public Class Test

        Public Overrides Function ToString() As String
            Return "Test lives in a namespace!"
        End Function

    End Class

End Namespace
'</snippet1>

Namespace ca1050_2

    '<snippet2>
    Public Class MainHolder

        Public Shared Sub Main1050()
            Dim t1 As New Test()
            Console.WriteLine(t1.ToString())

            Dim t2 As New ca1050.Test()
            Console.WriteLine(t2.ToString())
        End Sub

    End Class
    '</snippet2>

End Namespace
