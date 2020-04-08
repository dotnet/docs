'<Snippet1>
Imports System.Threading
Imports System.Threading.Tasks

'Use the following config settings to enable the throwing of unobserved exceptions.
'<configuration>
'  <startup>
'    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
'  </startup>
'  <runtime>
'    <ThrowUnobservedTaskExceptions enabled="true"/>
'  </runtime>
'</configuration>

Public Class Example
	Shared Sub Main()
        Task.Run(Sub() Throw New InvalidOperationException("test"))
		Do
			Thread.Sleep(100)
			GC.Collect()
			GC.WaitForPendingFinalizers()
		Loop
	End Sub
End Class
'</Snippet1>