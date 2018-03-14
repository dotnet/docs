'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports Microsoft.VisualBasic


Public Class Test
    Public Shared Sub Main() 
        Console.WriteLine(vbCrLf & "--- Get the generic type that defines a constructed type.")
        
        ' Create a Dictionary of Test objects, using strings for the
        ' keys.
        Dim d As New Dictionary(Of String, Test)
        
        ' Get a Type object representing the constructed type.
        '
        Dim constructed As Type = d.GetType()
        DisplayTypeInfo(constructed)
        
        Dim generic As Type = constructed.GetGenericTypeDefinition()
        DisplayTypeInfo(generic)
    End Sub 'Main
    
    Private Shared Sub DisplayTypeInfo(ByVal t As Type) 
        Console.WriteLine(vbCrLf & t.ToString())
        Console.WriteLine(vbTab & "Is this a generic type definition? " _
            & t.IsGenericTypeDefinition)
        Console.WriteLine(vbTab & "Is it a generic type? " _
            & t.IsGenericType)
        Dim typeArguments As Type() = t.GetGenericArguments()
        Console.WriteLine(vbTab & "List type arguments (" _
            & typeArguments.Length & "):")
        For Each tParam As Type In typeArguments
            Console.WriteLine(vbTab & vbTab & tParam.ToString())
        Next tParam
    End Sub 'DisplayTypeInfo
End Class 'Test

' This example produces the following output:
'
'--- Get the generic type that defines a constructed type.
'
'System.Collections.Generic.Dictionary`2[System.String,Test]
'        Is this a generic type definition? False
'        Is it a generic type? True
'        List type arguments (2):
'                System.String
'                Test
'
'System.Collections.Generic.Dictionary`2[TKey,TValue]
'        Is this a generic type definition? True
'        Is it a generic type? True
'        List type arguments (2):
'                TKey
'                TValue
' 
'</Snippet1>