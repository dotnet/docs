'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Public Class Test
    Private Shared Sub DisplayGenericTypeInfo(ByVal t As Type) 
        Console.WriteLine(vbCrLf & t.ToString())
        
        Console.WriteLine(vbTab & "Is this a generic type definition? " _
            & t.IsGenericTypeDefinition)
        
        Console.WriteLine(vbTab & "Is it a generic type? " _
            & t.IsGenericType)
        
        '<Snippet2>
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
        '</Snippet2>
    
    End Sub 
    
    
    Public Shared Sub Main() 
        Console.WriteLine(vbCrLf & "--- Display information about a constructed type, its")
        Console.WriteLine("    generic type definition, and an ordinary type.")
        
        ' Create a Dictionary of Test objects, using strings for the
        ' keys.       
        Dim d As New Dictionary(Of String, Test)()

        DisplayGenericTypeInfo(d.GetType())
        DisplayGenericTypeInfo(d.GetType().GetGenericTypeDefinition())
        
        ' Display information for an ordinary type.
        DisplayGenericTypeInfo(GetType(String))
    
    End Sub 'Main
End Class 'Test

' This example produces the following output:
'
'--- Display information about a constructed type, its
'    generic type definition, and an ordinary type.
'
'System.Collections.Generic.Dictionary[System.String, Test]
'        Is this a generic type definition? False
'        Is it a generic type? True
'        List type arguments (2):
'                System.String
'                Test
'
'System.Collections.Generic.Dictionary[TKey,TValue]
'        Is this a generic type definition? True
'        Is it a generic type? True
'        List type arguments (2):
'                TKey    (unassigned - parameter position 0)
'                TValue  (unassigned - parameter position 1)
'
'System.String
'        Is this a generic type definition? False
'        Is it a generic type? False
'</Snippet1>