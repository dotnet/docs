
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIATransformPattern_snippets
    
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

        Dim conditionCanMove As New PropertyCondition( _
        TransformPattern.CanMoveProperty, False)

        Dim conditionCanResize As New PropertyCondition( _
        TransformPattern.CanResizeProperty, True)

        Dim conditionCanRotate As New PropertyCondition( _
        TransformPattern.CanRotateProperty, True)

        ' Use any combination of the preceding condtions to 
        ' find the control(s) of interest
        Dim condition As AndCondition = New AndCondition( _
        conditionCanRotate, conditionCanMove, conditionCanResize)

        Return rootElement.FindAll(TreeScope.Descendants, condition)

    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a TransformPattern control pattern from 
    ''' an automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A TransformPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetTransformPattern( _
    ByVal targetControl As AutomationElement) As TransformPattern
        Dim transformPattern As TransformPattern = Nothing

        Try
            transformPattern = DirectCast( _
            targetControl.GetCurrentPattern(transformPattern.Pattern), _
            TransformPattern)
        Catch exc As InvalidOperationException
            ' object doesn't support the TransformPattern control pattern
            Return Nothing
        End Try

        Return transformPattern

    End Function 'GetTransformPattern    
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Calls the TransformPattern.Rotate() method for an associated 
    ''' automation element.
    ''' </summary>
    ''' <param name="transformPattern">
    ''' The TransformPattern control pattern obtained from
    ''' an automation element.
    ''' </param>
    ''' <param name="degrees">
    ''' The amount of degrees to rotate the automation element.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub RotateElement( _
    ByVal transformPattern As TransformPattern, ByVal degrees As Double)
        Try
            If transformPattern.Current.CanRotate Then
                transformPattern.Rotate(degrees)
            End If
        Catch
            ' object is not able to perform the requested action
            Return
        End Try

    End Sub 'RotateElement
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Calls the TransformPattern.Move() method for an associated 
    ''' automation element.
    ''' </summary>
    ''' <param name="transformPattern">
    ''' The TransformPattern control pattern obtained from
    ''' an automation element.
    ''' </param>
    ''' <param name="x">
    ''' The number of screen pixels to move the automation element 
    ''' horizontally.
    ''' </param>
    ''' <param name="y">
    ''' The number of screen pixels to move the automation element 
    ''' vertically.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub MoveElement( _
    ByVal transformPattern As TransformPattern, _
    ByVal x As Double, ByVal y As Double)
        Try
            If transformPattern.Current.CanMove Then
                transformPattern.Move(x, y)
            End If
        Catch exc As InvalidOperationException
            ' object is not able to perform the requested action
            Return
        End Try

    End Sub 'MoveElement    
    ' </Snippet103>

    ' <Snippet104>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Calls the TransformPattern.Resize() method for an associated 
    ''' automation element.
    ''' </summary>
    ''' <param name="transformPattern">
    ''' The TransformPattern control pattern obtained from
    ''' an automation element.
    ''' </param>
    ''' <param name="width">
    ''' The requested width of the automation element.
    ''' </param>
    ''' <param name="height">
    ''' The requested height of the automation element.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ResizeElement( _
    ByVal transformPattern As TransformPattern, _
    ByVal width As Double, ByVal height As Double)
        Try
            If transformPattern.Current.CanResize Then
                transformPattern.Resize(width, height)
            End If
        Catch
            ' object is not able to perform the requested action
            Return
        End Try

    End Sub 'ResizeElement
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
            Dim app As New UIATransformPattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIATransformPattern_snippets