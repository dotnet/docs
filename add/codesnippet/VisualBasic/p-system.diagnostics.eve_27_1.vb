Imports System
Imports System.Diagnostics

Class MyEventlogClass

   Public Shared Sub Main()
      Dim myEventType As String = Nothing
      ' Associate the instance of 'EventLog' with local System Log.
      Dim myEventLog As New EventLog("System", ".")
      Console.WriteLine("1:Error")
      Console.WriteLine("2:Information")
      Console.WriteLine("3:Warning")
      Console.WriteLine("Select the Event Type")
      Dim myOption As Integer = Convert.ToInt32(Console.ReadLine())
      Select Case myOption
         Case 1
            myEventType = "Error"
         Case 2
            myEventType = "Information"
         Case 3
            myEventType = "Warning"
         Case Else
      End Select

      Dim myLogEntryCollection As EventLogEntryCollection = myEventLog.Entries
      Dim myCount As Integer = myLogEntryCollection.Count
      ' Iterate through all 'EventLogEntry' instances in 'EventLog'.
      Dim i As Integer
      For i = myCount - 1 To -1 Step -1
         Dim myLogEntry As EventLogEntry = myLogEntryCollection(i)
         ' Select the entry having desired EventType.
         If myLogEntry.EntryType.ToString().Equals(myEventType) Then
            ' Display Source of the event.
            Console.WriteLine(myLogEntry.Source + " was the source of last "& _
                             "event of type " & myLogEntry.EntryType.ToString())
            Return
         End If
      Next i

   End Sub 'Main
End Class 'MyEventlogClass