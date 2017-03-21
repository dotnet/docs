        ' ReturnTypeCustomAttributes returns an ICustomeAttributeProvider
        ' that can be used to enumerate the custom attributes of the
        ' return value. At present, there is no way to set such custom
        ' attributes, so the list is empty.
        If hello.ReturnType Is GetType(System.Void) Then
            Console.WriteLine("The method has no return type.")
        Else
            Dim caProvider As ICustomAttributeProvider = _
                hello.ReturnTypeCustomAttributes
            Dim returnAttributes() As Object = _
                caProvider.GetCustomAttributes(True)
            If returnAttributes.Length = 0 Then
                Console.WriteLine(vbCrLf _
                    & "The return type has no custom attributes.")
            Else
                Console.WriteLine(vbCrLf _
                    & "The return type has the following custom attributes:")
                For Each attr As Object In returnAttributes
                    Console.WriteLine(vbTab & attr.ToString())
                Next attr
            End If
        End If