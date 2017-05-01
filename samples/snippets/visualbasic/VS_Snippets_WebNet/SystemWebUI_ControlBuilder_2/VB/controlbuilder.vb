' <snippet1> 
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.Drawing
Imports System.Security.Permissions


Namespace CustomControls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyTableCell
        Inherits TableCell
        Implements INamingContainer
    End Class


    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyCell
        Inherits Control
        Implements INamingContainer
        ' Class Name: MyCell.
        ' Declares the class for the child controls to be included in the control collection.

        Private _id As String
        Private _value As String
        Private _backColor As Color

        Public Property CellID() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property Text() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property


        Public Property BackColor() As Color
            Get
                Return _backColor
            End Get
            Set(ByVal value As Color)
                _backColor = value
            End Set
        End Property
    End Class

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyControlBuilderVB
        Inherits ControlBuilder

        Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attribs As IDictionary) As Type

            ' Allows TableRow without "runat=server" attribute to be added to the collection.
            If (String.Compare(tagName, "mycell", True) = 0) Then
                Return GetType(MyCell)
            End If
            Return Nothing
        End Function

        ' Ignores literals between rows.
        Public Overrides Sub AppendLiteralString(ByVal s As String)
            ' Ignores literals between rows.
        End Sub

    End Class

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal), ControlBuilderAttribute(GetType(MyControlBuilderVB))> _
        Public Class MyVB_CustomControl
        Inherits Control
        Implements INamingContainer

        ' Class name: MyVB_CustomControl.
        ' Processes the element declarations within a control 
        ' declaration. This builds the actual control.

        ' Custom control to build programmatically.
        Private _table As Table

        Private _cellObjects As New Hashtable()

        ' Variables that must contain the control attributes as defined in the Web page.
        Private _rows As Integer
        Private _columns As Integer
        Private _title As String

        ' Rows property to be used as the attribute name in the Web page.     
        Public Property Rows() As Integer
            Get
                Return _rows
            End Get
            Set(ByVal value As Integer)
                _rows = value
            End Set
        End Property

        ' Columns property to be used as the attribute name in the Web page.

        Public Property Columns() As Integer
            Get
                Return _columns
            End Get
            Set(ByVal value As Integer)
                _columns = value
            End Set
        End Property

        ' Title property to be used as the attribute name in the Web page   
        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal value As String)
                _title = value
            End Set
        End Property


        Protected Sub createNewRow(ByVal rowNumber As Integer)

            ' Creates a row and adds it to the table.
            Dim row As TableRow

            row = New TableRow()
            _table.Rows.Add(row)

            ' Creates a cell that contains text.
            Dim y As Integer
            For y = 0 To Columns - 1
                appendCell(row, rowNumber, y)
            Next y
        End Sub 'createNewRow


        Protected Sub appendCell(ByVal row As TableRow, ByVal rowNumber As Integer, ByVal cellNumber As Integer)
            Dim cell As TableCell
            Dim textbox As TextBox

            cell = New TableCell()

            textbox = New TextBox()

            cell.Controls.Add(textbox)

            textbox.ID = "r" + rowNumber.ToString() + "c" + cellNumber.ToString()

            ' Checks for the MyCell child object.
            If Not (_cellObjects(textbox.ID) Is Nothing) Then
                Dim cellLookup As MyCell
                cellLookup = CType(_cellObjects(textbox.ID), MyCell)

                textbox.Text = cellLookup.Text
                textbox.BackColor = cellLookup.BackColor

            Else
                textbox.Text = "Row: " + rowNumber.ToString() + " Cell: " + cellNumber.ToString()
            End If

            row.Cells.Add(cell)
        End Sub 'appendCell

        ' Called at runtime when a child object is added to the collection.
        Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)

            Dim cell As MyCell = CType(obj, MyCell)
            If Not (cell Is Nothing) Then
                _cellObjects.Add(cell.CellID, cell)
            End If
        End Sub 'AddParsedSubObject


        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            ' Sub name: OnPreRender.
            ' Carries out changes affecting the control state and renders the resulting UI.

            ' Increases the number of rows if needed.
            While _table.Rows.Count < Rows
                createNewRow(_table.Rows.Count)
            End While

            ' Checks that each row has the correct number of columns.
            Dim i As Integer
            For i = 0 To _table.Rows.Count - 1
                While _table.Rows(i).Cells.Count < Columns
                    appendCell(_table.Rows(i), i, _table.Rows(i).Cells.Count)
                End While

                While _table.Rows(i).Cells.Count > Columns
                    _table.Rows(i).Cells.RemoveAt((_table.Rows(i).Cells.Count - 1))
                End While
            Next i
        End Sub 'OnPreRender


        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub CreateChildControls()
            ' Sub name: CreateChildControls.
            ' Adds the Table and the text controls to the control collection. 


            Dim [text] As LiteralControl

            ' Initializes the text control using the Title property.
            [text] = New LiteralControl("<h5>" + Title + "</h5>")
            Controls.Add([text])


            _table = New Table()

            Controls.Add(_table)
        End Sub
    End Class

End Namespace

' </snippet1>
