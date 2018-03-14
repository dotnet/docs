
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation



Class PropertySnips
    
    'AutomationElement autoElement;
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()

    End Sub 'New

    ' <Snippet172> 

    Dim propChangeHandler As AutomationPropertyChangedEventHandler

    ''' <summary>
    ''' Adds a handler for property-changed event; in particular, a change in the enabled state.
    ''' </summary>
    ''' <param name="element">The UI Automation element whose state is being monitored.</param>
    Public Sub SubscribePropertyChange(ByVal element As AutomationElement)
        propChangeHandler = _
            New AutomationPropertyChangedEventHandler(AddressOf OnPropertyChange)
        Automation.AddAutomationPropertyChangedEventHandler(element, TreeScope.Element, _
            propChangeHandler, AutomationElement.IsEnabledProperty)

    End Sub 'SubscribePropertyChange



    ''' <summary>
    ''' Handler for property changes.
    ''' </summary>
    ''' <param name="src">The source whose properties changed.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub OnPropertyChange(ByVal src As Object, ByVal e As AutomationPropertyChangedEventArgs) 
        Dim sourceElement As AutomationElement = DirectCast(src, AutomationElement)
        If e.Property Is AutomationElement.IsEnabledProperty Then
            Dim enabled As Boolean = CBool(e.NewValue)
            ' TODO: Do something with the new value. 
            ' The element that raised the event can be identified by its runtime ID property.
        Else
        End If
     ' TODO: Handle other property-changed events.
    End Sub 'OnPropertyChange
    
    
    Public Sub UnsubscribePropertyChange(ByVal element As AutomationElement)
        If (propChangeHandler IsNot Nothing) Then
            Automation.RemoveAutomationPropertyChangedEventHandler(element, propChangeHandler)
        End If

    End Sub 'UnsubscribePropertyChange
    
    ' </Snippet172>
    Public Sub GetAllProperties(ByVal autoElement As AutomationElement) 
        
        ' *** AcceleratorKeyProperty
        ' <Snippet124>
        Dim acceleratorKey As String = _
            CStr(autoElement.GetCurrentPropertyValue(AutomationElement.AcceleratorKeyProperty))
        ' </Snippet124>

        ' <Snippet125>
        Dim acceleratorKeyString As String
        Dim acceleratorKeyNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.AcceleratorKeyProperty, True)
        If acceleratorKeyNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            acceleratorKeyString = CStr(acceleratorKeyNoDefault)
        End If
        ' </Snippet125>
        
        ' *** AccessKeyProperty
        ' <Snippet127>
        Dim accessKey As String = _
            CStr(autoElement.GetCurrentPropertyValue(AutomationElement.AccessKeyProperty))
        ' </Snippet127>

        ' <Snippet128>
        Dim accessKeyString As String
        Dim accessKeyNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.AccessKeyProperty, True)
        If accessKeyNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            accessKeyString = CStr(accessKeyNoDefault)
        End If

        ' </Snippet128>

        ' *** AutomationIdProperty

        ' <Snippet129>
        Dim autoId As String = _
            CStr(autoElement.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty))
        ' </Snippet129>

        ' <Snippet130>
        Dim autoIdString As String
        Dim autoIdNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, True)
        If autoIdNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            autoIdString = CStr(autoIdNoDefault)
        End If
        ' </Snippet130>

        ' *** BoundingRectangleProperty. Default is Rect.Empty.

        ' <Snippet131>
        Dim boundingRect As System.Windows.Rect = CType(autoElement.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty), System.Windows.Rect)
        ' </Snippet131>

        ' <Snippet132>
        Dim boundingRect1 As System.Windows.Rect
        Dim boundingRectNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.BoundingRectangleProperty, True)
        If boundingRectNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            boundingRect1 = DirectCast(boundingRectNoDefault, System.Windows.Rect)
        End If
        ' </Snippet132>

        ' *** ClassNameProperty

        ' <Snippet133>
        Dim className As Object = autoElement.GetCurrentPropertyValue(AutomationElement.ClassNameProperty)
        ' </Snippet133>

        ' <Snippet134>
        Dim classNameString As String
        Dim classNameNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.ClassNameProperty, True)
        If classNameNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            classNameString = CStr(classNameNoDefault)
        End If
        ' </Snippet134>

        ' *** ClickablePointProperty. 

        ' <Snippet135>
        Dim clickablePoint As New System.Windows.Point(- 1, - 1)
        Dim prop As Object = autoElement.GetCurrentPropertyValue(AutomationElement.ClickablePointProperty)
        ' Do not attempt to cast prop if it is null.
        If TypeOf prop Is System.Windows.Point Then
            clickablePoint = DirectCast(prop, System.Windows.Point)
        End If
        ' </Snippet135>

        ' <Snippet166>
        Dim clickablePoint1 As System.Windows.Point
        Dim clickablePointNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.ClickablePointProperty, True)
        If clickablePointNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            clickablePoint1 = DirectCast(clickablePointNoDefault, System.Windows.Point)
        End If
        ' </Snippet166>

        ' *** ControlTypeProperty

        ' <Snippet136>
        Dim controlTypeId As ControlType = _
          DirectCast(autoElement.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty), ControlType)
        ' </Snippet136>

        ' <Snippet137>
        Dim controlTypeId1 As ControlType
        Dim controlTypeNoDefault As Object = _
            autoElement.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty, True)
        If controlTypeNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            controlTypeId1 = DirectCast(controlTypeNoDefault, ControlType)
        End If
        ' </Snippet137>
        
        ' *** CultureInfoProperty
        ' <Snippet138>
        Dim culture As System.Globalization.CultureInfo = _
            DirectCast(autoElement.GetCurrentPropertyValue(AutomationElement.CultureProperty), _
            System.Globalization.CultureInfo)
        ' </Snippet138>

        ' *** FrameworkIdProperty

        ' <Snippet139>
        Dim frameworkId As String = _
            CStr(autoElement.GetCurrentPropertyValue(AutomationElement.FrameworkIdProperty))
        ' </Snippet139>
        
        ' *** HasKeyboardFocusProperty
        ' <Snippet140>
        Dim hasFocus As Boolean = CBool(autoElement.GetCurrentPropertyValue(AutomationElement.HasKeyboardFocusProperty))
        ' </Snippet140>
        
        ' *** IsContentElementProperty
        ' <Snippet141>
        Dim isContent As Boolean = CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsContentElementProperty))
        ' </Snippet141>

        ' <Snippet142>
        Dim isContent1 As Boolean
        Dim isContentNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.IsContentElementProperty, True)
        If isContentNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            isContent1 = CBool(isContentNoDefault)
        End If
        ' </Snippet142>

        ' *** IsControlElementProperty

        ' <Snippet143>
        Dim isControl As Boolean = CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsControlElementProperty))
        ' </Snippet143>

        ' <Snippet144>
        Dim isControl1 As Boolean
        Dim isControlNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.IsControlElementProperty, True)
        If isControlNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            isControl1 = CBool(isControlNoDefault)
        End If
        ' </Snippet144>
        
        ' *** IsXXXPatternAvailableProperty

        ' <Snippet145>
        ' TODO  Substitute the appropriate field for IsDockPatternAvailableProperty.
        Dim isPatternAvailable As Boolean = _
            CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsDockPatternAvailableProperty))
        ' </Snippet145>
        
        ' *** IsEnabledProperty

        ' <Snippet146>
        Dim isControlEnabled As Boolean = _
            CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty))
        ' </Snippet146>
        
        ' *** IsKeyboardFocusableProperty

        ' <Snippet147>
        Dim isControlFocusable As Boolean = _
            CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsKeyboardFocusableProperty))
        ' </Snippet147>

        ' *** IsOffscreenProperty

        ' <Snippet148>
        Dim isControlOffscreen As Boolean = _
            CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsOffscreenProperty))
        ' </Snippet148>
        
        ' <Snippet149>
        Dim isControlOffscreen1 As Boolean
        Dim isOffscreenNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.IsOffscreenProperty, True)
        If isOffscreenNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            isControlOffscreen1 = CBool(isOffscreenNoDefault)
        End If
        ' </Snippet149>
        
        ' *** IsPasswordProperty

        ' <Snippet150>
        Dim isTextPassword As Boolean = CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsPasswordProperty))
        ' </Snippet150>
        
        ' *** IsRequiredForFormProperty

        ' <Snippet151> 
        Dim isRequired As Boolean = _
            CBool(autoElement.GetCurrentPropertyValue(AutomationElement.IsRequiredForFormProperty))
        ' </Snippet151>

        ' *** ItemStatusProperty

        ' <Snippet152>
        Dim itemStatus As String = _
            CStr(autoElement.GetCurrentPropertyValue(AutomationElement.ItemStatusProperty))
        ' </Snippet152>

        ' <Snippet153>
        Dim itemStatus1 As String
        Dim itemStatusNoDefault As Object = _
            autoElement.GetCurrentPropertyValue(AutomationElement.ItemStatusProperty, True)
        If itemStatusNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            itemStatus1 = CStr(itemStatusNoDefault)
        End If
        ' </Snippet153>
        
        ' *** ItemTypeProperty
        ' <Snippet154>
        Dim itemType As String = _
            CStr(autoElement.GetCurrentPropertyValue(AutomationElement.ItemTypeProperty))
        ' </Snippet154>

        ' <Snippet155>
        Dim itemType1 As String
        Dim itemTypeNoDefault As Object = _
            autoElement.GetCurrentPropertyValue(AutomationElement.ItemTypeProperty, True)
        If itemTypeNoDefault Is AutomationElement.NotSupported Then
            itemType1 = "Unknown type"
        Else
            itemType1 = CStr(itemStatusNoDefault)
        End If
        ' </Snippet155>
        
        ' *** LabeledByProperty
        ' <Snippet156>
        Dim labeler As AutomationElement = _
            DirectCast(autoElement.GetCurrentPropertyValue(AutomationElement.LabeledByProperty), _
            AutomationElement)
        ' </Snippet156>

        ' <Snippet157>
        Dim labeler1 As AutomationElement
        Dim labelerNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.LabeledByProperty, True)
        If labelerNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            labeler1 = DirectCast(labelerNoDefault, AutomationElement)
        End If
        ' </Snippet157>
        
        ' *** LocalizedControlTypeProperty
        ' <Snippet158>
        Dim localizedType As String = _
            Cstr(autoElement.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty))
        ' </Snippet158>

        ' <Snippet159>
        Dim localizedType1 As String
        Dim localizedTypeNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty, True)
        If localizedTypeNoDefault Is AutomationElement.NotSupported Then
            localizedType1 = "Unknown type."
        Else
            localizedType1 = CStr(localizedTypeNoDefault)
        End If
        ' </Snippet159>

        ' *** NameProperty

        ' <Snippet160>
        Dim nameProp As String = _
            CStr(autoElement.GetCurrentPropertyValue(AutomationElement.NameProperty))
        ' </Snippet160>

        ' <Snippet161>
        Dim nameProp1 As String
        Dim namePropNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.NameProperty, True)
        If namePropNoDefault Is AutomationElement.NotSupported Then
            nameProp1 = "No name."
        Else
            nameProp1 = CStr(namePropNoDefault)
        End If
        ' </Snippet161>
        
        ' *** NativeWindowHandleProperty

        ' <Snippet162>
        Dim nativeHandle As Integer = _
            CInt(autoElement.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty))
        ' </Snippet162>

        ' <Snippet163>
        Dim nativeHandle1 As Integer
        Dim nativeHandleNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty, True)
        If nativeHandleNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            nativeHandle1 = CInt(nativeHandleNoDefault)
        End If
        ' </Snippet163>
        
        
        ' *** OrientationProperty
        ' <Snippet164>
        Dim orientationType As OrientationType = _
            DirectCast(autoElement.GetCurrentPropertyValue(AutomationElement.OrientationProperty), _
            OrientationType)
        ' </Snippet164>

        ' <Snippet165>
        Dim orientationType1 As OrientationType
        Dim orientationTypeNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.OrientationProperty, True)
        If orientationTypeNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            orientationType1 = DirectCast(orientationTypeNoDefault, OrientationType)
        End If
        ' </Snippet165>
        
        ' *** ProcessIdProperty

        ' <Snippet167>
        Dim processIdentifier As Integer = _
            CInt(autoElement.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty))
        ' </Snippet167>

        ' <Snippet168>
        Dim processIdentifier1 As Integer
        Dim processIdentifierNoDefault As Object = autoElement.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty, True)
        If processIdentifierNoDefault Is AutomationElement.NotSupported Then
            ' TODO Handle the case where you do not wish to proceed using the default value.
        Else
            processIdentifier1 = CInt(processIdentifierNoDefault)
        End If
        ' </Snippet168>
        
        ' *** RuntimeIdProperty
        ' <Snippet169>
        Dim runtimeIdentifier As Integer() = _
            CType(autoElement.GetCurrentPropertyValue(AutomationElement.RuntimeIdProperty), Integer())
        ' </Snippet169>    
    End Sub 'GetAllProperties
End Class 'PropertySnips 

' <Snippet999>
'  To be written.
' </Snippet999>