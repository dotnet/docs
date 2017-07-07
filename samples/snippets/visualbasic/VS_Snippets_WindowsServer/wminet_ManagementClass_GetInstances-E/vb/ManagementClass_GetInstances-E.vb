'<Snippet1>
Imports System
Imports System.Management

Class Sample

    Public Overloads Shared Function _
    Main(ByVal args() As String) As Integer

        Dim opt As New EnumerationOptions
        ' Will enumerate instances of the given class and any subclasses.
        opt.EnumerateDeep = True
        Dim mngmtClass As New ManagementClass("CIM_Service")
        Dim o As ManagementObject
        For Each o In mngmtClass.GetInstances(opt)
            Console.WriteLine(o("Name"))
        Next o

    End Function
End Class
'</Snippet1>
