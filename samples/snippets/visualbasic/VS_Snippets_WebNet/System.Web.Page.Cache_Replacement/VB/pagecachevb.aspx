<%@ Page Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
' <snippet1>
   ' This is a simple page that demonstrates how to place a value
   ' in the cache from a page, and one way to retrieve the value.
   ' Declare two constants, myInt1 and myInt2 and set their values
   ' and declare a string variable, myValue.
   Const myInt1 As Integer = 35
   Const myInt2 As Integer = 77
   Dim myValue As String


   ' When the page is loaded, the sum of the constants
   ' is placed in the cache and assigned a key, key1.
   Sub Page_Load(sender As [Object], arg As EventArgs)
      Cache("key1")= myInt1 + myInt2
   End Sub 'Page_Load
 

   ' When a user clicks a button, the sum associated
   ' with key1 is retrieved from the Cache using the 
   ' Cache.Get method. It is converted to a string
   ' and displayed in a Label Web server control.
   Sub CacheBtn_Click(sender As Object, e As EventArgs)
     If Cache("key1") Is Nothing Then
      myLabel.Text = "That object is not cached."
     Else
      myValue = Cache.Get("key1").ToString()
      myLabel.Text = myValue
     End If
   End Sub 'CacheBtn_Click
' </snippet1>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Using the Page.Cache Property</title>
 
</head>
<body>
    <form id="form1" runat="server">
        Click the button to view a value stored in the Page's Cache object.
        <p> 
            <br />
            <asp:label id="myLabel" runat="server"></asp:label>
        </p>
        <p>
            <asp:Button id="myButton" OnClick="CacheBtn_Click" runat="server" 
                Text="Click here!"></asp:Button>
        </p>
    </form>
</body>
</html>
