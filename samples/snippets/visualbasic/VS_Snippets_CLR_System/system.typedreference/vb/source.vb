Imports System
Imports System.Reflection

Public Class TypedReferenceArray
        Shared Sub Main()
		Try
' <Snippet1>
		Assembly.Load("mscorlib.dll").GetType("System.TypedReference[]")
' </Snippet1>
		Catch ex as Exception
			Console.WriteLine(ex.Message)
			Console.WriteLine(ex.StackTrace)
		End Try
	End Sub
End Class