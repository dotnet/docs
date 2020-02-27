Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks

Class HttpClient_Example
' <Snippet1>
	' HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
    Shared ReadOnly client As HttpClient = New HttpClient()

	Private Shared Async Function Main() As Task
		' Call asynchronous network methods in a try/catch block to handle exceptions.
		Try
			Dim response As HttpResponseMessage = Await client.GetAsync("http://www.contoso.com/")
			response.EnsureSuccessStatusCode()
			Dim responseBody As String = Await response.Content.ReadAsStringAsync()
			' Above three lines can be replaced with new helper method below
			' Dim responseBody As String = Await client.GetStringAsync(uri)

			Console.WriteLine(responseBody)
		Catch e As HttpRequestException
			Console.WriteLine(Environment.NewLine & "Exception Caught!")
			Console.WriteLine("Message :{0} ", e.Message)
		End Try
	End Function
' </Snippet1>		
End Class
