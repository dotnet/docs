'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Public Class Test
    Public Shared Sub Main()
        Console.WriteLine(vbCrLf & "--- Create a constructed type from the generic Dictionary type.")

        ' Create a type object representing the generic Dictionary 
        ' type, by omitting the type arguments (but keeping the 
        ' comma that separates them, so the compiler can infer the
        ' number of type parameters).
        Dim generic As Type = GetType(Dictionary(Of ,))
        DisplayTypeInfo(generic)

        ' Create an array of types to substitute for the type
        ' parameters of Dictionary. The key is of type string, and
        ' the type to be contained in the Dictionary is Test.
        Dim typeArgs() As Type = { GetType(String), GetType(Test) }

        ' Create a Type object representing the constructed generic
        ' type.
        Dim constructed As Type = generic.MakeGenericType(typeArgs)
        DisplayTypeInfo(constructed)

        ' Compare the type objects obtained above to type objects
        ' obtained using GetType() and GetGenericTypeDefinition().
        Console.WriteLine(vbCrLf & "--- Compare types obtained by different methods:")

        Dim t As Type = GetType(Dictionary(Of String, Test))
        Console.WriteLine(vbTab & "Are the constructed types equal? " _
            & (t Is constructed))
        Console.WriteLine(vbTab & "Are the generic types equal? " _ 
            & (t.GetGenericTypeDefinition() Is generic))
    End Sub

    Private Shared Sub DisplayTypeInfo(ByVal t As Type)
        Console.WriteLine(vbCrLf & t.ToString())

        Console.WriteLine(vbTab & "Is this a generic type definition? " _ 
            & t.IsGenericTypeDefinition)

        Console.WriteLine(vbTab & "Is it a generic type? " _ 
            & t.IsGenericType)

        Dim typeArguments() As Type = t.GetGenericArguments()
        Console.WriteLine(vbTab & "List type arguments ({0}):", _
            typeArguments.Length)
        For Each tParam As Type In typeArguments       
            Console.WriteLine(vbTab & vbTab & tParam.ToString())
        Next
    End Sub
End Class

' This example produces the following output:
'
'--- Create a constructed type from the generic Dictionary type.
'
'System.Collections.Generic.Dictionary'2[TKey,TValue]
'        Is this a generic type definition? True
'        Is it a generic type? True
'        List type arguments (2):
'                TKey
'                TValue
'
'System.Collections.Generic.Dictionary`2[System.String,Test]
'        Is this a generic type definition? False
'        Is it a generic type? True
'        List type arguments (2):
'                System.String
'                Test
'
'--- Compare types obtained by different methods:
'        Are the constructed types equal? True
'        Are the generic types equal? True
'</Snippet1>
