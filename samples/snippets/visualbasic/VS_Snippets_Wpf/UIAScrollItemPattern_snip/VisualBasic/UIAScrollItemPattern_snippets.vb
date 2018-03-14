
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation
Imports System.Windows.Controls



Class UIAScrollItemPattern_snippets
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New() 
    
    End Sub 'New
    
    
    ' <Snippet100>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ScrollItemPattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A ScrollItemPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetScrollItemPattern( _
    ByVal targetControl As AutomationElement) As ScrollItemPattern
        Dim scrollItemPattern As ScrollItemPattern = Nothing

        Try
            scrollItemPattern = DirectCast( _
            targetControl.GetCurrentPattern( _
            scrollItemPattern.Pattern), ScrollItemPattern)
        Catch
            ' Object doesn't support the ScrollItemPattern control pattern
            Return Nothing
        End Try

        Return scrollItemPattern

    End Function 'GetScrollItemPattern    
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' A Select, AddToSelection or RemoveFromSelection event handler that 
    ''' scrolls a SelectionItem object into the viewable region of its 
    ''' container control.
    ''' </summary>
    '''--------------------------------------------------------------------
    Private Sub OnSelectionItemSelect( _
    ByVal src As Object, ByVal e As SelectionChangedEventArgs)
        Dim selectionItem As AutomationElement = _
        DirectCast(src, AutomationElement)

        Dim scrollItemPattern As ScrollItemPattern = _
        GetScrollItemPattern(selectionItem)

        If scrollItemPattern Is Nothing Then
            Return
        End If

        Try
            scrollItemPattern.ScrollIntoView()
        Catch exc As InvalidOperationException
            ' The item cannot be scrolled into view.
            ' TO DO: error handling.
        End Try

    End Sub 'OnSelectionItemSelect 
    ' </Snippet101>

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
            Dim app As New UIAScrollItemPattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIAScrollItemPattern_snippets