<!-- <Snippet4> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Calendar_Init(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Do any related intialization work.
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Control Init Event Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Calendar ID="Calendar1"
                     runat="server" 
                     OnInit="Calendar_Init"/>
    </div>
    </form>
</body>
</html>
<!-- </Snippet4> -->

