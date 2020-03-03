<!-- <Snippet1> -->
<%@ Page language="vb" AutoEventWireup="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ASP.NET Example</title>
<script language="vb" runat="server">     
      Sub GetProcessInfo(sender As Object, e As System.EventArgs)
        Dim pi As ProcessInfo

        'Get information about the current process.
        pi = ProcessModelInfo.GetCurrentProcessInfo()

        Literal1.Text = "<p>Age: " & pi.Age.ToString & "</p>"
        Literal1.Text = Literal1.Text & "<p>PeakMemoryUsed: " & pi.PeakMemoryUsed.ToString & "</p>"
        Literal1.Text = Literal1.Text & "<p>ProcessID: " & pi.ProcessID.ToString & "</p>"
        Literal1.Text = Literal1.Text & "<p>RequestCount: " & pi.RequestCount.ToString & "</p>"
        Literal1.Text = Literal1.Text & "<p>ShutdownReason: " & pi.ShutdownReason.ToString & "</p>"
        Literal1.Text = Literal1.Text & "<p>StartTime: " & pi.StartTime.ToString & "</p>"
        Literal1.Text = Literal1.Text & "<p>Status: " & pi.Status.ToString & "</p>"
      End Sub
    </script>
  </head>
  <body>
    <form id="WebForm2" method="post" runat="server">
      <asp:button id="Button1" OnClick="GetProcessInfo" runat="server" Text="Get Process Info"></asp:button>
            &nbsp;
      <asp:Literal id="Literal1" runat="server"></asp:Literal>
    </form>
  </body>
</html>
<!-- </Snippet1> -->