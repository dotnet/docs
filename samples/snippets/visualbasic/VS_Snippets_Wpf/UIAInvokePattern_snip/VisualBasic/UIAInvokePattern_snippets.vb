
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIAInvokePattern_snippets
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()

    End Sub 'New

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains an InvokePattern control pattern from a control
    ''' and calls the InvokePattern.Invoke() method on the control.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The control of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub InvokeControl(ByVal targetControl As AutomationElement) 
        Dim invokePattern As InvokePattern = Nothing
        
        Try
            invokePattern = _
            DirectCast(targetControl.GetCurrentPattern(invokePattern.Pattern), _
            InvokePattern)
        Catch e As ElementNotEnabledException
            ' Object is not enabled.
            Return
        Catch e As InvalidOperationException
            ' Object doesn't support the InvokePattern control pattern
            Return
        End Try
        
        invokePattern.Invoke()
    
    End Sub 'InvokeControl
    ' </Snippet101>
End Class 'UIAInvokePattern_snippets 