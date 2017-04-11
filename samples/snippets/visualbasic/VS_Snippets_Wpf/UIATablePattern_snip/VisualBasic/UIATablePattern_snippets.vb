
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIATablePattern_snippets
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
            Dim app As New UIATablePattern_snippets()
            
            app.Run()
        
        End Sub 'Main
    End Class 'TestMain
    
    
    ' <SnippetStartTarget>
    ''' -------------------------------------------------------------------
    ''' <summary>
    ''' Starts the target application and returns the automation element 
    ''' obtained from the targets window handle.
    ''' </summary>
    ''' <param name="exe">
    ''' The target application.
    ''' </param>
    ''' <param name="filename">
    ''' The text file to be opened in the target application
    ''' </param>
    ''' <returns>
    ''' An automation element representing the target application.
    ''' </returns>
    ''' -------------------------------------------------------------------
    Private Function StartTarget(ByVal exe As String, ByVal filename As String) As AutomationElement
        ' Start text editor and load with a text file.
        Dim p As Process = Process.Start(exe, filename)

        ' targetApp --> the root automation element
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
    ''' An automation element representing a table control.
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

        Dim conditionSupportsTablePattern As New PropertyCondition( _
        AutomationElement.IsTablePatternAvailableProperty, True)

        Dim conditionIndeterminateTraversal As New PropertyCondition( _
        TablePattern.RowOrColumnMajorProperty, RowOrColumnMajor.Indeterminate)

        Dim conditionRowColumnTraversal As New PropertyCondition( _
        TablePattern.RowOrColumnMajorProperty, RowOrColumnMajor.ColumnMajor)

        Dim conditionTable As New AndCondition( _
        conditionSupportsTablePattern, _
        New OrCondition(conditionIndeterminateTraversal, _
        conditionRowColumnTraversal))

        Return targetApp.FindAll(TreeScope.Descendants, conditionTable)

    End Function 'FindAutomationElement
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a TablePattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
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
            targetControl.GetCurrentPattern(tablePattern.Pattern), TablePattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the 
            ' GridPattern control pattern
            Return Nothing
        End Try

        Return tablePattern

    End Function 'GetTablePattern
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a table items primary row or column header.
    ''' </summary>
    ''' <param name="tableItem">
    ''' The table item of interest.
    ''' </param>
    ''' <returns>
    ''' The table item header.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetTableItemHeader( _
    ByVal tableItem As TableItemPattern) As AutomationElement
        If tableItem Is Nothing Then
            Throw New ArgumentException("Target element cannot be null.")
        End If

        Dim tablePattern As TablePattern = _
        GetTablePattern(tableItem.Current.ContainingGrid)

        If tablePattern Is Nothing Then
            Return Nothing
        End If

        Dim tableHeaders As AutomationElement() = _
        GetPrimaryHeaders(tablePattern)

        If tableHeaders Is Nothing Then
            ' Indeterminate headers.
            Return Nothing
        End If

        If tablePattern.Current.RowOrColumnMajor = _
        RowOrColumnMajor.ColumnMajor Then
            Return tableHeaders(tableItem.Current.Column)
        End If

        If tablePattern.Current.RowOrColumnMajor = _
        RowOrColumnMajor.RowMajor Then
            Return tableHeaders(tableItem.Current.Row)
        End If

        Return Nothing

    End Function 'GetTableItemHeader    

    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains an array of table headers.
    ''' </summary>
    ''' <param name="tablePattern">
    ''' The TablePattern object of interest.
    ''' </param>
    ''' <returns>
    ''' The table primary row or column headers.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Overloads Function GetPrimaryHeaders( _
    ByVal tablePattern As TablePattern) As AutomationElement()
        If tablePattern.Current.RowOrColumnMajor = _
        RowOrColumnMajor.RowMajor Then
            Return tablePattern.Current.GetRowHeaders()
        End If

        If tablePattern.Current.RowOrColumnMajor = _
        RowOrColumnMajor.ColumnMajor Then
            Return tablePattern.Current.GetColumnHeaders()
        End If

        Return Nothing

    End Function 'GetPrimaryHeaders
    ' </Snippet102>

    ' <Snippet1025>
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
    ''' Automation element array objects.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Overloads Function GetPrimaryHeaders( _
    ByVal targetControl As AutomationElement, _
    ByVal roworcolumnMajor As RowOrColumnMajor) As AutomationElement()
        If targetControl Is Nothing Then
            Throw New ArgumentException("Target element cannot be null.")
        End If

        Try
            If roworcolumnMajor = roworcolumnMajor.RowMajor Then
                Return DirectCast(targetControl.GetCurrentPropertyValue( _
                TablePattern.RowHeadersProperty), AutomationElement())
            End If

            If roworcolumnMajor = roworcolumnMajor.ColumnMajor Then
                Return DirectCast(targetControl.GetCurrentPropertyValue( _
                TablePattern.ColumnHeadersProperty), AutomationElement())
            End If
        Catch exc As InvalidOperationException
            ' TablePattern not supported.
            ' TO DO: error processing.
        End Try

        Return Nothing

    End Function 'GetPrimaryHeaders
    ' </Snippet1025>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the current property values from target.
    ''' </summary>
    ''' <param name="tablePattern">
    ''' A TablePattern control pattern obtained from 
    ''' an automation element representing a target control.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub GetRowColumnCounts(ByVal tablePattern As TablePattern)
        If tablePattern Is Nothing Then
            Throw New ArgumentException("Target element cannot be null.")
        End If

        Console.WriteLine(tablePattern.Current.RowCount.ToString())
        Console.WriteLine(tablePattern.Current.ColumnCount.ToString())

    End Sub 'GetRowColumnCounts    
    ' </Snippet103>

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
End Class 'UIATablePattern_snippets