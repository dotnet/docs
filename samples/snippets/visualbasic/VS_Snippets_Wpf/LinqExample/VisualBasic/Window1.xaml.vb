Imports System
Imports System.Collections.Generic
'<SnippetUsing>
Imports System.Linq
'</SnippetUsing>
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace LinqExample
	Partial Public Class Window1
		Inherits Window
		'<SnippetTasks>
		Private tasks As New Tasks()
		'</SnippetTasks>

		Public Sub New()
			InitializeComponent()

		End Sub

		'<SnippetHandler>
		Private Sub ListBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Dim pri As Integer = Int32.Parse((TryCast((TryCast(sender, ListBox)).SelectedItem, ListBoxItem)).Content.ToString())

			'<SnippetLinq>
            Me.DataContext = From task In tasks
                             Where task.Priority = pri
                             Select task
			'</SnippetLinq>
		End Sub
		'</SnippetHandler>
	End Class

End Namespace

