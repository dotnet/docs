<%@ Register TagPrefix="CustomLiteralControl" Namespace="CustomLiteralControl" Assembly="customliteralcontrol" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">

 Sub Page_Load (Sender as Object, e As EventArgs )
' <Snippet4>
    Dim myLiteralControlClass1 as CustomLiteralControlClass = _
    new CustomLiteralControlClass()
    myLiteralControlClass1.Text="This Control demonstrates the constructor1"
' </Snippet4>
' <Snippet5>
    Dim myLiteralControlClass2 as CustomLiteralControlClass = _
    new CustomLiteralControlClass("This Control demonstrates the constructor2")
' </Snippet5>
    Label1.Text="<br /><b>"+myLiteralControlClass1.Text+"</b></br>"
    Label2.Text="<br /><b>"+myLiteralControlClass2.Text+"</b></br>"
    MyControl.Text=""
 End Sub

 Sub Show_Text( sender as object,e as EventArgs )
       MyControl.Text=TextBox1.Text
 End Sub

      </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>
                </title>
<%--
           ' System.Web.UI.LiteralControl.LiteralControl()
           ' System.Web.UI.LiteralControl.LiteralControl(string)
            The following example demonstrates LiteralControl() and LiteraControl(string) 
            constructors.The class CustomLiteralControl class is derived from LiteralControl.
            'Text' is the property of 'LiteralControl' overriden in CustomLiteralControlClass.
     --%>
    </head>
    <body>
        <form method="post" action="WebForm1.aspx" runat="server" id="Form1">
            <h1 style="text-align:center">Sample for LiteralControl Class</h1>
            <h3>
                <b>Enter some text into the textbox.. </b>
            </h3>
            <asp:TextBox ID="TextBox1" Runat="server" Text=""></asp:TextBox>
            <br />
            <asp:Button ID="Button1" Runat="server" Text="Submit" OnClick="Show_Text"></asp:Button>
            <CustomLiteralControl:CustomLiteralControlClass ID="MyControl" runat="server">
                <asp:Button id="Button2" Text="Hello this is  text of child control of the  CustomLiteralControlClass" runat="server"></asp:Button>
            </CustomLiteralControl:CustomLiteralControlClass>
            <asp:Label ID="Label1" Runat="server"></asp:Label>
            <asp:Label ID="Label2" Runat="server"></asp:Label>
        </form>
    </body>
</html>
