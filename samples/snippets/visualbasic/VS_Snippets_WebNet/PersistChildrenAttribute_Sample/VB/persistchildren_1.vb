' <snippet1>
' Create a namespace that defines two classes, one a custom control, Employee,
' which is created for every instance of a child element with its name
' declared in a page associated with this namespace, the other, Employees,
' which contains these child elements.
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace PersistChildrenSampleVB

' Create a class that will be rendered as a child of the control
' that has the ParseChildren attribute applied to it.
 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class Employee
   Private _name As String
   Private _title As String
   Private _alias As String
   
   
   Public Sub New()
      Me.New("", "", "")
   End Sub 'New

    
   Public Sub New(name As String, title As String, employeeAlias As String)
      Me._name = name
      Me._title = title
      Me._alias = employeeAlias
   End Sub 'New
   
   Public Property Name() As String
      Get
         Return _name
      End Get
      Set
         _name = value
      End Set
   End Property
   
   
   Public Property Title() As String
      Get
         Return _title
      End Get
      Set
         _title = value
      End Set
   End Property
   
   
   Public Property [Alias]() As String
      Get
         Return _alias
      End Get
      Set
         _alias = value
      End Set
   End Property
End Class 'Employee

' <snippet2>
 ' Use the PersistChildren attribute to set the Persist
 ' property to false so that none of this class's
 ' child controls will be persisted as controls. They will
 ' be persisted only as child elements of this class.
 ' If you set the PersistChildren attribute to true, or if you
 ' do not include this attribute when you create a control,
 ' the child controls will be persisted as controls.
 <PersistChildren(False)>  _
 <AspNetHostingPermission(SecurityAction.Demand, _
   Level:=AspNetHostingPermissionLevel.Minimal)> _
 Public NotInheritable Class CollectionPropertyControl
   Inherits Control
   Private _header As String
   Private _employees As New ArrayList()
   
   
   Public Property Header() As String
      Get
         Return _header
      End Get
      Set
         _header = value
      End Set
   End Property
   
   
   
   
   Public ReadOnly Property Employees() As ArrayList
      Get
         Return _employees
      End Get
   End Property
   
   ' Override the CreateChildControls method to 
   ' add child controls to the Employees property when this
   ' custom control is requested from a page.
   Protected Overrides Sub CreateChildControls()
      Dim label As New Label()
      label.Text = Header
      label.BackColor = Color.Beige
      label.ForeColor = Color.Red
      Controls.Add(label)
      Controls.Add(New LiteralControl("<BR> <BR>"))
      
      Dim table As New Table()
      Dim htr As New TableRow()
      
      Dim hcell1 As New TableHeaderCell()
      hcell1.Text = "Name"
      htr.Cells.Add(hcell1)
      
      Dim hcell2 As New TableHeaderCell()
      hcell2.Text = "Title"
      htr.Cells.Add(hcell2)
      
      Dim hcell3 As New TableHeaderCell()
      hcell3.Text = "Alias"
      htr.Cells.Add(hcell3)
      table.Rows.Add(htr)
      
      table.BorderWidth = Unit.Pixel(2)
      table.BackColor = Color.Beige
      table.ForeColor = Color.Red
      Dim employee As Employee
      For Each employee In  Employees
         Dim tr As New TableRow()
         
         Dim cell1 As New TableCell()
         cell1.Text = employee.Name
         tr.Cells.Add(cell1)
         
         Dim cell2 As New TableCell()
         cell2.Text = employee.Title
         tr.Cells.Add(cell2)
         
         Dim cell3 As New TableCell()
         cell3.Text = employee.Alias
         tr.Cells.Add(cell3)
         
         table.Rows.Add(tr)
      Next employee
      Controls.Add(table)
   End Sub 'CreateChildControls 
 End Class 'CollectionPropertyControl
' </snippet2>
End Namespace ' PersistChildrenSampleVB
' </snippet1>