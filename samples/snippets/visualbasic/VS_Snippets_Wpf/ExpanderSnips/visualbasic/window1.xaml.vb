Namespace ExpanderSnips
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub InitializeExpander(ByVal sender As Object, ByVal e As EventArgs)
		'<SnippetCollapsed>
		 AddHandler myExpander.Collapsed, AddressOf expanderHasCollapsed
		'</SnippetCollapsed>

		 '<SnippetExpanded>
		 AddHandler yourExpander.Expanded, AddressOf expanderHasExpanded
		 '</SnippetExpanded>

		 '<SnippetExpandDirection>
		 myExpanderOpensUp.ExpandDirection = ExpandDirection.Up
		 '</SnippetExpandDirection>


		 '<SnippetIsExpanded>
		 myExpanderIsExpanded.IsExpanded = True
		 '</SnippetIsExpanded>
		End Sub
		'<SnippetCollapsedHandler>
		Private Sub expanderHasCollapsed(ByVal sender As Object, ByVal args As RoutedEventArgs)
			'Do something when the Expander control collapses
		End Sub
		'</SnippetCollapsedHandler>

		'<SnippetExpandedHandler>
		Private Sub expanderHasExpanded(ByVal sender As Object, ByVal args As RoutedEventArgs)
			'Do something when the Expander control expands
		End Sub
		'</SnippetExpandedHandler>
	End Class
End Namespace