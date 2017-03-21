        ' Create an instance of an unmanged COM object.
        Dim UnmanagedComClassInstance As New UnmanagedComClass()

        ' Create a string to pass to the COM object.
        Dim helloString As String = "Hello World!"

        ' Wrap the string with the VariantWrapper class.
        Dim var As Object = New System.Runtime.InteropServices.VariantWrapper(helloString)

        ' Pass the wrapped object.
        UnmanagedComClassInstance.MethodWithStringRefParam(var)