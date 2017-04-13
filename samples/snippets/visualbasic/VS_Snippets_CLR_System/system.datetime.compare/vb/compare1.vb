' Visual Basic .NET Document
Option Strict On
   
' <Snippet1>
Module Example
   Public Sub Main()
      Dim date1 As Date = #08/01/2009 12:00AM#
      Dim date2 As Date = #08/01/2009 12:00PM#
      Dim result As Integer = DateTime.Compare(date1, date2)
      Dim relationship As String
      
      If result < 0 Then
         relationship = "is earlier than"
      ElseIf result = 0 Then
         relationship = "is the same time as"         
      Else
         relationship = "is later than"
      End If
      
      Console.WriteLine("{0} {1} {2}", date1, relationship, date2)
   End Sub
End Module
' The example displays the following output:
'    8/1/2009 12:00:00 AM is earlier than 8/1/2009 12:00:00 PM
' </Snippet1>

' Dim t1 As New DateTime(100)
' Dim t2 As New DateTime(20)
' 
' If DateTime.Compare(t1, t2) > 0 Then
'     Console.WriteLine("t1 > t2")
' End If
' If DateTime.Compare(t1, t2) = 0 Then
'     Console.WriteLine("t1 == t2")
' End If
' If DateTime.Compare(t1, t2) < 0 Then
'     Console.WriteLine("t1 < t2")
' End If
' 

