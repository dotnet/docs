' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class MyBinder
    Inherits Binder
    Public Sub New()
        MyBase.new()
    End Sub 'New
    Private Class BinderState
        Public args() As Object
    End Class 'BinderState

    Public Overrides Function BindToField(ByVal bindingAttr As BindingFlags, ByVal match() As FieldInfo, ByVal value As Object, ByVal culture As CultureInfo) As FieldInfo
        If match Is Nothing Then
            Throw New ArgumentNullException("match")
        End If
        ' Get a field for which the value parameter can be converted to the specified field type.
        Dim i As Integer
        For i = 0 To match.Length - 1
            If Not (ChangeType(value, match(i).FieldType, culture) Is Nothing) Then
                Return match(i)
            End If
        Next i
        Return Nothing
    End Function 'BindToField

    Public Overrides Function BindToMethod(ByVal bindingAttr As BindingFlags, ByVal match() As MethodBase, ByRef args() As Object, ByVal modifiers() As ParameterModifier, ByVal culture As CultureInfo, ByVal names() As String, ByRef state As Object) As MethodBase
        ' Store the arguments to the method in a state object.
        Dim myBinderState As New BinderState()
        Dim arguments() As Object = New [Object](args.Length) {}
        args.CopyTo(arguments, 0)
        myBinderState.args = arguments
        state = myBinderState

        If match Is Nothing Then
            Throw New ArgumentNullException()
        End If
        ' Find a method that has the same parameters as those of args.
        Dim i As Integer
        For i = 0 To match.Length - 1
            ' Count the number of parameters that match.
            Dim count As Integer = 0
            Dim parameters As ParameterInfo() = match(i).GetParameters()
            ' Go on to the next method if the number of parameters do not match.
            If args.Length <> parameters.Length Then
                GoTo ContinueFori
            End If
            ' Match each of the parameters that the user expects the method to have.
            Dim j As Integer
            For j = 0 To args.Length - 1
                ' If names is not null, then reorder args.
                If Not (names Is Nothing) Then
                    If names.Length <> args.Length Then
                        Throw New ArgumentException("names and args must have the same number of elements.")
                    End If
                    Dim k As Integer
                    For k = 0 To names.Length - 1
                        If String.Compare(parameters(j).Name, names(k).ToString()) = 0 Then
                            args(j) = myBinderState.args(k)
                        End If
                    Next k
                End If ' Determine whether the types specified by the user can be converted to parameter type.
                If Not (ChangeType(args(j), parameters(j).ParameterType, culture) Is Nothing) Then
                    count += 1
                Else
                    Exit For
                End If
            Next j
            ' Determine whether the method has been found.
            If count = args.Length Then
                Return match(i)
            End If
ContinueFori:
        Next i
        Return Nothing
    End Function 'BindToMethod

    Public Overrides Function ChangeType(ByVal value As Object, ByVal myChangeType As Type, ByVal culture As CultureInfo) As Object
        ' Determine whether the value parameter can be converted to a value of type myType.
        If CanConvertFrom(value.GetType(), myChangeType) Then
            ' Return the converted object.
            Return Convert.ChangeType(value, myChangeType)
            ' Return null.
        Else
            Return Nothing
        End If
    End Function 'ChangeType

    Public Overrides Sub ReorderArgumentArray(ByRef args() As Object, ByVal state As Object)
        'Redimension the array to hold the state values.
        ReDim args(CType(state, BinderState).args.Length)
        ' Return the args that had been reordered by BindToMethod.
        CType(state, BinderState).args.CopyTo(args, 0)
    End Sub 'ReorderArgumentArray

    Public Overrides Function SelectMethod(ByVal bindingAttr As BindingFlags, ByVal match() As MethodBase, ByVal types() As Type, ByVal modifiers() As ParameterModifier) As MethodBase
        If match Is Nothing Then
            Throw New ArgumentNullException("match")
        End If
        Dim i As Integer
        For i = 0 To match.Length - 1
            ' Count the number of parameters that match.
            Dim count As Integer = 0
            Dim parameters As ParameterInfo() = match(i).GetParameters()
            ' Go on to the next method if the number of parameters do not match.
            If types.Length <> parameters.Length Then
                GoTo ContinueFori
            End If
            ' Match each of the parameters that the user expects the method to have.
            Dim j As Integer
            For j = 0 To types.Length - 1
                ' Determine whether the types specified by the user can be converted to parameter type.
                If CanConvertFrom(types(j), parameters(j).ParameterType) Then
                    count += 1
                Else
                    Exit For
                End If
            Next j ' Determine whether the method has been found.
            If count = types.Length Then
                Return match(i)
            End If
ContinueFori:
        Next i
        Return Nothing
    End Function 'SelectMethod
    Public Overrides Function SelectProperty(ByVal bindingAttr As BindingFlags, ByVal match() As PropertyInfo, ByVal returnType As Type, ByVal indexes() As Type, ByVal modifiers() As ParameterModifier) As PropertyInfo
        If match Is Nothing Then
            Throw New ArgumentNullException("match")
        End If
        Dim i As Integer
        For i = 0 To match.Length - 1
            ' Count the number of indexes that match.
            Dim count As Integer = 0
            Dim parameters As ParameterInfo() = match(i).GetIndexParameters()

            ' Go on to the next property if the number of indexes do not match.
            If indexes.Length <> parameters.Length Then
                GoTo ContinueFori
            End If
            ' Match each of the indexes that the user expects the property to have.
            Dim j As Integer
            For j = 0 To indexes.Length - 1
                ' Determine whether the types specified by the user can be converted to index type.
                If CanConvertFrom(indexes(j), parameters(j).ParameterType) Then
                    count += 1
                Else
                    Exit For
                End If
            Next j ' Determine whether the property has been found.
            If count = indexes.Length Then
                ' Determine whether the return type can be converted to the properties type.
                If CanConvertFrom(returnType, match(i).PropertyType) Then
                    Return match(i)
                Else
                    GoTo ContinueFori
                End If
            End If
ContinueFori:
        Next i
        Return Nothing
    End Function 'SelectProperty

    ' Determine whether type1 can be converted to type2. Check only for primitive types.
    Private Function CanConvertFrom(ByVal type1 As Type, ByVal type2 As Type) As Boolean
        If type1.IsPrimitive And type2.IsPrimitive Then
            Dim typeCode1 As TypeCode = Type.GetTypeCode(type1)
            Dim typeCode2 As TypeCode = Type.GetTypeCode(type2)
            ' If both type1 and type2 have same type, return true.
            If typeCode1 = typeCode2 Then
                Return True
            End If ' Possible conversions from Char follow.
            If typeCode1 = TypeCode.Char Then
                Select Case typeCode2
                    Case TypeCode.UInt16
                        Return True
                    Case TypeCode.UInt32
                        Return True
                    Case TypeCode.Int32
                        Return True
                    Case TypeCode.UInt64
                        Return True
                    Case TypeCode.Int64
                        Return True
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from Byte follow.
            If typeCode1 = TypeCode.Byte Then
                Select Case typeCode2
                    Case TypeCode.Char
                        Return True
                    Case TypeCode.UInt16
                        Return True
                    Case TypeCode.Int16
                        Return True
                    Case TypeCode.UInt32
                        Return True
                    Case TypeCode.Int32
                        Return True
                    Case TypeCode.UInt64
                        Return True
                    Case TypeCode.Int64
                        Return True
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from SByte follow.
            If typeCode1 = TypeCode.SByte Then
                Select Case typeCode2
                    Case TypeCode.Int16
                        Return True
                    Case TypeCode.Int32
                        Return True
                    Case TypeCode.Int64
                        Return True
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from UInt16 follow.
            If typeCode1 = TypeCode.UInt16 Then
                Select Case typeCode2
                    Case TypeCode.UInt32
                        Return True
                    Case TypeCode.Int32
                        Return True
                    Case TypeCode.UInt64
                        Return True
                    Case TypeCode.Int64
                        Return True
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from Int16 follow.
            If typeCode1 = TypeCode.Int16 Then
                Select Case typeCode2
                    Case TypeCode.Int32
                        Return True
                    Case TypeCode.Int64
                        Return True
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from UInt32 follow.
            If typeCode1 = TypeCode.UInt32 Then
                Select Case typeCode2
                    Case TypeCode.UInt64
                        Return True
                    Case TypeCode.Int64
                        Return True
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from Int32 follow.
            If typeCode1 = TypeCode.Int32 Then
                Select Case typeCode2
                    Case TypeCode.Int64
                        Return True
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from UInt64 follow.
            If typeCode1 = TypeCode.UInt64 Then
                Select Case typeCode2
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from Int64 follow.
            If typeCode1 = TypeCode.Int64 Then
                Select Case typeCode2
                    Case TypeCode.Single
                        Return True
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If ' Possible conversions from Single follow.
            If typeCode1 = TypeCode.Single Then
                Select Case typeCode2
                    Case TypeCode.Double
                        Return True
                    Case Else
                        Return False
                End Select
            End If
        End If
        Return False
    End Function 'CanConvertFrom
End Class 'MyBinder


Public Class MyClass1
    Public myFieldB As Short
    Public myFieldA As Integer

    Public Overloads Sub MyMethod(ByVal i As Long, ByVal k As Char)
        Console.WriteLine(ControlChars.NewLine & "This is MyMethod(long i, char k).")
    End Sub 'MyMethod

    Public Overloads Sub MyMethod(ByVal i As Long, ByVal j As Long)
        Console.WriteLine(ControlChars.NewLine & "This is MyMethod(long i, long j).")
    End Sub 'MyMethod
End Class 'MyClass1


Public Class Binder_Example
    Public Shared Sub Main()
        ' Get the type of MyClass1.
        Dim myType As Type = GetType(MyClass1)
        ' Get the instance of MyClass1.
        Dim myInstance As New MyClass1()
        Console.WriteLine(ControlChars.Cr & "Displaying the results of using the MyBinder binder.")
        Console.WriteLine()
        ' Get the method information for MyMethod.
        Dim myMethod As MethodInfo = myType.GetMethod("MyMethod", BindingFlags.Public Or BindingFlags.Instance, New MyBinder(), New Type() {GetType(Short), GetType(Short)}, Nothing)
        Console.WriteLine(MyMethod)
        ' Invoke MyMethod.
        myMethod.Invoke(myInstance, BindingFlags.InvokeMethod, New MyBinder(), New [Object]() {CInt(32), CInt(32)}, CultureInfo.CurrentCulture)
    End Sub 'Main
End Class 'Binder_Example
' </Snippet1>
