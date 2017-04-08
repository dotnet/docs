'<SnippetCodeBehind>

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace MyUserControl
	Partial Public Class NumericUpDown
		Inherits System.Windows.Controls.UserControl
		''' <summary>
		''' Initializes a new instance of the NumericUpDownControl.
		''' </summary>
		Public Sub New()
			InitializeComponent()

		End Sub

		'<SnippetDependencyProperty>
		''' <summary>
		''' Identifies the Value dependency property.
		''' </summary>
		Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(Decimal), GetType(NumericUpDown), New FrameworkPropertyMetadata(MinValue, New PropertyChangedCallback(AddressOf OnValueChanged), New CoerceValueCallback(AddressOf CoerceValue)))

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

		Private Shared Overloads Function CoerceValue(ByVal element As DependencyObject, ByVal value As Object) As Object
			Dim newValue As Decimal = CDec(value)
			Dim control As NumericUpDown = CType(element, NumericUpDown)

			newValue = Math.Max(MinValue, Math.Min(MaxValue, newValue))

			Return newValue
		End Function

		Private Shared Sub OnValueChanged(ByVal obj As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
			Dim control As NumericUpDown = CType(obj, NumericUpDown)

			Dim e As New RoutedPropertyChangedEventArgs(Of Decimal)(CDec(args.OldValue), CDec(args.NewValue), ValueChangedEvent)
			control.OnValueChanged(e)
		End Sub
		'</SnippetDependencyProperty>

		'<SnippetRoutedEvent>
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
		'</SnippetRoutedEvent>

		Private Sub upButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Value += 1
		End Sub

		Private Sub downButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Value -= 1
		End Sub

		Private Const MinValue As Decimal = 0, MaxValue As Decimal = 100
	End Class
End Namespace
'</SnippetCodeBehind>