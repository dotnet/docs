
        // Processes the messages that have been buffered.
        // It is called by the ASP.NET when the flushing of 
        // the buffer is required.
        public override void ProcessEventFlush(
            WebEventBufferFlushInfo flushInfo)
        {

            // Customize event information to be sent to 
            // the Windows Event Viewer Application Log.
            customInfo.AppendLine(
                "SampleEventLogWebEventProvider buffer flush.");

            customInfo.AppendLine(
                string.Format("NotificationType: {0}",
                GetNotificationType(flushInfo)));

            customInfo.AppendLine(
                string.Format("EventsInBuffer: {0}",
                GetEventsInBuffer(flushInfo)));

            customInfo.AppendLine(
                string.Format(
                "EventsDiscardedSinceLastNotification: {0}",
                GetEventsDiscardedSinceLastNotification(flushInfo)));

           
            // Read each buffered event and send it to the
            // Application Log.
            foreach (WebBaseEvent eventRaised in flushInfo.Events)
                customInfo.AppendLine(eventRaised.ToString());

            // Store the information in the specified file.
            StoreToFile(customInfo, logFilePath, FileMode.Append);
        }