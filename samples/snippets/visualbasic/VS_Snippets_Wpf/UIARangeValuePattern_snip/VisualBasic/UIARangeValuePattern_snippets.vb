
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation
Imports System.IO
Imports System.Diagnostics



Class UIARangeValuePattern_snippets
    Private targetControl As AutomationElementCollection
    
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New() 
        Dim targetWindow As AutomationElement = StartTargetApp((System.Windows.Forms.Application.StartupPath + "\UIARangeValuePattern_snip_Target.exe"))
        targetControl = FindAutomationElement(targetWindow)
        
        Dim rangeValuePattern As RangeValuePattern = GetRangeValuePattern(targetControl(0))
        
        Dim d As Object = GetRangeValueProperty(rangeValuePattern, rangeValuePattern.LargeChangeProperty)
        
        ' <Snippet103SmallChange>
        SetRangeValue(targetControl(0), rangeValuePattern.Current.SmallChange, 1)
        ' </Snippet103SmallChange>
        ' <Snippet103LargeChange>
        SetRangeValue(targetControl(0), rangeValuePattern.Current.LargeChange, - 1)
        ' </Snippet103LargeChange>
        ' <Snippet104Minimum>
        SetRangeValue(targetControl(0), rangeValuePattern.Current.Minimum)
        ' </Snippet104Minimum>
        ' <Snippet104Maximum>
        SetRangeValue(targetControl(0), rangeValuePattern.Current.Maximum)

    End Sub 'New
     ' </Snippet104Maximum>
    
    
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Starts the target app containing controls of interest.
    ''' </summary>
    ''' <param name="target">
    ''' The filepath for the target executable.
    ''' </param>
    ''' <returns>
    ''' An automation element representing the target window.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function StartTargetApp( _
    ByVal target As String) As AutomationElement
        Dim p As Process = Process.Start(target)
        If p.WaitForInputIdle(5000) = False Then
            Return Nothing
        Else
            System.Windows.MessageBox.Show( _
            "Target ready for user interaction")
        End If

        ' Return the automation element
        Return AutomationElement.FromHandle(p.MainWindowHandle)

    End Function 'StartTargetApp


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
        RangeValuePattern.IsReadOnlyProperty, False)

        Return targetApp.FindAll(TreeScope.Descendants, conditionIsReadOnly)

    End Function 'FindAutomationElement
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a RangeValuePattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A RangeValuePattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetRangeValuePattern( _
    ByVal targetControl As AutomationElement) As RangeValuePattern
        Dim rangeValuePattern As RangeValuePattern = Nothing

        Try
            rangeValuePattern = DirectCast( _
            targetControl.GetCurrentPattern(rangeValuePattern.Pattern), _
            RangeValuePattern)
        Catch exc As InvalidOperationException
            ' Object doesn't support the 
            ' RangeValuePattern control pattern
            Return Nothing
        End Try

        Return rangeValuePattern

    End Function 'GetRangeValuePattern    
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Gets the current property values from target.
    ''' </summary>
    ''' <param name="rangeValuePattern">
    ''' A RangeValuePattern control pattern obtained from 
    ''' an automation element representing a target control.
    ''' </param>
    ''' <param name="automationProperty">
    ''' The automation property of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Function GetRangeValueProperty( _
    ByVal rangeValuePattern As RangeValuePattern, _
    ByVal automationProperty As AutomationProperty) As Object
        If (rangeValuePattern Is Nothing Or _
        automationProperty Is Nothing) Then
            Throw New ArgumentException("Argument cannot be null.")
        End If

        If automationProperty.Id = _
        rangeValuePattern.MinimumProperty.Id Then
            Return rangeValuePattern.Current.Minimum
        End If
        If automationProperty.Id = _
        rangeValuePattern.MaximumProperty.Id Then
            Return rangeValuePattern.Current.Maximum
        End If
        If automationProperty.Id = _
        rangeValuePattern.SmallChangeProperty.Id Then
            Return rangeValuePattern.Current.SmallChange
        End If
        If automationProperty.Id = _
        rangeValuePattern.LargeChangeProperty.Id Then
            Return rangeValuePattern.Current.LargeChange
        End If
        If automationProperty.Id = _
        rangeValuePattern.ValueProperty.Id Then
            Return rangeValuePattern.Current.Value
        End If
        Return Nothing

    End Function 'GetRangeValueProperty    
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Sets the range value of the control of interest.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <param name="rangeValue">
    ''' The value (either relative or absolute) to set the control to.
    ''' </param>
    ''' <param name="rangeDirection">
    ''' The value used to specify the direction of adjustment.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Overloads Sub SetRangeValue( _
    ByVal targetControl As AutomationElement, _
    ByVal rangeValue As Double, ByVal rangeDirection As Double)
        If targetControl Is Nothing OrElse _
        rangeValue = 0 OrElse rangeDirection = 0 Then
            Throw New ArgumentException("Argument cannot be null or zero.")
        End If

        Dim rangeValuePattern As RangeValuePattern = _
        GetRangeValuePattern(targetControl)

        If rangeValuePattern.Current.IsReadOnly Then
            Throw New InvalidOperationException("Control is read-only.")
        End If

        rangeValue = rangeValue * Math.Sign(rangeDirection)

        Try
            If rangeValue <= rangeValuePattern.Current.Maximum OrElse _
            rangeValue >= rangeValuePattern.Current.Minimum Then
                rangeValuePattern.SetValue(rangeValue)
            End If
        Catch exc As ArgumentOutOfRangeException
            ' TO DO: Error handling.
        Catch exc As ArgumentException
            ' TO DO: Error handling.
        End Try

    End Sub 'SetRangeValue
    ' </Snippet103>

    ' <Snippet104>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Sets the range value of the control of interest.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <param name="rangeValue">
    ''' The value (either relative or absolute) to set the control to.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Overloads Sub SetRangeValue( _
    ByVal targetControl As AutomationElement, ByVal rangeValue As Double)
        If targetControl Is Nothing Then
            Throw New ArgumentException("Argument cannot be null.")
        End If

        Dim rangeValuePattern As RangeValuePattern = _
        GetRangeValuePattern(targetControl)

        If rangeValuePattern.Current.IsReadOnly Then
            Throw New InvalidOperationException("Control is read-only.")
        End If

        Try
            rangeValuePattern.SetValue(rangeValue)
        Catch exc As ArgumentOutOfRangeException
            ' TO DO: Error handling.
        Catch exc As ArgumentException
            ' TO DO: Error handling.
        End Try

    End Sub 'SetRangeValue 
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
            Dim app As New UIARangeValuePattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIARangeValuePattern_snippets 