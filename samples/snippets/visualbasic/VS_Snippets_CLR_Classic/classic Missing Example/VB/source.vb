' <Snippet1>
Imports System
Imports System.Reflection

Public Module Example
    
    Sub Main()
        ' To invoke MyMethod with the default argument value, pass 
        ' Missing.Value for the optional parameter. First, get the 
        ' method.
        Dim mi As MethodInfo = _
            GetType(MissingSample).GetMethod("MyMethod")

        ' Second, create an array of parameters to pass to the method.
        ' In this case, the array contains just one element.
        Dim arguments() As Object =  { Missing.Value }

        ' Finally, invoke the method. Specify Nothing for the target
        ' object, because the method is Shared.
        mi.Invoke(Nothing, arguments)
    End Sub
    
End Module

' This code example produces the following output:
'
'k = 33
' </Snippet1>
