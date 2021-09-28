' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
    Public Sub Main()
        ' Show hash code in current domain.
        Dim display As New DisplayString()
        display.ShowStringHashCode()

        ' Create a new app domain and show string hash code.
        Dim domain As AppDomain = AppDomain.CreateDomain("NewDomain")
        Dim display2 = CType(domain.CreateInstanceAndUnwrap(GetType(Example).Assembly.FullName,
                                                            "DisplayString"), DisplayString)
        display2.ShowStringHashCode()
    End Sub
End Module

Public Class DisplayString : Inherits MarshalByRefObject

    Private s As String = "This is a string."

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim s2 As String = TryCast(obj, String)
        If s2 Is Nothing Then
            Return False
        Else
            Return s = s2
        End If
    End Function

    Public Overloads Function Equals(str As String) As Boolean
        Return s = str
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return s.GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Return s
    End Function

    Public Sub ShowStringHashCode()
        Console.WriteLine("String '{0}' in domain '{1}': {2:X8}",
                          s, AppDomain.CurrentDomain.FriendlyName,
                          s.GetHashCode())
    End Sub
End Class
' </Snippet2>
