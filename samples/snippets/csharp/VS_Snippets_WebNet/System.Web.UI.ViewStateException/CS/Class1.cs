using System;
using System.Collections;
using System.Web.UI;
using System.Web;

// Compile this same using the following command line:
//   csc /t:exe /out:objectstateformattertest.exe objectstateformattertest.cs
public class ObjectStateFormatterTest
{

    public static void Main()
    {
        string SortDirection = "ASC";
        string SelectedColumn = "Employee";
        int CurrentPage = 1;

        // <snippet1>

        ArrayList controlProperties = new ArrayList(3);

        controlProperties.Add(SortDirection);
        controlProperties.Add(SelectedColumn);
        controlProperties.Add(CurrentPage.ToString());

        // Create an ObjectStateFormatter to serialize the ArrayList.
        ObjectStateFormatter formatter = new ObjectStateFormatter();

        // Call the Serialize method to serialize the ArrayList to a Base64 encoded string.
        string base64StateString = formatter.Serialize(controlProperties);
        
        // </snippet1>
    }


    // <snippet2>
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
    // </snippet2>

    private void LogEvent(String message)
    {

    }
    

}
