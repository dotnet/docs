 '<Snippet1>
Imports System
Imports System.Security
Imports System.Threading



Class Test
    
    Shared Sub Main() 
        Dim cCallBack As New ContextCallback(AddressOf Callback)
        SecurityContext.Run(SecurityContext.Capture(), cCallBack, "Hello world.")
    End Sub 'Main
    
    Shared Sub Callback(ByVal o As Object) 
        Console.WriteLine(o)
    
    End Sub 'Callback
End Class 'Test
'</Snippet1>