		// Create log stream 1.
				sequence1 = new LogRecordSequence(logStream1,
					FileMode.OpenOrCreate,
					FileAccess.ReadWrite,
					FileShare.ReadWrite);

		// Log Extents are shared between the two streams. 
		// Add two extents to sequence1.
				sequence1.LogStore.Extents.Add("MyExtent0", containerSize);
				sequence1.LogStore.Extents.Add("MyExtent1");

		// Create log stream 2.
				sequence2 = new LogRecordSequence(logStream2,
					FileMode.OpenOrCreate,
					FileAccess.ReadWrite,
					FileShare.ReadWrite);