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
    ' implement the InstantiateIn method. The FormView
    ' control calls this method to create the template's 
    ' content. 
    Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
    
      ' Create the child controls contained in the template.
      ' For this example, the item template displays the
      ' FirstName and LastName fields from the data source.
      ' To support data binding, create event handlers 
      ' for the DataBinding event of each child child control.
      ' The event handler must bind the appropriate value 
      ' to the control.
      Dim firstNameLabel As New Label()
      firstNameLabel.ID = "FirstNameLabel"
      AddHandler firstNameLabel.DataBinding, AddressOf FirstNameLabel_DataBinding
      
      Dim lineBreak As LiteralControl = New LiteralControl("<br/>")
      
      Dim lastNameLabel As New Label()
      lastNameLabel.ID = "LastNameLabel"
      AddHandler lastNameLabel.DataBinding, AddressOf LastNameLabel_DataBinding

      ' Add the controls to the Controls collection of the 
      ' container control.
      container.Controls.Add(firstNameLabel)
      container.Controls.Add(lineBreak)
      container.Controls.Add(lastNameLabel)
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
    employeesFormView.PagerSettings.Mode = PagerButtons.NextPrevious
    employeesFormView.HeaderText = "Employee Name"
    employeesFormView.RowStyle.BackColor = System.Drawing.Color.LightBlue
    employeesFormView.HeaderStyle.BackColor = System.Drawing.Color.Silver
    employeesFormView.PagerStyle.BackColor = System.Drawing.Color.Silver

    ' Create the dynamic template using the custom template class.
    employeesFormView.ItemTemplate = New EmployeeTemplate()

    ' Add the FormView object to the Controls collection
    ' of the PlaceHolder control.
    DetailsViewPlaceHolder.Controls.Add(employeesFormView)

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" > 
  <head runat="server">
    <title>FormView Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>FormView Constructor Example</h3>
        
      <!-- Use a PlaceHolder control as the container for the -->
      <!-- dynamically generated FormView control.            -->       
      <asp:PlaceHolder id="DetailsViewPlaceHolder"
        runat="server"/>
            
      <!-- This example uses Microsoft SQL Server and connects  -->
      <!-- to the Northwind sample database. Use an ASP.NET     -->
      <!-- expression to retrieve the connection string value   -->
      <!-- from the Web.config file.                            -->
      <asp:sqldatasource id="EmployeeSource"
        selectcommand="Select [EmployeeID], [LastName], [FirstName] From [Employees]"
        connectionstring="<%$ ConnectionStrings:NorthWindConnectionString%>" 
        runat="server"/>
          
    </form>
  </body>
</html>

<!-- </Snippet1> -->
