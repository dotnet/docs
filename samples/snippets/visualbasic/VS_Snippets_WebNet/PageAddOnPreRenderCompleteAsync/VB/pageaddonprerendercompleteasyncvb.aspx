<!-- <Snippet1> -->
<%@ page language="VB" Async="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  Dim myRequest As System.Net.WebRequest
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = "Page_Load: Thread #" & System.Threading.Thread.CurrentThread.GetHashCode()
    
    Dim bh As New BeginEventHandler(AddressOf Me.BeginGetAsyncData)
    Dim eh As New EndEventHandler(AddressOf Me.EndGetAsyncData)
    
    Me.AddOnPreRenderCompleteAsync(bh, eh)
    
    ' Initialize the WebRequest object.
    Dim address As String
    address = "http://localhost/"
    myRequest = System.Net.WebRequest.Create(address)
    
  End Sub
  
  Function BeginGetAsyncData(ByVal src As Object, ByVal args As EventArgs, ByVal cb As AsyncCallback, ByVal state As Object) As IAsyncResult
    Label2.Text = "BeginGetAsyncData: Thread #" & System.Threading.Thread.CurrentThread.GetHashCode()
    Return Me.myRequest.BeginGetResponse(cb, state)
  End Function
  
  Sub EndGetAsyncData(ByVal ar As IAsyncResult)
    Label3.Text = "EndGetAsyncData: Thread #" & System.Threading.Thread.CurrentThread.GetHashCode()
    
    Dim myResponse As System.Net.WebResponse
    myResponse = Me.myRequest.EndGetResponse(ar)
    
    Dim reader As New System.IO.StreamReader(myResponse.GetResponseStream())
    result.Text = reader.ReadToEnd()
    myResponse.Close()
  End Sub
  
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      Page.AddOnPreRenderCompleteAsync Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:label id="Label1" runat="server">
        Label 1</asp:label><br />
      <asp:label id="Label2" runat="server">
        Label 2</asp:label><br />
      <asp:label id="Label3" runat="server">
        Label 3</asp:label><br />
      <asp:textbox id="result" runat="server" textMode="multiLine" ReadOnly="true" columns="80" rows="25" />
    </form>
  </body>
</html>
<!-- </Snippet1> -->
