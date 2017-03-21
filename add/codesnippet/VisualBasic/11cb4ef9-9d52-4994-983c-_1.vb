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