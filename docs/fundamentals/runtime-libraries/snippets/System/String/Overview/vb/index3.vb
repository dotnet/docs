' Visual Basic .NET Document
Option Strict On
Option Infer On 

' <Snippet6>
Imports System.Collections.Generic
Imports System.Globalization

Module Example14
    Public Sub Main()
        ' First sentence of The Mystery of the Yellow Room, by Leroux.
        Dim opening As String = "Ce n'est pas sans une certaine émotion que " +
                              "je commence à raconter ici les aventures " +
                              "extraordinaires de Joseph Rouletabille."
        ' Character counters.
        Dim nChars As Integer = 0
        ' Objects to store word count.
        Dim chars As New List(Of Integer)()
        Dim elements As New List(Of Integer)()

        For Each ch In opening
            ' Skip the ' character.
            If ch = ChrW(&H27) Then Continue For

            If Char.IsWhiteSpace(ch) Or Char.IsPunctuation(ch) Then
                chars.Add(nChars)
                nChars = 0
            Else
                nChars += 1
            End If
        Next

        Dim te As TextElementEnumerator = StringInfo.GetTextElementEnumerator(opening)
        Do While te.MoveNext()
            Dim s As String = te.GetTextElement()
            ' Skip the ' character.
            If s = ChrW(&H27) Then Continue Do
            If String.IsNullOrEmpty(s.Trim()) Or (s.Length = 1 AndAlso Char.IsPunctuation(Convert.ToChar(s))) Then
                elements.Add(nChars)
                nChars = 0
            Else
                nChars += 1
            End If
        Loop

        ' Display character counts.
        Console.WriteLine("{0,6} {1,20} {2,20}",
                        "Word #", "Char Objects", "Characters")
        For ctr As Integer = 0 To chars.Count - 1
            Console.WriteLine("{0,6} {1,20} {2,20}",
                           ctr, chars(ctr), elements(ctr))
        Next
    End Sub
End Module
' The example displays the following output:
'    Word #         Char Objects           Characters
'         0                    2                    2
'         1                    4                    4
'         2                    3                    3
'         3                    4                    4
'         4                    3                    3
'         5                    8                    8
'         6                    8                    7
'         7                    3                    3
'         8                    2                    2
'         9                    8                    8
'        10                    2                    1
'        11                    8                    8
'        12                    3                    3
'        13                    3                    3
'        14                    9                    9
'        15                   15                   15
'        16                    2                    2
'        17                    6                    6
'        18                   12                   12
' </Snippet6>    
