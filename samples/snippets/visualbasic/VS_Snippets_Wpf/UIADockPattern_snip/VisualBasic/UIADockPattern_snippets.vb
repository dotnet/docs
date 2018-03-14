
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIADockPattern_snippets
    
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

        Dim conditionSupportsDock As New PropertyCondition( _
        AutomationElement.IsDockPatternAvailableProperty, True)

        Return targetApp.FindAll( _
        TreeScope.Descendants, conditionSupportsDock)

    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a DockPattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A DockPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetDockPattern( _
    ByVal targetControl As AutomationElement) As DockPattern
        Dim dockPattern As DockPattern = Nothing

        Try
            dockPattern = DirectCast( _
            targetControl.GetCurrentPattern(dockPattern.Pattern), _
            DockPattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the DockPattern control pattern
            Return Nothing
        End Try

        Return dockPattern

    End Function 'GetDockPattern    
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the current DockPosition of a target.
    ''' </summary>
    ''' <param name="dockControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' The current dock position.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Overloads Function GetCurrentDockPosition( _
    ByVal dockControl As AutomationElement) As DockPosition
        If dockControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement parameter must not be null.")
        End If

        Return CType(dockControl.GetCurrentPropertyValue( _
        DockPattern.DockPositionProperty), DockPosition)

    End Function 'GetCurrentDockPosition
    ' </Snippet102>

    ' <Snippet1025>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the current view identifier from a target.
    ''' </summary>
    ''' <param name="dockPattern">
    ''' The control pattern of interest.
    ''' </param>
    ''' <returns>
    ''' The current dock position.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Overloads Function GetCurrentDockPosition( _
    ByVal dockPattern As DockPattern) As DockPosition
        If dockPattern Is Nothing Then
            Throw New ArgumentNullException( _
            "DockPattern parameter must not be null.")
        End If

        Return dockPattern.Current.DockPosition

    End Function 'GetCurrentDockPosition    
    ' </Snippet1025>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Sets the dock position of a target.
    ''' </summary>
    ''' <param name="dockControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <param name="dockPosition">
    ''' The requested DockPosition.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub SetDockPositionOfControl( _
    ByVal dockControl As AutomationElement, _
    ByVal dockPosition As DockPosition)
        If dockControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement parameter must not be null.")
        End If

        Try
            Dim dockPattern As DockPattern = GetDockPattern(dockControl)
            If dockPattern Is Nothing Then
                Return
            End If
            dockPattern.SetDockPosition(dockPosition)
        Catch exc As InvalidOperationException
            ' When a control is not able to dock.
            ' TO DO: error handling
        End Try

    End Sub 'SetDockPositionOfControl 
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
            Dim app As New UIADockPattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIADockPattern_snippets