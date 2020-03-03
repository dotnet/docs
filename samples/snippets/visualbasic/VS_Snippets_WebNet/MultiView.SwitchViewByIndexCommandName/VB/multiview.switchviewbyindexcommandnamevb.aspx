<!--<Snippet1>-->
<%@ Page Language="VB" %>

  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    Sub Page4SaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        
      ' The user wants to save the survey results.
      ' Insert code here to save survey results.
        
      ' Disable the navigation buttons.
      Page4Save.Enabled = False
      Page4Restart.Enabled = False

    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>MultiView.SwitchViewByIndexCommandName Example</title>
</head>
<body>
    <form id="Form1" runat="Server">
        
      <h3>MultiView.SwitchViewByIndexCommandName Example</h3>
        
      <asp:Panel id="Page1ViewPanel" 
        Width="330px" 
        Height="150px"
        HorizontalAlign="Left"
        Font-size="12" 
        BackColor="#C0C0FF" 
        BorderColor="#404040"
        BorderStyle="Double"                     
        runat="Server">  

        <asp:MultiView id="DevPollMultiView"
          ActiveViewIndex="0"
          runat="Server">

          <asp:View id="Page1" 
            runat="Server">   

            <asp:Label id="Page1Label" 
              Font-bold="true"                         
              Text="What kind of applications do you develop?"
              runat="Server"
              AssociatedControlID="Page1">
            </asp:Label>
            
            <br/><br/>

            <asp:RadioButton id="Page1Radio1"
              Text="Web Applications" 
              Checked="False" 
              GroupName="RadioGroup1" 
              runat="server">
            </asp:RadioButton>
            
            <br/>

            <asp:RadioButton id="Page1Radio2"
              Text="Windows Forms Applications" 
              Checked="False" 
              GroupName="RadioGroup1" 
              runat="server">
            </asp:RadioButton>
                     
            <br/><br/><br/>                                       
                     
            <asp:Button id="Page1Next"
              Text = "Next"
              CommandName="NextView"
              Height="25"
              Width="70"
              runat= "Server">
            </asp:Button>     
                          
          </asp:View>

          <asp:View id="Page2" 
            runat="Server">

            <asp:Label id="Page2Label" 
              Font-bold="true"                        
              Text="How long have you been a developer?"
              runat="Server"
              AssociatedControlID="Page2">                    
            </asp:Label>
            
            <br/><br/>

            <asp:RadioButton id="Page2Radio1"
              Text="Less than five years" 
              Checked="False" 
              GroupName="RadioGroup1" 
              runat="Server">
            </asp:RadioButton>
            
            <br/>

            <asp:RadioButton id="Page2Radio2"
              Text="More than five years" 
              Checked="False" 
              GroupName="RadioGroup1" 
              runat="Server">
            </asp:RadioButton>
            
            <br/><br/><br/>

            <asp:Button id="Page2Back"
              Text = "Previous"
              CommandName="PrevView"
              Height="25"
              Width="70"
              runat= "Server">
            </asp:Button> 

            <asp:Button id="Page2Next"
              Text = "Next"
              CommandName="NextView"
              Height="25"
              Width="70"
              runat="Server">
            </asp:Button> 
                
          </asp:View>

          <asp:View id="Page3" 
            runat="Server">

            <asp:Label id="Page3Label1" 
              Font-bold="true"                        
              Text= "What is your primary programming language?"                        
              runat="Server"
              AssociatedControlID="Page3">                    
            </asp:Label>
            
            <br/><br/>

            <asp:RadioButton id="Page3Radio1"
              Text="Visual Basic" 
              Checked="False" 
              GroupName="RadioGroup1" 
              runat="Server">
            </asp:RadioButton>
            
            <br/>

            <asp:RadioButton id="Page3Radio2"
              Text="C#" 
              Checked="False" 
              GroupName="RadioGroup1" 
              runat="Server">
            </asp:RadioButton>
            
            <br/>

            <asp:RadioButton id="Page3Radio3"
              Text="C++" 
              Checked="False" 
              GroupName="RadioGroup1" 
              runat="Server">
            </asp:RadioButton>
            
            <br/><br/>

            <asp:Button id="Page3Back"
              Text = "Previous"
              CommandName="PrevView"
              Height="25"
              Width="70"
              runat="Server">
            </asp:Button> 

            <asp:Button id="Page3Next"
              Text = "Next"
              CommandName="NextView"
              Height="25"
              Width="70"
              runat="Server">
            </asp:Button>
            
            <br/>
                    
          </asp:View>     
            
          <asp:View id="Page4"
            runat="Server">
                    
          <asp:Label id="Label1"
            Font-bold="true"                                           
            Text = "Thank you for taking the survey."
            runat="Server"
            AssociatedControlID="Page4">
          </asp:Label>
                    
          <br/><br/><br/><br/><br/><br/>       
                           
          <asp:Button id="Page4Save"
            Text = "Save Responses"
            OnClick="Page4SaveButton_Click"
            Height="25"
            Width="110"
            runat="Server">
          </asp:Button>
                
          <asp:Button id="Page4Restart"
            Text = "Retake Survey"
            commandname="SwitchViewByIndex"
            commandargument="0"
            Height="25"
            Width="110"
            runat= "Server">
          </asp:Button>                    
                    
        </asp:View>  
       
      </asp:MultiView>
        
    </asp:Panel> 

  </form>
</body>
</html>
<!--</Snippet1>-->
