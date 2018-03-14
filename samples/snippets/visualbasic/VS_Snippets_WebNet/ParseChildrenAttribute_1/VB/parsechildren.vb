' <snippet1>
Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls


    ' The child element class.

    <AspNetHostingPermission(SecurityAction.Demand, _
       Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class Employee
        Private _name As String
        Private _title As String
        Private _alias As String


        Public Sub New()
            Me.New("", "", "")
        End Sub 'New


        Public Sub New(ByVal name As String, ByVal title As String, ByVal employeeAlias As String)
            Me._name = name
            Me._title = title
            Me._alias = employeeAlias
        End Sub 'New

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = Value
            End Set
        End Property


        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = Value
            End Set
        End Property


        Public Property [Alias]() As String
            Get
                Return _alias
            End Get
            Set(ByVal value As String)
                _alias = Value
            End Set
        End Property
    End Class 'Employee
    ' <snippet2>
    ' Use the ParseChildren attribute to set the ChildrenAsProperties
    ' and DefaultProperty properties. Using this constructor, the
    ' control parses all child controls as properties and must define
    ' a public property named Employees, which it declares as
    ' an ArrayList. Nested (child) elements must correspond to
    ' child elements of the Employees property or to other
    ' properties of the control.   
    <ParseChildren(True, "Employees")> _
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
            Set(ByVal value As String)
                _header = Value
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
            label.BackColor = System.Drawing.Color.Beige
            label.ForeColor = System.Drawing.Color.Red
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
            table.BackColor = System.Drawing.Color.Beige
            table.ForeColor = System.Drawing.Color.Red
            Dim employee As Employee
            For Each employee In Employees
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
    End Class 
' </snippet2>
End Namespace
' </snippet1>