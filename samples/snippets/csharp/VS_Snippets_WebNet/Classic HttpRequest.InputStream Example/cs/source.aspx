<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        // <Snippet1>

        System.IO.Stream str; String strmContents;
        Int32 counter, strLen, strRead;
        // Create a Stream object.
        str = Request.InputStream;
        // Find number of bytes in stream.
        strLen = Convert.ToInt32(str.Length);
        // Create a byte array.
        byte[] strArr = new byte[strLen];
        // Read stream into byte array.
        strRead = str.Read(strArr, 0, strLen);
                        
        // Convert byte array to a text string.
        strmContents = "";
        for (counter = 0; counter < strLen; counter++)
        {
            strmContents = strmContents + strArr[counter].ToString();            
        }
        // </Snippet1>

        Response.Write(strmContents);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />    
    </div>
    </form>
</body>
</html>
