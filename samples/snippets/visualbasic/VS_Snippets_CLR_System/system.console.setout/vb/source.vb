Imports System
Imports System.IO

Public Class SetOutSample
        Shared Sub Main()
		Try
' <Snippet1>
        Console.WriteLine("Hello World")
        Dim fs As New FileStream("Test.txt", FileMode.Create)
        ' First, save the standard output.
        Dim tmp as TextWriter = Console.Out
        Dim sw As New StreamWriter(fs)
        Console.SetOut(sw)
        Console.WriteLine("Hello file")
        Console.SetOut(tmp)
        Console.WriteLine("Hello World")
        sw.Close()
' </Snippet1>
		Catch ex as Exception
			Console.WriteLine(ex.Message)
			Console.WriteLine(ex.StackTrace)
		End Try
	End Sub
End Class