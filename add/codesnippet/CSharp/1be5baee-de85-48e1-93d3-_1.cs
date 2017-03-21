
        // Processes the incoming events.
        // This method performs custom processing and, 
        // if buffering is enabled, it calls the 
        // base.ProcessEvent to buffer the event
        // information.
        public override void ProcessEvent(
            WebBaseEvent eventRaised)
        {

            if (UseBuffering)
                // Buffering enabled, call the 
                // base event to buffer event information.
                base.ProcessEvent(eventRaised);
            else
            {
                // Buffering disabled, store the 
                // current event now.
                customInfo.AppendLine(
                    "*** Buffering disabled ***");
                customInfo.AppendLine(
                    eventRaised.ToString());
                // Store the information in the specified file.
                StoreToFile(customInfo, 
                    logFilePath, FileMode.Append);
            }
        }