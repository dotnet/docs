Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace MyCustomControl
	Partial Public Class NumericUpDown
		Inherits Control
		''' <summary>
		''' Initializes a new instance of the NumericUpDownControl.
		''' </summary>
		Public Sub New()
			InitializeCommands()
		End Sub

		'<SnippetStaticConstructor>
		Shared Sub New()
			DefaultStyleKeyProperty.OverrideMetadata(GetType(NumericUpDown), New FrameworkPropertyMetadata(GetType(NumericUpDown)))
		End Sub
		'</SnippetStaticConstructor>

		''' <summary>
		''' Gets or sets the value assigned to the control.
		''' </summary>
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
'<SnippetDependencyPropertyChangedEventArgs>
		Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(Decimal), GetType(NumericUpDown), New FrameworkPropertyMetadata(MinValue, New PropertyChangedCallback(AddressOf OnValueChanged), New CoerceValueCallback(AddressOf CoerceValue)))

		Private Shared Overloads Function CoerceValue(ByVal element As DependencyObject, ByVal value As Object) As Object
			Dim newValue As Decimal = CDec(value)

			newValue = Math.Max(MinValue, Math.Min(MaxValue, newValue))

			Return newValue
		End Function

		Private Shared Sub OnValueChanged(ByVal obj As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
			Dim control As NumericUpDown = CType(obj, NumericUpDown)

			Dim e As New RoutedPropertyChangedEventArgs(Of Decimal)(CDec(args.OldValue), CDec(args.NewValue), ValueChangedEvent)
			control.OnValueChanged(e)
		End Sub
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
		''' <summary>
		''' Raises the ValueChanged event.
		''' </summary>
		''' <param name="args">Arguments associated with the ValueChanged event.</param>
		Protected Overridable Sub OnValueChanged(ByVal args As RoutedPropertyChangedEventArgs(Of Decimal))
			MyBase.RaiseEvent(args)
		End Sub
'</SnippetDependencyPropertyChangedEventArgs>

		#Region "Commands"
'<SnippetCommands>

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
			_increaseCommand = New RoutedCommand("IncreaseCommand", GetType(NumericUpDown))
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
			Value += 1
		End Sub
		Protected Overridable Sub OnDecrease()
			Value -= 1
		End Sub

		Private Shared _increaseCommand As RoutedCommand
		Private Shared _decreaseCommand As RoutedCommand
'</SnippetCommands>

		#End Region

		Private Const MinValue As Decimal = 0, MaxValue As Decimal = 100
	End Class
End Namespace