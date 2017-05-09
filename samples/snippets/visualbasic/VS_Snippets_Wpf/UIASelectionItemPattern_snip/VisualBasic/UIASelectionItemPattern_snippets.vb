
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIASelectionItemPattern_snippets
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()

    End Sub 'New


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

        Dim conditionIsSelected As New PropertyCondition( _
        SelectionItemPattern.IsSelectedProperty, False)

        Return rootElement.FindAll(TreeScope.Descendants, conditionIsSelected)
    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Subscribe to the selection item events of interest.
    ''' </summary>
    ''' <param name="selectionItem">
    ''' Automation element that supports SelectionItemPattern and is 
    ''' a child of a selection container that supports SelectionPattern
    ''' </param>
    ''' <remarks>
    ''' The events are raised by the SelectionItem elements, 
    ''' not the Selection container.
    ''' </remarks>
    '''--------------------------------------------------------------------
    Private Sub SetSelectionEventHandlers( _
    ByVal selectionItem As AutomationElement)
        Dim selectionHandler As AutomationEventHandler = _
        New AutomationEventHandler(AddressOf OnSelectionHandler)

        Automation.AddAutomationEventHandler( _
        SelectionItemPattern.ElementSelectedEvent, _
        selectionItem, TreeScope.Element, selectionHandler)
        Automation.AddAutomationEventHandler( _
        SelectionItemPattern.ElementAddedToSelectionEvent, _
        selectionItem, TreeScope.Element, selectionHandler)
        Automation.AddAutomationEventHandler( _
        SelectionItemPattern.ElementRemovedFromSelectionEvent, _
        selectionItem, TreeScope.Element, selectionHandler)
    End Sub 'SetSelectionEventHandlers


    Private Sub OnSelectionHandler(ByVal src As Object, ByVal e As AutomationEventArgs)
        ' TODO: event handling
    End Sub 'SelectionHandler
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a SelectionItemPattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A SelectionItemPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetSelectionItemPattern( _
    ByVal targetControl As AutomationElement) As SelectionItemPattern
        Dim selectionItemPattern As SelectionItemPattern = Nothing

        Try
            selectionItemPattern = DirectCast( _
            targetControl.GetCurrentPattern(selectionItemPattern.Pattern), _
            SelectionItemPattern)
        Catch
            ' Object doesn't support the SelectionItemPattern control pattern
            Return Nothing
        End Try

        Return selectionItemPattern
    End Function 'GetSelectionItemPattern
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Retrieves the selection container for a selection item.
    ''' </summary>
    ''' <param name="selectionItem">
    ''' An automation element that supports SelectionItemPattern.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Function GetSelectionItemContainer( _
    ByVal selectionItem As AutomationElement) As AutomationElement
        ' Selection item cannot be null
        If selectionItem Is Nothing Then
            Throw New ArgumentException()
        End If

        Dim selectionItemPattern As SelectionItemPattern = _
        DirectCast(selectionItem.GetCurrentPattern( _
        selectionItemPattern.Pattern), SelectionItemPattern)
        If selectionItemPattern Is Nothing Then
            Return Nothing
        Else
            Return selectionItemPattern.Current.SelectionContainer
        End If
    End Function 'GetSelectionItemContainer
    ' </Snippet103>

    ' <Snippet1035>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Retrieves the selection items for a selection container.
    ''' </summary>
    ''' <param name="rootElement">
    ''' The automation element from which to start searching.
    ''' </param>
    ''' <param name="selectionContainer">
    ''' An automation element that supports SelectionPattern.
    ''' </param>
    ''' <returns>
    ''' A collection of automation elements satisfying 
    ''' the specified condition(s).
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function FindElementBasedOnContainer( _
    ByVal rootElement As AutomationElement, _
    ByVal selectionContainer As AutomationElement) As AutomationElementCollection
        Dim containerCondition As PropertyCondition = _
            New PropertyCondition( _
            SelectionItemPattern.SelectionContainerProperty, _
            selectionContainer)
        Dim selectionItems As AutomationElementCollection = _
            rootElement.FindAll(TreeScope.Descendants, containerCondition)
        Return selectionItems
    End Function
    ' </Snippet1035>

    ' <Snippet104>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Attempts to add the current item to a collection 
    ''' of selected items. 
    ''' </summary>
    ''' <param name="selectionItem">
    ''' An automation element that supports SelectionItemPattern.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub AddItemToSelection(ByVal selectionItem As AutomationElement)
        If selectionItem Is Nothing Then
            Throw New ArgumentNullException("Argument cannot be null or empty.")
        End If

        Dim selectionContainer As AutomationElement = _
        GetSelectionItemContainer(selectionItem)

        ' Selection container cannot be null
        If selectionContainer Is Nothing Then
            Throw New ElementNotAvailableException()
        End If

        Dim selectionPattern As SelectionPattern = DirectCast( _
        selectionContainer.GetCurrentPattern(selectionPattern.Pattern), _
        SelectionPattern)

        If selectionPattern Is Nothing Then
            Return
        End If

        If selectionPattern.Current.CanSelectMultiple Then
            Dim selectionItemPattern As SelectionItemPattern = DirectCast( _
            selectionItem.GetCurrentPattern(selectionItemPattern.Pattern), _
            SelectionItemPattern)

            If Not (selectionItemPattern Is Nothing) Then
                Try
                    selectionItemPattern.AddToSelection()
                Catch
                    ' Unable to add to selection
                    Return
                End Try
            End If
        End If

    End Sub 'AddItemToSelection    
    ' </Snippet104>

    ' <Snippet105>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Attempts to remove the current item from a collection 
    ''' of selected items. 
    ''' </summary>
    ''' <param name="selectionItem">
    ''' An automation element that supports SelectionItemPattern.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub RemoveItemFromSelection( _
    ByVal selectionItem As AutomationElement)
        If selectionItem Is Nothing Then
            Throw New ArgumentNullException( _
            "Argument cannot be null or empty.")
        End If

        Dim selectionContainer As AutomationElement = _
        GetSelectionItemContainer(selectionItem)

        ' Selection container cannot be null
        If selectionContainer Is Nothing Then
            Throw New ElementNotAvailableException()
        End If

        Dim selectionPattern As SelectionPattern = DirectCast( _
        selectionContainer.GetCurrentPattern(selectionPattern.Pattern), _
        SelectionPattern)

        If selectionPattern Is Nothing Then
            Return
        End If

        ' Check if a selection is required
        If selectionPattern.Current.IsSelectionRequired AndAlso _
        selectionPattern.Current.GetSelection().GetLength(0) <= 1 Then
            Return
        End If

        Dim selectionItemPattern As SelectionItemPattern = DirectCast( _
        selectionItem.GetCurrentPattern(selectionItemPattern.Pattern), _
        SelectionItemPattern)

        If Not (selectionItemPattern Is Nothing) AndAlso selectionItemPattern.Current.IsSelected Then
            Try
                selectionItemPattern.RemoveFromSelection()
            Catch
                ' Unable to remove from selection
                Return
            End Try
        End If
    End Sub 'RemoveItemFromSelection
    ' </Snippet105>

    ' <Snippet106>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Selects a string item in a container.
    ''' </summary>
    ''' <param name="selectionContainer">The selection container.</param>
    ''' <param name="itemText">The text to select.</param>
    ''' <remarks>
    ''' This deselects any currently selected items. 
    ''' To add the item to the current selection in a multiselect list, 
    ''' use AddToSelection instead of Select.
    ''' </remarks>
    '''--------------------------------------------------------------------
    Public Sub SelectListItem( _
    ByVal selectionContainer As AutomationElement, ByVal itemText As String)
        If selectionContainer Is Nothing OrElse itemText = "" Then
            Throw New ArgumentException("Argument cannot be null or empty.")
        End If

        Dim propertyCondition = _
        New PropertyCondition(AutomationElement.NameProperty, _
        itemText, PropertyConditionFlags.IgnoreCase)

        Dim firstMatch As AutomationElement = _
        selectionContainer.FindFirst(TreeScope.Children, propertyCondition)

        If Not (firstMatch Is Nothing) Then
            Try
                Dim selectionItemPattern As SelectionItemPattern
                selectionItemPattern = DirectCast( _
                firstMatch.GetCurrentPattern(selectionItemPattern.Pattern), _
                SelectionItemPattern)
                selectionItemPattern.Select()
            Catch
                ' Unable to select
                Return
            End Try
        End If
    End Sub 'SelectListItem
    ' </Snippet106>

    '''--------------------------------------------------------------------
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    '''--------------------------------------------------------------------

    Friend NotInheritable Class TestMain

        <STAThread()> _
        Shared Sub Main()
            ' Create an instance of the sample class 
            ' and call its Run() method to start it.
            Dim app As New UIASelectionItemPattern_snippets()

        End Sub 'Main
    End Class 'TestMain
End Class 'UIASelectionItemPattern_snippets