        // Create a markup class constructor that uses the
        // DefaultTabString property to establish indent settings
        // for the writer.
        public SimpleHtmlTextWriter(TextWriter writer)
            :
            this(writer, DefaultTabString)
        {
        }