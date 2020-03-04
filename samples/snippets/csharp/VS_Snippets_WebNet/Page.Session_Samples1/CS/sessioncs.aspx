<%@ Page debug="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
  <script language="C#" runat="server">
// <snippet1>
      // Create a private function that obtains
      // information stored in Session state
      // in the application's Global.asax file.
      // When this method is called and a key name
      // that is stored in Session state is passed
      // as the paramter, the key is obtained and
      // converted to a string.
      String GetStyle(String key) {
        return Session[key].ToString();       
      }
// </snippet1> 
  </script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Storing Volatile Data in Session State</title>
      <style type="text/css">

        body {
          font: <%=GetStyle("FontSize")%> <%=GetStyle("FontName")%>;
          background-color: <%=GetStyle("BackColor")%>;
        }

        a { color: <%=GetStyle("LinkColor")%> }

      </style>
  </head>
<body style="color:<%=GetStyle("ForeColor")%>">

    <h3>Storing Volatile Data in Session State</h3>
    <form id="form1" runat="server">

        <b><a href="customizecs.aspx">Customize This Page</a></b><br />

        Imagine some content here ...<br />
        Imagine some content here ...<br />
        Imagine some content here ...<br />
        Imagine some content here ...<br />
        Imagine some content here ...<br />
        Imagine some content here ...<br />
        Imagine some content here ...<br />
        Imagine some content here ...<br />
    
    </form>

  </body>
  
</html>


  