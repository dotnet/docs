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