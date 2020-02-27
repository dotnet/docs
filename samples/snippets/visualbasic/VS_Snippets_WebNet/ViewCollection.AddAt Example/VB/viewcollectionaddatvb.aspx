<!--<Snippet1>-->
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ViewCollection example</title>
<script runat="server">
      
        Sub Button1_Click(ByVal Sender As Object, ByVal e As EventArgs)
            ' Create a MultiView control.
            Dim MultiView1 As New MultiView

            ' Create a ViewCollection for the View 
            ' controls contained in MultiView1.
            Dim myViewCollection As New ViewCollection(MultiView1)

            ' Create a View control. 
            Dim View1 As New View
            ' Use a helper function to create the view.
            View1 = CreateView("View1")
            ' Add View1 to myViewCollection at index 0.
            myViewCollection.AddAt(0, View1)

            ' Create a second View control and 
            ' add it to myViewCollection at index 1.
            Dim View2 As New View
            View2 = CreateView("View2")
            myViewCollection.AddAt(1, View2)

            ' Create a third View control and 
            ' add it to myViewCollection at index 0.
            ' Inserting View3 at index 0 
            ' causes View1 to move to index 1  
            ' and View2 to move to index 2.
            Dim View3 As New View
            View3 = CreateView("View3")
            myViewCollection.AddAt(0, View3)

            ' Show the contents of myViewCollection on the page.
            DisplayViewCollectionContents(myViewCollection)
            
        End Sub

        ' A function to programmatically create a View control.
        Private Function CreateView(ByVal viewId As String) As View
            ' Create a View control
            Dim myView As New View
            myView.ID = viewId

            ' Create a Panel control.
            Dim Panel1 As New Panel

            ' Set the style properties for Panel1.
            Panel1.Height = New Unit(150)
            Panel1.Width = New Unit(150)
            Panel1.BackColor = System.Drawing.Color.Azure
            Panel1.BorderStyle = BorderStyle.Double

            ' Add Panel1 to the Controls collection
            ' of the View control.
            myView.Controls.Add(Panel1)

            ' Create a Label control.
            Dim Label1 As New Label

            ' Set the properties for Label1.
            Label1.Text = "This is " + CStr(myView.ID)

            ' Add Label1 to the Controls collection
            ' of the Panel1 control.
            Panel1.Controls.Add(Label1)

            Return myView
        End Function

        ' A sub-routine to display the contents of myViewCollection.
        Sub DisplayViewCollectionContents(ByVal collection As ViewCollection)
            ' Use the Item property to access the ID of the View
            ' control at the specified index in the collection.
            Label1.Text = "The view at index 0 is " + collection.Item(0).ID
            Label2.Text = "The view at index 1 is " + collection.Item(1).ID
            Label3.Text = "The view at index 2 is " + collection.Item(2).ID
        End Sub

</script>
 
</head>
<body>

    <form id="Form1" runat="server">

        <h3>ViewCollection example</h3> 

        <asp:Button id="Button2" 
            Text="Show ViewCollection contents" 
            OnClick="Button1_Click" 
            runat="Server"/>
        <br /><br />  
        
        <hr />
  
        <asp:Label ID="Label1"
            runat="Server">
        </asp:Label><br /><br /> 

        <asp:Label ID="Label2"
            runat="Server">
        </asp:Label><br /><br />

        <asp:Label ID="Label3"
            runat="Server">
        </asp:Label><br /><br /> 
       
    </form>
   
</body>
</html>
<!--</Snippet1>-->