			' Create a LogRecordSequence.
			sequence = New LogRecordSequence(Me.logName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None)

			' At least one container/extent must be added for Log Record Sequence.
			sequence.LogStore.Extents.Add(Me.logContainer, Me.containerSize)

			MySequence = sequence