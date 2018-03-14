' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Public Structure OperationTime
   Public Sub New(ctr As Integer, elapsed As TimeSpan)
      Operations = ctr
      ElapsedTime = elapsed
   End Sub
   
   Public Operations As Integer
   Public ElapsedTime As TimeSpan
End Structure

Module Example
   Public Sub Main()
      Dim stringTimes As New List(Of OperationTime)()
      Dim builderTimes As New List(Of OperationTime)()
       
      ' Begin the time for a string
      Dim sTimer As New Stopwatch()
      Dim sbTimer As New Stopwatch()
      
      ' We want to include object instantiation in the timer.
      sTimer.Start()
      Dim baseS1 As String = "Beginning"
      sTimer.Stop()
      
      sbTimer.Start()
      Dim baseS2 As New StringBuilder("Beginning")
      sbTimer.Stop()
      
      ' Record time for every 10 operations for a 100 operation string concatenation.
      sTimer.Start()
      For ctr As Integer = 1 To 100
         bases1 += "a"
         If ctr Mod 10 = 0 Then
            sTimer.Stop()
            stringTimes.Add(New OperationTime(ctr, sTimer.Elapsed))
            sTimer.Start()
         End If
      Next
      sTimer.Stop()
      
      sbTimer.Start()
      For ctr As Integer = 1 To 100
         bases2.Append("a")
         If ctr Mod 10 = 0 Then
            sbTimer.Stop()
            builderTimes.Add(New OperationTime(ctr, sbTimer.Elapsed))
            sbTimer.Start()
         End If
      Next
      sbTimer.Stop()

      ' Display performance information
      Console.WriteLine("{0,10} {1,20} {2,20}", 
                        "Operations", "String Time", "StringBuilder Time")

      For ctr As Integer = 0 To stringTimes.Count - 1
         Console.WriteLine("{0,10} {1,20} {2,20}", stringTimes(ctr).Operations,
                           stringTimes(ctr).ElapsedTime, builderTimes(ctr).ElapsedTime)      
      Next 
   End Sub
End Module
' The example displays the following output:
'    Operations          String Time   StringBuilder Time
'            10     00:00:00.0000019     00:00:00.0000087
'            20     00:00:00.0000025     00:00:00.0000087
'            30     00:00:00.0000032     00:00:00.0000090
'            40     00:00:00.0000038     00:00:00.0000090
'            50     00:00:00.0000090     00:00:00.0000094
'            60     00:00:00.0000097     00:00:00.0000097
'            70     00:00:00.0000103     00:00:00.0000097
'            80     00:00:00.0000110     00:00:00.0000100
'            90     00:00:00.0000181     00:00:00.0000100
'           100     00:00:00.0000188     00:00:00.0000103
' </Snippet2>
