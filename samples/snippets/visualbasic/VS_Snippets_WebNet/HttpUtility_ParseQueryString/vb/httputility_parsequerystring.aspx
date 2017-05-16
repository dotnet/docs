<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim currurl As String = HttpContext.Current.Request.RawUrl
    Dim querystring As String = Nothing
    
    ' Check to make sure some query string variables
    ' exist and if not add some and redirect.
    Dim iqs As Int32 = currurl.IndexOf("?".ToCharArray())
    If (iqs = -1) Then
      
      Dim redirecturl As String = currurl & "?var1=1&var2=2+2%2f3&var1=3"
      Response.Redirect(redirecturl, True)
      
      ' If query string variables exist, put them in
      ' a string.
    ElseIf (iqs >= 0) Then
      
      If (iqs < currurl.Length - 1) Then
        querystring = currurl.Substring(iqs + 1)
      End If
          
    End If

    ' Parse the query string variables into a NameValueCollection.
    Dim qscoll As NameValueCollection = HttpUtility.ParseQueryString(querystring)
    
    ' Iterate through the collection.
    Dim sb As New StringBuilder("<br />")
    For Each s As String In qscoll.AllKeys
      
      sb.Append(s & " - " & qscoll(s) & "<br />")
    
    Next s
    
    ' Write the result to a label
    ParseOutput.Text = sb.ToString()
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HttpUtility ParseQueryString Example</title>
</head>
<body>
    <form id="Form1" runat="server">
      Query string variables are:
      <asp:Label  id="ParseOutput"
                  runat="server" />
    </form>
</body>
</html>
<!-- </Snippet1> -->
