   ' Display the current event log overflow settings, and 
   ' prompt the user to input a new overflow setting.
   Shared Sub ChangeEventLogOverflowAction(logName As String)

       If EventLog.Exists(logName) Then 
           Dim inputLog As EventLog = New EventLog(logName)
           Console.WriteLine("  Event log {0}", inputLog.Log)

           Dim logOverflow As OverflowAction = inputLog.OverflowAction
           Dim numDays As Int32 = inputLog.MinimumRetentionDays

           Console.WriteLine("  Current overflow setting = {0}", _
                             logOverflow.ToString())

           ' Prompt user for a new overflow setting.
           GetNewOverflowSetting(logOverflow, numDays)

           If Not logOverflow = inputLog.OverflowAction Then
               inputLog.ModifyOverflowPolicy(logOverflow, numDays)
               Console.WriteLine("Event log overflow policy was modified successfully!")
           Else
               Console.WriteLine("Event log overflow policy was not modified.")
           End If
           
       Else
           Console.WriteLine("Event log {0} was not found.", logName)
       End If
  
   End Sub