 '<Snippet1>
Imports System
Imports System.IO
Imports System.Globalization
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Class EventLogProperties
   
   ' The main entry point for the sample application.
   Public Shared Sub Main()
      DisplayEventLogProperties()

      Console.WriteLine()
      Console.WriteLine("Enter the name of an event log to change the")
      Console.WriteLine("overflow policy (or press Enter to exit): ")
      Dim input As String = Console.ReadLine()

      If Not String.IsNullOrEmpty(input) Then
          ChangeEventLogOverflowAction(input)
      End If
   End Sub

   ' Prompt the user for the overflow policy setting.
   Shared Sub GetNewOverflowSetting(ByRef logOverflow As OverflowAction, _
                                    ByRef numDays As Int32)
   
       Console.Write("Enter the new overflow policy setting - [")
       Console.Write(" OverwriteOlder,")
       Console.Write(" DoNotOverwrite,")
       Console.Write(" OverwriteAsNeeded")
       Console.WriteLine("] : ")

       Dim input As String = Console.ReadLine()
        
       If Not String.IsNullOrEmpty(input) Then
    
           Select Case input.Trim().ToUpper(CultureInfo.InvariantCulture)
               Case "OVERWRITEOLDER"
                   logOverflow = OverflowAction.OverwriteOlder
                   Console.WriteLine("Enter the number of days to retain events: ")
                   input = Console.ReadLine()
                   if Not Int32.TryParse(input, numDays) OrElse numDays = 0 Then
                       Console.WriteLine("  Invalid input, defaulting to 7 days.")
                       numDays = 7
                   End If
               Case "DONOTOVERWRITE"
                   logOverflow = OverflowAction.DoNotOverwrite
               Case "OVERWRITEASNEEDED"
                   logOverflow = OverflowAction.OverwriteAsNeeded
               Case Else
                   Console.WriteLine("Unrecognized overflow policy value.")
           End Select
       End If

       Console.WriteLine()

   End Sub


    
   ' <Snippet2>
   Shared Sub DisplayEventLogProperties()

      ' Iterate through the current set of event log files,
      ' displaying the property settings for each file.
      Dim eventLogs As EventLog() = EventLog.GetEventLogs()
      
      Dim e As EventLog
      For Each e In  eventLogs
         Dim sizeKB As Int64 = 0
         
         Console.WriteLine()
         Console.WriteLine("{0}:", e.LogDisplayName)
         Console.WriteLine("  Log name = " + ControlChars.Tab _
                             + ControlChars.Tab + " {0}", e.Log)

         Console.WriteLine("  Number of event log entries = {0}", e.Entries.Count.ToString())
         
         ' Determine if there is an event log file for this event log.
         Dim regEventLog As RegistryKey
         regEventLog = Registry.LocalMachine.OpenSubKey( _
                ("System\CurrentControlSet\Services\EventLog\" + e.Log))

         If Not (regEventLog Is Nothing) Then

            Dim temp As Object = regEventLog.GetValue("File")
            If Not (temp Is Nothing) Then

               Console.WriteLine("  Log file path = " + ControlChars.Tab _
                                     + " {0}", temp.ToString())
               Dim file As New FileInfo(temp.ToString())
               
               ' Get the current size of the event log file.
               If file.Exists Then
                  sizeKB = file.Length / 1024
                  If file.Length Mod 1024 <> 0 Then
                     sizeKB += 1
                  End If
                  Console.WriteLine("  Current size = " + ControlChars.Tab _
                             + " {0} kilobytes", sizeKB.ToString())
               End If
            Else
               Console.WriteLine("  Log file path = " + ControlChars.Tab _
                                + " <not set>")
            End If
         End If
         
         ' Display the maximum size and overflow settings.
         sizeKB = e.MaximumKilobytes
         Console.WriteLine("  Maximum size = " + ControlChars.Tab _
                            + " {0} kilobytes", sizeKB.ToString())
         Console.WriteLine("  Overflow setting = " + ControlChars.Tab _
                            + " {0}", e.OverflowAction.ToString())
         
         Select Case e.OverflowAction
            Case OverflowAction.OverwriteOlder
               Console.WriteLine(ControlChars.Tab + _
                    " Entries are retained a minimum of {0} days.", _
                    e.MinimumRetentionDays)
            Case OverflowAction.DoNotOverwrite
               Console.WriteLine(ControlChars.Tab + _
                    " Older entries are not overwritten.")
            Case OverflowAction.OverwriteAsNeeded
               Console.WriteLine(ControlChars.Tab + _
                    " If number of entries equals max size limit, a new event log entry overwrites the oldest entry.")
            Case Else
         End Select

      Next e

   End Sub
   ' </Snippet2>

   ' <Snippet3>
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
   ' </Snippet3>

End Class
'</Snippet1>