'<SnippetControlLogic>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports System.Windows.Media

'<SnippetClassAttributes>
<TemplatePart(Name:="UpButtonElement", Type:=GetType(RepeatButton))> _
<TemplatePart(Name:="DownButtonElement", Type:=GetType(RepeatButton))> _
<TemplateVisualState(Name:="Positive", GroupName:="ValueStates")> _
<TemplateVisualState(Name:="Negative", GroupName:="ValueStates")> _
<TemplateVisualState(Name:="Focused", GroupName:="FocusedStates")> _
<TemplateVisualState(Name:="Unfocused", GroupName:="FocusedStates")> _
Public Class NumericUpDown
    Inherits Control

    '</SnippetClassAttributes>
    Public Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(NumericUpDown), New FrameworkPropertyMetadata(GetType(NumericUpDown)))
        Me.IsTabStop = True
    End Sub

    Public Shared ReadOnly ValueProperty As DependencyProperty =
        DependencyProperty.Register("Value", GetType(Integer), GetType(NumericUpDown),
                          New PropertyMetadata(New PropertyChangedCallback(AddressOf ValueChangedCallback)))

    Public Property Value() As Integer

        Get
            Return CInt(GetValue(ValueProperty))
        End Get

        Set(ByVal value As Integer)

            SetValue(ValueProperty, value)
        End Set
    End Property

    '<SnippetEntireValueChangedCallback>
    '<SnippetValueChangedCallback>
    Private Shared Sub ValueChangedCallback(ByVal obj As DependencyObject,
                                            ByVal args As DependencyPropertyChangedEventArgs)

        Dim ctl As NumericUpDown = DirectCast(obj, NumericUpDown)
        Dim newValue As Integer = CInt(args.NewValue)

        '</SnippetValueChangedCallback>
        ' Call UpdateStates because the Value might have caused the
        ' control to change ValueStates.
        ctl.UpdateStates(True)

        ' Call OnValueChanged to raise the ValueChanged event.
        '<SnippetValueChangedCallbackEnd>
        ctl.OnValueChanged(New ValueChangedEventArgs(NumericUpDown.ValueChangedEvent, newValue))
    End Sub
    '</SnippetValueChangedCallbackEnd>
    '</SnippetEntireValueChangedCallback>

    Public Shared ReadOnly ValueChangedEvent As RoutedEvent =
        EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Direct,
                                         GetType(ValueChangedEventHandler), GetType(NumericUpDown))

    Public Custom Event ValueChanged As ValueChangedEventHandler

        AddHandler(ByVal value As ValueChangedEventHandler)
            Me.AddHandler(ValueChangedEvent, value)
        End AddHandler

        RemoveHandler(ByVal value As ValueChangedEventHandler)
            Me.RemoveHandler(ValueChangedEvent, value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.RaiseEvent(e)
        End RaiseEvent

    End Event


    Protected Overridable Sub OnValueChanged(ByVal e As ValueChangedEventArgs)
        ' Raise the ValueChanged event so applications can be alerted
        ' when Value changes.
        MyBase.RaiseEvent(e)
    End Sub


#Region "NUDCode"
    '<SnippetUpdateStates>
    Private Sub UpdateStates(ByVal useTransitions As Boolean)

        '<SnippetValueStateChange>
        If Value >= 0 Then
            VisualStateManager.GoToState(Me, "Positive", useTransitions)
        Else
            VisualStateManager.GoToState(Me, "Negative", useTransitions)
        End If
        '</SnippetValueStateChange>

        If IsFocused Then
            VisualStateManager.GoToState(Me, "Focused", useTransitions)
        Else
            VisualStateManager.GoToState(Me, "Unfocused", useTransitions)

        End If
    End Sub
    '</SnippetUpdateStates>

    '<SnippetApplyTemplate>
    Public Overloads Overrides Sub OnApplyTemplate()

        UpButtonElement = TryCast(GetTemplateChild("UpButton"), RepeatButton)
        DownButtonElement = TryCast(GetTemplateChild("DownButton"), RepeatButton)

        UpdateStates(False)
    End Sub
    '</SnippetApplyTemplate>

    Private m_downButtonElement As RepeatButton

    Private Property DownButtonElement() As RepeatButton
        Get
            Return m_downButtonElement
        End Get

        Set(ByVal value As RepeatButton)

            If m_downButtonElement IsNot Nothing Then
                RemoveHandler m_downButtonElement.Click, AddressOf downButtonElement_Click
            End If
            m_downButtonElement = value

            If m_downButtonElement IsNot Nothing Then
                AddHandler m_downButtonElement.Click, AddressOf downButtonElement_Click
            End If
        End Set
    End Property

    Private Sub downButtonElement_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Value -= 1
    End Sub

    '<SnippetUpButtonProperty>
    Private m_upButtonElement As RepeatButton

    Private Property UpButtonElement() As RepeatButton
        Get
            Return m_upButtonElement
        End Get

        Set(ByVal value As RepeatButton)
            If m_upButtonElement IsNot Nothing Then
                RemoveHandler m_upButtonElement.Click, AddressOf upButtonElement_Click
            End If
            m_upButtonElement = value

            If m_upButtonElement IsNot Nothing Then
                AddHandler m_upButtonElement.Click, AddressOf upButtonElement_Click
            End If
        End Set
    End Property
    '</SnippetUpButtonProperty>

    Private Sub upButtonElement_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Value += 1
    End Sub

    '<SnippetControlFocus>
    Protected Overloads Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonDown(e)
        Focus()
    End Sub
    '</SnippetControlFocus>

    '<SnippetFocusProperty>

    '<SnippetOnGotFocus>
    Protected Overloads Overrides Sub OnGotFocus(ByVal e As RoutedEventArgs)
        MyBase.OnGotFocus(e)
        UpdateStates(True)
    End Sub
    '</SnippetOnGotFocus>

    Protected Overloads Overrides Sub OnLostFocus(ByVal e As RoutedEventArgs)
        MyBase.OnLostFocus(e)
        UpdateStates(True)
    End Sub
    '</SnippetFocusProperty>
#End Region
End Class


Public Delegate Sub ValueChangedEventHandler(ByVal sender As Object,
                                             ByVal e As ValueChangedEventArgs)

Public Class ValueChangedEventArgs
    Inherits RoutedEventArgs
    Private _value As Integer

    Public Sub New(ByVal id As RoutedEvent,
                   ByVal num As Integer)

        _value = num
        RoutedEvent = id
    End Sub

    Public ReadOnly Property Value() As Integer
        Get
            Return _value
        End Get
    End Property
End Class
'</SnippetControlLogic>


Namespace ControlContract
    '<SnippetControlContract>
    <TemplatePart(Name:="UpButtonElement", Type:=GetType(RepeatButton))> _
    <TemplatePart(Name:="DownButtonElement", Type:=GetType(RepeatButton))> _
    <TemplateVisualState(Name:="Positive", GroupName:="ValueStates")> _
    <TemplateVisualState(Name:="Negative", GroupName:="ValueStates")> _
    <TemplateVisualState(Name:="Focused", GroupName:="FocusedStates")> _
    <TemplateVisualState(Name:="Unfocused", GroupName:="FocusedStates")> _
    Public Class NumericUpDown
        Inherits Control
        Public Shared ReadOnly BackgroundProperty As DependencyProperty
        Public Shared ReadOnly BorderBrushProperty As DependencyProperty
        Public Shared ReadOnly BorderThicknessProperty As DependencyProperty
        Public Shared ReadOnly FontFamilyProperty As DependencyProperty
        Public Shared ReadOnly FontSizeProperty As DependencyProperty
        Public Shared ReadOnly FontStretchProperty As DependencyProperty
        Public Shared ReadOnly FontStyleProperty As DependencyProperty
        Public Shared ReadOnly FontWeightProperty As DependencyProperty
        Public Shared ReadOnly ForegroundProperty As DependencyProperty
        Public Shared ReadOnly HorizontalContentAlignmentProperty As DependencyProperty
        Public Shared ReadOnly PaddingProperty As DependencyProperty
        Public Shared ReadOnly TextAlignmentProperty As DependencyProperty
        Public Shared ReadOnly TextDecorationsProperty As DependencyProperty
        Public Shared ReadOnly TextWrappingProperty As DependencyProperty
        Public Shared ReadOnly VerticalContentAlignmentProperty As DependencyProperty


        Private _Background As Brush
        Public Property Background() As Brush
            Get
                Return _Background
            End Get
            Set(ByVal value As Brush)
                _Background = value
            End Set
        End Property

        Private _BorderBrush As Brush
        Public Property BorderBrush() As Brush
            Get
                Return _BorderBrush
            End Get
            Set(ByVal value As Brush)
                _BorderBrush = value
            End Set
        End Property

        Private _BorderThickness As Thickness
        Public Property BorderThickness() As Thickness
            Get
                Return _BorderThickness
            End Get
            Set(ByVal value As Thickness)
                _BorderThickness = value
            End Set
        End Property

        Private _FontFamily As FontFamily
        Public Property FontFamily() As FontFamily
            Get
                Return _FontFamily
            End Get
            Set(ByVal value As FontFamily)
                _FontFamily = value
            End Set
        End Property

        Private _FontSize As Double
        Public Property FontSize() As Double
            Get
                Return _FontSize
            End Get
            Set(ByVal value As Double)
                _FontSize = value
            End Set
        End Property

        Private _FontStretch As FontStretch
        Public Property FontStretch() As FontStretch
            Get
                Return _FontStretch
            End Get
            Set(ByVal value As FontStretch)
                _FontStretch = value
            End Set
        End Property

        Private _FontStyle As FontStyle
        Public Property FontStyle() As FontStyle
            Get
                Return _FontStyle
            End Get
            Set(ByVal value As FontStyle)
                _FontStyle = value
            End Set
        End Property

        Private _FontWeight As FontWeight
        Public Property FontWeight() As FontWeight
            Get
                Return _FontWeight
            End Get
            Set(ByVal value As FontWeight)
                _FontWeight = value
            End Set
        End Property

        Private _Foreground As Brush
        Public Property Foreground() As Brush
            Get
                Return _Foreground
            End Get
            Set(ByVal value As Brush)
                _Foreground = value
            End Set
        End Property

        Private _HorizontalContentAlignment As HorizontalAlignment
        Public Property HorizontalContentAlignment() As HorizontalAlignment
            Get
                Return _HorizontalContentAlignment
            End Get
            Set(ByVal value As HorizontalAlignment)
                _HorizontalContentAlignment = value
            End Set
        End Property

        Private _Padding As Thickness
        Public Property Padding() As Thickness
            Get
                Return _Padding
            End Get
            Set(ByVal value As Thickness)
                _Padding = value
            End Set
        End Property

        Private _TextAlignment As TextAlignment
        Public Property TextAlignment() As TextAlignment
            Get
                Return _TextAlignment
            End Get
            Set(ByVal value As TextAlignment)
                _TextAlignment = value
            End Set
        End Property

        Private _TextDecorations As TextDecorationCollection
        Public Property TextDecorations() As TextDecorationCollection
            Get
                Return _TextDecorations
            End Get
            Set(ByVal value As TextDecorationCollection)
                _TextDecorations = value
            End Set
        End Property

        Private _TextWrapping As TextWrapping
        Public Property TextWrapping() As TextWrapping
            Get
                Return _TextWrapping
            End Get
            Set(ByVal value As TextWrapping)
                _TextWrapping = value
            End Set
        End Property

        Private _VerticalContentAlignment As VerticalAlignment
        Public Property VerticalContentAlignment() As VerticalAlignment
            Get
                Return _VerticalContentAlignment
            End Get
            Set(ByVal value As VerticalAlignment)
                _VerticalContentAlignment = value
            End Set
        End Property
    End Class
    '</SnippetControlContract>
End Namespace