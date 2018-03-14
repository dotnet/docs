Imports System

Public Class TypedReferenceArray
        Shared Sub Main()
		Try
' <Snippet1>
		Dim ad As AppDomain  = AppDomain.CreateDomain("ChildDomain")
		ad.Load("MyAssembly")
' </Snippet1>
		Catch ex as Exception
			Console.WriteLine(ex.Message)
			Console.WriteLine(ex.StackTrace)
		End Try
	End Sub
End Class