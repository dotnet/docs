' <Snippet102> 

Imports System.Windows.Automation
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.IO


Namespace CSClient
	Friend Class CSClientProgram
		<DllImport("kernel32.dll")>
		Shared Function GetConsoleWindow() As IntPtr
		End Function

		Shared Sub Main(ByVal args() As String)
			' TODO  Change the path to the appropriate one for your CSProviderDLL.
			Dim fileloc As String = "C:\SampleDependencies\CSProviderDLL.dll"
			Dim a As System.Reflection.Assembly = Nothing
			Try
				a = System.Reflection.Assembly.LoadFile(fileloc)
			Catch e1 As FileNotFoundException
				Console.WriteLine(e1.Message)

			End Try
			If a IsNot Nothing Then
				Try
					ClientSettings.RegisterClientSideProviderAssembly(a.GetName())
				Catch e As ProxyAssemblyNotLoadedException
					Console.WriteLine(e.Message)
				End Try

				Dim hwnd As IntPtr = GetConsoleWindow()

				' Get an AutomationElement that represents the window. 
				Dim elementWindow As AutomationElement = AutomationElement.FromHandle(hwnd)
				Console.WriteLine("Found UI Automation client-side provider for:")

				' The name property is furnished by the client-side provider.
				Console.WriteLine(elementWindow.Current.Name)
				Console.WriteLine()
			End If
			Console.WriteLine("Press any key to exit.")
			Console.ReadLine()
		End Sub
	End Class
End Namespace
' </Snippet102>

