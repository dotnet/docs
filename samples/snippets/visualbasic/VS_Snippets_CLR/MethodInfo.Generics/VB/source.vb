'<Snippet1>
Imports System
Imports System.Reflection

'<Snippet2>
' Define a class with a generic method.
Public Class Example
    Public Shared Sub Generic(Of T)(ByVal toDisplay As T)
        Console.WriteLine(vbCrLf & "Here it is: {0}", toDisplay)
    End Sub
End Class
'</Snippet2>

Public Class Test
    Public Shared Sub Main() 
        Console.WriteLine(vbCrLf & "--- Examine a generic method.")
        
        '<Snippet3>
        ' Create a Type object representing class Example, and
        ' get a MethodInfo representing the generic method.
        '
        Dim ex As Type = GetType(Example)
        Dim mi As MethodInfo = ex.GetMethod("Generic")
        
        DisplayGenericMethodInfo(mi)
        
        ' Assign the Integer type to the type parameter of the Example 
        ' method.
        '
        Dim arguments() As Type = { GetType(Integer) }
        Dim miConstructed As MethodInfo = mi.MakeGenericMethod(arguments)
        
        DisplayGenericMethodInfo(miConstructed)
        '</Snippet3>

        ' Invoke the method.
        Dim args() As Object = { 42 }
        miConstructed.Invoke(Nothing, args)
        
        ' Invoke the method normally.
        Example.Generic(Of Integer)(42)
        
        '<Snippet4>
        ' Get the generic type definition from the constructed method,
        ' and show that it's the same as the original definition.
        '
        Dim miDef As MethodInfo = miConstructed.GetGenericMethodDefinition()
        Console.WriteLine(vbCrLf & "The definition is the same: {0}", _
            miDef Is mi)
        '</Snippet4>  
    End Sub 'Main
      
    Private Shared Sub DisplayGenericMethodInfo(ByVal mi As MethodInfo) 
        Console.WriteLine(vbCrLf & mi.ToString())
        
        '<Snippet5>
        Console.WriteLine(vbTab _
            & "Is this a generic method definition? {0}", _
            mi.IsGenericMethodDefinition)
        '</Snippet5>

        '<Snippet6>
        Console.WriteLine(vbTab & "Is it a generic method? {0}", _
            mi.IsGenericMethod)
        '</Snippet6>

        '<Snippet7>
        Console.WriteLine(vbTab _
            & "Does it have unassigned generic parameters? {0}", _
            mi.ContainsGenericParameters)
        '</Snippet7>

        '<Snippet8>
        ' If this is a generic method, display its type arguments.
        '
        If mi.IsGenericMethod Then
            Dim typeArguments As Type() = mi.GetGenericArguments()
            
            Console.WriteLine(vbTab & "List type arguments ({0}):", _
                typeArguments.Length)
            
            For Each tParam As Type In typeArguments
                ' IsGenericParameter is true only for generic type
                ' parameters.
                '
                If tParam.IsGenericParameter Then
                    Console.WriteLine(vbTab & vbTab _
                        & "{0}  parameter position: {1}" _
                        & vbCrLf & vbTab & vbTab _
                        & "   declaring method: {2}", _
                        tParam,  _
                        tParam.GenericParameterPosition, _
                        tParam.DeclaringMethod)
                Else
                    Console.WriteLine(vbTab & vbTab & tParam.ToString())
                End If
            Next tParam
        End If
        '</Snippet8>
    End Sub 
End Class 

' This example produces the following output:
'
'--- Examine a generic method.
'
'Void Generic[T](T)
'        Is this a generic method definition? True
'        Is it a generic method? True
'        Does it have unassigned generic parameters? True
'        List type arguments (1):
'                T  parameter position: 0
'                   declaring method: Void Generic[T](T)
'
'Void Generic[Int32](Int32)
'        Is this a generic method definition? False
'        Is it a generic method? True
'        Does it have unassigned generic parameters? False
'        List type arguments (1):
'                System.Int32
'
'Here it is: 42
'
'Here it is: 42
'
'The definition is the same: True
'
'</Snippet1>