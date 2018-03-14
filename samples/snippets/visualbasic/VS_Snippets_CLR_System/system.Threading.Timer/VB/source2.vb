' <snippet2>
Imports System
Imports System.Threading

Public Class Example
    Private Shared ticker As Timer

    Public Shared Sub TimerMethod(state As Object)
        Console.Write(".")
    End Sub

    Public Shared Sub Main()
        ticker = New Timer(AddressOf TimerMethod, Nothing, 1000, 1000)

        Console.WriteLine("Press the Enter key to end the program.")
        Console.ReadLine()
    End Sub
End Class
' </snippet2>