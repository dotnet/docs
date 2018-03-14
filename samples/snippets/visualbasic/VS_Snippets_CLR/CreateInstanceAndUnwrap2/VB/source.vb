'<Snippet1>
Imports System.Reflection

Public Class Worker
    Inherits MarshalByRefObject
    
    Public Sub PrintDomain() 
        Console.WriteLine("Object is executing in AppDomain ""{0}""", _
            AppDomain.CurrentDomain.FriendlyName)
    End Sub 
End Class 

Class Example
    
    Public Shared Sub Main() 
        ' Create an ordinary instance in the current AppDomain
        Dim localWorker As New Worker()
        localWorker.PrintDomain()
        
        ' Create a new application domain, create an instance
        ' of Worker in the application domain, and execute code
        ' there.
        Dim ad As AppDomain = AppDomain.CreateDomain("New domain")
        Dim remoteWorker As Worker = CType( _
            ad.CreateInstanceAndUnwrap( _
                GetType(Worker).Assembly.FullName, _
                "Worker"), _
            Worker)
        remoteWorker.PrintDomain()
    
    End Sub 
End Class 

' This code produces output similar to the following:
'
'Object is executing in AppDomain "source.exe"
'Object is executing in AppDomain "New domain"
'</Snippet1>