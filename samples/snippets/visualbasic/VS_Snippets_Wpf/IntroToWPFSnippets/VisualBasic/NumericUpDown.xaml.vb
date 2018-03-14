'<SnippetUserControlCODEBEHIND1>
imports System 'EventArgs
imports System.Windows 'DependencyObject, DependencyPropertyChangedEventArgs, 
                       ' FrameworkPropertyMetadata, PropertyChangedCallback, 
                       ' RoutedPropertyChangedEventArgs
imports System.Windows.Controls 'UserControl

Namespace SDKSample

    ' Interaction logic for NumericUpDown.xaml
    Partial Public Class NumericUpDown
        Inherits System.Windows.Controls.UserControl

        'NumericUpDown user control implementation
        '</SnippetUserControlCODEBEHIND1>
        ''' <summary>
        ''' Initializes a new instance of the NumericUpDownControl.
        ''' </summary>
        Public Sub New()
            Me.InitializeComponent()
            Me.UpdateTextBlock()
        End Sub

        '''<summary>
        ''' Gets or sets the value assigned to the control.
        ''' </summary>
        Public Property Value() As Decimal
            Get
                Return CDec(MyBase.GetValue(NumericUpDown.ValueProperty))
            End Get
            Set(ByVal value As Decimal)
                MyBase.SetValue(NumericUpDown.ValueProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Identifies the Value dependency property.
        ''' </summary>
        Public Shared ReadOnly ValueProperty As DependencyProperty = _
            DependencyProperty.Register("Value", GetType(Decimal), _
            GetType(NumericUpDown), New FrameworkPropertyMetadata(New Decimal(0), _
            New PropertyChangedCallback(AddressOf NumericUpDown.OnValueChanged)))

        Private Shared Sub OnValueChanged(ByVal obj As DependencyObject, _
            ByVal args As DependencyPropertyChangedEventArgs)
            Dim control As NumericUpDown = DirectCast(obj, NumericUpDown)
            control.UpdateTextBlock()
            Dim eventArgs As New RoutedPropertyChangedEventArgs(Of Decimal)( _
                CDec(args.OldValue), CDec(args.NewValue), _
                NumericUpDown.ValueChangedEvent)
            control.OnValueChanged(eventArgs)
        End Sub

        ''' <summary>
        ''' Identifies the ValueChanged routed event.
        ''' </summary>
        Public Shared ReadOnly ValueChangedEvent As RoutedEvent = _
            EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, _
            GetType(RoutedPropertyChangedEventHandler(Of Decimal)), _
            GetType(NumericUpDown))

        ''' <summary>
        ''' Occurs when the Value property changes.
        ''' </summary>
        Public Custom Event ValueChanged As RoutedPropertyChangedEventHandler(Of Decimal)
            AddHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Decimal))
                MyBase.AddHandler(NumericUpDown.ValueChangedEvent, value)
            End AddHandler
            RemoveHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Decimal))
                MyBase.RemoveHandler(NumericUpDown.ValueChangedEvent, value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, _
                ByVal value As RoutedPropertyChangedEventArgs(Of Decimal))
                MyBase.RaiseEvent(value)
            End RaiseEvent
        End Event

        Protected Overridable Sub OnValueChanged( _
            ByVal value As RoutedPropertyChangedEventArgs(Of Decimal))
            MyBase.RaiseEvent(value)
        End Sub


        Private Sub downButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If (Me.Value > New Decimal(0)) Then
                Me.Value = Me.Value - 1
            End If
        End Sub

        Private Sub upButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If (Me.Value < New Decimal(100)) Then
                Me.Value = Me.Value + 1
            End If
        End Sub

        Private Sub UpdateTextBlock()
            Me.valueText.Text = Me.Value.ToString
        End Sub

        Private Shared ReadOnly MaxValue As Decimal = 100
        Private Shared ReadOnly MinValue As Decimal = 0
        '<SnippetUserControlCODEBEHIND2>

    End Class

End Namespace
'</SnippetUserControlCODEBEHIND2>