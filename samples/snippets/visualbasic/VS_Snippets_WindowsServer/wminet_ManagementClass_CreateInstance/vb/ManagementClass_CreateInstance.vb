'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim envClass As New ManagementClass( _
            "Win32_Environment")
        Dim newInstance As ManagementObject

        newInstance = envClass.CreateInstance()
        newInstance("Name") = "testEnvironmentVariable"
        newInstance("VariableValue") = "testValue"
        newInstance("UserName") = "<SYSTEM>"
        newInstance.Put()  'to commit the new instance.

    End Function
End Class
'</Snippet1>