<!-- <Snippet1> -->

<%@ Page language="C#" %>
<%@ import namespace="System.IO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    void EmployeesGridView_RowUpdating(Object sender, GridViewUpdateEventArgs e)
    {
    
        // Record the update operation in a log file.
        
        // Create the log text. 
        String logText = "";
        
        // Append the key field values to the log text.
        foreach (DictionaryEntry keyEntry in e.Keys)
        {
            logText += keyEntry.Key + "=" + keyEntry.Value + ";";
        }
        
        // Append the text to a log file.
        StreamWriter sw;
        sw = File.AppendText(Server.MapPath(null) + "\\updatelog.txt");
        sw.WriteLine(logText);
        sw.Flush();
        sw.Close();
    
    }

    void EmployeesGridView_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
    {
    
        if (e.Exception == null)
        {
            // The update operation succeeded. Clear the message label.
            Message.Text = "";
        }
        else
        {
            // The update operation failed. Display an error message.
            Message.Text = e.AffectedRows.ToString() + " rows updated. " + e.Exception.Message;
            e.ExceptionHandled = true;
        }
        
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>GridViewUpdateEventArgs Keys Example</title>
</head>
<body>
        <form id="Form1" runat="server">
        
            <h3>GridViewUpdateEventArgs Keys Example</h3>
            
            <asp:label id="Message"
                 forecolor="Red"          
                 runat="server"/>
                
            <br/>

            <!-- The GridView control automatically sets the columns     -->
            <!-- specified in the datakeynames attribute as read-only.   -->
            <!-- No input controls are rendered for these columns in     -->
            <!-- edit mode.                                              -->
            <asp:gridview id="EmployeesGridView" 
                datasourceid="EmployeesSqlDataSource"
                DataKeyNames="EmployeeID"
                autogenerateeditbutton="True" 
                onrowupdating="EmployeesGridView_RowUpdating"
                onrowupdated="EmployeesGridView_RowUpdated"   
                runat="server">
            </asp:gridview>
            
            <!-- This example uses Microsoft SQL Server and connects -->
            <!-- to the Northwind sample database.                   -->
            <asp:sqldatasource id="EmployeesSqlDataSource"  
                selectcommand="SELECT [EmployeeID], [LastName], [FirstName], [HireDate] FROM [Employees]"
                updatecommand="UPDATE [Employees] SET [LastName] = @LastName, [FirstName] = @FirstName, [HireDate] = @HireDate WHERE [EmployeeID] = @EmployeeID" 
                ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                runat="server" >
            </asp:sqldatasource>
            
        </form>
    </body>
</html>

<!-- </Snippet1> -->
