
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIAGridPattern_snippets
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
    ''' <returns>
    ''' A collection of automation elements satisfying 
    ''' the specified condition(s).
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function FindAutomationElement( _
    ByVal targetApp As AutomationElement) As AutomationElementCollection
        If targetApp Is Nothing Then
            Throw New ArgumentException("Root element cannot be null.")
        End If

        Dim conditionSupportsGridPattern As New PropertyCondition( _
        AutomationElement.IsGridPatternAvailableProperty, True)

        Dim conditionOneColumn As New PropertyCondition( _
        GridPattern.ColumnCountProperty, 1)

        Dim conditionOneRow As New PropertyCondition( _
        GridPattern.RowCountProperty, 1)

        Dim conditionSingleItemGrid As New AndCondition( _
        conditionSupportsGridPattern, conditionOneColumn, conditionOneRow)

        Return targetApp.FindAll( _
        TreeScope.Descendants, conditionSingleItemGrid)

    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
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
            targetControl.GetCurrentPattern( _
            gridPattern.Pattern), GridPattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the 
            ' GridPattern control pattern
            Return Nothing
        End Try

        Return gridPattern
    End Function 'GetGridPattern    
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Set up grid event listeners.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub SetGridEventListeners( _
    ByVal targetControl As AutomationElement)
        Dim gridStructureChangedListener As StructureChangedEventHandler = _
        AddressOf OnGridStructureChange
        Automation.AddStructureChangedEventHandler( _
        targetControl, TreeScope.Element, gridStructureChangedListener)
    End Sub 'SetGridEventListeners    
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Event handler for grid structure change.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    '''--------------------------------------------------------------------
    Private Sub OnGridStructureChange( _
    ByVal src As Object, ByVal e As StructureChangedEventArgs)
        ' Make sure the element still exists. Elements such as tooltips
        ' can disappear before the event is processed.
        Dim sourceElement As AutomationElement
        Try
            sourceElement = DirectCast(src, AutomationElement) 
        Catch exc As ElementNotAvailableException
            Return
        End Try

        Dim gridPattern As GridPattern = GetGridPattern(sourceElement)

        If gridPattern Is Nothing Then
            Return
        End If

        If gridPattern.Current.ColumnCount <> columnCount Then
            ' Column item added.
        ElseIf gridPattern.Current.RowCount <> rowCount Then
            ' Row item added.
        End If

    End Sub 'OnGridStructureChange 
    ' Member variables to track current row and column counts.
    Private columnCount As Integer = 0
    Private rowCount As Integer = 0

    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Handles our application shutdown.
    ''' </summary>
    ''' <param name="args">Event arguments.</param>
    '''--------------------------------------------------------------------
    Protected Overrides Sub OnExit( _
    ByVal args As System.Windows.ExitEventArgs)
        Automation.RemoveAllEventHandlers()
        MyBase.OnExit(args)
    End Sub 'OnExit

    ' </Snippet103>
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
            Dim app As New UIAGridPattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain 
End Class 'UIAGridPattern_snippets 