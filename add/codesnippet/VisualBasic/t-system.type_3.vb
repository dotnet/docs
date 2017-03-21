Imports System
Imports System.Reflection

Module Example
    
    Sub Main() 

        Dim t As Type = GetType(String)
        
        Dim substr As MethodInfo = t.GetMethod("Substring", _
            New Type() { GetType(Integer), GetType(Integer) })
        
        Dim result As Object = _ 
            substr.Invoke("Hello, World!", New Object() { 7, 5 })
        Console.WriteLine("{0} returned ""{1}"".", substr, result)
    
    End Sub 
End Module

' This code example produces the following output:
'
'System.String Substring(Int32, Int32) returned "World".