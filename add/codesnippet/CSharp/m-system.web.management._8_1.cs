        // Flush the input buffer if required.
        public override void Flush()
        {
            // Create a string builder to 
            // hold the event information.
            StringBuilder reData = new StringBuilder();

            // Store custom information.
            reData.Append("SampleEventProvider processing." +
                Environment.NewLine);
            reData.Append("Flush done at: {0}" +
                DateTime.Now.TimeOfDay.ToString() +
                Environment.NewLine);
            
            foreach (WebBaseEvent e in msgBuffer)
            {
                // Store event data.
                reData.Append(e.ToString());
            }

            // Store the information in the specified file.
            StoreToFile(reData, logFilePath, FileMode.Append);

            // Reset the message counter.
            msgCounter = 0;
            
            // Clear the buffer.
            msgBuffer.Clear();

        }