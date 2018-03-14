Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Resources
Imports System.Windows.Markup
Imports System.Threading
Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		Private Sub OnStartup(ByVal sender As Object, ByVal e As RoutedEventArgs)

			' <Snippet2>
			Dim childrenCountSlider As Slider = CType(LogicalTreeHelper.FindLogicalNode(myWindow, "ChildrenCountSlider"), Slider)
			AddHandler childrenCountSlider.ValueChanged, AddressOf OnChildrenCountChanged
			'</Snippet2>

			Dim columnCountSlider As Slider = CType(LogicalTreeHelper.FindLogicalNode(myWindow, "ColumnCountSlider"), Slider)
			AddHandler columnCountSlider.ValueChanged, AddressOf OncolumnCountChanged

		End Sub




		'///////////////// Event Handlers


'<SnippetRoutedPropertyChangedEvent>
		Private Sub OnChildrenCountChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))
			Dim childrenCount As Integer = CInt(Fix(Math.Floor(e.NewValue + 0.5)))

			'  Update the children count...
			Dim g As AutoIndexingGrid = CType(LogicalTreeHelper.FindLogicalNode(myWindow, "TargetGrid"), AutoIndexingGrid)
			Do While g.Children.Count < childrenCount
				Dim c As New Control()
				g.Children.Add(c)
				c.Style = CType(c.FindResource("ImageWithBorder"), Style)
			Loop
			Do While g.Children.Count > childrenCount
				g.Children.Remove(g.Children(g.Children.Count - 1))
			Loop

			' <Snippet6>

			'  Update TextBlock element displaying the count...
			Dim t As TextBlock = CType(LogicalTreeHelper.FindLogicalNode(myWindow, "ChildrenCountDisplay"), TextBlock)
			t.Text = childrenCount.ToString()
			'</Snippet6>
		End Sub
'</SnippetRoutedPropertyChangedEvent>

		Private Sub OncolumnCountChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))
			Dim columnCount As Integer = CInt(Fix(Math.Floor(e.NewValue + 0.5)))

			'  Update column count...
			Dim g As AutoIndexingGrid = CType(LogicalTreeHelper.FindLogicalNode(myWindow, "TargetGrid"), AutoIndexingGrid)
			Do While g.ColumnDefinitions.Count < columnCount
				g.ColumnDefinitions.Add(New ColumnDefinition())
			Loop
			Do While g.ColumnDefinitions.Count > columnCount
				g.ColumnDefinitions.Remove(g.ColumnDefinitions(g.ColumnDefinitions.Count - 1))
			Loop

			'  Update TextBlock element displaying the count...
			Dim t As TextBlock = CType(LogicalTreeHelper.FindLogicalNode(myWindow, "ColumnCountDisplay"), TextBlock)
			t.Text = columnCount.ToString()
		End Sub


	End Class


	 ''' <summary>
	''' AutoIndexingGrid - sample implementation of auto indexing, row primary grid
	''' </summary>

	' <Snippet5>
	Public Class AutoIndexingGrid
		Inherits Grid
		' <Snippet3>
		Protected Overrides Function MeasureOverride(ByVal constraint As Size) As Size
			If _updateChildenIndices OrElse _columnCount <> MyBase.ColumnDefinitions.Count Then
				_updateChildenIndices = False
				_columnCount = MyBase.ColumnDefinitions.Count

				'  Update the number of rows
				Dim newRowCount As Integer = ((MyBase.Children.Count - 1) / _columnCount + 1)
				Do While MyBase.RowDefinitions.Count < newRowCount
					MyBase.RowDefinitions.Add(New RowDefinition())
				Loop
				If MyBase.RowDefinitions.Count > newRowCount Then
					MyBase.RowDefinitions.RemoveRange(newRowCount, MyBase.RowDefinitions.Count - newRowCount)
				End If

				'  Update children indices
				Dim i As Integer = 0
				Dim childrenCount As Integer = MyBase.Children.Count
				Do While i < childrenCount
					Dim child As UIElement = MyBase.Children(i)
					Grid.SetColumn(child, i Mod _columnCount)
					Grid.SetRow(child, i \ _columnCount)
					i += 1
				Loop
			End If

			Return (MyBase.MeasureOverride(constraint))
		End Function
		'</Snippet3>

		' <Snippet4>
		Protected Overrides Sub OnVisualChildrenChanged(ByVal visualAdded As DependencyObject, ByVal visualRemoved As DependencyObject)
			'  Remember that children collection has changed 
			_updateChildenIndices = True

			MyBase.OnVisualChildrenChanged(visualAdded, visualRemoved)
		End Sub
		'</Snippet4>

		Private _updateChildenIndices As Boolean = True ' A value of "true" forces children to be re-indexed at the next oportunity
		Private _columnCount As Integer
	End Class
	'</Snippet5>
End Namespace


