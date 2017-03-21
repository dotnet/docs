
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
   void Page_Load(Object Sender,EventArgs e)
   {
       Response.Write("<h2>Sample for ControlCollection Class</h2>");

       LiteralControl myLiteralControl 
           = new LiteralControl("ChildControl1");

       myButton.Controls.Add(myLiteralControl);
       myButton.Controls.AddAt(1,new LiteralControl("ChildControl2"));

       System.Array myControlCollectionArray 
           = Array.CreateInstance(typeof(object), 
               myButton.Controls.Count);
       myButton.Controls.CopyTo(myControlCollectionArray,0);

       IEnumerator myEnumerator1 = 
           myControlCollectionArray.GetEnumerator();

       while (myEnumerator1.MoveNext())
       {
           object myObject = myEnumerator1.Current;

           if(myObject.GetType().Equals(typeof(LiteralControl)))
           {
               LiteralControl childControl = 
                   (LiteralControl)myEnumerator1.Current;
               Response.Write("<p style=\"font-weight:bold\">");
               Response.Write("This is the  text of the child Control:" 
                   + Server.HtmlEncode(childControl.Text));
           }
       }

       myButton.Controls.Remove(myButton.Controls[0]);
       Response.Write("</p><p style=\"font-weight:bold\">");
       Response.Write("ChildControl1 is removed<br />");
       Response.Write("The count of ControlCollection = "
           + myButton.Controls.Count.ToString() + "</p>");
       myButton.Controls.Clear();
   }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="myButton" Text="Sample ServerControl" 
            Runat="server"></asp:Button>

    </div>
    </form>
</body>
</html>