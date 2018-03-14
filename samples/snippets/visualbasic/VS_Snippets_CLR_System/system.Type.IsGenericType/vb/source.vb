' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Reflection

' 
Public Class Base(Of T, U)
End Class

Public Class Derived(Of V) 
    Inherits Base(Of String, V)

    Public F As G(Of Derived(Of V))

    Public Class Nested
    End Class
End Class

Public Class G(Of T)
End Class 

Module Example

    Sub Main

        ' Get the generic type definition for Derived, and the base
        ' type for Derived.
        '
        Dim tDerived As Type = GetType(Derived(Of ))
        Dim tDerivedBase As Type = tDerived.BaseType

        ' Declare an array of Derived(Of Integer), and get its type.
        '
        Dim d(0) As Derived(Of Integer)
        Dim tDerivedArray As Type = d.GetType()

        ' Get a generic type parameter, the type of a field, and a
        ' type that is nested in Derived. Notice that in order to
        ' get the nested type it is necessary to either (1) specify
        ' the generic type definition Derived(Of ), as shown here,
        ' or (2) specify a type parameter for Derived.
        '
        Dim tT As Type = GetType(Base(Of ,)).GetGenericArguments()(0)
        Dim tF As Type = tDerived.GetField("F").FieldType
        Dim tNested As Type = GetType(Derived(Of ).Nested)

        DisplayGenericType(tDerived, "Derived(Of V)")
        DisplayGenericType(tDerivedBase, "Base type of Derived(Of V)")
        DisplayGenericType(tDerivedArray, "Array of Derived(Of Integer)")
        DisplayGenericType(tT, "Type parameter T from Base(Of T)")
        DisplayGenericType(tF, "Field type, G(Of Derived(Of V))")
        DisplayGenericType(tNested, "Nested type in Derived(Of V)")

    End Sub

    Sub DisplayGenericType(ByVal t As Type, ByVal caption As String)

        Console.WriteLine(vbLf & caption)
        Console.WriteLine("    Type: {0}", t)

        Console.WriteLine(vbTab & "            IsGenericType: {0}", _
            t.IsGenericType)
        Console.WriteLine(vbTab & "  IsGenericTypeDefinition: {0}", _
            t.IsGenericTypeDefinition)
        Console.WriteLine(vbTab & "ContainsGenericParameters: {0}", _
            t.ContainsGenericParameters)
        Console.WriteLine(vbTab & "       IsGenericParameter: {0}", _
            t.IsGenericParameter)

    End Sub

End Module

' This code example produces the following output:
'
'Derived(Of V)
'    Type: Derived`1[V]
'                    IsGenericType: True
'          IsGenericTypeDefinition: True
'        ContainsGenericParameters: True
'               IsGenericParameter: False
'
'Base type of Derived(Of V)
'    Type: Base`2[System.String,V]
'                    IsGenericType: True
'          IsGenericTypeDefinition: False
'        ContainsGenericParameters: True
'               IsGenericParameter: False
'
'Array of Derived(Of Integer)
'    Type: Derived`1[System.Int32][]
'                    IsGenericType: False
'          IsGenericTypeDefinition: False
'        ContainsGenericParameters: False
'               IsGenericParameter: False
'
'Type parameter T from Base(Of T)
'    Type: T
'                    IsGenericType: False
'          IsGenericTypeDefinition: False
'        ContainsGenericParameters: True
'               IsGenericParameter: True
'
'Field type, G(Of Derived(Of V))
'    Type: G`1[Derived`1[V]]
'                    IsGenericType: True
'          IsGenericTypeDefinition: False
'        ContainsGenericParameters: True
'               IsGenericParameter: False
'
'Nested type in Derived(Of V)
'    Type: Derived`1+Nested[V]
'                    IsGenericType: True
'          IsGenericTypeDefinition: True
'        ContainsGenericParameters: True
'               IsGenericParameter: False
'</Snippet1>
