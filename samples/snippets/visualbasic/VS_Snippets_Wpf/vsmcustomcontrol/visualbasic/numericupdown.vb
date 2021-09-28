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

    Public Sub New(ByVal id As RoutedEvent,
                   ByVal num As Integer)

        Value = num
        RoutedEvent = id
    End Sub

    Public ReadOnly Property Value() As Integer
End Class
'</SnippetControlLogic>


Namespace ControlContract
    '<SnippetControlContract>
    <TemplatePart(Name:="UpButtonElement", Type:=GetType(RepeatButton))>
    <TemplatePart(Name:="DownButtonElement", Type:=GetType(RepeatButton))>
    <TemplateVisualState(Name:="Positive", GroupName:="ValueStates")>
    <TemplateVisualState(Name:="Negative", GroupName:="ValueStates")>
    <TemplateVisualState(Name:="Focused", GroupName:="FocusedStates")>
    <TemplateVisualState(Name:="Unfocused", GroupName:="FocusedStates")>
    Public Class NumericUpDown
        Inherits Control
        Public Shared ReadOnly TextAlignmentProperty As DependencyProperty
        Public Shared ReadOnly TextDecorationsProperty As DependencyProperty
        Public Shared ReadOnly TextWrappingProperty As DependencyProperty

        Public Property TextAlignment() As TextAlignment

        Public Property TextDecorations() As TextDecorationCollection

        Public Property TextWrapping() As TextWrapping
    End Class
    '</SnippetControlContract>
End Namespace
