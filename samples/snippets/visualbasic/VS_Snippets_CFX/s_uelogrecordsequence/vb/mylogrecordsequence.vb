' snippet for System.IO.Log.LogRecordSequence
' <Snippet0>

Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Text
Imports System.IO.Log

Namespace MyLogRecordSequence
	Public Class MyLog
		Private logName As String = "test.log"
		Private logContainer As String = "MyExtent0"
		Private containerSize As Integer = 32 * 1024
		Private sequence As LogRecordSequence = Nothing
		Private delete As Boolean = True

		' These are used in the TailPinned event handler.
		Public Shared MySequence As LogRecordSequence = Nothing
		Public Shared AdvanceBase As Boolean = True

		Public Sub New()
		' <Snippet1>
			' Create a LogRecordSequence.
			sequence = New LogRecordSequence(Me.logName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None)

			' At least one container/extent must be added for Log Record Sequence.
			sequence.LogStore.Extents.Add(Me.logContainer, Me.containerSize)

			MySequence = sequence
		' </Snippet1>

		End Sub

		Public Sub AddExtents()
			' Add two additional extents. The extents are 
			' of the same size as the first extent.
			sequence.LogStore.Extents.Add("MyExtent1")
			sequence.LogStore.Extents.Add("MyExtent2")
		End Sub

		Public Sub EnumerateExtents()
			Dim store As LogStore = sequence.LogStore

			Console.WriteLine("Enumerating Log Extents...")
			Console.WriteLine("    Extent Count: {0} extents", store.Extents.Count)
			Console.WriteLine("    Extents Are...")
            For Each extent In store.Extents
                Console.WriteLine("      {0} ({1}, {2})", Path.GetFileName(extent.Path), extent.Size, extent.State)
            Next extent
			Console.WriteLine("    Free Extents: {0} Free", store.Extents.FreeCount)
		End Sub

		Public Sub SetLogPolicy()
			Console.WriteLine()
			Console.WriteLine("Setting current log policy...")

		 ' <Snippet2>
			' SET LOG POLICY

			Dim policy As LogPolicy = sequence.LogStore.Policy

			' Set AutoGrow policy. This enables the log to automatically grow
			' when the existing extents are full. New extents are added until
			' we reach the MaximumExtentCount extents.
			' AutoGrow policy is supported only in Windows Vista and not available in R2.

			'policy.AutoGrow = true;

			' Set the Growth Rate in terms of extents. This policy specifies
			' "how much" the log should grow. 
			policy.GrowthRate = New PolicyUnit(2, PolicyUnitType.Extents)

			' Set the AutoShrink policy. This enables the log to automatically
			' shrink if the available free space exceeds the shrink percentage. 
			' AutoGrow/shrink policy is supported only in Windows Vista and not available in R2.

			'policy.AutoShrinkPercentage = new PolicyUnit(30, PolicyUnitType.Percentage);

			' Set the PinnedTailThreshold policy.
			' A tail pinned event is triggered when there is no
			' log space available and log space may be freed by advancing the base.
			' The user must handle the tail pinned event by advancing the base of the log. 
			' If the user is not able to move the base of the log, the user should report with exception in
			' the tail pinned handler.
			' PinnedTailThreashold policy dictates the amount of space that the TailPinned event requests 
			' for advancing the base of the log. The amount of space can be in percentage or in terms of bytes 
			' which is rounded off to the nearest containers in CLFS. The default is 35 percent.


			policy.PinnedTailThreshold = New PolicyUnit(10, PolicyUnitType.Percentage)

			' Set the maximum extents the log can have.
			policy.MaximumExtentCount = 6

			' Set the minimum extents the log can have.
			policy.MinimumExtentCount = 2

			' Set the prefix for new containers that are added. 
			' when AutoGrow is enabled.
			'policy.NewExtentPrefix = "MyLogPrefix";

			' Set the suffix number for new containers that are added.
			' when AutoGrow is enabled. 
			policy.NextExtentSuffix = 3

			' Commit the log policy.
			policy.Commit()

			' Refresh updates the IO.Log policy properties with current log policy 
			' set in the log. 
			policy.Refresh()

			' LOG POLICY END
			' 
			' </Snippet2>

			'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
			' Setting up IO.Log provided capabilities...
			' 

		' <Snippet3>
			' SET RETRY APPEND

			' IO.Log provides a mechanism similar to AutoGrow.
			' If the existing log is full and an append fails, setting RetryAppend
			' invokes the CLFS policy engine to add new extents and re-tries
			' record appends. If MaximumExtent count has been reached, 
			' a SequenceFullException is thrown. 
			' 

			sequence.RetryAppend = True

			' RETRY APPEND END
		' </Snippet3>

		' <Snippet4>
			' REGISTER FOR TAILPINNED EVENT NOTIFICATIONS

			' Register for TailPinned Event by passing in an event handler.
			' An event is raised when the log full condition is reached.
			' The user should either advance the base sequence number to the 
			' nearest valid sequence number recommended in the tail pinned event or
			' report a failure that it is not able to advance the base sequence 
			' number. 
			'

			AddHandler sequence.TailPinned, AddressOf HandleTailPinned

		' </Snippet4>
			Console.WriteLine("Done...")
		End Sub

		Public Sub ShowLogPolicy()
			Console.WriteLine()
			Console.WriteLine("Showing current log policy...")

			Dim policy As LogPolicy = sequence.LogStore.Policy

			Console.WriteLine("    Minimum extent count:  {0}", policy.MinimumExtentCount)
			Console.WriteLine("    Maximum extent count:  {0}", policy.MaximumExtentCount)
			Console.WriteLine("    Growth rate:           {0}", policy.GrowthRate)
			Console.WriteLine("    Pinned tail threshold: {0}", policy.PinnedTailThreshold)
			Console.WriteLine("    Auto shrink percent:   {0}", policy.AutoShrinkPercentage)
			Console.WriteLine("    Auto grow enabled:     {0}", policy.AutoGrow)
			Console.WriteLine("    New extent prefix:     {0}", policy.NewExtentPrefix)
			Console.WriteLine("    Next extent suffix:    {0}", policy.NextExtentSuffix)

		End Sub

		' <Snippet5>
		' Append records. Appending three records.  
		Public Sub AppendRecords()
			Console.WriteLine("Appending Log Records...")
			Dim previous As SequenceNumber = SequenceNumber.Invalid

			previous = sequence.Append(CreateData("Hello World!"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)
			previous = sequence.Append(CreateData("This is my first Logging App"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)
			previous = sequence.Append(CreateData("Using LogRecordSequence..."), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)

			Console.WriteLine("Done...")
		End Sub
		' </Snippet5>


		' Read the records added to the log. 
		Public Sub ReadRecords()
			Dim enc As Encoding = Encoding.Unicode

			Console.WriteLine()

			Console.WriteLine("Reading Log Records...")
			Try
				For Each record As LogRecord In Me.sequence.ReadLogRecords(Me.sequence.BaseSequenceNumber, LogRecordEnumeratorType.Next)
					Dim data(record.Data.Length - 1) As Byte
					record.Data.Read(data, 0, CInt(Fix(record.Data.Length)))
					Dim mystr As String = enc.GetString(data)
					Console.WriteLine("    {0}", mystr)
				Next record
			Catch e As Exception
				Console.WriteLine("Exception {0} {1}", e.GetType(), e.Message)
			End Try

			Console.WriteLine()
		End Sub

		Public Sub FillLog()
			Dim append As Boolean = True

			Do While append
				Try
					sequence.Append(CreateData(16 * 1024), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)

				Catch e1 As SequenceFullException
					Console.WriteLine("Log is Full...")
					append = False
				End Try
			Loop
		End Sub

		' Dispose the record sequence and delete the log file. 
		Public Sub Cleanup()
			' Dispose the sequence
			sequence.Dispose()

			' Delete the log file.
			If delete Then
				Try
					' This deletes the base log file and all the extents associated with the log.
					LogStore.Delete(Me.logName)
				Catch e As Exception
					Console.WriteLine("Exception {0} {1}", e.GetType(), e.Message)
				End Try
			End If
		End Sub

		' Converts the given data to an Array of ArraySegment<byte> 
		Public Shared Function CreateData(ByVal str As String) As IList(Of ArraySegment(Of Byte))
			Dim enc As Encoding = Encoding.Unicode

			Dim array() As Byte = enc.GetBytes(str)

			Dim segments(0) As ArraySegment(Of Byte)
			segments(0) = New ArraySegment(Of Byte)(array)

            Return System.Array.AsReadOnly(Of ArraySegment(Of Byte))(segments)
		End Function

		Public Shared Function CreateData(ByVal size As Integer) As IList(Of ArraySegment(Of Byte))
			Dim array(size - 1) As Byte

			Dim rand As New Random()
			rand.NextBytes(array)

			Dim segments(0) As ArraySegment(Of Byte)
			segments(0) = New ArraySegment(Of Byte)(array)

            Return System.Array.AsReadOnly(Of ArraySegment(Of Byte))(segments)
		End Function

		Public Shared Function GetAdvanceBaseSeqNumber(ByVal recTargetSeqNum As SequenceNumber) As SequenceNumber
			Dim targetSequenceNumber As SequenceNumber = SequenceNumber.Invalid

			Console.WriteLine("Getting actual target sequence number...")

			' 
			' Implement the logic for returning a valid sequence number closer to
			' recommended target sequence number. 
			'

			Return targetSequenceNumber
		End Function

		Public Shared Sub HandleTailPinned(ByVal arg As Object, ByVal tailPinnedEventArgs As TailPinnedEventArgs)
			Console.WriteLine("TailPinned has fired")

			' Based on the implementation of a logging application, the log base can be moved
			' to free up more log space and if it is not possible to move the 
			' base, the application should report by throwing an exception.

			If MyLog.AdvanceBase Then
				Try
					' TailPnnedEventArgs has the recommended sequence number and its generated 
					' based on PinnedTailThreshold policy. 
					' This does not map to an actual sequence number in the record sequence
					' but an approximation and potentially frees up the threshold % log space
					' when the log base is advanced to a valid sequence number closer to the 
					' recommended sequence number. 
					' The user should use this sequence number to locate a closest valid sequence
					' number to advance the base of the log.

					Dim recommendedTargetSeqNum As SequenceNumber = tailPinnedEventArgs.TargetSequenceNumber

					' Get the actual Target sequence number.
					Dim actualTargetSeqNum As SequenceNumber = MyLog.GetAdvanceBaseSeqNumber(recommendedTargetSeqNum)

					MySequence.AdvanceBaseSequenceNumber(actualTargetSeqNum)
				Catch e As Exception
					Console.WriteLine("Exception thrown {0} {1}", e.GetType(), e.Message)
				End Try
			Else
				' Report back Error if under some conditions the log cannot
				' advance the base sequence number.

				Console.WriteLine("Reporting Error! Unable to move the base sequence number!")
				Throw New IOException()
			End If
		End Sub
	End Class

	Friend Class LogSample
		Shared Sub Main(ByVal args() As String)
			' Create log record sequence.
			Dim log As New MyLog()

			' Add additional extents.
			log.AddExtents()

			' Enumerate the current log extents.
			log.EnumerateExtents()

			' Set log policies and register for TailPinned event notifications. 
			log.SetLogPolicy()

			log.ShowLogPolicy()

			' Append a few records and read the appended records. 
			log.AppendRecords()
			log.ReadRecords()

			' Fill the Log to trigger log growth...and subsequent TailPinned notifications.
			log.FillLog()

			log.EnumerateExtents()

			log.Cleanup()
		End Sub
	End Class
End Namespace

' </Snippet0>
