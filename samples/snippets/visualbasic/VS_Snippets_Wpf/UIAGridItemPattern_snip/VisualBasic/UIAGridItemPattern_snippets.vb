
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIAGridItemPattern_snippets
    Inherits System.Windows.Application
    
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
    ''' <param name="targetApp">
    ''' The automation element from which to start searching.
    ''' </param>
    ''' <param name="targetControl">
    ''' The specific grid container of interest.
    ''' </param>
    ''' <returns>
    ''' A collection of automation elements satisfying 
    ''' the specified condition(s).
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function FindAutomationElement( _
    ByVal targetApp As AutomationElement, _
    ByVal targetControl As AutomationElement) As AutomationElementCollection
        If targetApp Is Nothing Then
            Throw New ArgumentException("Root element cannot be null.")
        End If

        Dim conditionSupportsGridItemPattern As New PropertyCondition( _
        AutomationElement.IsGridItemPatternAvailableProperty, True)

        Dim conditionContainerGrid As New PropertyCondition( _
        GridItemPattern.ContainingGridProperty, targetControl)

        Dim conditionGridItems As New AndCondition( _
        conditionSupportsGridItemPattern, conditionContainerGrid)

        Return targetApp.FindAll(TreeScope.Descendants, conditionGridItems)

    End Function 'FindAutomationElement
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a GridItemPattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A GridItemPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetGridItemPattern( _
    ByVal targetControl As AutomationElement) As GridItemPattern
        Dim gridItemPattern As GridItemPattern = Nothing

        Try
            gridItemPattern = DirectCast( _
            targetControl.GetCurrentPattern(gridItemPattern.Pattern), _
            GridItemPattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the 
            ' GridPattern control pattern
            Return Nothing
        End Try

        Return gridItemPattern

    End Function 'GetGridItemPattern
    ' </Snippet101>

    ' <Snippet1015>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a GridPattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A GridPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetGridPattern( _
    ByVal targetControl As AutomationElement) As GridPattern
        Dim gridPattern As GridPattern = Nothing

        Try
            gridPattern = DirectCast( _
            targetControl.GetCurrentPattern(gridPattern.Pattern), GridPattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the 
            ' GridPattern control pattern
            Return Nothing
        End Try

        Return gridPattern
    End Function 'GetGridPattern
    ' </Snippet1015>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Set up grid item event listeners.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The grid item container of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub SetGridItemEventListeners( _
    ByVal targetControl As AutomationElement)
        Dim gridItemFocusChangedListener As AutomationFocusChangedEventHandler = _
        AddressOf OnGridItemFocusChange
        Automation.AddAutomationFocusChangedEventHandler( _
        gridItemFocusChangedListener)
    End Sub 'SetGridItemEventListeners
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Event handler for grid item focus change.
    ''' Can be used to track traversal of individual grid items 
    ''' within a grid.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    '''--------------------------------------------------------------------
    Private Sub OnGridItemFocusChange( _
    ByVal src As Object, ByVal e As AutomationFocusChangedEventArgs)
        ' Make sure the element still exists. Elements such as tooltips
        ' can disappear before the event is processed.
        Dim sourceElement As AutomationElement
        Try
            sourceElement = DirectCast(src, AutomationElement)
        Catch exc As ElementNotAvailableException
            Return
        End Try

        ' Gets a GridItemPattern from the source of the event.
        Dim gridItemPattern As GridItemPattern = _
        GetGridItemPattern(sourceElement)

        If gridItemPattern Is Nothing Then
            Return
        End If

        ' Gets a GridPattern from the grid container.
        Dim gridPattern As GridPattern = _
        GetGridPattern(gridItemPattern.Current.ContainingGrid)

        If gridPattern Is Nothing Then
            Return
        End If

        Dim gridItem As AutomationElement = Nothing
        Try
            gridItem = gridPattern.GetItem( _
            gridItemPattern.Current.Row, gridItemPattern.Current.Column)
        Catch
            ' If the requested row coordinate is larger than the RowCount 
            ' or the column coordinate is larger than the ColumnCount.
            ' -- OR --
            ' If either of the requested row or column coordinates 
            ' are less than zero.
            ' TO DO: error handling.
        End Try

        ' Further event processing can be done at this point.
        ' For the purposes of this sample we just report item properties.
        Dim gridItemReport As New StringBuilder()
        gridItemReport.AppendLine( _
        gridItemPattern.Current.Row.ToString()).AppendLine( _
        gridItemPattern.Current.Column.ToString()).AppendLine( _
        gridItemPattern.Current.RowSpan.ToString()).AppendLine( _
        gridItemPattern.Current.ColumnSpan.ToString()).AppendLine( _
        gridItem.Current.AutomationId.ToString())
        Console.WriteLine(gridItemReport.ToString())

    End Sub 'OnGridItemFocusChange
    
    
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Handles our application shutdown.
    ''' </summary>
    ''' <param name="args">Event arguments.</param>
    '''--------------------------------------------------------------------
    Protected Overrides Sub OnExit(ByVal args As System.Windows.ExitEventArgs) 
        Automation.RemoveAllEventHandlers()
        MyBase.OnExit(args)
    
    End Sub 'OnExit    
    ' </Snippet103>

    ' <Snippet104>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the current property values from target.
    ''' </summary>
    ''' <param name="gridItemPattern">
    ''' A GridItemPattern control pattern obtained from 
    ''' an automation element representing a target control.
    ''' </param>
    ''' <param name="automationProperty">
    ''' The automation property of interest.
    ''' </param>
    ''' <returns>
    ''' An integer object representing the requested property value.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetGridItemProperties( _
    ByVal gridItemPattern As GridItemPattern, _
    ByVal automationProperty As AutomationProperty) As Object
        If automationProperty.Id = gridItemPattern.ColumnProperty.Id Then
            Return gridItemPattern.Current.Column
        End If
        If automationProperty.Id = gridItemPattern.RowProperty.Id Then
            Return gridItemPattern.Current.Row
        End If
        If automationProperty.Id = gridItemPattern.ColumnSpanProperty.Id Then
            Return gridItemPattern.Current.ColumnSpan
        End If
        If automationProperty.Id = gridItemPattern.RowSpanProperty.Id Then
            Return gridItemPattern.Current.RowSpan
        End If

        Return Nothing

    End Function 'GetGridItemProperties
    ' </Snippet104>

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
            Dim app As New UIAGridItemPattern_snippets()
            
            app.Run()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIAGridItemPattern_snippets