' <snippet1>
' Code for building SimpleType.dll.
Imports System.Reflection
Imports System.Globalization
Imports Simple_Type

Namespace Simple_Type
    Public Class MySimpleClass
        Public Sub MyMethod(str As String, i As Integer)
            Console.WriteLine("MyMethod parameters: {0}, {1}", str, i)
        End Sub

        Public Sub MyMethod(str As String, i As Integer, j As Integer)
            Console.WriteLine("MyMethod parameters: {0}, {1}, {2}",
                str, i, j)
        End Sub
    End Class
End Namespace

Namespace Custom_Binder
    Class MyMainClass
        Shared Sub Main()
            ' Get the type of MySimpleClass.
            Dim myType As Type = GetType(MySimpleClass)

            ' Get an instance of MySimpleClass.
            Dim myInstance As New MySimpleClass()
            Dim myCustomBinder As New MyCustomBinder()

            ' Get the method information for the particular overload
            ' being sought.
            Dim myMethod As MethodInfo = myType.GetMethod("MyMethod",
                BindingFlags.Public Or BindingFlags.Instance,
                myCustomBinder, New Type() {GetType(String),
                GetType(Integer)}, Nothing)
            Console.WriteLine(myMethod.ToString())

            ' Invoke the overload.
            myType.InvokeMember("MyMethod", BindingFlags.InvokeMethod,
                myCustomBinder, myInstance,
                New Object() {"Testing...", CInt(32)})
        End Sub
    End Class

    ' ****************************************************
    '  A simple custom binder that provides no
    '  argument type conversion.
    ' ****************************************************
    Class MyCustomBinder
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
End Namespace
' </snippet1>
