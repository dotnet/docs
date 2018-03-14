
Imports System
Imports System.Runtime.InteropServices



Class Program

    Shared Sub Main(ByVal args() As String)
        ' <snippet1>
        ' Create an instance of an unmanged COM object.
        Dim UnmanagedComClassInstance As New UnmanagedComClass()

        ' Create a string to pass to the COM object.
        Dim helloString As String = "Hello World!"

        ' Wrap the string with the VariantWrapper class.
        Dim var As Object = New System.Runtime.InteropServices.VariantWrapper(helloString)

        ' Pass the wrapped object.
        UnmanagedComClassInstance.MethodWithStringRefParam(var)
	'</snippet1>

    End Sub 'Main  
End Class 'Program



Class UnmanagedComClass

    Public Sub New()

    End Sub 'New

    Public Sub MethodWithStringRefParam(ByRef var As Object)

    End Sub 'MethodWithStringRefParam
End Class 'UnmanagedComClass