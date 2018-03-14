<!--<Snippet1>-->
<%@ outputcache duration="60" varybyparam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" language="VB">  
  
  Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    ' Programmatically create a Substitution control.
    Dim Substitution1 As New Substitution
    
    ' Specify the callback method.
    Substitution1.MethodName = "GetCurrentDateTime"
    
    ' Add the Substitution control to the controls
    ' collection of PlaceHolder1.
    PlaceHolder1.Controls.Add(Substitution1)
    
    ' Display the current date and time in the label.
    ' Output caching applies to this section of the page.
    CachedDateLabel.Text = DateTime.Now.ToString()
  End Sub
  
  ' The Substitution control calls this method to retrieve
  ' the current date and time. This section of the page
  ' is exempt from output caching. 
  Shared Function GetCurrentDateTime(ByVal context As HttpContext) As String
    Return DateTime.Now.ToString()
  End Function
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>Substitution Constructor Example</title>
</head>
<body>
  <form id="Form1" runat="server">
  
    <h3>Substitution Constructor Example</h3>  
    
    <p>This section of the page is not cached:</p>
    <asp:placeholder id="PlaceHolder1"
      runat="Server">
    </asp:placeholder>
    
    <br />
    
    <p>This section of the page is cached:</p>
    
    <asp:label id="CachedDateLabel"
      runat="Server">
    </asp:label>
    
    <br /><br />
    
    <asp:button id="RefreshButton"
      text="Refresh Page"
      runat="Server">
    </asp:button>     

  </form>
</body>
</html>
<!--</Snippet1>-->
