Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	'<SnippetPlainView>
	Public Class PlainView
		Inherits ViewBase

	  Public Shared ReadOnly ItemContainerStyleProperty As DependencyProperty = ItemsControl.ItemContainerStyleProperty.AddOwner(GetType(PlainView))

	  Public Property ItemContainerStyle() As Style
		  Get
			  Return CType(GetValue(ItemContainerStyleProperty), Style)
		  End Get
		  Set(ByVal value As Style)
			  SetValue(ItemContainerStyleProperty, value)
		  End Set
	  End Property

	  Public Shared ReadOnly ItemTemplateProperty As DependencyProperty = ItemsControl.ItemTemplateProperty.AddOwner(GetType(PlainView))

	  Public Property ItemTemplate() As DataTemplate
		  Get
			  Return CType(GetValue(ItemTemplateProperty), DataTemplate)
		  End Get
		  Set(ByVal value As DataTemplate)
			  SetValue(ItemTemplateProperty, value)
		  End Set
	  End Property

	  Public Shared ReadOnly ItemWidthProperty As DependencyProperty = WrapPanel.ItemWidthProperty.AddOwner(GetType(PlainView))

	  Public Property ItemWidth() As Double
		  Get
			  Return CDbl(GetValue(ItemWidthProperty))
		  End Get
		  Set(ByVal value As Double)
			  SetValue(ItemWidthProperty, value)
		  End Set
	  End Property


	  Public Shared ReadOnly ItemHeightProperty As DependencyProperty = WrapPanel.ItemHeightProperty.AddOwner(GetType(PlainView))

	  Public Property ItemHeight() As Double
		  Get
			  Return CDbl(GetValue(ItemHeightProperty))
		  End Get
		  Set(ByVal value As Double)
			  SetValue(ItemHeightProperty, value)
		  End Set
	  End Property


	  Protected Overrides ReadOnly Property DefaultStyleKey() As Object
		  Get
			Return New ComponentResourceKey(Me.GetType(), "myPlainViewDSK")
		  End Get
	  End Property

	End Class
'</SnippetPlainView> 
End Namespace
