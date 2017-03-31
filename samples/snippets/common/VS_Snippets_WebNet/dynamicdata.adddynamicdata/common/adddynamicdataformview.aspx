<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDynamicDataFormView.aspx.cs" Inherits="AddDynamicDataFormView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <h2 class="DDSubHeader">Accessing <%= table.DisplayName%> Using a FormView Control and Dynamic Data</h2>
  
    <br />
    
    <div class="DDNavigation">
       <a id="A3" runat="server" href="~/default.aspx">
       <img id="Img3" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
    
    <div class="ExampleView"> 
     This example shows how to add dynamic behavior to the 
     <code><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.formview.aspx" 
        target="_blank">System.Web.UI.WebControls.FormView</a></code> control by using the following types:
        <ul>
           <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamicdatamanager.aspx" 
                target="_blank">System.Web.DynamicData.DynamicDataManager</a></code></li>
            <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamicvalidator.aspx" 
                target="_blank">System.Web.DynamicData.DynamicValidator</a></code></li>
            <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamiccontrol.aspx" 
                target="_blank">System.Web.DynamicData.DynamicControl</a></code></li>
        </ul>
     </div>
     
    <form id="form1" runat="server">
    
       
        <%-- Define the script manager to manage partial rendering. --%>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"/>
        
       
        <hr />
   
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  
            <ContentTemplate>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" 
                    HeaderText="List of validation errors" CssClass="DDValidator" />
                <asp:DynamicValidator runat="server" ID="DynamicValidator1"
                    ControlToValidate="FormViewId" Display="None" CssClass="DDValidator"  />

                 <asp:DynamicDataManager ID="DynamicDataManager1" runat="server">
                    <DataControls>
                        <asp:DataControlReference ControlID="FormViewId" />
                    </DataControls>
                </asp:DynamicDataManager>
        
                <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                    ContextTypeName="AdventureWorksLT_DataModel.AdventureWorksLT_DataEntities" 
                    EnableDelete="True" 
                    EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
                    EntitySetName="Customers">
                </asp:EntityDataSource>

	      <%-- <Snippet4> --%>
              <asp:FormView ID="FormViewId" runat="server" AllowPaging="True"  CssClass="DDDetailsTable"
                  DataSourceID="EntityDataSource1">
                  <EditItemTemplate>
                      FirstName:
                      <asp:DynamicControl ID="FirstNameDynamicControl" runat="server" 
                          DataField="FirstName" Mode="Edit" />
                      <br />
                      LastName:
                      <asp:DynamicControl ID="LastNameDynamicControl" runat="server" 
                          DataField="LastName" Mode="Edit" />
                      <br />
                      CompanyName:
                      <asp:DynamicControl ID="CompanyNameDynamicControl" runat="server" 
                          DataField="CompanyName" Mode="Edit" />
                      <br />
                      EmailAddress:
                      <asp:DynamicControl ID="EmailAddressDynamicControl" runat="server" 
                          DataField="EmailAddress" Mode="Edit" />
                      <br />
                      ModifiedDate:
                      <asp:DynamicControl ID="ModifiedDateDynamicControl" runat="server" 
                          DataField="ModifiedDate" Mode="Edit" />
                      <br />
                      <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                          CommandName="Update" Text="Update" />
                      &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                          CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                  </EditItemTemplate>
                  
                  <ItemTemplate>
                  <table  class="DDDetailsTable">
                    <tr> 
                        <td> FirstName:</td>
                        <td> <asp:DynamicControl ID="FirstNameDynamicControl" runat="server" 
                          DataField="FirstName" /></td> 
                    </tr>
                   
                    <tr>
                        <td> LastName: </td>
                        <td> <asp:DynamicControl ID="LastNameDynamicControl" runat="server" 
                          DataField="LastName" /></td>
                    </tr>                
                    <tr>
                        <td> Company Name: </td>
                        <td> <asp:DynamicControl ID="CompanyNameDynamicControl" runat="server" 
                          DataField="CompanyName" /> </td>
                    </tr>
                    <tr>
                        <td>EmailAddress:</td>
                        <td><asp:DynamicControl ID="EmailAddressDynamicControl" runat="server" 
                            DataField="EmailAddress" /></td>
                    </tr>
                    <tr>
                        <td> Modified Date:</td>
                        <td><asp:DynamicControl ID="ModifiedDateDynamicControl4" runat="server" 
                          DataField="ModifiedDate" /></td>
                    </tr>
                        
                  </table>
                     
                  <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Edit" /> &nbsp;
                  <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this item?");' />
         
                  </ItemTemplate>
                  
              </asp:FormView>

	      <%-- </Snippet4> --%>

            </ContentTemplate>


        </asp:UpdatePanel>
    </form>
</body>
</html>
