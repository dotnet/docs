
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIAExpandCollapsePattern_snippets
    
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

        Dim conditionLeafNode As New PropertyCondition( _
        ExpandCollapsePattern.ExpandCollapseStateProperty, _
        ExpandCollapseState.LeafNode)

        Return targetApp.FindAll(TreeScope.Descendants, conditionLeafNode)

    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains an ExpandCollapsePattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A ExpandCollapsePattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetExpandCollapsePattern( _
    ByVal targetControl As AutomationElement) As ExpandCollapsePattern
        Dim expandCollapsePattern As ExpandCollapsePattern = Nothing

        Try
            expandCollapsePattern = DirectCast( _
            targetControl.GetCurrentPattern(expandCollapsePattern.Pattern), _
            ExpandCollapsePattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the ExpandCollapsePattern control pattern.
            Return Nothing
        End Try

        Return expandCollapsePattern

    End Function 'GetExpandCollapsePattern    
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Programmatically expand or collapse a menu item.
    ''' </summary>
    ''' <param name="menuItem">
    ''' The target menu item.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ExpandCollapseMenuItem(ByVal menuItem As AutomationElement)
        If menuItem Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If

        Dim expandCollapsePattern As ExpandCollapsePattern = _
        GetExpandCollapsePattern(menuItem)

        If expandCollapsePattern Is Nothing Then
            Return
        End If

        If expandCollapsePattern.Current.ExpandCollapseState = _
        ExpandCollapseState.LeafNode Then
            Return
        End If

        Try
            If expandCollapsePattern.Current.ExpandCollapseState = _
            ExpandCollapseState.Expanded Then
                ' Collapse the menu item.
                expandCollapsePattern.Collapse()

            ElseIf expandCollapsePattern.Current.ExpandCollapseState = _
            ExpandCollapseState.Collapsed OrElse _
            expandCollapsePattern.Current.ExpandCollapseState = _
            ExpandCollapseState.PartiallyExpanded Then
                ' Expand the menu item.
                expandCollapsePattern.Expand()
            End If
        Catch exc As ElementNotEnabledException
            ' Control is not enabled
            ' TO DO: error handling.
        Catch exc As InvalidOperationException
            ' Control is unable to perform operation 
            ' TO DO: error handling.
        End Try

    End Sub 'ExpandCollapseMenuItem ' TO DO: error handling.
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
            Dim app As New UIAExpandCollapsePattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIAExpandCollapsePattern_snippets