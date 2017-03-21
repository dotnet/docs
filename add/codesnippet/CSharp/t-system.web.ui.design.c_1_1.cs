    // Define a custom class derived from the SqlDataSource Web control. 
    public class SqlDataSourceWithBackup : SqlDataSource
    {
        private string _alternateConnectionString;

        // Define an alternate connection string, which could be used
        // as a fallback value if the primary connection string fails.
        
        // The EditorAttribute indicates the property can
        // be edited at design-time with the ConnectionStringEditor class.
        [
          DefaultValue(""),
          EditorAttribute(typeof(System.Web.UI.Design.ConnectionStringEditor),
                         typeof(System.Drawing.Design.UITypeEditor)),
          Category("Data"),
          Description("The alternate connection string.")
        ]
        public string AlternateConnectionString
        {
            get
            {
                return _alternateConnectionString;
            }
            set
            {
                _alternateConnectionString = value;
            }

        }
        
    }