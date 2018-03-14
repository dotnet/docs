<!-- <Snippet1> -->

<%@ page language="VB" %>
<%@ import namespace="System.Data"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  ' To dynamically create a template for a FormView control,
  ' you must create a custom template class to represent 
  ' the template. This template class represents the item
  ' template for a FormView control.
  Private NotInheritable Class EmployeeTemplate
    Implements ITemplate
    
    ' When implementing the ITemplate interface, you must
    ' the implement the InstantiateIn method. The FormView
    ' control calls this method to create the template's 
    ' content. 
    Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
    
      ' Create the child controls contained in the template.
      ' For this example, the item template displays the
      ' FirstName and LastName field from the data source.
      ' To support data-binding, create event handlers 
      ' for the DataBinding event of the child child controls.
      ' The event handlers must bind the appropriate value 
      ' to the control.
      Dim firstNameLabel As New Label()
      firstNameLabel.ID = "FirstNameLabel"
      AddHandler firstNameLabel.DataBinding, AddressOf FirstNameLabel_DataBinding
      
      Dim nameLineBreak As New LiteralControl("<br/>")
      Dim buttonLineBreak As New LiteralControl("<br/>")

      Dim lastNameLabel As New Label()
      lastNameLabel.ID = "LastNameLabel"
      AddHandler lastNameLabel.DataBinding, AddressOf LastNameLabel_DataBinding

      ' Create a custom button control to display in the item
      ' template. When a button within a FormView control is 
      ' clicked, the ItemCommand event is raised. The ItemCommand
      ' event is used to handle the clicking of this button.
      Dim deleteButton As New Button()
      deleteButton.ID = "DeleteButton"
      deleteButton.CommandName = "Delete"
      deleteButton.Text = "Delete"

      ' Add the controls to the Controls collection of the 
      ' container control.
      container.Controls.Add(firstNameLabel)
      container.Controls.Add(nameLineBreak)
      container.Controls.Add(lastNameLabel)
      container.Controls.Add(buttonLineBreak)
      container.Controls.Add(deleteButton)

    End Sub
    
    ' This event handler binds the value of the FirstName field
    ' to the FirstNameLabel Label control displayed in the template.
    Private Sub FirstNameLabel_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

      ' Use the sender parameter to retrieve the Label control
      ' being bound to data.
      Dim firstNameLabelControl As Label = CType(sender, Label)

      ' Retrieve the value to bind to the Label control. First,
      ' use the NamingContainer property to retrieve the parent 
      ' control of the Label control. In this example, the parent 
      ' control is the FormView control.
      Dim formViewContainer As FormView = CType(firstNameLabelControl.NamingContainer, FormView)
      
      ' Get the data item bound to the FormView control.
      Dim rowView As DataRowView = CType(formViewContainer.DataItem, DataRowView)

      ' Use the data item to retrieve the value of the FirstName field
      ' Set the Text property of the Label control to this value.        
      firstNameLabelControl.Text = rowView("FirstName").ToString()
  
    End Sub

    ' This event handler binds the value of the LastName field
    ' to the LastNameLabel Label control displayed in the template.
    Private Sub LastNameLabel_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

      ' Use the sender parameter to retrieve the Label control
      ' being bound to data.
      Dim lastNameLabelControl As Label = CType(sender, Label)

      ' Retrieve the value to bind to the Label control. First,
      ' use the NamingContainer property to retrieve the parent 
      ' control of the Label control. In this example, the parent 
      ' control is the FormView control.
      Dim formViewContainer As FormView = CType(lastNameLabelControl.NamingContainer, FormView)

      ' Get the data item bound to the FormView control.
      Dim rowView As DataRowView = CType(formViewContainer.DataItem, DataRowView)

      ' Use the data item to retrieve the value of the LastName field
      ' Set the Text property of the Label control to this value.         
      lastNameLabelControl.Text = rowView("LastName").ToString()
    
    End Sub

  End Class

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Create a new FormView object.
    Dim employeesFormView As New FormView()

    ' Set the FormView object's properties.
    employeesFormView.ID = "EmployeesFormView"
    employeesFormView.DataSourceID = "EmployeeSource"
    employeesFormView.AllowPaging = True
    employeesFormView.HeaderText = "Employee Name"
    
    Dim keyArray() As String = {"EmployeeID"}
    employeesFormView.DataKeyNames = keyArray

    ' Programmatically register the event handler for the 
    ' ItemDeleted event of the FormView control.
    AddHandler employeesFormView.ItemDeleted, AddressOf EmployeeFormView_ItemDeleted

    ' Create the dynamic template using the custom template class.
    employeesFormView.ItemTemplate = New EmployeeTemplate()

    ' Add the FormView object to the Controls collection
    ' of the PlaceHolder control.
    FormViewPlaceHolder.Controls.Add(employeesFormView)

  End Sub

  Sub EmployeeFormView_ItemDeleted(ByVal sender As Object, ByVal e As FormViewDeletedEventArgs)
  
    ' Use the Exception property to determine whether an exception
    ' occurred during the delete operation.
    If e.Exception Is Nothing Then
    
      ' Use the AffectedRows property to determine whether the
      ' record was deleted. Sometimes an error might occur that 
      ' does not raise an exception, but prevents the delete
      ' operation from completing.
      If e.AffectedRows = 1 Then
      
        MessageLabel.Text = "Record deleted successfully."
      
      Else
              
        MessageLabel.Text = "An error occurred during the delete operation."
      
      End If
    
    Else
    
      ' Insert the code to handle the exception.
      MessageLabel.Text = e.Exception.Message
      
      ' Use the ExceptionHandled property to indicate that the 
      ' exception is already handled.
      e.ExceptionHandled = True
      
    End If
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>FormViewDeletedEventHandler Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormViewDeletedEventHandler Example</h3>
      
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated FormView control.            -->       
      <asp:placeholder id="FormViewPlaceHolder"
        runat="server"/>
            
      <br/><br/>
      
      <asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>
          
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName], [Title], [PhotoPath] From [Employees]"
        deletecommand="Delete [Employees] Where [EmployeeID]=@EmployeeID"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
            
    </form>
  </body>
</html>

<!-- </Snippet1> -->