
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation
Imports System.Diagnostics



Class UIAMultipleViewPattern_snippets
    Private targetControl As AutomationElementCollection
    
    
    '/ <summary>
    '/ Constructor.
    '/ </summary>
    Public Sub New() 
        Dim targetWindow As AutomationElement = StartTargetApp((System.Windows.Forms.Application.StartupPath + "\MultipleViewPattern_snip_Target.exe"))
        
        targetWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, New PropertyCondition(AutomationElement.NameProperty, "C:\Documents and Settings\kbridge\Desktop\UISpy"))
        targetControl = FindAutomationElement(targetWindow)
        
        Dim multipleViewPattern As MultipleViewPattern = GetMultipleViewPattern(targetControl(0))
        
        Dim i As Integer = GetCurrentViewProperty(targetControl(0))
    
    End Sub 'New
     
    
    ' <Snippet100>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Finds all automation elements that satisfy 
    '/ the specified condition(s).
    '/ </summary>
    '/ <param name="targetApp">
    '/ The automation element from which to start searching.
    '/ </param>
    '/ <returns>
    '/ A collection of automation elements satisfying 
    '/ the specified condition(s).
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function FindAutomationElement( _
    ByVal targetApp As AutomationElement) As AutomationElementCollection
        If targetApp Is Nothing Then
            Throw New ArgumentException("Root element cannot be null.")
        End If

        Dim conditionSupportsMultipleView As New PropertyCondition( _
        AutomationElement.IsMultipleViewPatternAvailableProperty, True)

        Return targetApp.FindAll( _
        TreeScope.Descendants, conditionSupportsMultipleView)

    End Function 'FindAutomationElement    
    ' </Snippet100>

    ' <Snippet101>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Obtains a MultipleViewPattern control pattern from an 
    '/ automation element.
    '/ </summary>
    '/ <param name="targetControl">
    '/ The automation element of interest.
    '/ </param>
    '/ <returns>
    '/ A MultipleViewPattern object.
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function GetMultipleViewPattern( _
    ByVal targetControl As AutomationElement) As MultipleViewPattern
        Dim multipleViewPattern As MultipleViewPattern = Nothing

        Try
            multipleViewPattern = DirectCast( _
            targetControl.GetCurrentPattern(multipleViewPattern.Pattern), _
            MultipleViewPattern)
        Catch exc As InvalidOperationException
            'Object doesn't support the MultipleViewPattern control pattern
            Return Nothing
        End Try

        Return multipleViewPattern
    End Function 'GetMultipleViewPattern    
    ' </Snippet101>

    ' <Snippet102>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Gets the collection of currently supported views from a target.
    '/ </summary>
    '/ <param name="multipleViewControl">
    '/ The current multiple view control.
    '/ </param>
    '/ <returns>
    '/ A collection of identifiers representing the supported views.
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function GetSupportedViewsFromPattern( _
    ByVal multipleViewControl As AutomationElement) As Integer()
        If multipleViewControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement parameter must not be null.")
        End If

        Return DirectCast(multipleViewControl.GetCurrentPropertyValue( _
        MultipleViewPattern.SupportedViewsProperty), Integer())
    End Function 'GetSupportedViewsProperty
    ' </Snippet102>

    ' <Snippet1025>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Gets the collection of currently supported views from a target.
    '/ </summary>
    '/ <param name="multipleViewPattern">
    '/ The MultipleViewPattern obtained from a multiple view control.
    '/ </param>
    '/ <returns>
    '/ A collection of identifiers representing the supported views.
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function GetSupportedViewsFromControl( _
    ByVal multipleViewPattern As MultipleViewPattern) As Integer()
        If multipleViewPattern Is Nothing Then
            Throw New ArgumentNullException( _
            "MultipleViewPattern parameter must not be null.")
        End If

        Return multipleViewPattern.Current.GetSupportedViews()

    End Function 'GetSupportedViewsFromControl    
    ' </Snippet1025>

    ' <Snippet103>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Gets the current view identifier from a target.
    '/ </summary>
    '/ <param name="multipleViewControl">
    '/ The current multiple view control.
    '/ </param>
    '/ <returns>
    '/ The current view identifier.
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function GetCurrentViewProperty( _
    ByVal multipleViewControl As AutomationElement) As Integer
        If multipleViewControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement parameter must not be null.")
        End If

        Return Fix(multipleViewControl.GetCurrentPropertyValue( _
        MultipleViewPattern.CurrentViewProperty))

    End Function 'GetCurrentViewProperty    
    ' </Snippet103>

    ' <Snippet1035>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Gets the current view identifier from a target.
    '/ </summary>
    '/ <param name="multipleViewPattern">
    '/ The control pattern of interest.
    '/ </param>
    '/ <returns>
    '/ The current view identifier.
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function GetCurrentViewFromPattern( _
    ByVal multipleViewPattern As MultipleViewPattern) As Integer
        If multipleViewPattern Is Nothing Then
            Throw New ArgumentNullException( _
            "MultipleViewPattern parameter must not be null.")
        End If

        Return multipleViewPattern.Current.CurrentView

    End Function 'GetCurrentViewFromPattern    
    ' </Snippet1035>

    ' <Snippet104>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Sets the current view of a target.
    '/ </summary>
    '/ <param name="multipleViewControl">
    '/ The current multiple view control.
    '/ </param>
    '/ <param name="viewID">
    '/ The view identifier from the supported views collection.
    '/ </param>
    '/--------------------------------------------------------------------
    Private Sub SetView( _
    ByVal multipleViewControl As AutomationElement, _
    ByVal viewID As Integer)
        If multipleViewControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement parameter must not be null.")
        End If

        ' Get a MultipleViewPattern from the current control.
        Dim multipleViewPattern As MultipleViewPattern = _
        GetMultipleViewPattern(multipleViewControl)

        If Not (multipleViewPattern Is Nothing) Then
            Try
                multipleViewPattern.SetCurrentView(viewID)
            Catch exc As ArgumentException
                ' viewID is not a member of the supported views collection
                ' TO DO: error handling
            End Try
        End If
    End Sub 'SetView    
    ' </Snippet104>

    ' <Snippet105>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Gets the name of the current view of a target.
    '/ </summary>
    '/ <param name="multipleViewControl">
    '/ The current multiple view control.
    '/ </param>
    '/ <returns>
    '/ The current view name.
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function ViewName( _
    ByVal multipleViewControl As AutomationElement) As String
        If multipleViewControl Is Nothing Then
            Throw New ArgumentNullException( _
            "AutomationElement parameter must not be null.")
        End If

        If Not (multipleViewControl Is Nothing) Then
            Try
                ' Get a MultipleViewPattern from the current control.
                Dim multipleViewPattern As MultipleViewPattern = _
                GetMultipleViewPattern(multipleViewControl)
                Dim viewID As Integer = _
                DirectCast(multipleViewControl.GetCurrentPropertyValue( _
                multipleViewPattern.CurrentViewProperty), Integer)
                Return multipleViewPattern.GetViewName(viewID)
            Catch exc As ArgumentException
                ' TO DO: error handling
            End Try
        End If
        Return Nothing
    End Function 'ViewName
    
    ' </Snippet105>
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ Starts the target app containing controls of interest.
    '/ </summary>
    '/ <param name="target">
    '/ The filepath for the target executable.
    '/ </param>
    '/ <returns>
    '/ An automation element representing the target window.
    '/ </returns>
    '/--------------------------------------------------------------------
    Private Function StartTargetApp( _
    ByVal target As String) As AutomationElement
        Dim p As Process = Process.Start(target)
        If p.WaitForInputIdle(50000) = False Then
            Return Nothing
        Else
            System.Windows.MessageBox.Show( _
            "Target ready for user interaction")
        End If

        ' Return the automation element
        Return AutomationElement.FromHandle(p.MainWindowHandle)

    End Function 'StartTargetApp
    
    '/--------------------------------------------------------------------
    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    '/--------------------------------------------------------------------
    
    NotInheritable Friend Class TestMain
        
        <STAThread()>  _
        Shared Sub Main() 
            ' Create an instance of the sample class 
            ' and call its Run() method to start it.
            Dim app As New UIAMultipleViewPattern_snippets()
        
        End Sub 'Main
    End Class 'TestMain
End Class 'UIAMultipleViewPattern_snippets