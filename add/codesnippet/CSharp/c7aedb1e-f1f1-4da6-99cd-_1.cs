
        // Process the event that has been raised.
        public override void ProcessEvent(WebBaseEvent raisedEvent)
        { 
            if (msgCounter < maxMsgNumber)
            {
                // Buffer the event information.
                msgBuffer.Enqueue(raisedEvent);
                // Increment the message counter.
                msgCounter += 1;
            }
            else
            {
                // Flush the buffer.
                Flush();
            }
        }
