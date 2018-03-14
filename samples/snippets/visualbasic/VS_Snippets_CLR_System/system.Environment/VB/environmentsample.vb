Imports System.Xml
Imports System.IO
Imports System.Collections
Imports System.Reflection

'<Snippet1>
Public Class EnvironmentSample   
    
    Public Shared Sub Main()
        
        '<Snippet2>
        OuterMethod()
        '</Snippet2>

        '<Snippet6>											 			
        Console.WriteLine("Initial WS:" + Environment.WorkingSet.ToString())
        Dim i1(), i2(), i3() As Integer
        i1 = New Integer(10000) {}
        Console.WriteLine("WS 1:" + Environment.WorkingSet.ToString())
        i2 = New Integer(10000) {}
        Console.WriteLine("WS 2:" + Environment.WorkingSet.ToString())
        i3 = New Integer(10000) {}
        Console.WriteLine("WS 3:" + Environment.WorkingSet.ToString())
        '</Snippet6>											 			 
        
    End Sub 'Main
    
    '<Snippet3>		
    Shared Sub OuterMethod()
        InnerMethod()
    End Sub 'OuterMethod
    
    
    Shared Sub InnerMethod()
        Console.WriteLine(("StackTrace after calling Main()->OuterMethod()->InnerMethod():" + Environment.StackTrace))
    End Sub 'InnerMethod
    '</Snippet3>		
    
End Class 'EnvironmentSample
'</Snippet1>

