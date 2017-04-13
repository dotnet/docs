<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Clear the BulletedList.
        BulletedList1.Items.Clear();
        
        // Check to see if at least one file was specified.
        if (FileUpload1.HasFile | FileUpload2.HasFile)
        {
            Label1.Text = "The file collection consists of:";
            
            // Get the HttpFileCollection.
            HttpFileCollection hfc = Request.Files;
            foreach (String h in hfc.AllKeys)
            {
                // Add an item to the BulletedList if a file
                // was specified for the corresponding control.
                if (hfc[h].ContentLength > 0)
                    BulletedList1.Items.Add(Server.HtmlEncode(hfc[h].FileName));
            }
            
        }
        else
        {
            Label1.Text = "You did not specify any files to upload or " +
                "the file(s) could not be found.";
        }

    }        
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HttpFileCollection Example</title>
</head>
<body>
    <form id="form1" 
          runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" 
                        runat="server" />
        <br />
        <asp:FileUpload ID="FileUpload2" 
                        runat="server" />
        <br />
        <asp:Button ID="Button1" 
                    runat="server" 
                    OnClick="Button1_Click" 
                    Text="Upload" />
        <br />
        <asp:Label ID="Label1" 
                   runat="server"/>
        <br />
        <asp:BulletedList ID="BulletedList1" 
                          runat="server">
        </asp:BulletedList>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
