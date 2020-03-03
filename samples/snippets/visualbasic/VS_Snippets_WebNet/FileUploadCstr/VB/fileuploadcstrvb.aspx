<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>FileUpload Constructor Example</title>
<script runat="server">
        
        Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            
            ' Create a FileUpload control.
            Dim FileUpload1 As New FileUpload
            
            ' Add the FileUpload control to the Controls collection
            ' of the PlaceHolder control.
            PlaceHolder1.Controls.Add(FileUpload1)
            
        End Sub
       
    </script>

</head>
<body>

    <h3>FileUpload Constructor Example</h3>

    <form id="Form1" runat="server">
   
        <asp:PlaceHolder id="PlaceHolder1"                 
            runat="server">
        </asp:PlaceHolder>
            
        <hr />

         <asp:Button id="Button1" 
             Text="Create and show a FileUpload control" 
             OnClick="Button1_Click" 
             runat="server"/>              
         
    </form>

</body>
</html>
<!--</Snippet1>-->
