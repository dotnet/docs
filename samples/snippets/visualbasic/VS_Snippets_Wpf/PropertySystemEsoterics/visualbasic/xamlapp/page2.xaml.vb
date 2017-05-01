Imports System
Imports System.Windows
Imports System.Collections
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Controls.Primitives
Imports System.Text
Imports System.Windows.Media.Animation

Namespace SDKSample
	Partial Public Class XAMLAPPPage2
	  Private Sub OnDPSelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
		Dim selected As ListBoxItem = CType(e.AddedItems(0), ListBoxItem) ' we won't handle multiselect
		Dim pm As PropertyMetadata
		Dim dp As DependencyProperty = Nothing
		Select Case selected.Content.ToString()
		  Case ("ToggleButton.IsChecked")
			dp = ToggleButton.IsCheckedProperty
		  Case("Control.Background")
			dp = Control.BackgroundProperty
		  Case ("Storyboard.TargetName")
			dp = Storyboard.TargetNameProperty
		  Case ("FrameworkElement.DataContext")
			dp = FrameworkElement.DataContextProperty
		  Case ("FrameworkElement.Margin")
			dp = FrameworkElement.MarginProperty
		  Case ("ToolBar.Orientation")
			dp = ToolBar.OrientationProperty
		  Case ("UIElement.Visibility")
			dp = UIElement.VisibilityProperty
		End Select
		'<SnippetDPProps>
		'<SnippetDPGetMetadataSingle>        
		pm = dp.GetMetadata(dp.OwnerType)
		'</SnippetDPGetMetadataSingle>
		MetadataClass.Text = pm.GetType().Name
		TypeofPropertyValue.Text = dp.PropertyType.Name
		DefaultPropertyValue.Text = If((pm.DefaultValue IsNot Nothing), pm.DefaultValue.ToString(), "null")
		HasCoerceValue.Text = If((pm.CoerceValueCallback Is Nothing), "No", pm.CoerceValueCallback.Method.Name)
		HasPropertyChanged.Text = If((pm.PropertyChangedCallback Is Nothing), "No", pm.PropertyChangedCallback.Method.Name)
            [ReadOnly].Text = If((dp.ReadOnly), "Yes", "No")
		'</SnippetDPProps>
		'<SnippetFPMProperties>
		Dim fpm As FrameworkPropertyMetadata = TryCast(pm, FrameworkPropertyMetadata)
		If fpm IsNot Nothing Then
			AffectsArrange.Text = If((fpm.AffectsArrange), "Yes", "No")
			AffectsMeasure.Text = If((fpm.AffectsMeasure), "Yes", "No")
			AffectsRender.Text = If((fpm.AffectsRender), "Yes", "No")
                [Inherits].Text = If((fpm.Inherits), "Yes", "No")
			IsDataBindingAllowed.Text = If((fpm.IsDataBindingAllowed), "Yes", "No")
			BindsTwoWayByDefault.Text = If((fpm.BindsTwoWayByDefault), "Yes", "No")
		'</SnippetFPMProperties>
		Else
			AffectsArrange.Text = "N/A"
			AffectsMeasure.Text = "N/A"
			AffectsRender.Text = "N/A"
                [Inherits].Text = "N/A"
			IsDataBindingAllowed.Text = "N/A"
			BindsTwoWayByDefault.Text = "N/A"
		End If
		'<SnippetDPDefaultValue>
		Dim pmDefault As PropertyMetadata = dp.DefaultMetadata
		'</SnippetDPDefaultValue>

	  End Sub
	  '<SnippetTrySetValue>
	  Private Sub TrySetValue(ByVal target As DependencyObject, ByVal dp As DependencyProperty, ByVal providedValue As Object)
		If dp.IsValidType(providedValue) Then
		  target.SetValue(dp, providedValue)
		End If
	  End Sub
	  '</SnippetTrySetValue>
	  '<SnippetTrySetValueWithValidate>
	  Private Sub TrySetValueWithValidate(ByVal target As DependencyObject, ByVal dp As DependencyProperty, ByVal providedValue As Object)
		If dp.IsValidValue(providedValue) Then
		  target.SetValue(dp, providedValue)
		End If
	  End Sub
	  '</SnippetTrySetValueWithValidate>
	End Class
End Namespace