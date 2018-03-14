<!-- <Snippet1> -->
<%@ Page language="c#" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ASP.NET Example</title>
<script language="c#" runat="server">     
      void GetProcessInfo(Object sender, EventArgs e) 
      {
        ProcessInfo pi;

        // Get the current process information.
        pi = ProcessModelInfo.GetCurrentProcessInfo();

        Literal1.Text = "<p>Age: " + pi.Age + "</p>";
        Literal1.Text += "<p>PeakMemoryUsed: " + pi.PeakMemoryUsed + "</p>";
        Literal1.Text += "<p>ProcessID: " + pi.ProcessID + "</p>";
        Literal1.Text += "<p>RequestCount: " + pi.RequestCount + "</p>";
        Literal1.Text += "<p>ShutdownReason: " + pi.ShutdownReason + "</p>";
        Literal1.Text += "<p>StartTime: " + pi.StartTime + "</p>";
        Literal1.Text += "<p>Status: " + pi.Status + "</p>";
      }
      </script>
    </head>
    <body>
    <form id="WebForm1" method="post" runat="server">
      <asp:button id="Button1" OnClick="GetProcessInfo" runat="server" Text="Get Process Info"></asp:button>
            &nbsp;
      <asp:Literal id="Literal1" runat="server"></asp:Literal>
    </form>
  </body>
</html>
<!-- </Snippet1> -->