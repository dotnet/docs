        If t.IsGenericType Then
            ' If this is a generic type, display the type arguments.
            '
            Dim typeArguments As Type() = t.GetGenericArguments()
            
            Console.WriteLine(vbTab & "List type arguments (" _
                & typeArguments.Length & "):")
            
            For Each tParam As Type In typeArguments
                ' If this is a type parameter, display its position.
                '
                If tParam.IsGenericParameter Then
                    Console.WriteLine(vbTab & vbTab & tParam.ToString() _
                        & vbTab & "(unassigned - parameter position " _
                        & tParam.GenericParameterPosition & ")")
                Else
                    Console.WriteLine(vbTab & vbTab & tParam.ToString())
                End If
            Next tParam
        End If