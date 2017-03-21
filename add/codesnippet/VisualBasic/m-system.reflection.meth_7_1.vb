        ' If this is a generic method, display its type arguments.
        '
        If mi.IsGenericMethod Then
            Dim typeArguments As Type() = mi.GetGenericArguments()
            
            Console.WriteLine(vbTab & "List type arguments ({0}):", _
                typeArguments.Length)
            
            For Each tParam As Type In typeArguments
                ' IsGenericParameter is true only for generic type
                ' parameters.
                '
                If tParam.IsGenericParameter Then
                    Console.WriteLine(vbTab & vbTab _
                        & "{0}  parameter position: {1}" _
                        & vbCrLf & vbTab & vbTab _
                        & "   declaring method: {2}", _
                        tParam,  _
                        tParam.GenericParameterPosition, _
                        tParam.DeclaringMethod)
                Else
                    Console.WriteLine(vbTab & vbTab & tParam.ToString())
                End If
            Next tParam
        End If