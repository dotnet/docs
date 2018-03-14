
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Text
Imports System.IO.Log

' This sample demonstrate how to create a multiplexed log with two streams. 
' Doing interleaving appends and reading the log records back for both 
' the streams.

Namespace MyMultiplexLog
	Friend Class MyMultiplexLog
		Private Shared Sub Main2(ByVal args() As String)
			Try
				Dim myLog As String = "MyMultiplexLog"
				Dim logStream1 As String = "MyMultiplexLog::MyLogStream1"
				Dim logStream2 As String = "MyMultiplexLog::MyLogStream2"
				Dim containerSize As Integer = 32 * 1024

				Dim sequence1 As LogRecordSequence = Nothing
				Dim sequence2 As LogRecordSequence = Nothing

				Console.WriteLine("Creating Multiplexed log with two streams")

		' <Snippet11>
		' Create log stream 1.
				sequence1 = New LogRecordSequence(logStream1, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)

		' Log Extents are shared between the two streams. 
		' Add two extents to sequence1.
				sequence1.LogStore.Extents.Add("MyExtent0", containerSize)
				sequence1.LogStore.Extents.Add("MyExtent1")

		' Create log stream 2.
				sequence2 = New LogRecordSequence(logStream2, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
		' </Snippet11>

		' <Snippet13>
		' Start Appending in two streams with interleaving appends.

				Dim previous1 As SequenceNumber = SequenceNumber.Invalid
				Dim previous2 As SequenceNumber = SequenceNumber.Invalid

				Console.WriteLine("Appending interleaving records in stream1 and stream2...")
				Console.WriteLine()
		' Append two records in stream1.
				previous1 = sequence1.Append(CreateData("MyLogStream1: Hello World!"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)
				previous1 = sequence1.Append(CreateData("MyLogStream1: This is my first Logging App"), previous1, previous1, RecordAppendOptions.ForceFlush)

		' Append two records in stream2.
				previous2 = sequence2.Append(CreateData("MyLogStream2: Hello World!"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)
				previous2 = sequence2.Append(CreateData("MyLogStream2: This is my first Logging App"), previous2, previous2, RecordAppendOptions.ForceFlush)

		' Append the third record in stream1.
				previous1 = sequence1.Append(CreateData("MyLogStream1: Using LogRecordSequence..."), previous1, previous1, RecordAppendOptions.ForceFlush)

		' Append the third record in stream2.
				previous2 = sequence2.Append(CreateData("MyLogStream2: Using LogRecordSequence..."), previous2, previous2, RecordAppendOptions.ForceFlush)
		' </Snippet13>

		' Read the log records from stream1 and stream2.

				Dim enc As Encoding = Encoding.Unicode
				Console.WriteLine()
				Console.WriteLine("Reading Log Records from stream1...")
				' <Snippet10>
                For Each record In sequence1.ReadLogRecords(sequence1.BaseSequenceNumber, LogRecordEnumeratorType.Next)
                    Dim data(record.Data.Length - 1) As Byte
                    record.Data.Read(data, 0, CInt(Fix(record.Data.Length)))
                    Dim mystr As String = enc.GetString(data)
                    Console.WriteLine("    {0}", mystr)
                Next record
				' </Snippet10>

				Console.WriteLine()
				Console.WriteLine("Reading the log records from stream2...")
                For Each record In sequence2.ReadLogRecords(sequence2.BaseSequenceNumber, LogRecordEnumeratorType.Next)
                    Dim data(record.Data.Length - 1) As Byte
                    record.Data.Read(data, 0, CInt(Fix(record.Data.Length)))
                    Dim mystr As String = enc.GetString(data)
                    Console.WriteLine("    {0}", mystr)
                Next record
				' <Snippet12>
				Console.WriteLine()

		' Cleanup...
				sequence1.Dispose()
				sequence2.Dispose()
				' </Snippet12>

				LogStore.Delete(myLog)

				Console.WriteLine("Done...")
			Catch e As Exception
				Console.WriteLine("Exception thrown {0} {1}", e.GetType(), e.Message)
			End Try
		End Sub

	' Converts the given data to Array of ArraySegment<byte> 
		Public Shared Function CreateData(ByVal str As String) As IList(Of ArraySegment(Of Byte))
			Dim enc As Encoding = Encoding.Unicode

			Dim array() As Byte = enc.GetBytes(str)

			Dim segments(0) As ArraySegment(Of Byte)
			segments(0) = New ArraySegment(Of Byte)(array)

            Return System.Array.AsReadOnly(Of ArraySegment(Of Byte))(segments)
		End Function

	End Class
End Namespace

