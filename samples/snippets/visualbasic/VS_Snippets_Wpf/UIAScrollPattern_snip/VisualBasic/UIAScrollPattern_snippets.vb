
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class UIAScrollPattern_snippets
    
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

        Dim conditionSupportsScroll As New PropertyCondition( _
        AutomationElement.IsScrollPatternAvailableProperty, True)

        Dim conditionHorizontallyScrollable As New PropertyCondition( _
        ScrollPattern.HorizontallyScrollableProperty, True)

        Dim conditionVerticallyScrollable As New PropertyCondition( _
        ScrollPattern.VerticallyScrollableProperty, True)

        ' Use any combination of the preceding conditions to 
        ' find the control(s) of interest
        Dim condition As AndCondition = New AndCondition( _
        conditionSupportsScroll, _
        conditionHorizontallyScrollable, _
        conditionVerticallyScrollable)

        Return targetApp.FindAll(TreeScope.Descendants, condition)

    End Function 'FindAutomationElement
    ' </Snippet100>

    ' <Snippet101>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ScrollPattern control pattern from an 
    ''' automation element.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' A ScrollPattern object.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetScrollPattern( _
    ByVal targetControl As AutomationElement) As ScrollPattern
        Dim scrollPattern As ScrollPattern = Nothing

        Try
            scrollPattern = DirectCast( _
            targetControl.GetCurrentPattern(scrollPattern.Pattern), _
            ScrollPattern)
        Catch
            ' Object doesn't support the ScrollPattern control pattern
            Return Nothing
        End Try

        Return scrollPattern

    End Function 'GetScrollPattern
    ' </Snippet101>

    ' <Snippet102>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ScrollPattern control pattern from an automation 
    ''' element and attempts to scroll to the top left 'home' position.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ScrollHome(ByVal targetControl As AutomationElement) 
        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If
        
        Dim scrollPattern As ScrollPattern = _
        GetScrollPattern(targetControl)
        
        If scrollPattern Is Nothing Then
            Return
        End If
        
        Try
            scrollPattern.SetScrollPercent(0, 0)
        Catch exc As InvalidOperationException
            ' Control not able to scroll in the direction requested;
            ' when scrollable property of that direction is False
            ' TO DO: error handling.
        Catch exc As ArgumentOutOfRangeException
            ' A value greater than 100 or less than 0 is passed in 
            ' (except -1 which is equivalent to NoScroll).
            ' TO DO: error handling.
        End Try

    End Sub 'ScrollHome
    ' </Snippet102>

    ' <Snippet103>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ScrollPattern control pattern from an automation 
    ''' element and attempts to scroll to the top of the
    ''' viewfinder.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ScrollToTop(ByVal targetControl As AutomationElement) 
        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If
        
        Dim scrollPattern As ScrollPattern = GetScrollPattern(targetControl)
        
        Try
            scrollPattern.SetScrollPercent(ScrollPattern.NoScroll, 0)
        Catch exc As InvalidOperationException
            ' Control not able to scroll in the direction requested;
            ' when scrollable property of that direction is False
            ' TO DO: error handling.
        Catch exc As ArgumentOutOfRangeException
            ' A value greater than 100 or less than 0 is passed in 
            ' (except -1 which is equivalent to NoScroll).
            ' TO DO: error handling.
        End Try

    End Sub 'ScrollToTop
    ' </Snippet103>

    ' <Snippet104>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains the current scroll positions of the viewable region 
    ''' within the content area.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' The horizontal and vertical scroll percentages.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetScrollPercentages( _
    ByVal targetControl As AutomationElement) As Double()
        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If

        Dim percentage(1) As Double

        percentage(0) = System.Convert.ToDouble( _
        targetControl.GetCurrentPropertyValue( _
        ScrollPattern.HorizontalScrollPercentProperty))

        percentage(1) = System.Convert.ToDouble( _
        targetControl.GetCurrentPropertyValue( _
        ScrollPattern.VerticalScrollPercentProperty))

        Return percentage

    End Function 'GetScrollPercentages    
    ' </Snippet104>

    ' <Snippet1045>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains the current scroll positions of the viewable region 
    ''' within the content area.
    ''' </summary>
    ''' <param name="scrollPattern">
    ''' The ScrollPattern control pattern obtained from the 
    ''' element of interest.
    ''' </param>
    ''' <returns>
    ''' The horizontal and vertical scroll percentages.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Function GetScrollPercentagesFromPattern( _
    ByVal scrollPattern As ScrollPattern) As Double()
        If scrollPattern Is Nothing Then
            Throw New ArgumentNullException( _
            "ScrollPattern argument cannot be null.")
        End If

        Dim percentage(1) As Double

        percentage(0) = scrollPattern.Current.HorizontalScrollPercent

        percentage(1) = scrollPattern.Current.VerticalScrollPercent

        Return percentage

    End Function 'GetScrollPercentagesFromPattern
    ' </Snippet1045>

    ' <Snippet105>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains the current vertical and horizontal sizes of the viewable  
    ''' region as percentages of the total content area.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <returns>
    ''' The horizontal and vertical view sizes.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Overloads Function GetViewSizes( _
    ByVal targetControl As AutomationElement) As Double()
        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If

        Dim viewSizes(1) As Double

        viewSizes(0) = System.Convert.ToDouble( _
        targetControl.GetCurrentPropertyValue( _
        ScrollPattern.HorizontalViewSizeProperty))

        viewSizes(1) = System.Convert.ToDouble( _
        targetControl.GetCurrentPropertyValue( _
        ScrollPattern.VerticalViewSizeProperty))

        Return viewSizes

    End Function 'GetViewSizes
    ' </Snippet105>

    ' <Snippet1055>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains the current vertical and horizontal sizes of the viewable  
    ''' region as percentages of the total content area.
    ''' </summary>
    ''' <param name="scrollPattern">
    ''' The ScrollPattern control pattern obtained from the 
    ''' element of interest.
    ''' </param>
    ''' <returns>
    ''' The horizontal and vertical view sizes.
    ''' </returns>
    '''--------------------------------------------------------------------
    Private Overloads Function GetViewSizes( _
    ByVal scrollPattern As ScrollPattern) As Double()
        If scrollPattern Is Nothing Then
            Throw New ArgumentNullException( _
            "ScrollPattern argument cannot be null.")
        End If

        Dim viewSizes(1) As Double

        viewSizes(0) = scrollPattern.Current.HorizontalViewSize

        viewSizes(1) = scrollPattern.Current.VerticalViewSize

        Return viewSizes

    End Function 'GetViewSizes    
    ' </Snippet1055>

    ' <Snippet106>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ScrollPattern control pattern from an automation 
    ''' element and attempts to scroll the requested amounts.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <param name="hScrollAmount">
    ''' The requested horizontal scroll amount.
    ''' </param>
    ''' <param name="vScrollAmount">
    ''' The requested vertical scroll amount.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ScrollElement( _
    ByVal targetControl As AutomationElement, _
    ByVal hScrollAmount As ScrollAmount, _
    ByVal vScrollAmount As ScrollAmount)
        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If

        Dim scrollPattern As ScrollPattern = GetScrollPattern(targetControl)

        If scrollPattern Is Nothing Then
            Return
        End If

        Try
            scrollPattern.Scroll(hScrollAmount, vScrollAmount)
        Catch exc As InvalidOperationException
            ' Control not able to scroll in the direction requested;
            ' when scrollable property of that direction is False
            ' TO DO: error handling.
        Catch exc As ArgumentException
            ' If a control supports SmallIncrement values exclusively 
            ' for horizontal or vertical scrolling but a LargeIncrement 
            ' value (NaN if not supported) is passed in.
            ' TO DO: error handling.
        End Try

    End Sub 'ScrollElement
    ' </Snippet106>
    ' <Snippet107>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ScrollPattern control pattern from an automation 
    ''' element and attempts to horizontally scroll the requested amount.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <param name="hScrollAmount">
    ''' The requested horizontal scroll amount.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ScrollElementHorizontally( _
    ByVal targetControl As AutomationElement, _
    ByVal hScrollAmount As ScrollAmount)
        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If

        Dim scrollPattern As ScrollPattern = GetScrollPattern(targetControl)

        If scrollPattern Is Nothing Then
            Return
        End If

        If Not scrollPattern.Current.HorizontallyScrollable Then
            Return
        End If

        Try
            scrollPattern.ScrollHorizontal(hScrollAmount)
        Catch exc As InvalidOperationException
            ' Control not able to scroll in the direction requested;
            ' when scrollable property of that direction is False
            ' TO DO: error handling.
        Catch exc As ArgumentException
            ' If a control supports SmallIncrement values exclusively 
            ' for horizontal or vertical scrolling but a LargeIncrement 
            ' value (NaN if not supported) is passed in.
            ' TO DO: error handling.
        End Try

    End Sub 'ScrollElementHorizontally
    ' </Snippet107>

    ' <Snippet108>
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Obtains a ScrollPattern control pattern from an automation 
    ''' element and attempts to horizontally scroll the requested amount.
    ''' </summary>
    ''' <param name="targetControl">
    ''' The automation element of interest.
    ''' </param>
    ''' <param name="vScrollAmount">
    ''' The requested vertical scroll amount.
    ''' </param>
    '''--------------------------------------------------------------------
    Private Sub ScrollElementVertically( _
    ByVal targetControl As AutomationElement, _
    ByVal vScrollAmount As ScrollAmount)
        If targetControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement argument cannot be null.")
        End If

        Dim scrollPattern As ScrollPattern = GetScrollPattern(targetControl)

        If scrollPattern Is Nothing Then
            Return
        End If

        If Not scrollPattern.Current.VerticallyScrollable Then
            Return
        End If

        Try
            scrollPattern.ScrollVertical(vScrollAmount)
        Catch exc As InvalidOperationException
            ' Control not able to scroll in the direction requested;
            ' when scrollable property of that direction is False
            ' TO DO: error handling.
        Catch exc As ArgumentException
            ' If a control supports SmallIncrement values exclusively 
            ' for horizontal or vertical scrolling but a LargeIncrement 
            ' value (NaN if not supported) is passed in.
            ' TO DO: error handling.
        End Try

    End Sub 'ScrollElementVertically 
    ' </Snippet108>

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
            Dim app As New UIAScrollPattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIAScrollPattern_snippets