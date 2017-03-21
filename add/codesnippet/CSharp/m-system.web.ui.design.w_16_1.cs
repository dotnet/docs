        // Generate design time markup.
        public override string GetDesignTimeHtml()
        {
            // Generate a design-time placeholder containing the 
            // DataFile and the ConnectionString properties.
            // Split the ConnectionString into segments so it doesn't make
            // placeholder too wide.
            string[] connectParts = GetConnectionString().Split(new char[] { ';' });
            string connectString = "&nbsp;&nbsp;" + connectParts[0];

            for (int i = 1; i < connectParts.Length; i++)
                connectString += ";<br>&nbsp;&nbsp;" + connectParts[i].Trim();

            return CreatePlaceHolderDesignTimeHtml(
                "DataFile: " + DataFile + "<br />" +
                "Connection string:<br />" + connectString);
        }