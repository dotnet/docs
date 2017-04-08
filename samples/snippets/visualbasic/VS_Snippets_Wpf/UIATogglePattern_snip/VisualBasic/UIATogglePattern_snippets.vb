
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIATogglePattern_snippets
    
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

        Dim conditionOn As New PropertyCondition( _
        TogglePattern.ToggleStateProperty, ToggleState.On)

        Dim conditionIndeterminate As New PropertyCondition( _
        TogglePattern.ToggleStateProperty, ToggleState.Indeterminate)

        ' Use any combination of the preceding condtions to 
        ' find the control(s) of interest
        Dim condition As OrCondition = _
        New OrCondition(conditionOn, conditionIndeterminate)

        Return rootElement.FindAll(TreeScope.Descendants, condition)

    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a TogglePattern control pattern from an automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A TogglePattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetTogglePattern( _
    ByVal targetControl As AutomationElement) As TogglePattern
        Dim togglePattern As TogglePattern = Nothing

        Try
            togglePattern = DirectCast( _
            targetControl.GetCurrentPattern(togglePattern.Pattern), _
            TogglePattern)
        Catch
            ' object doesn't support the TogglePattern control pattern
            Return Nothing
        End Try

        Return togglePattern

    End Function 'GetTogglePattern
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Calls the TogglePattern.Toggle() method for an associated 
    ''' automation element.
    ''' </summary>
    ''' <param name="togglePattern">
    ''' The TogglePattern control pattern obtained from
    ''' an automation element.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ToggleElement(ByVal togglePattern As TogglePattern)
        Try
            togglePattern.Toggle()
        Catch
            ' object is not able to perform the requested action
            Return
        End Try

    End Sub 'ToggleElement
    ' </Snippet102>

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
            Dim app As New UIATogglePattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIATogglePattern_snippets