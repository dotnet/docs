<!-- <snippet4> -->
<%@ Page Language="vb" %>
<%@ Register TagPrefix="aspSample" TagName="Books" Src="Booksvb.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    ' Display the current time whenever the page is loaded.
    Private Sub Page_Load(sender As Object, e As EventArgs)
        lblPageMessage.Text = DateTime.Now.ToString()
    End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>        
        <form id="Form1" method="post" runat="server">
         <table> 
           <tbody>
              <tr>
               <td> This is user control displaying data:</td> 
               <td> <aspSample:Books id="ucBooks" runat="server"></aspSample:Books>
               </td>
              </tr> 
              <tr>
               <td> The page was generated at:</td>
               <td> <asp:Label id="lblPageMessage" Runat="server"></asp:Label> 
               </td> 
              </tr> 
           </tbody> 
         </table> 
       </form>        
</body> 
</html>
<!-- </snippet4> -->

