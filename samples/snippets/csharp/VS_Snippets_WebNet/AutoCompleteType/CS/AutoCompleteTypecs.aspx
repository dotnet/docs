<!-- <Snippet1> -->

<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>AutoCompleteType example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <!-- You need to enable the AutoComplete feature on -->
      <!-- a browser that supports it (such as Internet   -->
      <!-- Explorer 5.0 and later) for this sample to     -->
      <!-- work. The AutoComplete lists are created after -->
      <!-- the Submit button is clicked.                  -->
    
      <h3>AutoCompleteType example</h3>
    
      Enter values in the text boxes and click the Submit <br/>
      button. <br/><br/> 
    
      <!-- The following TextBox controls have different  -->
      <!-- categories assigned to their AutoCompleteType  -->
      <!-- properties.                                    -->
      First Name:<br/>
      <asp:textbox id="FirstNameTextBox"
        autocompletetype="FirstName" 
        runat="server"/>
      <br/>
        
      Last Name:<br/>   
      <asp:textbox id="LastNameTextBox"
        autocompletetype="LastName" 
        runat="server"/>
      <br/>
      
      Email:<br/>   
      <asp:textbox id="EmailTextBox"
        autocompletetype="Email" 
        runat="server"/>
      <br/>
      
      <!-- The following TextBox controls have the same   -->
      <!-- categories assigned to their AutoCompleteType  -->
      <!-- properties. They share the same AutoComplete   -->
      <!-- list.                                          -->
      Phone Line #1:<br/>
      <asp:textbox id="Phone1TextBox"
        autocompletetype="HomePhone" 
        runat="server"/>
      <br/>
      
      Phone Line #2:<br/>
      <asp:textbox id="Phone2TextBox"
        autocompletetype="HomePhone" 
        runat="server"/>
      <br/>

    
      <!-- The following TextBox control has its          -->
      <!-- AutoCompleteType property set to               -->
      <!-- AutoCompleteType.None. All TextBox controls    -->
      <!-- with the same ID across different pages share  -->
      <!-- the same AutoComplete list.                    -->
      Category:<br/>   
      <asp:textbox id="CategoryTextBox"
        autocompletetype="None" 
        runat="server"/>
      <br/>
        
      <!-- The following TextBox control has the          -->
      <!-- AutoComplete feature disabled.                 -->
      Comments:<br/>   
      <asp:textbox id="CommentsTextBox"
        autocompletetype="Disabled" 
        runat="server"/>
      <br/>
      <br/><br/>  
      
      <asp:button id="SubmitButton"
        text="Submit"
        runat="Server"/>
    
    </form>
  </body>
</html>

<!-- </Snippet1> -->