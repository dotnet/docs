'<Snippet1>
Imports System
Imports System.Management


Class Sample
    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim existingClass As New ManagementClass("CIM_Service")
        Dim newClass As ManagementClass

        newClass = existingClass.Derive("My_Service")
        newClass.Put()  'to commit the new class to the WMI repository.

    End Function
End Class
'</Snippet1>