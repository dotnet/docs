            // Create a LogRecordSequence.
            sequence = new LogRecordSequence(this.logName,
                                              FileMode.CreateNew,
                                              FileAccess.ReadWrite,
                                              FileShare.None);

            // At least one container/extent must be added for Log Record Sequence.
            sequence.LogStore.Extents.Add(this.logContainer, this.containerSize);
     
            MySequence = sequence;