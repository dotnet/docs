' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Text

Module Example7
    Public Sub Main()
        ' Create a StringBuilder object with no text.
        Dim sb As New StringBuilder()
        ' Append some text.
        sb.Append("*"c, 10).Append(" Adding Text to a StringBuilder Object ").Append("*"c, 10)
        sb.AppendLine()
        sb.AppendLine()
        sb.AppendLine("Some code points and their corresponding characters:")
        ' Append some formatted text.
        For ctr = 50 To 60
            sb.AppendFormat("{0,12:X4} {1,12}", ctr, Convert.ToChar(ctr))
            sb.AppendLine()
        Next
        ' Find the end of the introduction to the column.
        Dim pos As Integer = sb.ToString().IndexOf("characters:") + 11 +
                           Environment.NewLine.Length
        ' Insert a column header.
        sb.Insert(pos, String.Format("{2}{0,12:X4} {1,12}{2}", "Code Unit",
                                   "Character", vbCrLf))

        ' Convert the StringBuilder to a string and display it.      
        Console.WriteLine(sb.ToString())
    End Sub
End Module
' The example displays the following output:
'       ********** Adding Text to a StringBuilder Object **********
'       
'       Some code points and their corresponding characters:
'       
'          Code Unit    Character
'               0032            2
'               0033            3
'               0034            4
'               0035            5
'               0036            6
'               0037            7
'               0038            8
'               0039            9
'               003A            :
'               003B            ;
'               003C            <
' </Snippet9>
