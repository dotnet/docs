<%@ Page Language="VB" Debug = "true"%>
<%@ Reference Control="simpleformvb.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
' System.Web.UI.TemplateControl.LoadControl
' The following example demonstrates the method 'LoadControl' of class 'TemplateControl'.
'  Note that since 'TemplateControl' is abstract,this example uses 'Page' class which derives 
'  from 'TemplateControl' class.
   
'  Loads and displays a UserControl defined in a seperate Logonform.ascx file.You need to have "Logonform.ascx"
'  and "LogOnControl.cs" file in the same directory as the aspx file. 

' <Snippet1>
    Sub Page_Init(sender As Object, e As System.EventArgs)
 Response.Write("<h4><b>A Simple User Control</b></h4><br />")
 ' Obtain a UserControl object 'SimpleControl' from the user control file 'SimpleFormvb.ascx'.
 Dim myControl As SimpleControl = CType(LoadControl("simpleformvb.ascx"), SimpleControl)
   myPlaceholder.Controls.Add(myControl)
End Sub 'Page_Init
' </Snippet1>
  </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
     <form id="form1" runat="server">
     <asp:placeholder id = "myPlaceholder" runat="server" />
     </form>
   </body>
</html>
