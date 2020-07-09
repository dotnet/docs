Imports System.Reflection
Imports System.Globalization

Class CustomBinder
    Inherits Binder

    Public Overrides Function BindToMethod(bindingAttr As BindingFlags,
        match() As MethodBase, ByRef args As Object(),
        modIfiers() As ParameterModIfier, culture As CultureInfo,
        names() As String, ByRef state As Object) As MethodBase

        If match is Nothing Then
            Throw New ArgumentNullException("match")
        End If
        ' Arguments are not being reordered.
        state = Nothing
        ' Find a parameter match and return the first method with
        ' parameters that match the request.
        For Each mb As MethodBase in match
            Dim parameters() As ParameterInfo = mb.GetParameters()

            If ParametersMatch(parameters, args) Then
                Return mb
            End If
        Next mb
        Return Nothing
    End Function

    Public Overrides Function BindToField(bindingAttr As BindingFlags,
        match() As FieldInfo, value As Object, culture As CultureInfo) As FieldInfo
        If match Is Nothing
            Throw New ArgumentNullException("match")
        End If
        For Each fi As FieldInfo in match
            If fi.GetType() = value.GetType() Then
                Return fi
            End If
        Next fi
        Return Nothing
    End Function

    Public Overrides Function SelectMethod(bindingAttr As BindingFlags,
        match() As MethodBase, types() As Type,
        modifiers() As ParameterModifier) As MethodBase

        If match Is Nothing Then
            Throw New ArgumentNullException("match")
        End If

        ' Find a parameter match and return the first method with
        ' parameters that match the request.
        For Each mb As MethodBase In match
            Dim parameters() As ParameterInfo = mb.GetParameters()
            If ParametersMatch(parameters, types) Then
                Return mb
            End If
        Next mb

        Return Nothing
    End Function

    Public Overrides Function SelectProperty(
        bindingAttr As BindingFlags, match() As PropertyInfo,
        returnType As Type, indexes() As Type,
        modIfiers() As ParameterModIfier) As PropertyInfo

        If match Is Nothing Then
            Throw New ArgumentNullException("match")
        End If
        For Each pi As PropertyInfo In match
            If pi.GetType() = returnType And
                ParametersMatch(pi.GetIndexParameters(), indexes) Then
                Return pi
            End If
        Next pi
        Return Nothing
    End Function

    Public Overrides Function ChangeType(
        value As Object,
        myChangeType As Type,
        culture As CultureInfo) As Object

        Try
            Dim newType As Object
            newType = Convert.ChangeType(value, myChangeType)
            Return newType
            ' Throw an InvalidCastException If the conversion cannot
            ' be done by the Convert.ChangeType method.
        Catch
            Return Nothing
        End Try
    End Function

    Public Overrides Sub ReorderArgumentArray(ByRef args() As Object, state As Object)
        ' No operation is needed here because BindToMethod does not
        ' reorder the args array. The most common implementation
        ' of this method is shown below.

        ' ((BinderState)state).args.CopyTo(args, 0)
    End Sub

    ' Returns true only If the type of each object in a matches
    ' the type of each corresponding object in b.
    Private Overloads Function ParametersMatch(a() As ParameterInfo, b() As Object) As Boolean
        If a.Length <> b.Length Then
            Return false
        End If
        For i As Integer = 0 To a.Length - 1
            If a(i).ParameterType <> b(i).GetType() Then
                Return false
            End If
        Next i
        Return true
    End Function

    ' Returns true only If the type of each object in a matches
    ' the type of each corresponding enTry in b.
    Private Overloads Function ParametersMatch(a() As ParameterInfo,
        b() As Type) As Boolean

        If a.Length <> b.Length Then
            Return false
        End If
        For i As Integer = 0 To a.Length - 1
            If a(i).ParameterType <> b(i)
                Return false
            End If
        Next
        Return true
    End Function
End Class

'<snippet2>
Public Class CustomBinderDriver
    Public Shared Sub Main()
        Dim t As Type = GetType(CustomBinderDriver)
        Dim binder As New CustomBinder()
        Dim flags As BindingFlags = BindingFlags.InvokeMethod Or BindingFlags.Instance Or
            BindingFlags.Public Or BindingFlags.Static
        Dim args() As Object

        ' Case 1. Neither argument coercion nor member selection is needed.
        args = New object() {}
        t.InvokeMember("PrintBob", flags, binder, Nothing, args)

        ' Case 2. Only member selection is needed.
        args = New object() {42}
        t.InvokeMember("PrintValue", flags, binder, Nothing, args)

        ' Case 3. Only argument coercion is needed.
        args = New object() {"5.5"}
        t.InvokeMember("PrintNumber", flags, binder, Nothing, args)
    End Sub

    Public Shared Sub PrintBob()
        Console.WriteLine("PrintBob")
    End Sub

    Public Shared Sub PrintValue(value As Long)
        Console.WriteLine("PrintValue ({0})", value)
    End Sub

    Public Shared Sub PrintValue(value As String)
        Console.WriteLine("PrintValue ""{0}"")", value)
    End Sub

    Public Shared Sub PrintNumber(value As Double)
        Console.WriteLine("PrintNumber ({0})", value)
    End Sub
End Class
'</snippet2>
