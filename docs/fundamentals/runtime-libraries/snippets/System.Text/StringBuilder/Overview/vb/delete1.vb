' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Text

Module Example6
    Public Sub Main()
        Dim sb As New StringBuilder("A StringBuilder object")
        ShowSBInfo(sb)
        ' Remove "object" from the text.
        Dim textToRemove As String = "object"
        Dim pos As Integer = sb.ToString().IndexOf(textToRemove)
        If pos >= 0 Then
            sb.Remove(pos, textToRemove.Length)
            ShowSBInfo(sb)
        End If
        ' Clear the StringBuilder contents.
        sb.Clear()
        ShowSBInfo(sb)
    End Sub

    Public Sub ShowSBInfo(sb As StringBuilder)
        Console.WriteLine()
        Console.WriteLine("Value: {0}", sb.ToString())
        For Each prop In sb.GetType().GetProperties
            If prop.GetIndexParameters().Length = 0 Then
                Console.Write("{0}: {1:N0}    ", prop.Name, prop.GetValue(sb))
            End If
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    Value: A StringBuilder object
'    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 22
'    
'    Value: A StringBuilder
'    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 16
'    
'    Value:
'    Capacity: 22    MaxCapacity: 2,147,483,647    Length: 0
' </Snippet10>

