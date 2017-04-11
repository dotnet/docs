<%@ Page Language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Public Sub Page_Load(sender As Object, e As EventArgs)
        Response.Write("<h2><center><b><font color=""blue""> Sample for ControlCollection Class</font></h2></center></b>")
        ' <snippet1>
       ' Create a LiteralControl and use the Add method to add it
       ' to a button's ControlCollection, then use the AddAt method
       ' to add another LiteralControl to the collection at the
       ' index location of 1.
       Dim myLiteralControl As LiteralControl =  _
           new LiteralControl("ChildControl1")
       myButton.Controls.Add(myLiteralControl)
       myButton.Controls.AddAt(1,new LiteralControl("ChildControl2"))
       Response.Write("<b>ChildControl2 is added at index 1</b>")
       
       ' Get the Index location of the myLiteralControl LiteralControl
       ' and write it to the page.
       Response.Write("<br /><b>Index of the ChildControl myLiteralControl is </b>" & _
                        myButton.Controls.IndexOf(myLiteralControl))
' </snippet1>      
       GetCount(sender, e)
    End Sub

 
 ' <snippet2> 
    ' Create a method that enuberates through a 
    ' button's ControlCollection in a thread-safe manner.  
    Public Sub ListControlCollection(sender As Object, e As EventArgs)
       Dim myEnumerator As IEnumerator = myButton.Controls.GetEnumerator()

       ' Check the IsSynchronized property. If False,
       ' use the SyncRoot method to get an object that 
       ' allows the enumeration of all controls to be 
       ' thread safe.
       If myButton.Controls.IsSynchronized = False Then
         SyncLock myButton.Controls.SyncRoot
           While (myEnumerator.MoveNext())
    
           Dim myObject As Object  = myEnumerator.Current
               
             Dim childControl As LiteralControl = CType(myEnumerator.Current, LiteralControl)
             Response.Write("<b><br /> This is the  text of the child Control  </b>: " & _
                            childControl.Text)
           End While
          msgReadOnly.Text = myButton.Controls.IsReadOnly.ToString()
          
          End SyncLock
       End If       
     End Sub
  ' </snippet2>
    
    
  ' <snippet3>
     ' Create a method that retrieves the number of controls
     ' in a control collection, and write the number to a page.
     Public Sub GetCount(sender As Object, e As EventArgs)
     
        msgCount.Text = "The number of controls in the ControlsCollection is: " & myButton.Controls.Count.ToString()
     
     End Sub
  ' </snippet3>
  

     Public Sub btnRemove_Click(sender As Object, e As EventArgs)
     
        Dim myChildControl As LiteralControl
        
' <snippet4>
        ' Use the Contains method to check whether
        ' a child control exists, and if it does,
        ' use the Remove method to delete it.        
        If myButton.Controls.Contains(myChildControl)
           myButton.Controls.Remove(myChildControl)
           msgRemove.Text = "You removed myLiteralControl."
        Else
           msgRemove.Text="The control to remove does not exist." 
        End If
' </snippet4>      
        GetCount(sender, e)
        
     End Sub
     
     Public Sub btnRemoveAt_Click(sender As Object, e As EventArgs)
        
 ' <snippet5>
        ' Use the RemoveAt method to delete the child control
        ' at index location 1.           
        myButton.Controls.RemoveAt(1)
        msgRemoveAt.Text = "The control at index location 1 has been removed."
 ' </snippet5>      
        
        GetCount(sender, e)        
     
     End Sub
     

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <asp:Button id="myButton" OnClick="btnRemove_Click" Runat="server" Text="Remove"></asp:Button>
        <asp:Label id="msgRemove" Runat="server" ></asp:Label>
        
        <asp:Button id="Btn2" OnClick="btnRemoveAt_Click" Runat="Server" Text="RemoveAt" />
        <asp:Label id="msgRemoveAt" Runat="server" ></asp:Label>
        
        <asp:Label id="msgCount" Runat="Server" ></asp:Label>
        <asp:Label id="msgReadOnly" Runat="Server" ></asp:Label>
    </form>
</body>
</html>