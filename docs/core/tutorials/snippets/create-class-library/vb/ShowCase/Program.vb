Imports UtilityLibraries

Module Program
    Dim row As Integer = 0

    Sub Main()
        Do
            If row = 0 OrElse row >= 25 Then ResetConsole()

            Dim input As String = Console.ReadLine()
            If String.IsNullOrEmpty(input) Then Return

            Console.WriteLine($"Input: {input} {"Begins with uppercase? ",30}: " +
                              $"{If(input.StartsWithUpper(), "Yes", "No")} {Environment.NewLine}")
            row += 3
        Loop While True
    End Sub

    Private Sub ResetConsole()
        If row > 0 Then
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End If   
        Console.Clear()
        Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit; otherwise, enter a string and press <Enter>:{Environment.NewLine}")
        row = 3  
    End Sub
End Module
