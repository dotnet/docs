        public SampleBufferedWebEventProvider()
        {
            // Perform local initializations.

            // Path of local file where to store 
            // event info.
            // Assure that the path works for you and
            // that the right permissions are set.
            logFilePath = "C:/test/log.doc";
            
            // Instantiate buffer to contain 
            // local data.
            customInfo = new StringBuilder();

        }
