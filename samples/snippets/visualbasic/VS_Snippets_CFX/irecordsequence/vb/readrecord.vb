'<snippet0>
Imports System
Imports System.IO
Imports System.IO.Log
Imports System.Collections.Generic
Imports System.Text


Namespace MyFileRecordSequence


Friend Class ReadRecordsSample
	Private Shared Function AppendRecord(ByVal sequence As IRecordSequence, ByVal message As String, ByVal user As SequenceNumber, ByVal previous As SequenceNumber) As SequenceNumber
		Dim data As New MemoryStream()
		Dim writer As New BinaryWriter(data)
		writer.Write(message)
		Dim segments() As ArraySegment(Of Byte)
		segments = New ArraySegment(Of Byte)(0){}
		segments(0) = New ArraySegment(Of Byte)(data.GetBuffer(), 0, CInt(Fix(data.Length)))
		Return sequence.Append(segments, user, previous,RecordAppendOptions.None)
	End Function
	Public Shared Sub Main(ByVal args() As String)
		Dim sequence As IRecordSequence
		sequence = New FileRecordSequence(args(0))
		Dim a, b, c, d As SequenceNumber
		a = AppendRecord(sequence, "This is record A", SequenceNumber.Invalid, SequenceNumber.Invalid)
		Console.WriteLine("Record A has sequence number System.IO.Log", a)
		b = AppendRecord(sequence, "This is record B", a, a)
		Console.WriteLine("Record B has sequence number System.IO.Log", b)
		c = AppendRecord(sequence, "This is record C", a, a)
		Console.WriteLine("Record C has sequence number System.IO.Log", c)
		d = AppendRecord(sequence, "This is record D", b, c)
		Console.WriteLine("Record D has sequence number System.IO.Log", d)
            For Each record In sequence.ReadLogRecords(a, LogRecordEnumeratorType.Next)
                Dim reader As New BinaryReader(record.Data)
                Console.WriteLine("System.IO.Log: T:System.IO.Log.IRecordSequence", record.SequenceNumber, reader.ReadString())
            Next record
            For Each record In sequence.ReadLogRecords(d, LogRecordEnumeratorType.User)
                Dim reader As New BinaryReader(record.Data)
                Console.WriteLine("System.IO.Log: T:System.IO.Log.IRecordSequence", record.SequenceNumber, reader.ReadString())
            Next record
            For Each record In sequence.ReadLogRecords(d, LogRecordEnumeratorType.Previous)
                Dim reader As New BinaryReader(record.Data)
                Console.WriteLine("System.IO.Log: T:System.IO.Log.IRecordSequence", record.SequenceNumber, reader.ReadString())
            Next record
	End Sub
End Class

'</snippet0>

'<snippet1>

	Public Class MyLog
		Private logName As String = "test.log"
		Private sequence As FileRecordSequence = Nothing
		Private delete As Boolean = True

		Public Sub New()
		' Create a FileRecordSequence.
			sequence = New FileRecordSequence(logName, FileAccess.ReadWrite)
		End Sub

	 '<snippet3>
	' Append records to the record sequence.
		Public Sub AppendRecords()
			Console.WriteLine("Appending Log Records...")
			Dim previous As SequenceNumber = SequenceNumber.Invalid

			previous = sequence.Append(CreateData("Hello World!"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)
			previous = sequence.Append(CreateData("This is my first Logging App"), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)
			previous = sequence.Append(CreateData("Using FileRecordSequence..."), SequenceNumber.Invalid, SequenceNumber.Invalid, RecordAppendOptions.ForceFlush)

			Console.WriteLine("Done...")
		End Sub
	'</snippet3>

	'<snippet2>
	' Read the records added to the log. 
		Public Sub ReadRecords()
			Dim enc As Encoding = Encoding.Unicode

			Console.WriteLine()

			Console.WriteLine("Reading Log Records...")
			Try
                For Each record In Me.sequence.ReadLogRecords(Me.sequence.BaseSequenceNumber, LogRecordEnumeratorType.Next)
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
	'</snippet2>

	' Dispose the record sequence and delete the log file. 
		Public Sub Cleanup()
		' Dispose the sequence.
			sequence.Dispose()

		' Delete the log file.
			If delete Then
				Try
					File.Delete(Me.logName)
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
	End Class

	Friend Class LogSample
		Private Shared Sub Main2(ByVal args() As String)
			Dim log As New MyLog()

			log.AppendRecords()
			log.ReadRecords()
			log.Cleanup()
		End Sub
	End Class
'</snippet1>
End Namespace

