Namespace SDKSample
	Partial Public Class DPCustom
		Private myShirt As Shirt
		Private Sub OnInit(ByVal sender As Object, ByVal e As EventArgs)
			myShirt = New Shirt()
			PopulateListbox(ShirtChoice, System.Enum.GetValues(GetType(ShirtTypes)))
			PopulateListbox(ShirtColorChoice, System.Enum.GetValues(GetType(ShirtColors)))
			PopulateListbox(ButtonChoice, System.Enum.GetValues(GetType(ButtonColors)))
			AddHandler myShirt.ButtonColorChanged, AddressOf UIButtonColorChanged
		End Sub
		Private Sub PopulateListbox(ByVal fe As FrameworkElement, ByVal values As Array)
			Dim lb As ListBox = TryCast(fe, ListBox)
			For j As Integer = 1 To values.Length - 1
				Dim lbi As New ListBoxItem()
				lbi.Content = CType(values.GetValue(j), [Enum])
				lb.Items.Add(lbi)
			Next j
		End Sub
		Private Sub ChooseShirt(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Dim lbi As ListBoxItem = (TryCast((TryCast(e.Source, ListBox)).SelectedItem, ListBoxItem))
			myShirt.ShirtType = CType(lbi.Content, ShirtTypes)
		End Sub
		Private Sub ChooseShirtColor(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Dim lbi As ListBoxItem = (TryCast((TryCast(e.Source, ListBox)).SelectedItem, ListBoxItem))
			myShirt.ShirtColor = CType(lbi.Content, ShirtColors)
		End Sub
		Private Sub ChooseButtonColor(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Dim lbi As ListBoxItem = (TryCast((TryCast(e.Source, ListBox)).SelectedItem, ListBoxItem))
			myShirt.ButtonColor = CType(lbi.Content, ButtonColors)
		End Sub
		Private Sub UIButtonColorChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim s As Shirt = CType(e.Source, Shirt)
			Dim b As ButtonColors = s.ButtonColor
			If b = ButtonColors.None Then
				ButtonChoice.Visibility = Visibility.Hidden
				ButtonChoiceLabel.Visibility = Visibility.Hidden
			Else
				ButtonChoice.Visibility = Visibility.Visible
				ButtonChoiceLabel.Visibility = Visibility.Visible
			End If
		End Sub
	End Class
	Public Enum ShirtTypes
		None
		Tee
		Bowling
		Dress
		Rugby
	End Enum
	Public Enum ShirtColors
		None
		White
		Red
		Green
		Yellow
	End Enum
	Public Enum ButtonColors
		None
		Black
		White
		Brown
		Gray
	End Enum

	Public Class Shirt
		Inherits Canvas
		Public Shared ReadOnly ShirtColorProperty As DependencyProperty = DependencyProperty.Register("ShirtColor", GetType(ShirtColors), GetType(Shirt), New FrameworkPropertyMetadata(ShirtColors.None))
		Public Property ShirtColor() As ShirtColors
			Get
				Return CType(GetValue(ShirtColorProperty), ShirtColors)
			End Get
			Set(ByVal value As ShirtColors)
				SetValue(ShirtColorProperty, value)
			End Set
		End Property
		Public Shared ReadOnly ShirtTypeProperty As DependencyProperty = DependencyProperty.Register("ShirtType", GetType(ShirtTypes), GetType(Shirt), New FrameworkPropertyMetadata(ShirtTypes.None, New PropertyChangedCallback(AddressOf OnShirtTypeChangedCallback)), New ValidateValueCallback(AddressOf ShirtValidateCallback))
		Public Property ShirtType() As ShirtTypes
			Get
                Return CType(GetValue(ShirtTypeProperty), ShirtTypes)
			End Get
			Set(ByVal value As ShirtTypes)
				SetValue(ShirtTypeProperty,value)
			End Set
		End Property
'<SnippetValidateValueCallback>
		Private Shared Function ShirtValidateCallback(ByVal value As Object) As Boolean
			Dim sh As ShirtTypes = CType(value, ShirtTypes)
			Return (sh=ShirtTypes.None OrElse sh = ShirtTypes.Bowling OrElse sh = ShirtTypes.Dress OrElse sh = ShirtTypes.Rugby OrElse sh = ShirtTypes.Tee)

		End Function
'</SnippetValidateValueCallback>
		Private Shared Sub OnShirtTypeChangedCallback(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			d.CoerceValue(ButtonColorProperty)
		End Sub
'<SnippetPropertyChangedCallbackPlusDPDef>
		Public Shared ReadOnly ButtonColorProperty As DependencyProperty = DependencyProperty.Register("ButtonColor", GetType(ButtonColors), GetType(Shirt), New FrameworkPropertyMetadata(ButtonColors.Black, New PropertyChangedCallback(AddressOf OnButtonColorChangedCallback), New CoerceValueCallback(AddressOf CoerceButtonColor)))
		Public Property ButtonColor() As ButtonColors
			Get
				Return CType(GetValue(ButtonColorProperty), ButtonColors)
			End Get
			Set(ByVal value As ButtonColors)
				SetValue(ButtonColorProperty, value)
			End Set
		End Property
		Private Shared Sub OnButtonColorChangedCallback(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim newargs As New RoutedEventArgs(ButtonColorChangedEvent)
			TryCast(d, FrameworkElement).RaiseEvent(newargs)
		End Sub
'</SnippetPropertyChangedCallbackPlusDPDef>
'<SnippetCoerceValueCallback>
		Private Shared Function CoerceButtonColor(ByVal d As DependencyObject, ByVal value As Object) As Object
			Dim newShirtType As ShirtTypes = (TryCast(d, Shirt)).ShirtType
			If newShirtType = ShirtTypes.Dress OrElse newShirtType = ShirtTypes.Bowling Then
				Return ButtonColors.Black
			End If
			Return ButtonColors.None
		End Function
'</SnippetCoerceValueCallback>
'<SnippetEventManagerClass>
		Public Shared ReadOnly ButtonColorChangedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("ButtonColorChanged",RoutingStrategy.Bubble,GetType(DependencyPropertyChangedEventHandler),GetType(Shirt))

		Public Custom Event ButtonColorChanged As RoutedEventHandler
			AddHandler(ByVal value As RoutedEventHandler)
				MyBase.AddHandler(ButtonColorChangedEvent,value)
			End AddHandler
			RemoveHandler(ByVal value As RoutedEventHandler)
				MyBase.RemoveHandler(ButtonColorChangedEvent, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As Object, ByVal e As RoutedEventArgs)
			End RaiseEvent
		End Event
'</SnippetEventManagerClass>
	End Class


End Namespace