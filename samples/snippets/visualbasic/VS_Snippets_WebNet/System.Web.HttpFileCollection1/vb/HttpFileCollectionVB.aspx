<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Clear the BulletedList.
        BulletedList1.Items.Clear()
        
        ' Check to see if at least one file was specified.
        If (FileUpload1.HasFile Or FileUpload2.HasFile) Then
            
            Label1.Text = "The file collection consists of:"
            
            ' Get the HttpFileCollection.
            Dim hfc As HttpFileCollection = Request.Files
            For Each h As String In hfc.AllKeys
                
                ' Add an item to the BulletedList if a file
                ' was specified for the corresponding control.
                If (hfc(h).ContentLength > 0) Then
                    BulletedList1.Items.Add(Server.HtmlEncode(hfc(h).FileName))
                End If
            Next
        Else
            
            Label1.Text = "You did not specify any files to upload or " & _
                "the file(s) could not be found."
            
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
