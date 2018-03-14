' WebControlDesignerCollectionEditors.vb
' <snippet5>
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Drawing.Design

Namespace Examples.VB.WebControls.Design

    Public Class CustomWebControl
        Inherits System.Web.UI.WebControls.WebControl

        Private textData As String

        ' <snippet1>        
        Private cells As TableCellCollection

        ' Associate the TableCellsCollectionEditor with the TestCells.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            TableCellsCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property TestCells() As TableCellCollection
            Get
                Return cells
            End Get
        End Property ' TestCells
        ' </snippet1>

        ' <snippet2>
        Private rows As TableRowCollection

        ' Associate the TableRowsCollectionEditor with the TestRows.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            TableRowsCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property TestRows() As TableRowCollection
            Get
                Return rows
            End Get
        End Property ' TestRows
        ' </snippet2>

        ' <snippet3>
        Private items As ListItemCollection

        ' Associate the ListItemsCollectionEditor with the ListItems.
        <EditorAttribute( GetType(System.Web.UI.Design.WebControls. _
            ListItemsCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property ListItems() As ListItemCollection
            Get
                Return items
            End Get
        End Property ' ListItems
        ' </snippet3>

        ' <snippet4>
        Private columns As DataGridColumnCollection

        ' Associate DataGridColumnCollectionEditor with the TestColumns.
        <EditorAttribute( GetType( System.Web.UI.Design.WebControls. _
            DataGridColumnCollectionEditor), _
            GetType(UITypeEditor))> _
        Public ReadOnly Property TestColumns() As DataGridColumnCollection
            Get
                Return columns
            End Get
        End Property ' TestColumns
        ' </snippet4> 

        <Bindable(True), Category("Appearance"), DefaultValue("")> _
        Public Property TextEntry() As String
            Get
                Return textData
            End Get

            Set(ByVal Value As String)
                textData = value
            End Set
        End Property ' TextEntry

        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
            output.Write(textData)
        End Sub ' Render

    End Class ' CustomWebControl
End Namespace ' Examples.VB.WebControls.Design
' </snippet5>
