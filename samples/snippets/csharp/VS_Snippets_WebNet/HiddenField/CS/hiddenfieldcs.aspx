<!-- <Snippet1> -->

<%@ Page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  void ValueHiddenField_ValueChanged (Object sender, EventArgs e)
  {
    
    // Display the value of the HiddenField control.
    Message.Text = "The value of the HiddenField control is " + ValueHiddenField.Value + ".";
    
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>HiddenField Example</title>
</head>
<body>
        <form id="Form1" runat="server">
        
            <h3>HiddenField Example</h3>

            Please enter a value and click the submit button.<br/>
            
            <asp:Textbox id="ValueTextBox"
              runat="server"/>
              
            <br/>  
              
            <input type="submit" name="SubmitButton"
             value="Submit"
             onclick="PageLoad()" />
             
            <br/>
            
            <asp:label id="Message" runat="server"/>    
            
            <asp:hiddenfield id="ValueHiddenField"
              onvaluechanged="ValueHiddenField_ValueChanged"
              value="" 
              runat="server"/>
            
        </form>
    </body>
</html>

<script type="text/javascript">

  <!--
  function PageLoad()
  {
  
    // Set the value of the HiddenField control with the
    // value from the TextBox.
    Form1.ValueHiddenField.value = Form1.ValueTextBox.value;
    
  }
  -->
  
</script>

<!-- </Snippet1> -->