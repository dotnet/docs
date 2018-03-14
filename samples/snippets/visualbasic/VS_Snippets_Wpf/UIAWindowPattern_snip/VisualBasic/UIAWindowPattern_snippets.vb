
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIAWindowPattern_snippets
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New() 
    
    End Sub 'New
    
    
    ' <Snippet100>
    '''------------------------------------------------------------------------
    ''' <summary>
    ''' Finds all automation elements that satisfy 
    ''' the specified condition(s).
    ''' </summary>
    ''' <param name="rootElement">
    ''' The automation element from which to start searching.
    ''' </param>
    ''' <returns>
    ''' A collection of automation elements satisfying 
    ''' the specified condition(s).
    ''' </returns>
    '''------------------------------------------------------------------------
    Private Function FindAutomationElement( _
        ByVal rootElement As AutomationElement) As AutomationElementCollection
        If rootElement Is Nothing Then
            Throw New ArgumentException("Root element cannot be null.")
        End If

        Dim conditionCanMaximize As _
            New PropertyCondition(WindowPattern.CanMaximizeProperty, True)

        Dim conditionCanMinimize As _
            New PropertyCondition(WindowPattern.CanMinimizeProperty, True)

        Dim conditionIsModal As _
            New PropertyCondition(WindowPattern.IsModalProperty, False)

        Dim conditionIsTopmost As _
            New PropertyCondition(WindowPattern.IsTopmostProperty, True)

        Dim conditionWindowInteractionState As _
            New PropertyCondition(WindowPattern.WindowInteractionStateProperty, _
            WindowInteractionState.ReadyForUserInteraction)

        Dim conditionWindowVisualState As _
            New PropertyCondition(WindowPattern.WindowVisualStateProperty, _
            WindowVisualState.Normal)

        ' Use any combination of the preceding condtions to 
        ' find the control(s) of interest
        Dim condition = New AndCondition(conditionCanMaximize, _
            conditionIsModal, conditionWindowInteractionState)

        Return rootElement.FindAll(TreeScope.Descendants, condition)

    End Function 'FindAutomationElement

    ' </Snippet100>

    ' <Snippet101>
    '''------------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a WindowPattern control pattern from an automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A WindowPattern object.
    ''' </returns>
    '''------------------------------------------------------------------------
    Private Function GetWindowPattern(ByVal targetControl As AutomationElement) As WindowPattern
        Dim windowPattern As WindowPattern = Nothing

        Try
            windowPattern = DirectCast( _
            targetControl.GetCurrentPattern(windowPattern.Pattern), _
            WindowPattern)
        Catch
            ' object doesn't support the WindowPattern control pattern
            Return Nothing
        End Try
        ' Make sure the element is usable.
        If False = windowPattern.WaitForInputIdle(10000) Then
            ' Object not responding in a timely manner
            Return Nothing
        End If
        Return windowPattern
    End Function 'GetWindowPattern
    
    ' </Snippet101>

    ' <Snippet102>
    '''------------------------------------------------------------------------
    ''' <summary>
    ''' Calls the WindowPattern.Close() method for an associated 
    ''' automation element.
    ''' </summary>
    ''' <param name="windowPattern">
    ''' The WindowPattern control pattern obtained from
    ''' an automation element.
    ''' </param>
    '''------------------------------------------------------------------------
    Private Sub CloseWindow(ByVal windowPattern As WindowPattern)
        Try
            windowPattern.Close()
        Catch
            ' object is not able to perform the requested action
            Return
        End Try

    End Sub 'CloseWindow
    
    ' </Snippet102>

    ' <Snippet103>
    '''------------------------------------------------------------------------
    ''' <summary>
    ''' Calls the WindowPattern.SetVisualState() method for an associated 
    ''' automation element.
    ''' </summary>
    ''' <param name="windowPattern">
    ''' The WindowPattern control pattern obtained from
    ''' an automation element.
    ''' </param>
    ''' <param name="visualState">
    ''' The specified WindowVisualState enumeration value.
    ''' </param>
    '''------------------------------------------------------------------------
    Private Sub SetVisualState(ByVal windowPattern As WindowPattern, _
        ByVal visualState As WindowVisualState)
        Try
            If (windowPattern.Current.WindowInteractionState = _
                    WindowInteractionState.ReadyForUserInteraction) Then
                Select Case visualState
                    Case WindowVisualState.Maximized
                        ' Confirm that the element can be maximized
                        If ((windowPattern.Current.CanMaximize) & _
                                Not (windowPattern.Current.IsModal)) Then
                            windowPattern.SetWindowVisualState( _
                            WindowVisualState.Maximized)
                        End If
                        ' TODO: additional processing
                    Case WindowVisualState.Minimized
                        ' Confirm that the element can be minimized
                        If ((windowPattern.Current.CanMinimize) & _
                                Not (windowPattern.Current.IsModal)) Then
                            windowPattern.SetWindowVisualState( _
                            WindowVisualState.Minimized)
                        End If
                        ' TODO: additional processing
                    Case WindowVisualState.Normal
                        windowPattern.SetWindowVisualState( _
                        WindowVisualState.Normal)
                    Case Else
                        windowPattern.SetWindowVisualState( _
                        WindowVisualState.Normal)
                End Select
                ' TODO: additional processing
            End If
        Catch exc As InvalidOperationException
            ' object is not able to perform the requested action
            Return
        End Try
    End Sub 'SetVisualState

    ' </Snippet103>

    ' <Snippet104>
    '''------------------------------------------------------------------------
    ''' <summary>
    ''' Register for events of interest.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    '''------------------------------------------------------------------------
    Private Sub RegisterForEvents(ByVal targetControl As AutomationElement)
        Dim eventHandler As AutomationEventHandler = AddressOf OnWindowOpenOrClose
        Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, _
            targetControl, TreeScope.Element, eventHandler)
        Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, _
            targetControl, TreeScope.Element, eventHandler)
    End Sub 'RegisterForEvents

    '''------------------------------------------------------------------------
    ''' <summary>
    ''' AutomationEventHandler delegate.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    '''------------------------------------------------------------------------
    Private Sub OnWindowOpenOrClose(ByVal src As Object, _
        ByVal e As AutomationEventArgs)
        ' Make sure the element still exists. Elements such as tooltips
        ' can disappear before the event is processed.
        Dim sourceElement As AutomationElement
        Try
            sourceElement = DirectCast(src, AutomationElement)
        Catch
            Return
        End Try

        If e.EventId Is WindowPattern.WindowOpenedEvent Then
            ' TODO: event handling
            Return
        End If
        If e.EventId Is WindowPattern.WindowClosedEvent Then
            ' TODO: event handling
            Return
        End If
    End Sub 'OnWindowOpenOrClose
    ' </Snippet104>

    ' <Snippet105>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Register for automation property change events of interest.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub RegisterForPropertyChangedEvents( _
    ByVal targetControl As AutomationElement)
        Dim propertyChangeListener As AutomationPropertyChangedEventHandler = _
            New AutomationPropertyChangedEventHandler(AddressOf _
            OnTopmostPropertyChange)
        Automation.AddAutomationPropertyChangedEventHandler( _
            targetControl, _
            TreeScope.Element, _
            propertyChangeListener, _
            WindowPattern.IsTopmostProperty)
    End Sub
    ' </Snippet105>

    ' <Snippet106>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Register for automation property change events of interest.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    '''--------------------------------------------------------------------
    Private Sub OnTopmostPropertyChange(ByVal src As Object, _
    ByVal e As AutomationPropertyChangedEventArgs)
        ' Make sure the element still exists. Elements such as tooltips
        ' can disappear before the event is processed.
        Dim sourceElement As AutomationElement
        Try
            sourceElement = DirectCast(src, AutomationElement)
        Catch exc As ElementNotAvailableException
            Return
        End Try
        ' Get a WindowPattern from the source of the event.
        Dim windowPattern As WindowPattern = GetWindowPattern(sourceElement)
        If (WindowPattern.Current.IsTopmost) Then
            'TODO: event handling
        End If
    End Sub
    ' </Snippet106>
End Class 'UIAWindowPattern_snippets 