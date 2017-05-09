<!--<Snippet1>-->
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {
    
    // The first time the page loads, set the values
    // of the HtmlInputText and HtmlInputCheckBox controls.
    if (!IsPostBack)
    {
      InputText1.Value = "Test";
      InputCheckBox1.Checked = true;
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" 
      runat="server">

    <title>HtmlForm SubmitDisabledControls Property Example</title>

</head>

<body>

  <form id="form1" 
        submitdisabledcontrols="true" 
        runat="server">
    
      <h3>HtmlForm SubmitDisabledControls Property Example</h3>
    
      <input id="InputText1" 
             name="InputText1" 
             type="text" 
             runat="server" />
    
      <input id="InputCheckBox1" 
             name="InputCheckBox1" 
             type="Checkbox" 
             runat="server" />
    
      <asp:button id="PostBackButton"
                  text="Post back"
                  runat="server" />

  </form>    
    
</body>

</html>

<script type="text/javascript">

    // Disable the HTML controls on the form.
    document.all('InputText1').disabled = true;
    document.all('InputCheckBox1').disabled = true;

</script>
<!--</Snippet1>-->

