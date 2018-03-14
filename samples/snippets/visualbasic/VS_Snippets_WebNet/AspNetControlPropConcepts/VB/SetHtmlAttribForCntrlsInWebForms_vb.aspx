<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id ="head1" runat="server">
    <title>How to: Set HTML Attributes for Controls in Web Forms Pages (Visual Basic)</title>
</head>

<!--<Snippet7>-->
<body id="body" runat="server">
    <form id="form1" runat="server">
      <!-- Example1 --> 
      <input runat="server" id="Button1" type="button" onmouseover="rollover()" onmouseout="exitrollover()" />
    </form>
</body>

<script runat="server">
    
    Private Sub Page_Load(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles MyBase.Load
        
        ' Example 2
        Button1.Attributes.Add("onclick", "alert('hello, world')")
        Button1.Style.Add("background-color", "red")
        
        ' Example 3
        body.Attributes("bgcolor") = "lightblue"
                
    End Sub
    
</script>
<!--</Snippet7>-->

</html>
