<!-- <Snippet1> -->
<!-- 
This example demonstrates using a hyperlink column. The code below
should be copied into a file called DetailsPageVB.aspx. The file
should be stored in the same directory as the file HyperTextColumnVB.aspx
described above.
-->
<!-- </Snippet1> -->
<!-- <Snippet2> -->
<!-- To view this code snippet in a fully-working example, see the 
HyperLinkColumn class topic. -->

<!-- </Snippet2> -->

<!-- <Snippet3> -->
<%@ Page language="VB" AutoEventWireup="true" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>HyperLinkColumn Example</title>
<script runat="server">
            Private dv As DataView
            Private dt As New DataTable()

            Private Sub Page_Load(sender As Object, e As System.EventArgs) _
                Handles MyBase.Load

                ' Get the item value that was passed on the query string.
                Dim myCollection As NameValueCollection = Request.QueryString
                Dim selectedItem As String = myCollection.Get("id")

                Label1.Text = "Item " & selectedItem & _ 
                    " has been added to your order."
            End Sub
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <h3>HyperLinkColumn Example</h3>
                <p><asp:Label id="Label1" runat="server">Label</asp:Label></p>
                <p><asp:HyperLink id="HyperLink1" runat="server" 
                    BorderColor="#8080FF" BorderStyle="Groove" ForeColor="Blue"
                    NavigateUrl="HyperTextColumnVB.aspx"> return to items page 
                   </asp:HyperLink></p>
        </form>
    </body>
</html>
<!-- </Snippet3> -->
