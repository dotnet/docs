'<Snippet1>
Imports System
Imports System.Reflection

Public Class Example
    
    ' The following attribute indicates to the loader that assemblies 
    ' in the global assembly cache should be shared across multiple
    ' application domains.
    <LoaderOptimizationAttribute(LoaderOptimization.MultiDomainHost)> _
    Public Shared Sub Main() 
        ' Show information for the default application domain.
        ShowDomainInfo()
        
        ' Create a new application domain and display its information.
        Dim newDomain As AppDomain = AppDomain.CreateDomain("MyMultiDomain")
        newDomain.DoCallBack(AddressOf ShowDomainInfo)
    
    End Sub 'Main
    
    
    ' This method has the same signature as the CrossAppDomainDelegate,
    ' so that it can be executed easily in the new application domain.
    ' 
    Public Shared Sub ShowDomainInfo() 
        Dim ad As AppDomain = AppDomain.CurrentDomain
        Console.WriteLine()
        Console.WriteLine("FriendlyName: {0}", ad.FriendlyName)
        Console.WriteLine("Id: {0}", ad.Id)
        Console.WriteLine("IsDefaultAppDomain: {0}", ad.IsDefaultAppDomain())
    
    End Sub 
End Class
'</Snippet1>