'<Snippet1>
Imports System
Imports System.Management

Public Class Sample

    Public Shared Function Main(ByVal args() _
        As String) As Integer

        Dim opt As New EnumerationOptions

        ' Causes return of deep subclasses
        ' as opposed to only immediate ones.
        opt.EnumerateDeep = True

        Dim cls As New ManagementClass("CIM_LogicalDisk")
        Dim subclasses As ManagementObjectCollection

        subclasses = cls.GetSubclasses(opt)

        For Each subclass As ManagementClass In subclasses
            Console.WriteLine("Subclass found: {0}", _
                subclass("__CLASS"))
        Next

        Return 0
    End Function
End Class
'</Snippet1>