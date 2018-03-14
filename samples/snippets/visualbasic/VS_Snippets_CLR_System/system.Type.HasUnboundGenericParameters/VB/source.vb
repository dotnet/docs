'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

' Define a base class with two type parameters.
Public Class Base(Of T, U)
End Class

' Define a derived class. The derived class inherits from a constructed
' class that meets the following criteria:
'   (1) Its generic type definition is Base<T, U>.
'   (2) It uses int for the first type parameter.
'   (3) For the second type parameter, it uses the same type that is used
'       for the type parameter of the derived class.
' Thus, the derived class is a generic type with one type parameter, but
' its base class is an open constructed type with one assigned type
' parameter and one unassigned type parameter.
Public Class Derived(Of V)
    Inherits Base(Of Integer, V)
End Class

Public Class Test
    
    Public Shared Sub Main() 
        Console.WriteLine(vbCrLf _
            & "--- Display a generic type and the open constructed")
        Console.WriteLine("    type from which it is derived.")
        
        ' Create a Type object representing the generic type definition 
        ' for the Derived type, by omitting the type argument. (For
        ' types with multiple type parameters, supply the commas but
        ' omit the type arguments.) 
        '
        Dim derivedType As Type = GetType(Derived(Of ))
        DisplayGenericTypeInfo(derivedType)
        
        ' Display its open constructed base type.
        DisplayGenericTypeInfo(derivedType.BaseType)
    
    End Sub 'Main
    
    Private Shared Sub DisplayGenericTypeInfo(ByVal t As Type) 
        Console.WriteLine(vbCrLf & "{0}", t)
        
        Console.WriteLine(vbTab & "Is this a generic type definition? " _
            & t.IsGenericTypeDefinition)
        
        Console.WriteLine(vbTab & "Is it a generic type? " _
            & t.IsGenericType)
        
        Console.WriteLine(vbTab _
            & "Does it have unassigned generic parameters? " _
            & t.ContainsGenericParameters)
        
        If t.IsGenericType Then
            ' If this is a generic type, display the type arguments.
            '
            Dim typeArguments As Type() = t.GetGenericArguments()
            
            Console.WriteLine(vbTab & "List type arguments (" _
                & typeArguments.Length & "):")
            
            For Each tParam As Type In typeArguments
                ' IsGenericParameter is true only for generic type
                ' parameters.
                '
                If tParam.IsGenericParameter Then
                    Console.WriteLine(vbTab & vbTab & tParam.ToString() _
                        & "  (unassigned - parameter position " _
                        & tParam.GenericParameterPosition & ")")
                Else
                    Console.WriteLine(vbTab & vbTab & tParam.ToString())
                End If
            Next tParam
        End If
    
    End Sub 'DisplayGenericTypeInfo
End Class 'Test

' This example produces the following output:
'
'--- Display a generic type and the open constructed
'    type from which it is derived.
'
'Derived`1[V]
'        Is this a generic type definition? True
'        Is it a generic type? True
'        Does it have unassigned generic parameters? True
'        List type arguments (1):
'                V  (unassigned - parameter position 0)
'
'Base`2[System.Int32,V]
'        Is this a generic type definition? False
'        Is it a generic type? True
'        Does it have unassigned generic parameters? True
'        List type parameters (2):
'                System.Int32
'                V  (unassigned - parameter position 0)
' 
'</Snippet1>