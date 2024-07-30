Imports System.Net.Http
Imports System.Net.Http.Json

Namespace HttpClientExtensionMethods

    Public Class User
        Public Property Id As Integer
        Public Property Name As String
        Public Property Username As String
        Public Property Email As String
    End Class

    Public Class Program

        Public Shared Async Function Main() As Task
            Using client As New HttpClient With {
                .BaseAddress = New Uri("https://jsonplaceholder.typicode.com")
                }

                ' Get the user information.
                Dim user1 As User = Await client.GetFromJsonAsync(Of User)("users/1")
                Console.WriteLine($"Id: {user1.Id}")
                Console.WriteLine($"Name: {user1.Name}")
                Console.WriteLine($"Username: {user1.Username}")
                Console.WriteLine($"Email: {user1.Email}")

                ' Post a new user.
                Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("users", user1)
                Console.WriteLine(
                $"{(If(response.IsSuccessStatusCode, "Success", "Error"))} - {response.StatusCode}")
            End Using
        End Function

    End Class

End Namespace

' Produces output like the following example but with different names:
'
'Id: 1
'Name: Tyler King
'Username: Tyler
'Email: Tyler@contoso.com
'Success - Created
