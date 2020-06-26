Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Automation.Peers
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Globalization
Imports System.Diagnostics

Namespace CustomControlLibrary
	Public Partial Class NumericUpDown
		Inherits Control

		Public Sub New()
			MyBase.New()
			updateValueString()
		End Sub

		#Region "Properties"
		#Region "Value"
		Public Property Value() As Decimal
			Get
				Return CDec(GetValue(ValueProperty))
			End Get
			Set(ByVal value As Decimal)
				SetValue(ValueProperty, value)
			End Set
		End Property

		''' <summary>
		''' Identifies the Value dependency property.
		''' </summary>
		Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(Decimal), GetType(NumericUpDown), New FrameworkPropertyMetadata(DefaultValue, New PropertyChangedCallback(AddressOf OnValueChanged), New CoerceValueCallback(AddressOf CoerceValue)))

		Private Shared Sub OnValueChanged(ByVal obj As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
			Dim nudCtrl As NumericUpDown = CType(obj, NumericUpDown)

			Dim oldValue As Decimal = CDec(args.OldValue)
			Dim newValue As Decimal = CDec(args.NewValue)

'			#Region "Fire Automation events"
			'<SnippetRaiseEventFromControl>
			If AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged) Then
				Dim peer As NumericUpDownAutomationPeer = TryCast(UIElementAutomationPeer.FromElement(nudCtrl), NumericUpDownAutomationPeer)

				If peer IsNot Nothing Then
					peer.RaisePropertyChangedEvent(RangeValuePatternIdentifiers.ValueProperty, CDbl(oldValue), CDbl(newValue))
				End If
			End If
			'</SnippetRaiseEventFromControl>
'			#End Region

			Dim e As New RoutedPropertyChangedEventArgs(Of Decimal)(oldValue, newValue, ValueChangedEvent)

			nudCtrl.OnValueChanged(e)

			nudCtrl.updateValueString()
		End Sub

		''' <summary>
		''' Raises the ValueChanged event.
		''' </summary>
		''' <param name="args">Arguments associated with the ValueChanged event.</param>
		Protected Overridable Sub OnValueChanged(ByVal args As RoutedPropertyChangedEventArgs(Of Decimal))
			MyBase.RaiseEvent(args)
		End Sub

		Private Shared Overloads Function CoerceValue(ByVal element As DependencyObject, ByVal value As Object) As Object
			Dim newValue As Decimal = CDec(value)
			Dim control As NumericUpDown = CType(element, NumericUpDown)

			newValue = Math.Max(control.Minimum, Math.Min(control.Maximum, newValue))
			newValue = Decimal.Round(newValue, control.DecimalPlaces)

			Return newValue
		End Function
		#End Region
		#Region "Minimum"
		Public Property Minimum() As Decimal
			Get
				Return CDec(GetValue(MinimumProperty))
			End Get
			Set(ByVal value As Decimal)
				SetValue(MinimumProperty, value)
			End Set
		End Property

		Public Shared ReadOnly MinimumProperty As DependencyProperty = DependencyProperty.Register("Minimum", GetType(Decimal), GetType(NumericUpDown), New FrameworkPropertyMetadata(DefaultMinValue, New PropertyChangedCallback(AddressOf OnMinimumChanged),New CoerceValueCallback(AddressOf CoerceMinimum)))

		Private Shared Sub OnMinimumChanged(ByVal element As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
			element.CoerceValue(MaximumProperty)
			element.CoerceValue(ValueProperty)
		End Sub
		Private Shared Function CoerceMinimum(ByVal element As DependencyObject, ByVal value As Object) As Object
			Dim minimum As Decimal = CDec(value)
			Dim control As NumericUpDown = CType(element, NumericUpDown)
			Return Decimal.Round(minimum, control.DecimalPlaces)
		End Function
		#End Region
		#Region "Maximum"
		Public Property Maximum() As Decimal
			Get
				Return CDec(GetValue(MaximumProperty))
			End Get
			Set(ByVal value As Decimal)
				SetValue(MaximumProperty, value)
			End Set
		End Property

		Public Shared ReadOnly MaximumProperty As DependencyProperty = DependencyProperty.Register("Maximum", GetType(Decimal), GetType(NumericUpDown), New FrameworkPropertyMetadata(DefaultMaxValue, New PropertyChangedCallback(AddressOf OnMaximumChanged), New CoerceValueCallback(AddressOf CoerceMaximum)))

		Private Shared Sub OnMaximumChanged(ByVal element As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
			element.CoerceValue(ValueProperty)
		End Sub

		Private Shared Function CoerceMaximum(ByVal element As DependencyObject, ByVal value As Object) As Object
			Dim control As NumericUpDown = CType(element, NumericUpDown)
			Dim newMaximum As Decimal = CDec(value)
			Return Decimal.Round(Math.Max(newMaximum, control.Minimum),control.DecimalPlaces)
		End Function
		#End Region
		#Region "Change"
		Public Property Change() As Decimal
			Get
				Return CDec(GetValue(ChangeProperty))
			End Get
			Set(ByVal value As Decimal)
				SetValue(ChangeProperty, value)
			End Set
		End Property

		Public Shared ReadOnly ChangeProperty As DependencyProperty = DependencyProperty.Register("Change", GetType(Decimal), GetType(NumericUpDown), New FrameworkPropertyMetadata(DefaultChange, New PropertyChangedCallback(AddressOf OnChangeChanged),New CoerceValueCallback(AddressOf CoerceChange)), New ValidateValueCallback(AddressOf ValidateChange))

		Private Shared Function ValidateChange(ByVal value As Object) As Boolean
			Dim change As Decimal = CDec(value)
			Return change > 0
		End Function

		Private Shared Sub OnChangeChanged(ByVal element As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)

		End Sub

		Private Shared Function CoerceChange(ByVal element As DependencyObject, ByVal value As Object) As Object
			Dim newChange As Decimal = CDec(value)
			Dim control As NumericUpDown = CType(element, NumericUpDown)

			Dim coercedNewChange As Decimal = Decimal.Round(newChange, control.DecimalPlaces)

			'If Change is .1 and DecimalPlaces is changed from 1 to 0, we want Change to go to 1, not 0.
			'Put another way, Change should always be rounded to DecimalPlaces, but never smaller than the 
			'previous Change
			If coercedNewChange < newChange Then
				coercedNewChange = smallestForDecimalPlaces(control.DecimalPlaces)
			End If

			Return coercedNewChange
		End Function

		Private Shared Function smallestForDecimalPlaces(ByVal decimalPlaces As Integer) As Decimal
			If decimalPlaces < 0 Then
				Throw New ArgumentException("decimalPlaces")
			End If

			Dim d As Decimal = 1

			For i As Integer = 0 To decimalPlaces - 1
				d /= 10
			Next i

			Return d
		End Function

		#End Region
		#Region "DecimalPlaces"
		Public Property DecimalPlaces() As Integer
			Get
				Return CInt(Fix(GetValue(DecimalPlacesProperty)))
			End Get
			Set(ByVal value As Integer)
				SetValue(DecimalPlacesProperty, value)
			End Set
		End Property

		Public Shared ReadOnly DecimalPlacesProperty As DependencyProperty = DependencyProperty.Register("DecimalPlaces", GetType(Integer), GetType(NumericUpDown), New FrameworkPropertyMetadata(DefaultDecimalPlaces, New PropertyChangedCallback(AddressOf OnDecimalPlacesChanged)), New ValidateValueCallback(AddressOf ValidateDecimalPlaces))

		Private Shared Sub OnDecimalPlacesChanged(ByVal element As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
			Dim control As NumericUpDown = CType(element, NumericUpDown)
			control.CoerceValue(ChangeProperty)
			control.CoerceValue(MinimumProperty)
			control.CoerceValue(MaximumProperty)
			control.CoerceValue(ValueProperty)
			control.updateValueString()
		End Sub

		Private Shared Function ValidateDecimalPlaces(ByVal value As Object) As Boolean
			Dim decimalPlaces As Integer = CInt(Fix(value))
			Return decimalPlaces >= 0
		End Function

		#End Region

		#Region "ValueString"
		Public ReadOnly Property ValueString() As String
			Get
				Return CStr(GetValue(ValueStringProperty))
			End Get
		End Property

		Private Shared ReadOnly ValueStringPropertyKey As DependencyPropertyKey = DependencyProperty.RegisterAttachedReadOnly("ValueString", GetType(String), GetType(NumericUpDown), New PropertyMetadata())

		Public Shared ReadOnly ValueStringProperty As DependencyProperty = ValueStringPropertyKey.DependencyProperty

		Private Sub updateValueString()
			_numberFormatInfo.NumberDecimalDigits = Me.DecimalPlaces
			Dim newValueString As String = Me.Value.ToString("f",_numberFormatInfo)
			Me.SetValue(ValueStringPropertyKey, newValueString)
		End Sub
		Private _numberFormatInfo As New NumberFormatInfo()
		#End Region

		#End Region

		#Region "Events"
		''' <summary>
		''' Identifies the ValueChanged routed event.
		''' </summary>
		Public Shared ReadOnly ValueChangedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, GetType(RoutedPropertyChangedEventHandler(Of Decimal)), GetType(NumericUpDown))

		''' <summary>
		''' Occurs when the Value property changes.
		''' </summary>
		Public Custom Event ValueChanged As RoutedPropertyChangedEventHandler(Of Decimal)
			AddHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Decimal))
				MyBase.AddHandler(ValueChangedEvent, value)
			End AddHandler
			RemoveHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Decimal))
				MyBase.RemoveHandler(ValueChangedEvent, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As RoutedPropertyChangedEventArgs(Of Decimal))
			End RaiseEvent
		End Event
		#End Region

		#Region "Commands"

		Public Shared ReadOnly Property IncreaseCommand() As RoutedCommand
			Get
				Return _increaseCommand
			End Get
		End Property
		Public Shared ReadOnly Property DecreaseCommand() As RoutedCommand
			Get
				Return _decreaseCommand
			End Get
		End Property

		Private Shared Sub InitializeCommands()
			_increaseCommand = New RoutedCommand("IncreaseCommand",GetType(NumericUpDown))
			CommandManager.RegisterClassCommandBinding(GetType(NumericUpDown), New CommandBinding(_increaseCommand, AddressOf OnIncreaseCommand))
			CommandManager.RegisterClassInputBinding(GetType(NumericUpDown), New InputBinding(_increaseCommand, New KeyGesture(Key.Up)))

			_decreaseCommand = New RoutedCommand("DecreaseCommand", GetType(NumericUpDown))
			CommandManager.RegisterClassCommandBinding(GetType(NumericUpDown), New CommandBinding(_decreaseCommand, AddressOf OnDecreaseCommand))
			CommandManager.RegisterClassInputBinding(GetType(NumericUpDown), New InputBinding(_decreaseCommand, New KeyGesture(Key.Down)))
		End Sub

		Private Shared Sub OnIncreaseCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Dim control As NumericUpDown = TryCast(sender, NumericUpDown)
			If control IsNot Nothing Then
				control.OnIncrease()
			End If
		End Sub
		Private Shared Sub OnDecreaseCommand(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
			Dim control As NumericUpDown = TryCast(sender, NumericUpDown)
			If control IsNot Nothing Then
				control.OnDecrease()
			End If
		End Sub

		Protected Overridable Sub OnIncrease()
			Me.Value+=Change
		End Sub
		Protected Overridable Sub OnDecrease()
			Me.Value-=Change
		End Sub

		Private Shared _increaseCommand As RoutedCommand
		Private Shared _decreaseCommand As RoutedCommand
		#End Region

		#Region "Automation"
		'<SnippetOnCreateAutomationPeer>
		Protected Overrides Function OnCreateAutomationPeer() As AutomationPeer
			Return New NumericUpDownAutomationPeer(Me)
		End Function
		'</SnippetOnCreateAutomationPeer>
		#End Region

		''' <summary>
		''' This is a class handler for MouseLeftButtonDown event.
		''' The purpose of this handle is to move input focus to NumericUpDown when user pressed
		''' mouse left button on any part of slider that is not focusable.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Shared Overloads Sub OnMouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim control As NumericUpDown = CType(sender, NumericUpDown)

			' When someone click on a part in the NumericUpDown and it's not focusable
			' NumericUpDown needs to take the focus in order to process keyboard correctly
			If Not control.IsKeyboardFocusWithin Then
				e.Handled = control.Focus() OrElse e.Handled
			End If
		End Sub

		Private Const DefaultMinValue As Decimal = 0, DefaultValue As Decimal = DefaultMinValue, DefaultMaxValue As Decimal = 100, DefaultChange As Decimal = 1
		Private Const DefaultDecimalPlaces As Integer = 0
	End Class

	Public Class NumericUpDownAutomationPeer
		Inherits FrameworkElementAutomationPeer
		Implements IRangeValueProvider
		Public Sub New(ByVal control As NumericUpDown)
			MyBase.New(control)
		End Sub

		'<SnippetCoreOverrides>
		Protected Overrides Function GetClassNameCore() As String
			Return "NumericUpDown"
		End Function

		Protected Overrides Function GetAutomationControlTypeCore() As AutomationControlType
			Return AutomationControlType.Spinner
		End Function
		'</SnippetCoreOverrides>

		'<SnippetGetPattern>
		Public Overrides Function GetPattern(ByVal patternInterface As PatternInterface) As Object
			If patternInterface = PatternInterface.RangeValue Then
				Return Me
			End If
			Return MyBase.GetPattern(patternInterface)
		End Function
		'</SnippetGetPattern>


		#Region "IRangeValueProvider Members"

		Private ReadOnly Property IsReadOnly() As Boolean Implements IRangeValueProvider.IsReadOnly
			Get
				Return Not IsEnabled()
			End Get
		End Property

		Private ReadOnly Property LargeChange() As Double Implements IRangeValueProvider.LargeChange
			Get
				Return CDbl(MyOwner.Change)
			End Get
		End Property

		Private ReadOnly Property Maximum() As Double Implements IRangeValueProvider.Maximum
			Get
				Return CDbl(MyOwner.Maximum)
			End Get
		End Property

		Private ReadOnly Property Minimum() As Double Implements IRangeValueProvider.Minimum
			Get
				Return CDbl(MyOwner.Minimum)
			End Get
		End Property

		Private Sub SetValue(ByVal value As Double) Implements IRangeValueProvider.SetValue
			If Not IsEnabled() Then
				Throw New ElementNotEnabledException()
			End If

			Dim val As Decimal = CDec(value)
			If val < MyOwner.Minimum OrElse val > MyOwner.Maximum Then
				Throw New ArgumentOutOfRangeException("value")
			End If

			MyOwner.Value = val
		End Sub

		Private ReadOnly Property SmallChange() As Double Implements IRangeValueProvider.SmallChange
			Get
				Return CDbl(MyOwner.Change)
			End Get
		End Property

		Private ReadOnly Property Value() As Double Implements IRangeValueProvider.Value
			Get
				Return CDbl(MyOwner.Value)
			End Get
		End Property

		#End Region

		Private ReadOnly Property MyOwner() As NumericUpDown
			Get
				Return CType(MyBase.Owner, NumericUpDown)
			End Get
		   End Property
	' <snippetclose>
	End Class
	' </snippetclose>
End Namespace