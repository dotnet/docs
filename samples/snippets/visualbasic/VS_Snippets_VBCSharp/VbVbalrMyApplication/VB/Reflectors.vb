Public Class Reflectors
    Public Const bf As System.Reflection.BindingFlags = _
        System.Reflection.BindingFlags.DeclaredOnly Or _
        System.Reflection.BindingFlags.Public Or _
        System.Reflection.BindingFlags.NonPublic Or _
        System.Reflection.BindingFlags.Instance

    Shared Function InstantiateIt(ByVal t As Type, ByVal ParamArray args() As Object) As Object
        Try
            Dim ret As Object = t.InvokeMember(Nothing, _
                       bf Or System.Reflection.BindingFlags.CreateInstance, _
                       Nothing, Nothing, args)
            Return ret
        Catch ex As Exception
            '          MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Shared Function InvokeMethod(ByVal obj As Object, ByVal method As String, ByVal ParamArray args() As Object) As Object
        Try
            Dim ret As Object = obj.GetType.InvokeMember(method, _
                bf Or System.Reflection.BindingFlags.InvokeMethod, _
                Nothing, obj, args)
            Return ret
        Catch ex As Exception
            '            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function

    Shared Function GetProperty(ByVal obj As Object, ByVal method As String, ByVal ParamArray args() As Object) As Object
        Dim ret As Object = obj.GetType.InvokeMember(method, _
            bf Or System.Reflection.BindingFlags.GetProperty, _
            Nothing, obj, args)
        Return ret
    End Function

    Shared Function GetField(ByVal obj As Object, ByVal field As String) As Object
        Dim ret As Object = obj.GetType.InvokeMember(field, _
            bf Or System.Reflection.BindingFlags.GetField, _
            Nothing, obj, Nothing)
        Return ret
    End Function

    Shared Function ListMembers(ByVal obj As Object) As String
        Dim ret As String = ""
        For Each m As System.Reflection.MemberInfo In obj.GetType.GetMembers(bf)
            ret &= m.Name & "    " & m.ToString & vbCrLf
        Next
        Return ret
    End Function
    Shared Function GetProperties(ByVal obj As Object) As String
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
