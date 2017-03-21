    private ICollection LoadControlProperties(string serializedProperties)
    {

        ICollection controlProperties = null;

        // Create an ObjectStateFormatter to deserialize the properties.
        ObjectStateFormatter formatter = new ObjectStateFormatter();

        try
        {
            // Call the Deserialize method.
            controlProperties = (ArrayList)formatter.Deserialize(serializedProperties);
        }
        catch (HttpException e)
        {
            ViewStateException vse = (ViewStateException)e.InnerException;
            String logMessage;

            logMessage = "ViewStateException. Path: " + vse.Path + Environment.NewLine;
            logMessage += "PersistedState: " + vse.PersistedState + Environment.NewLine;
            logMessage += "Referer: " + vse.Referer + Environment.NewLine;
            logMessage += "UserAgent: " + vse.UserAgent + Environment.NewLine;

            LogEvent(logMessage);

            if (vse.IsConnected)
            {
                HttpContext.Current.Response.Redirect("ErrorPage.aspx");
            }
            else
            {
                throw e;
            }
        }
        return controlProperties;
    }