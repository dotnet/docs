
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIASelectionPattern_snippets
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()

    End Sub 'New

    '''--------------------------------------------------------------------
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    '''--------------------------------------------------------------------
    
    NotInheritable Friend Class TestMain
        
        <STAThread()>  _
        Shared Sub Main() 
            ' Create an instance of the sample class 
            ' and call its Run() method to start it.
            Dim app As New UIASelectionPattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
    
    
    ' <Snippet100>
    '''--------------------------------------------------------------------
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
    '''--------------------------------------------------------------------
    Private Function FindAutomationElement( _
    ByVal rootElement As AutomationElement) As AutomationElementCollection
        If rootElement Is Nothing Then
            Throw New ArgumentException("Root element cannot be null.")
        End If

        Dim conditionCanSelectMultiple As New PropertyCondition( _
        SelectionPattern.CanSelectMultipleProperty, True)

        Dim conditionIsSelectionRequired As New PropertyCondition( _
        SelectionPattern.IsSelectionRequiredProperty, False)

        ' Use any combination of the preceding condtions to 
        ' find the control(s) of interest
        Dim condition As New AndCondition( _
        conditionCanSelectMultiple, conditionIsSelectionRequired)

        Return rootElement.FindAll(TreeScope.Descendants, condition)
    End Function 'FindAutomationElement
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a SelectionPattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A SelectionPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetSelectionPattern( _
    ByVal targetControl As AutomationElement) As SelectionPattern
        Dim selectionPattern As SelectionPattern = Nothing

        Try
            selectionPattern = DirectCast( _
            targetControl.GetCurrentPattern(selectionPattern.Pattern), _
            SelectionPattern)
        ' Object doesn't support the SelectionPattern control pattern
        Catch
            Return Nothing
        End Try

        Return selectionPattern
    End Function 'GetSelectionPattern
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the currently selected SelectionItem objects from target.
    ''' </summary>
    ''' <param name="selectionContainer">
    ''' The current Selection container object.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Function GetCurrentSelectionProperty( _
    ByVal selectionContainer As AutomationElement) As AutomationElement()
        Try
            Return DirectCast(selectionContainer.GetCurrentPropertyValue( _
            SelectionPattern.SelectionProperty), AutomationElement())
            ' Container is not enabled
        Catch
            Return Nothing
        End Try
    End Function 'GetCurrentSelectionProperty
    ' </Snippet102>

    ' <Snippet1025>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the currently selected SelectionItem objects from target.
    ''' </summary>
    ''' <param name="selectionContainer">The current Selection container object.</param>
    '''--------------------------------------------------------------------
    Private Function GetCurrentSelection( _
    ByVal selectionContainer As AutomationElement) As AutomationElement()
        Try
            Dim selectionPattern As SelectionPattern = _
            selectionContainer.GetCurrentPattern(selectionPattern.Pattern)
            Return selectionPattern.Current.GetSelection()
            ' Container is not enabled
        Catch
            Return Nothing
        End Try
    End Function 'GetCurrentSelection
    ' </Snippet1025>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Subscribe to the selection events of interest.
    ''' </summary>
    ''' <param name="selectionContainer">
    ''' Automation element that supports SelectionPattern
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub SetSelectionEventHandlers( _
    ByVal selectionContainer As AutomationElement)
        Dim selectionInvalidatedHandler As AutomationEventHandler = _
        New AutomationEventHandler(AddressOf OnSelectionInvalidatedHandler)

        Automation.AddAutomationEventHandler( _
        SelectionPattern.InvalidatedEvent, _
        selectionContainer, TreeScope.Element, selectionInvalidatedHandler)

    End Sub 'SetSelectionEventHandlers

    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Selection invalidated event handler.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    '''--------------------------------------------------------------------
    Private Sub OnSelectionInvalidatedHandler( _
    ByVal src As Object, ByVal e As AutomationEventArgs)
        ' TODO: event handling
    End Sub 'SelectionHandler
    ' </Snippet103>

    ' <Snippet104>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the current property values from target.
    ''' </summary>
    ''' <param name="selectionPattern">
    ''' A SelectionPattern control pattern obtained from 
    ''' an automation element representing the selection control.
    ''' </param>
    ''' <param name="automationProperty">
    ''' The automation property of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Function GetSelectionObjectProperty( _
    ByVal selectionPattern As SelectionPattern, _
    ByVal automationProperty As AutomationProperty) As Boolean
        If automationProperty.Id = _
        selectionPattern.CanSelectMultipleProperty.Id Then
            Return selectionPattern.Current.CanSelectMultiple
        End If
        If automationProperty.Id = _
        selectionPattern.IsSelectionRequiredProperty.Id Then
            Return selectionPattern.Current.IsSelectionRequired
        End If
        Return False
    End Function 'GetSelectionObjectProperty
    ' </Snippet104>
End Class 'UIASelectionPattern_snippets 