Public Class Reflectors
    Public Const bf As System.Reflection.BindingFlags = _
        System.Reflection.BindingFlags.DeclaredOnly Or _
        System.Reflection.BindingFlags.Public Or _
        System.Reflection.BindingFlags.NonPublic Or _
        System.Reflection.BindingFlags.Instance

    Shared Function InstantiateIt(t As Type, ParamArray args() As Object) As Object
        Try
            Dim ret As Object = t.InvokeMember(Nothing,
                       bf Or System.Reflection.BindingFlags.CreateInstance,
                       Nothing, Nothing, args)
            Return ret
        Catch ex As Exception
            '          MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Shared Function InvokeMethod(obj As Object, method As String, ParamArray args() As Object) As Object
        Try
            Dim ret As Object = obj.GetType.InvokeMember(method,
                bf Or System.Reflection.BindingFlags.InvokeMethod,
                Nothing, obj, args)
            Return ret
        Catch ex As Exception
            '            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Shared Function GetProperty(obj As Object, method As String, ParamArray args() As Object) As Object
        Dim ret As Object = obj.GetType.InvokeMember(method,
            bf Or System.Reflection.BindingFlags.GetProperty,
            Nothing, obj, args)
        Return ret
    End Function

    Shared Function GetField(obj As Object, field As String) As Object
        Dim ret As Object = obj.GetType.InvokeMember(field,
            bf Or System.Reflection.BindingFlags.GetField,
            Nothing, obj, Nothing)
        Return ret
    End Function

    Shared Function ListMembers(obj As Object) As String
        Dim ret As String = ""
        For Each m As System.Reflection.MemberInfo In obj.GetType.GetMembers(bf)
            ret &= m.Name & "    " & m.ToString & vbCrLf
        Next
        Return ret
    End Function
    Shared Function GetProperties(obj As Object) As String
        Dim ret As String = "type = " & obj.GetType.ToString & vbCrLf

        For Each m As System.Reflection.PropertyInfo In obj.GetType.GetProperties(bf Or Reflection.BindingFlags.GetProperty)
            Dim s As String
            '   Dim gm As System.Reflection.MethodInfo = m.GetGetMethod
            '  Dim ps As System.Reflection.ParameterInfo() = gm.GetParameters
            ' Dim c As Integer = ps.Length


            '   If m.GetGetMethod.GetParameters Is Nothing Then
            Try
                Dim o As Object = GetProperty(obj, m.Name)
                If o Is Nothing Then
                    s = "Nothing"
                Else
                    s = o.ToString
                End If
            Catch ex As Exception
                s = "<got error>"
            End Try
            '  Else
            '     o = "<Cannot get value; requires parameters>"
            'End If
            '     If o Is Nothing Then o = "<NOTHING>"
            ret &= m.Name & "    " & s & vbCrLf
        Next
        Return ret
    End Function
End Class
