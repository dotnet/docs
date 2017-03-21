Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Globalization
Imports System.Windows.Media
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Collections.Generic


Namespace ListViewSnips
  ''' <summary>
  ''' Interaction logic for Window1.xaml
  ''' </summary>

  Partial Public Class Window1
	  Inherits Window
	Public Sub New()
	  InitializeComponent()
	End Sub

	  Private Sub Refresh(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  '<SnippetRefreshView>
		  Dim dataView As ICollectionView = CollectionViewSource.GetDefaultView(theListView.ItemsSource)
		  dataView.Refresh()
		  '</SnippetRefreshView>
	  End Sub
        ' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        ' private sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        ' Sample event handler:  
        ' private sub ButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)

  End Class
  Public Class SelectFavoriteCityTemplate
	  Inherits DataTemplateSelector
	 Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
		 Dim fre As FrameworkElement = CType(container, FrameworkElement)
		 Return (TryCast(fre.FindResource("FavoriteCityCellTemplate"), DataTemplate))
	 End Function
  End Class
	'<SnippetBackgroundConverter>
	Public NotInheritable Class BackgroundConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim item As ListViewItem = CType(value, ListViewItem)
			Dim listView As ListView = TryCast(ItemsControl.ItemsControlFromItemContainer(item), ListView)
			' Get the index of a ListViewItem
			Dim index As Integer = listView.ItemContainerGenerator.IndexFromContainer(item)

			If index Mod 2 = 0 Then
				Return Brushes.LightBlue
			Else
				Return Brushes.Beige
			End If
		End Function
		'</SnippetBackgroundConverter>

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotSupportedException()
		End Function
	End Class

	'<SnippetSubListView>
	Public Class SubListView
		Inherits ListView
		Protected Overrides Sub PrepareContainerForItemOverride(ByVal element As DependencyObject, ByVal item As Object)
			MyBase.PrepareContainerForItemOverride(element, item)
			If TypeOf View Is GridView Then
				Dim index As Integer = ItemContainerGenerator.IndexFromContainer(element)
				Dim lvi As ListViewItem = TryCast(element, ListViewItem)
				If index Mod 2 = 0 Then
					lvi.Background = Brushes.LightBlue
				Else
					lvi.Background = Brushes.Beige
				End If
			End If
		End Sub
	End Class
	'</SnippetSubListView>

	'<SnippetItemStyleSelector>
	Public Class ListViewItemStyleSelector
		Inherits StyleSelector
		Public Overrides Function SelectStyle(ByVal item As Object, ByVal container As DependencyObject) As Style
			Dim st As New Style()
			st.TargetType = GetType(ListViewItem)
			Dim backGroundSetter As New Setter()
			backGroundSetter.Property = ListViewItem.BackgroundProperty
			Dim listView As ListView = TryCast(ItemsControl.ItemsControlFromItemContainer(container), ListView)
			Dim index As Integer = listView.ItemContainerGenerator.IndexFromContainer(container)
			If index Mod 2 = 0 Then
				backGroundSetter.Value = Brushes.LightBlue
			Else
				backGroundSetter.Value = Brushes.Beige
			End If
			st.Setters.Add(backGroundSetter)
			Return st
		End Function
	End Class
	'</SnippetItemStyleSelector>


End Namespace