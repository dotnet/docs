
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIATableItemPattern_snippets
    Inherits System.Windows.Application
    
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
            Dim app As New UIATableItemPattern_snippets()
            
            app.Run()
        
        End Sub 'Main
    End Class 'TestMain
    
    
    ' <SnippetStartTarget>
    ''' -------------------------------------------------------------------
    ''' <summary>
    ''' Starts the target application and returns the AutomationElement 
    ''' obtained from the targets window handle.
    ''' </summary>
    ''' <param name="exe">
    ''' The target application.
    ''' </param>
    ''' <param name="filename">
    ''' The text file to be opened in the target application
    ''' </param>
    ''' <returns>
    ''' An AutomationElement representing the target application.
    ''' </returns>
    ''' -------------------------------------------------------------------
    Private Function StartTarget(ByVal exe As String, ByVal filename As String) As AutomationElement
        ' Start text editor and load with a text file.
        Dim p As Process = Process.Start(exe, filename)

        ' targetApp --> the root AutomationElement
        Dim targetApp As AutomationElement = _
        AutomationElement.FromHandle(p.MainWindowHandle)

        Return targetApp
    End Function
    ' </SnippetStartTarget>

    ' <SnippetGetTableElement>
    ''' -------------------------------------------------------------------
    ''' <summary>
    ''' Obtain the table control of interest from the target application.
    ''' </summary>
    ''' <param name="targetApp">
    ''' The target application.
    ''' </param>
    ''' <returns>
    ''' An AutomationElement representing a table control.
    ''' </returns>
    ''' -------------------------------------------------------------------
    Private Function GetTableElement(ByVal targetApp As AutomationElement) As AutomationElement
        ' The control type we're looking for; in this case 'Document'
        Dim cond1 As PropertyCondition = _
            New PropertyCondition( _
            AutomationElement.ControlTypeProperty, _
            ControlType.Table)

        ' The control pattern of interest; in this case 'TextPattern'.
        Dim cond2 As PropertyCondition = _
            New PropertyCondition( _
            AutomationElement.IsTablePatternAvailableProperty, _
            True)

        Dim tableCondition As AndCondition = New AndCondition(cond1, cond2)

        Dim targetTableElement As AutomationElement = _
        targetApp.FindFirst(TreeScope.Descendants, tableCondition)

        ' If targetTableElement is null then a suitable table control 
        ' was not found.
        Return targetTableElement
    End Function
    ' </SnippetGetTableElement>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a TableItemPattern control pattern from an 
    ''' AutomationElement.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The AutomationElement of interest.
    ''' </param>
    ''' <returns>
    ''' A TableItemPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetTableItemPattern( _
    ByVal targetControl As AutomationElement) As TableItemPattern
        Dim tableItemPattern As TableItemPattern = Nothing

        Try
            tableItemPattern = DirectCast( _
            targetControl.GetCurrentPattern(tableItemPattern.Pattern), TableItemPattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the 
            ' GridPattern control pattern
            Return Nothing
        End Try

        Return tableItemPattern

    End Function 'GetTableItemPattern    
    ' </Snippet101>

    ' <Snippet1015>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a TablePattern control pattern from an 
    ''' AutomationElement.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The AutomationElement of interest.
    ''' </param>
    ''' <returns>
    ''' A TablePattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetTablePattern( _
    ByVal targetControl As AutomationElement) As TablePattern
        Dim tablePattern As TablePattern = Nothing

        Try
            tablePattern = DirectCast( _
            targetControl.GetCurrentPattern(tablePattern.Pattern), _
            TablePattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the 
            ' TablePattern control pattern
            Return Nothing
        End Try

        Return tablePattern

    End Function 'GetTablePattern    
    ' </Snippet1015>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Set up table item event listeners.
    ''' </summary>
    ''' <remarks>
    ''' The event listener is essentially a focus change listener.
    ''' Since this is a global desktop listener, a filter would be required 
    ''' to ignore focus change events outside the table.
    ''' </remarks>
    '''--------------------------------------------------------------------
    Private Sub SetTableItemEventListeners( _
    ByVal targetControl As AutomationElement)
        Dim tableItemFocusChangedListener As AutomationFocusChangedEventHandler = _
        AddressOf OnTableItemFocusChange
        Automation.AddAutomationFocusChangedEventHandler( _
        tableItemFocusChangedListener)

    End Sub 'SetTableItemEventListeners    
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Event handler for table item focus change.
    ''' Can be used to track traversal of individual table items 
    ''' within a table.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    '''--------------------------------------------------------------------
    Private Sub OnTableItemFocusChange( _
    ByVal src As Object, ByVal e As AutomationFocusChangedEventArgs)
        ' Make sure the element still exists. Elements such as tooltips
        ' can disappear before the event is processed.
        Dim sourceElement As AutomationElement
        Try
            sourceElement = DirectCast(src, AutomationElement)
        Catch exc As ElementNotAvailableException
            Return
        End Try

        ' Get a TableItemPattern from the source of the event.
        Dim tableItemPattern As TableItemPattern = _
        GetTableItemPattern(sourceElement)

        If tableItemPattern Is Nothing Then
            Return
        End If

        ' Get a TablePattern from the container of the current element.
        Dim tablePattern As TablePattern = _
        GetTablePattern(tableItemPattern.Current.ContainingGrid)

        If tablePattern Is Nothing Then
            Return
        End If

        Dim tableItem As AutomationElement = Nothing
        Try
            tableItem = tablePattern.GetItem( _
            tableItemPattern.Current.Row, tableItemPattern.Current.Column)

        Catch exc As ArgumentOutOfRangeException
            ' If the requested row coordinate is larger than the RowCount 
            ' or the column coordinate is larger than the ColumnCount.
            ' -- OR --
            ' If either of the requested row or column coordinates 
            ' is less than zero.
            ' TO DO: error handling.
        End Try

        ' Further event processing can be done at this point.
        ' For the purposes of this sample we can just record item properties.
        Dim controlType As String = _
            tableItem.Current.ControlType.LocalizedControlType
        Dim columnHeaders As AutomationElement() = _
        tableItemPattern.Current.GetColumnHeaderItems()
        Dim rowHeaders As AutomationElement() = _
        tableItemPattern.Current.GetRowHeaderItems()
        Dim itemRow As Integer = tableItemPattern.Current.Row
        Dim itemColumn As Integer = tableItemPattern.Current.Column
        Dim itemRowSpan As Integer = tableItemPattern.Current.RowSpan
        Dim itemColumnSpan As Integer = tableItemPattern.Current.ColumnSpan

    End Sub 'OnTableItemFocusChange


    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Handles the application shutdown.
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
    ''' <param name="tableItemPattern">
    ''' A TableItemPattern control pattern obtained from 
    ''' an AutomationElement representing a target control.
    ''' </param>
    ''' <param name="automationProperty">
    ''' The automation property of interest.
    ''' </param>
    ''' <returns>
    ''' An object representing the requested integer property value.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetTableItemProperties( _
    ByVal tableItemPattern As TableItemPattern, _
    ByVal automationProperty As AutomationProperty) As Object
        If automationProperty.Id = tableItemPattern.ColumnProperty.Id Then
            Return tableItemPattern.Current.Column
        End If
        If automationProperty.Id = tableItemPattern.RowProperty.Id Then
            Return tableItemPattern.Current.Row
        End If
        If automationProperty.Id = tableItemPattern.ColumnSpanProperty.Id Then
            Return tableItemPattern.Current.ColumnSpan
        End If
        If automationProperty.Id = tableItemPattern.RowSpanProperty.Id Then
            Return tableItemPattern.Current.RowSpan
        End If

        Return Nothing

    End Function 'GetTableItemProperties    
    ' </Snippet104>

    ' <Snippet105>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains an array of primary table headers.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The target control of interest.
    ''' </param>
    ''' <param name="roworcolumnMajor">
    ''' The RowOrColumnMajor specifier.
    ''' </param>
    ''' <returns>
    ''' An AutomationElement array object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetPrimaryHeaders( _
    ByVal targetControl As AutomationElement, _
    ByVal roworcolumnMajor As RowOrColumnMajor) As [Object]
        If targetControl Is Nothing Then
            Throw New ArgumentException("Target element cannot be null.")
        End If

        Try
            If roworcolumnMajor = roworcolumnMajor.RowMajor Then
                Return targetControl.GetCurrentPropertyValue( _
                TableItemPattern.RowHeaderItemsProperty)
            End If

            If roworcolumnMajor = roworcolumnMajor.ColumnMajor Then
                Return targetControl.GetCurrentPropertyValue( _
                TableItemPattern.ColumnHeaderItemsProperty)
            End If
        Catch
        End Try
        ' TableItemPattern not supported.
        ' TO DO: error processing.

        Return Nothing

    End Function 'GetPrimaryHeaders
End Class 'UIATableItemPattern_snippets 
' </Snippet105>
