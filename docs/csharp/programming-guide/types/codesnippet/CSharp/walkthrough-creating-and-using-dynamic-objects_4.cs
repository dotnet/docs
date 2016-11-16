        // Store the path to the file and the initial line count value.
        private string p_filePath;

        // Public constructor. Verify that file exists and store the path in 
        // the private variable.
        public ReadOnlyFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File path does not exist.");
            }

            p_filePath = filePath;
        }