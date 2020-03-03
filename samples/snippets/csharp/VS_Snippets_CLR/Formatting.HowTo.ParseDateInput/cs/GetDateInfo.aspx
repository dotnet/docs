<!-- <Snippet1> -->

<%@ Page Language="C#" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Assembly Name="System.Core" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void OKButton_Click(object sender, EventArgs e)
    {
        string locale = "";
        DateTimeStyles styles = DateTimeStyles.AllowInnerWhite | DateTimeStyles.AllowLeadingWhite |
                                       DateTimeStyles.AllowTrailingWhite;
        DateTime inputDate;
        DateTime localDate = DateTime.Now;
        DateTimeOffset localDateOffset = DateTimeOffset.Now;
        int integerOffset;
        bool result = false;

        // Exit if input is absent.
        if (string.IsNullOrEmpty(this.DateString.Text)) return;

        // Hide form elements.
        this.DateForm.Visible = false;

        // Create array of CultureInfo objects
        CultureInfo[] cultures = new CultureInfo[Request.UserLanguages.Length + 1];
        for (int ctr = Request.UserLanguages.GetLowerBound(0); ctr <= Request.UserLanguages.GetUpperBound(0);
             ctr++)
        {
            locale = Request.UserLanguages[ctr];
            if (! string.IsNullOrEmpty(locale))
            {

                // Remove quality specifier, if present.
                if (locale.Contains(";"))
                   locale = locale.Substring(locale.IndexOf(';') -1);
                try
                {
                    cultures[ctr] = new CultureInfo(Request.UserLanguages[ctr], false);
                }
                catch (Exception) { }
            }
            else
            {
                cultures[ctr] = CultureInfo.CurrentCulture;
            }
        }
        cultures[Request.UserLanguages.Length] = CultureInfo.InvariantCulture;
        // Parse input using each culture.
        foreach (CultureInfo culture in cultures)
        {
            result = DateTime.TryParse(this.DateString.Text, culture.DateTimeFormat, styles, out inputDate);
            if (result) break;
        }
        // Display result to user.
        if (result)
        {
            Response.Write("<P />");
            Response.Write("The date you input was " + Server.HtmlEncode(this.DateString.Text) + "<BR />");
        }
        else
        {
            // Unhide form.
            this.DateForm.Visible = true;
            Response.Write("<P />");
            Response.Write("Unable to recognize " + Server.HtmlEncode(this.DateString.Text) + ".<BR />");
        }

        // Get date and time information from hidden field.
        string[] dates= Request.Form["DateInfo"].Split(';');

        // Parse local date using each culture.
        foreach (CultureInfo culture in cultures)
        {
            result = DateTime.TryParse(dates[0], culture.DateTimeFormat, styles, out localDate);
            if (result) break;
        }
        // Parse offset 
        result = int.TryParse(dates[1], out integerOffset);
        // Instantiate DateTimeOffset object representing user's local time
        if (result) 
        {
            try
            {
                localDateOffset = new DateTimeOffset(localDate, new TimeSpan(0, -integerOffset, 0));
            }
            catch (Exception)
            {
                result = false;
            }
        }
        // Display result to user.
        if (result)
        {
            Response.Write("<P />");
            Response.Write("Your local date and time is " + localDateOffset.ToString() + ".<BR />");
            Response.Write("The date and time on the server is " + 
                           TimeZoneInfo.ConvertTime(localDateOffset, 
                                                    TimeZoneInfo.Local).ToString() + ".<BR />");
            Response.Write("Coordinated Universal Time is " + localDateOffset.ToUniversalTime().ToString() + ".<BR />");
        }
        else
        {
            Response.Write("<P />");
            Response.Write("Unable to recognize " + Server.HtmlEncode(dates[0]) + ".<BR />");
        }
    }

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        string script = "function AddDateInformation() { \n" +
                  "var today = new Date();\n" +
                  "document.DateForm.DateInfo.value = today.toLocaleString() + \";\" + today.getTimezoneOffset();\n" +
                  " }";
        // Register client script
        ClientScriptManager scriptMgr = Page.ClientScript;
        scriptMgr.RegisterClientScriptBlock(this.GetType(), "SubmitOnClick", script, true);
    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Parsing a Date and Time Value</title>
</head>
<body>
    <form id="DateForm" runat="server">
    <div>
    <center>
       <asp:Label ID="Label1" runat="server" Text="Enter a Date and Time:" Width="248px"></asp:Label>
       <asp:TextBox ID="DateString" runat="server" Width="176px"></asp:TextBox><br />
    </center>       
    <br />
    <center>
    <asp:Button ID="OKButton" runat="server" Text="Button"  
            OnClientClick="AddDateInformation()" onclick="OKButton_Click" />
    <asp:HiddenField ID="DateInfo"  Value=""  runat="server" />
    </center>
    <br />
    </div>
    </form>
</body>
</html>

<!-- </Snippet1> -->
