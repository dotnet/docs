Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives

Namespace SDKSample
'<SnippetMyStateControl>
  Public Class MyStateControl
	  Inherits ButtonBase
	Public Sub New()
		MyBase.New()
	End Sub
	Public Property State() As Boolean
	  Get
		  Return CType(Me.GetValue(StateProperty), Boolean)
	  End Get
	  Set(ByVal value As Boolean)
		  Me.SetValue(StateProperty, value)
	  End Set
	End Property
	Public Shared ReadOnly StateProperty As DependencyProperty = DependencyProperty.Register("State", GetType(Boolean), GetType(MyStateControl),New PropertyMetadata(False))
  End Class
  '</SnippetMyStateControl>

  '<SnippetUnrelatedStateControl>
  Public Class UnrelatedStateControl
	  Inherits Control
	Public Sub New()
	End Sub
	Public Shared ReadOnly StateProperty As DependencyProperty = MyStateControl.StateProperty.AddOwner(GetType(UnrelatedStateControl), New PropertyMetadata(True))
	Public Property State() As Boolean
	  Get
		  Return CType(Me.GetValue(StateProperty), Boolean)
	  End Get
	  Set(ByVal value As Boolean)
		  Me.SetValue(StateProperty, value)
	  End Set
	End Property
  End Class
  '</SnippetUnrelatedStateControl>

  '<SnippetMyAdvancedStateControl>
  Public Class MyAdvancedStateControl
	  Inherits MyStateControl
	Public Sub New()
		MyBase.New()
	End Sub
	Shared Sub New()
	  MyStateControl.StateProperty.OverrideMetadata(GetType(MyAdvancedStateControl), New PropertyMetadata(True))
	End Sub
  End Class
  '</SnippetMyAdvancedStateControl>
	Public Class AreaButton
		Inherits Button
  '<SnippetInvalidateProperty>
		Shared Sub New()
			WidthProperty.OverrideMetadata(GetType(AreaButton), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf InvalidateAreaProperty)))
			HeightProperty.OverrideMetadata(GetType(AreaButton), New FrameworkPropertyMetadata(New PropertyChangedCallback(AddressOf InvalidateAreaProperty)))
		End Sub
		Private Shared Sub InvalidateAreaProperty(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			d.InvalidateProperty(AreaProperty)
		End Sub
   '</SnippetInvalidateProperty>
		Public ReadOnly Property Area() As Double
			Get
				Return CDbl(Me.GetValue(AreaProperty))
			End Get
		End Property
		Private Shared ReadOnly AreaPropertyKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly("Area", GetType(Double), GetType(AreaButton), New PropertyMetadata(0.0,Nothing,New CoerceValueCallback(AddressOf CalculateArea)))
		Private Shared Function CalculateArea(ByVal d As Object, ByVal previousValue As Object) As Object
			Dim fe As FrameworkElement = TryCast(d, FrameworkElement)
			If fe IsNot Nothing Then
				Return(fe.ActualWidth * fe.ActualHeight)
			Else
				Return Nothing
			End If
		End Function

		Public Shared ReadOnly AreaProperty As DependencyProperty = AreaPropertyKey.DependencyProperty
		Protected Overrides Sub OnClick()
			Me.Width += 1
			Me.Height += 1
			MyBase.OnClick()
			Me.Content = GetValue(AreaProperty).ToString()
		End Sub
	End Class
End Namespace
