<!-- <Snippet1> -->
<%@ page language="C#" Async="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  System.Net.WebRequest myRequest;

  void Page_Load(object sender, EventArgs e)
  {
    Label1.Text = "Page_Load: thread #" + System.Threading.Thread.CurrentThread.GetHashCode();

    BeginEventHandler bh = new BeginEventHandler(this.BeginGetAsyncData);
    EndEventHandler eh = new EndEventHandler(this.EndGetAsyncData);

    AddOnPreRenderCompleteAsync(bh, eh);

    // Initialize the WebRequest.
    string address = "http://localhost/";

    myRequest = System.Net.WebRequest.Create(address);
  }

  IAsyncResult BeginGetAsyncData(Object src, EventArgs args, AsyncCallback cb, Object state)
  {
    Label2.Text = "BeginGetAsyncData: thread #" + System.Threading.Thread.CurrentThread.GetHashCode();
    return myRequest.BeginGetResponse(cb, state);
  }

  void EndGetAsyncData(IAsyncResult ar)
  {
    Label3.Text = "EndGetAsyncData: thread #" + System.Threading.Thread.CurrentThread.GetHashCode();

    System.Net.WebResponse myResponse = myRequest.EndGetResponse(ar);

    result.Text = new System.IO.StreamReader(myResponse.GetResponseStream()).ReadToEnd();
    myResponse.Close();
  }

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
