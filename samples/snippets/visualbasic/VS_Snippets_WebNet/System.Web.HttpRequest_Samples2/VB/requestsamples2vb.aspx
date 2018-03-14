<!-- <snippet1> -->
<%@ Page Language="VB" Debug="true"%>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Samples.AspNet.VB.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
     
  Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
      
    ' Filter the text to be rendered as all uppercase.
    Response.Filter = New UpperCaseFilterStream(Response.Filter)
    
    ' Convert a virtual path to a fully qualified physical path.
    Dim fullpath As String = Request.MapPath("~\\TestFile.txt")
    
    Try
      
      Dim sr As StreamReader = New StreamReader(fullpath)
      
      Do While sr.Peek() >= 0
        Response.Write(Convert.ToChar(sr.Read()))
      Loop
      sr.Close()
      Message.Text = "Reading the file was successful."
      
    Catch ex As Exception
      
      Message.Text = "The process failed."

    End Try

    
  End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>HttpResponse.MapPath Example</title>
  </head>
  <body>
    <form id="Form1" runat="server">

      <asp:Label id="Message" 
                 runat="server"/>

    </form>
  </body>
</html>
<!-- </snippet1> -->
