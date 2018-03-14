
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIAValuePattern_snippets
    
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

        Dim conditionIsReadOnly As New PropertyCondition( _
        ValuePattern.IsReadOnlyProperty, False)

        Return targetApp.FindAll(TreeScope.Descendants, conditionIsReadOnly)

    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ValuePattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A ValuePattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetValuePattern( _
    ByVal targetControl As AutomationElement) As ValuePattern
        Dim valuePattern As ValuePattern = Nothing

        Try
            valuePattern = DirectCast( _
            targetControl.GetCurrentPattern(valuePattern.Pattern), _
            ValuePattern)
        Catch
            Return Nothing
        End Try

        Return valuePattern

    End Function 'GetValuePattern
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the current property values from target.
    ''' </summary>
    ''' <param name="valuePattern">
    ''' A ValuePattern control pattern obtained from 
    ''' an automation element representing a target control.
    ''' </param>
    ''' <param name="automationProperty">
    ''' The automation property of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Function GetValueProperty( _
    ByVal valuePattern As ValuePattern, _
    ByVal automationProperty As AutomationProperty) As Object
        If (valuePattern Is Nothing Or automationProperty Is Nothing) Then
            Throw New ArgumentNullException("Argument cannot be null.")
        End If

        If automationProperty.Id = valuePattern.ValueProperty.Id Then
            Return valuePattern.Current.Value
        End If
        Return Nothing

    End Function 'GetValueProperty    
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Inserts a string into a text control that supports ValuePattern.
    ''' </summary>
    ''' <param name="targetControl">A text control.</param>
    ''' <param name="value">The string to be inserted.</param>
    '''--------------------------------------------------------------------
    Private Sub InsertText(ByVal targetControl As AutomationElement, _
    ByVal value As String)
        ' Validate arguments / initial setup
        If value Is Nothing Then
            Throw New ArgumentNullException( _
            "String parameter must not be null.")
        End If

        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement parameter must not be null")
        End If

        ' A series of basic checks prior to attempting an insertion.
        '
        ' Check #1: Is control enabled?
        ' An alternative to testing for static or read-only controls 
        ' is to filter using 
        ' PropertyCondition(AutomationElement.IsEnabledProperty, true) 
        ' and exclude all read-only text controls from the collection.
        If Not targetControl.Current.IsEnabled Then
            Throw New InvalidOperationException( _
            "The control is not enabled." + vbLf + vbLf)
        End If

        ' Check #2: Are there styles that prohibit us 
        '           from sending text to this control?
        If Not targetControl.Current.IsKeyboardFocusable Then
            Throw New InvalidOperationException( _
            "The control is not focusable." + vbLf + vbLf)
        End If

        ' Once you have an instance of an AutomationElement,  
        ' check if it supports the ValuePattern pattern.
        Dim valuePattern As Object = Nothing

        If Not targetControl.TryGetCurrentPattern( _
        valuePattern.Pattern, valuePattern) Then
            ' Elements that support TextPattern 
            ' do not support ValuePattern and TextPattern
            ' does not support setting the text of 
            ' multi-line edit or document controls.
            ' For this reason, text input must be simulated.
            ' Control supports the ValuePattern pattern so we can 
            ' use the SetValue method to insert content.
        Else
            If CType(valuePattern, ValuePattern).Current.IsReadOnly Then
                Throw New InvalidOperationException("The control is read-only.")
            Else
                CType(valuePattern, ValuePattern).SetValue(value)
            End If
        End If

    End Sub 'InsertText
    '</Snippet103>



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
            Dim app As New UIAValuePattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIAValuePattern_snippets