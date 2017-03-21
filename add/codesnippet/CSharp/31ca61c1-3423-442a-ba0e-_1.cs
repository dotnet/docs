        public string AddPooling(string connectionString)
        {
            StringBuilder builder = new StringBuilder(connectionString);
            DbConnectionStringBuilder.AppendKeyValuePair(builder, "Pooling", "true");
            return builder.ToString();
        }