        // Initializes the provider.
        public SampleEventProvider(): base()
        {

            // Initialize the local path of the file 
            // that holds event information.
            logFilePath = "C:/test/log.doc";

            // Clear the message buffer.
            msgBuffer.Clear();

            // Initialize the max number of messages
            // to buffer.
            maxMsgNumber = 10;

            // More custom initialization goes here.

        }