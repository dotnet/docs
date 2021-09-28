Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace TableSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

			TableRowGroupsProperty()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			TableColumnsProperty()
			TableRowGroupsProperty()
			TableRowGroupRows()
			TableCellConst()
		End Sub

		Private Sub TableColumnsProperty()

			' <Snippet_Table_Columns_Add>
			Dim tbl As New Table()
			Dim columnsToAdd As Integer = 4
			For x As Integer = 0 To columnsToAdd - 1
				tbl.Columns.Add(New TableColumn())
			Next x
			' </Snippet_Table_Columns_Add>

			' Insert a new first column.
			' <Snippet_Table_Columns_Insert>
			tbl.Columns.Insert(0, New TableColumn())
			' </Snippet_Table_Columns_Insert>

			' Manipulating columns.
			' <Snippet_Table_Columns_Manip>
			tbl.Columns(0).Width = New GridLength(20)
			tbl.Columns(1).Background = Brushes.AliceBlue
			tbl.Columns(2).Width = New GridLength(20)
			tbl.Columns(3).Background = Brushes.AliceBlue
			' </Snippet_Table_Columns_Manip>

			' Get a count of columns hosted by the table.
			' <Snippet_Table_Columns_Count>
			Dim columns As Integer = tbl.Columns.Count
			' </Snippet_Table_Columns_Count>

			' Remove a particular column by reference (the 4th).
			' <Snippet_Table_Columns_DelRef>
			tbl.Columns.Remove(tbl.Columns(3))
			' </Snippet_Table_Columns_DelRef>

			' Remove a particular column by index (the 3rd).
			' <Snippet_Table_Columns_DelIndex>
			tbl.Columns.RemoveAt(2)
			' </Snippet_Table_Columns_DelIndex>

			' Remove all columns from the table's columns collection.
			' <Snippet_Table_Columns_Clear>
			tbl.Columns.Clear()
			' </Snippet_Table_Columns_Clear>
		End Sub

		Private Sub TableRowGroupsProperty()
			' Add rowgroups...
			' <Snippet_Table_RowGroups_Add>
			Dim tbl As New Table()
			Dim rowGroupsToAdd As Integer = 4
			For x As Integer = 0 To rowGroupsToAdd - 1
				tbl.RowGroups.Add(New TableRowGroup())
			Next x
			' </Snippet_Table_RowGroups_Add>

			' Insert rowgroup...
			' <Snippet_Table_RowGroups_Insert>
			tbl.RowGroups.Insert(0, New TableRowGroup())
			' </Snippet_Table_RowGroups_Insert>

			' Adding rows to a rowgroup...
				' <Snippet_Table_RowGroups_AddRows>
				Dim rowsToAdd As Integer = 10
				For x As Integer = 0 To rowsToAdd - 1
					tbl.RowGroups(0).Rows.Add(New TableRow())
				Next x
				' </Snippet_Table_RowGroups_AddRows>

			' Manipulating rows (through rowgroups)...

			' <Snippet_Table_RowGroups_ManipRows>
			' Alias the working TableRowGroup for ease in referencing.
			Dim trg As TableRowGroup = tbl.RowGroups(0)
			trg.Rows(0).Background = Brushes.CornflowerBlue
			trg.Rows(1).FontSize = 24
			trg.Rows(2).ToolTip = "This row's tooltip"
			' </Snippet_Table_RowGroups_ManipRows>

			' Adding cells to a row...
				' <Snippet_Table_RowGroups_AddCells>
				Dim cellsToAdd As Integer = 10
				For x As Integer = 0 To cellsToAdd - 1
					tbl.RowGroups(0).Rows(0).Cells.Add(New TableCell(New Paragraph(New Run("Cell " & (x + 1)))))
				Next x
				' </Snippet_Table_RowGroups_AddCells>

			' Manipulating cells (through rowgroups)...

			' <Snippet_Table_RowGroups_ManipCells>
			' Alias the working row for ease in referencing.
			Dim row As TableRow = tbl.RowGroups(0).Rows(0)
			row.Cells(0).Background = Brushes.PapayaWhip
			row.Cells(1).FontStyle = FontStyles.Italic
			' This call clears all of the content from this cell.
			row.Cells(2).Blocks.Clear()
			' </Snippet_Table_RowGroups_ManipCells>

			' Count rowgroups...
			' <Snippet_Table_RowGroups_Count>
			Dim rowGroups As Integer = tbl.RowGroups.Count
			' </Snippet_Table_RowGroups_Count>

			' Remove rowgroup by ref...
			' <Snippet_Table_RowGroups_DelRef>
			tbl.RowGroups.Remove(tbl.RowGroups(0))
			' </Snippet_Table_RowGroups_DelRef>

			' Remove rowgroup by index...
			' <Snippet_Table_RowGroups_DelIndex>
			tbl.RowGroups.RemoveAt(0)
			' </Snippet_Table_RowGroups_DelIndex>

			' Remove all rowgroups...
			' <Snippet_Table_RowGroups_Clear>
			tbl.RowGroups.Clear()
			' </Snippet_Table_RowGroups_Clear>
		End Sub

		Private Sub TableRowGroupRows()
			' <Snippet_TableRowGroup_Rows>
			Dim tbl As New Table()
			Dim trg As New TableRowGroup()

			tbl.RowGroups.Add(trg)

			' Add rows to a TableRowGroup collection.
			Dim rowsToAdd As Integer = 4
			For x As Integer = 0 To rowsToAdd - 1
				trg.Rows.Add(New TableRow())
			Next x

			' Insert a new first row (at the zero-index position).
			trg.Rows.Insert(0, New TableRow())

			' Manipulate rows...

			' Set the background on the first row.
			trg.Rows(0).Background = Brushes.CornflowerBlue
			' Set the font size on the second row.
			trg.Rows(1).FontSize = 24
			' Set a tooltip for the third row.
			trg.Rows(2).ToolTip = "This row's tooltip"

			' Adding cells to a row...
				Dim cellsToAdd As Integer = 10
				For x As Integer = 0 To cellsToAdd - 1
					trg.Rows(0).Cells.Add(New TableCell(New Paragraph(New Run("Cell " & (x + 1)))))
				Next x

			' Count rows.
			Dim rows As Integer = trg.Rows.Count

			' Remove 1st row by reference.
			trg.Rows.Remove(trg.Rows(0))

			' Remove all rows...
			trg.Rows.Clear()
			' </Snippet_TableRowGroup_Rows>        
		End Sub

		Private Sub TableCellConst()
			' <Snippet_TableCell_Const1>
			' A child Block element for the new TableCell element.
			Dim parx As New Paragraph(New Run("A bit of text content..."))

			' After this line executes, the new element "cellx"
			' contains the specified Block element, "parx".
			Dim cellx As New TableCell(parx)
			' </Snippet_TableCell_Const1>
		End Sub
	End Class
End Namespace
