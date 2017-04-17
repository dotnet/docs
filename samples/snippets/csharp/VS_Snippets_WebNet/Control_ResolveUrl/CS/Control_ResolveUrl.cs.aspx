<%@ Register TagPrefix="MyControl" Namespace="ResolveUrlSample" Assembly = "Control_ResolveUrl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>
            Control_ResolveUrl Sample
         </title>
</head>
<body>
      <script language="C#" runat="server">
      void Page_Load()
      {  
         myHyperLinkControl.ImageUrl = "Images\\sample.jpg";
      }  
      </script>
      <form id="form1" method="post" runat="server">
         <h4>
            Control_ResolveUrl Sample
         </h4>
         <MyControl:MyResolveUrl id="myHyperLinkControl" runat="server">
         </MyControl:MyResolveUrl>
      </form>
   </body>
</html>
