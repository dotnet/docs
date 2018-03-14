Imports UtilityLibraries

Module Program
    Sub Main()
        Dim rows As Integer = Console.WindowHeight

        Console.Clear()
        Do
            If Console.CursorTop >= rows OrElse Console.CursorTop = 0 Then
                Console.Clear()
                Console.WriteLine("\nPress <Enter> only to exit; otherwise, enter a string and press <Enter>:\n")
            End If
            Dim input As String = Console.ReadLine()
            If String.IsNullOrEmpty(input) Then Return

            Console.WriteLine($"Input: {input} {"Begins with uppercase? ",30}: " +
                              $"{If(input.StartsWithUpper(), "Yes", "No")} {vbCrLf}")
        Loop While True
    End Sub
End Module
