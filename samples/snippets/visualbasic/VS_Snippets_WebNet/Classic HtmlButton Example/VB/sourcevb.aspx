<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <script language="VB" runat="server">
       Sub FancyBtn_Click(Source As Object, E as EventArgs)
          Message.InnerHtml = "Your name is: " & Name.Value
       End Sub
    </script>
  
    <head runat="server">
    <title> Enter Name: </title>
</head>
<body>
          <form id="form1" method="post" runat="server">
  
            <h3> Enter Name: <input id="Name" type="text" size="40" runat="server" />
            </h3>
  
             <button onserverclick=" FancyBtn_Click" runat="server">
               <b><i> I'm a fancy HTML 4.0 button </i> </b> 
             </button>
  
                       
           <h1>
             <span id="Message" runat="server"></span>
           </h1>
  
          </form>
       </body>
 </html>
    
<!--</Snippet1>-->
