 '<Snippet1>
Imports System.Security
Imports System.Threading



Class Test
    
    Shared Sub Main() 
        Dim cCallBack As New ContextCallback(AddressOf Callback)
        SecurityContext.Run(SecurityContext.Capture(), cCallBack, "Hello world.")
    End Sub
    
    Shared Sub Callback(ByVal o As Object) 
        Console.WriteLine(o)
    
    End Sub
End Class
'</Snippet1>