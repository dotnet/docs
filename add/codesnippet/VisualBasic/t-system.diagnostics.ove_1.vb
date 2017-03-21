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