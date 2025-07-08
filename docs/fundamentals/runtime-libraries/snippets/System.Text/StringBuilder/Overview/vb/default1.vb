' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Reflection
Imports System.Text

Module Example5
    Public Sub Main()
        Dim sb As New StringBuilder()
        ShowSBInfo(sb)
        sb.Append("This is a sentence.")
        ShowSBInfo(sb)
        For ctr As Integer = 0 To 10
            sb.Append("This is an additional sentence.")
            ShowSBInfo(sb)
        Next
    End Sub

    Public Sub ShowSBInfo(sb As StringBuilder)
        For Each prop In sb.GetType().GetProperties
            If prop.GetIndexParameters().Length = 0 Then
                Console.Write("{0}: {1:N0}    ", prop.Name, prop.GetValue(sb))
            End If
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    Capacity: 16    MaxCapacity: 2,147,483,647    Length: 0
'    Capacity: 32    MaxCapacity: 2,147,483,647    Length: 19
'    Capacity: 64    MaxCapacity: 2,147,483,647    Length: 50
'    Capacity: 128    MaxCapacity: 2,147,483,647    Length: 81
'    Capacity: 128    MaxCapacity: 2,147,483,647    Length: 112
'    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 143
'    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 174
'    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 205
'    Capacity: 256    MaxCapacity: 2,147,483,647    Length: 236
'    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 267
'    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 298
'    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 329
'    Capacity: 512    MaxCapacity: 2,147,483,647    Length: 360
' </Snippet3>
