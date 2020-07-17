'<SnippetAllCode>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports System.Windows.Media

Namespace SDKSample
    Public Class MyEditContainer
        Inherits ContentControl
        Public Sub New()
            MyBase.New()
        End Sub
        '<SnippetStaticAndRegisterClassHandler>
        Shared Sub New()
            EventManager.RegisterClassHandler(GetType(MyEditContainer), PreviewMouseRightButtonDownEvent, New RoutedEventHandler(AddressOf LocalOnMouseRightButtonDown))
        End Sub
        Friend Shared Sub LocalOnMouseRightButtonDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MessageBox.Show("this is invoked before the On* class handler on UIElement")
            'e.Handled = True //uncommenting this would cause ONLY the subclass' class handler to respond
        End Sub
        '</SnippetStaticAndRegisterClassHandler>
        Public Shared ReadOnly EditStateChangedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("EditStageChanged", RoutingStrategy.Direct, GetType(RoutedPropertyChangedEventArgs(Of Boolean)), GetType(MyEditContainer))

        ' Provide CLR accessors for the event
        Public Custom Event EditStateChanged As RoutedEventHandler
            AddHandler(ByVal value As RoutedEventHandler)
                MyBase.AddHandler(EditStateChangedEvent, value)
            End AddHandler
            RemoveHandler(ByVal value As RoutedEventHandler)
                MyBase.RemoveHandler(EditStateChangedEvent, value)
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
            End RaiseEvent
        End Event
        Public Property EditState() As Boolean
            Get
                Return CType(GetValue(EditStateProperty), Boolean)
            End Get
            Set(ByVal value As Boolean)
                Me.SetValue(EditStateProperty, value)
            End Set
        End Property
        Public Shared ReadOnly EditStateProperty As DependencyProperty = DependencyProperty.Register("EditState", GetType(Boolean), GetType(MyEditContainer), New PropertyMetadata(False, New PropertyChangedCallback(AddressOf OnEditStateChanged)))
        Private Shared Sub OnEditStateChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            Dim ec As MyEditContainer = CType(d, MyEditContainer)
            If ec IsNot Nothing Then
                Dim newEventArgs As New RoutedPropertyChangedEventArgs(Of Boolean)(CBool(e.OldValue), CBool(e.NewValue))
                newEventArgs.RoutedEvent = EditStateChangedEvent
                ec.RaiseEvent(newEventArgs)
            End If
        End Sub
        '<SnippetOnStarClassHandler>
        Protected Overrides Sub OnPreviewMouseRightButtonDown(ByVal e As System.Windows.Input.MouseButtonEventArgs)
            e.Handled = True 'suppress the click event and other leftmousebuttondown responders
            Dim ec As MyEditContainer = CType(e.Source, MyEditContainer)
            If ec.EditState Then
                ec.EditState = False
            Else
                ec.EditState = True
            End If
            MyBase.OnPreviewMouseRightButtonDown(e)
        End Sub
        '</SnippetOnStarClassHandler>
    End Class
    Public Class AnotherEditContainer
        Inherits ContentControl
        Shared Sub New()
            EventManager.RegisterClassHandler(GetType(AnotherEditContainer), PreviewMouseLeftButtonDownEvent, New RoutedEventHandler(AddressOf MyEditContainer.LocalOnMouseRightButtonDown))
        End Sub
        '<SnippetRoutedEventAddOwner>
        Public Shared ReadOnly EditStateChangedEvent As RoutedEvent = MyEditContainer.EditStateChangedEvent.AddOwner(GetType(AnotherEditContainer))
        '</SnippetRoutedEventAddOwner>
        Public Shared ReadOnly EditStateProperty As DependencyProperty = MyEditContainer.EditStateProperty.AddOwner(GetType(AnotherEditContainer))
        Public Property EditState() As Boolean
            Get
                Return CType(GetValue(EditStateProperty), Boolean)
            End Get
            Set(ByVal value As Boolean)
                Me.SetValue(EditStateProperty, value)
            End Set
        End Property
        Protected Overrides Sub OnPreviewMouseLeftButtonDown(ByVal e As System.Windows.Input.MouseButtonEventArgs)
            e.Handled = True 'suppress the click event and other leftmousebuttondown responders
            Dim ec As AnotherEditContainer = CType(e.Source, AnotherEditContainer)
            If ec.EditState Then
                ec.EditState = False
            Else
                ec.EditState = True
            End If
            MyBase.OnPreviewMouseLeftButtonDown(e)
        End Sub
    End Class
End Namespace
'</SnippetAllCode>
