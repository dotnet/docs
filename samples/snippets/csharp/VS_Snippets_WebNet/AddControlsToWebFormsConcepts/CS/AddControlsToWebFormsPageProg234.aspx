<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Add Controls to a Web Forms Page Programmatically</title>
</head>

<script runat="server">
    
    private void Page_Load()
    {    
        //<Snippet2>
        Label myLabel = new Label();
        myLabel.Text = "Sample Label";
        //</Snippet2>
    
        //<Snippet3>
        Panel Panel1= new Panel();
        Panel1.Controls.Add(myLabel);
        //</Snippet3>
    }
    
    
    //<Snippet4>
    private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        DropDownList DropDownList1 = new DropDownList();
        PlaceHolder PlaceHolder1 = new PlaceHolder();
        
      // Get the number of labels to create.
     int numlabels = System.Convert.ToInt32(DropDownList1.SelectedItem.Text);
     for (int i=1; i<=numlabels; i++)
     {
       Label myLabel = new Label();
         
       // Set the label's Text and ID properties.
       myLabel.Text = "Label" + i.ToString();
       myLabel.ID = "Label" + i.ToString();
       PlaceHolder1.Controls.Add(myLabel);
       // Add a spacer in the form of an HTML <br /> element.
       PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
     } 
    }
 //</Snippet4>
    
</script>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
