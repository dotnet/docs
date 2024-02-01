' Visual Basic .NET Document
Option Strict On

Module Example15
    Public Sub Main()
        InstantiateByAssignment()
        Console.WriteLine("-----")
        CallConstructors()
        Console.WriteLine("-----")
        Concatenate()
        Console.WriteLine("-----")
        ExtractString()
        Console.WriteLine("-----")
        Formatting()
    End Sub

    Private Sub InstantiateByAssignment()
        ' <Snippet1>
        Dim string1 As String = "This is a string created by assignment."
        Console.WriteLine(string1)
        Dim string2 As String = "The path is C:\PublicDocuments\Report1.doc"
        Console.WriteLine(string2)
        ' The example displays the following output:
        '       This is a string created by assignment.
        '       The path is C:\PublicDocuments\Report1.doc      
        ' </Snippet1>
    End Sub

    Private Sub CallConstructors()
        ' <Snippet2>
        Dim chars() As Char = {"w"c, "o"c, "r"c, "d"c}

        ' Create a string from a character array.
        Dim string1 As New String(chars)
        Console.WriteLine(string1)

        ' Create a string that consists of a character repeated 20 times.
        Dim string2 As New String("c"c, 20)
        Console.WriteLine(string2)
        ' The example displays the following output:
        '       word
        '       cccccccccccccccccccc      
        ' </Snippet2> 
    End Sub

    Private Sub Concatenate()
        ' <Snippet3>
        Dim string1 As String = "Today is " + Date.Now.ToString("D") + "."
        Console.WriteLine(string1)
        Dim string2 As String = "This is one sentence. " + "This is a second. "
        string2 += "This is a third sentence."
        Console.WriteLine(string2)
        ' The example displays output like the following:
        '    Today is Tuesday, July 06, 2011.
        '    This is one sentence. This is a second. This is a third sentence.
        ' </Snippet3>
    End Sub

    Private Sub ExtractString()
        ' <Snippet4>
        Dim sentence As String = "This sentence has five words."
        ' Extract the second word.
        Dim startPosition As Integer = sentence.IndexOf(" ") + 1
        Dim word2 As String = sentence.Substring(startPosition,
                                               sentence.IndexOf(" ", startPosition) - startPosition)
        Console.WriteLine("Second word: " + word2)
        ' The example displays the following output:
        '       Second word: sentence
        ' </Snippet4>
    End Sub

    Private Sub Formatting()
        ' <Snippet5>
        Dim dateAndTime As DateTime = #07/06/2011 7:32:00AM#
        Dim temperature As Double = 68.3
        Dim result As String = String.Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.",
                                           dateAndTime, temperature)
        Console.WriteLine(result)
        ' The example displays the following output:
        '       At 7:32 AM on Wednesday, July 06, 2011, the temperature was 68.3 degrees Fahrenheit.      
        ' </Snippet5>
    End Sub
End Module

