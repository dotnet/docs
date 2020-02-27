<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">
    Sub Page_Load(Sender As Object, E As EventArgs)
      
          If Not (Page.IsPostBack)
            ViewState("Referer") = Request.Headers("Referer")
          BackColor.Value = Session("BackColor")
            ForeColor.Value = Session("ForeColor")
            LinkColor.Value = Session("LinkColor")
            FontSize.Value = Session("FontSize")
            FontName.Value = Session("FontName")
          End If
      End Sub
' <snippet2>
      Sub Submit_Click(Sender As Object, E As EventArgs)
      
        Session("BackColor") = BackColor.Value
        Session("ForeColor") = ForeColor.Value
        Session("LinkColor") = LinkColor.Value
        Session("FontSize")  = FontSize.Value
        Session("FontName")  = FontName.Value
        
        If Not ViewState("Referer") = Nothing Then
          Response.Redirect(ViewState("Referer").ToString())
        End If
      End Sub
' </snippet2>
    Sub Cancel_Click(Sender As Object, E As EventArgs)
        If Not ViewState("Referer") = Nothing Then
          Response.Redirect(ViewState("Referer").ToString())
        End If
      End Sub
    Function GetStyle(Key As String) As String
        Return Session(Key).ToString()
      End Function
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Customize This Page</title>
<style type="text/css">

    body {
      font: <%=GetStyle("FontSize")%> <%=GetStyle("FontName")%>;
      background-color: <%=GetStyle("BackColor")%>;
    }

    table {
      font: <%=GetStyle("FontSize")%> <%=GetStyle("FontName")%>;
      background-color: <%=GetStyle("BackColor")%>;
      foreground-color: <%=GetStyle("ForeColor")%>
    }

    a { color: <%=GetStyle("LinkColor")%> }

  </style>
</head>
  <body style="color:<%=GetStyle("ForeColor")%>"> 

    <form id="form1" runat="server">

    <h3>Customize This Page</h3>

    <b>Select Your Preferences: </b><p/>

    <table style="color:<%=GetStyle("ForeColor")%>">
      <tr>
        <td>Background Color:</td>
        <td>
          <select id="BackColor" runat="server">
            <option>beige</option>
            <option>yellow</option>
            <option>red</option>
            <option>blue</option>
            <option>lightblue</option>
            <option>lightgreen</option>
            <option>black</option>
            <option>white</option>
          </select>
        </td>
      </tr>
      <tr>
        <td>Foreground Color:</td>
        <td>
          <select id="ForeColor" runat="server">
            <option>black</option>
            <option>beige</option>
            <option>yellow</option>
            <option>red</option>
            <option>blue</option>
            <option>lightblue</option>
            <option>lightgreen</option>
            <option>white</option>
          </select>
        </td>
      </tr>
      <tr>
        <td>Hyperlink Color:</td>
        <td>
          <select id="LinkColor" runat="server">
            <option>blue</option>
            <option>beige</option>
            <option>yellow</option>
            <option>red</option>
            <option>lightblue</option>
            <option>lightgreen</option>
            <option>black</option>
            <option>white</option>
          </select>
        </td>
      </tr>
      <tr>
        <td>Font Size:</td>
        <td>
          <select id="FontSize" runat="server">
            <option>8pt</option>
            <option>10pt</option>
            <option>12pt</option>
            <option>14pt</option>
          </select>
        </td>
      </tr>
      <tr>
        <td>Font Name:</td>
        <td>
          <select id="FontName" runat="server">
            <option>verdana</option>
            <option>tahoma</option>
            <option>arial</option>
            <option>times</option>
          </select>
        </td>
      </tr>
    </table>

    <br />

    <input type="submit" onserverclick="Cancel_Click" value="Cancel" runat="server"/>
    <input type="submit" onserverclick="Submit_Click" value="Submit" runat="server"/>

    </form>

  </body>
</html>

  