
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Input.StylusPlugIns
Imports System.Windows.Media
Imports System.Windows
Imports System.Windows.Input
Imports System.Diagnostics
Imports System.Windows.Threading



'<Snippet19>
Delegate Sub WorkerMethod()

Class CustomDynamicRenderer
    Inherits DynamicRenderer

    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput)

        MyBase.OnStylusDown(rawStylusInput)
        rawStylusInput.NotifyWhenProcessed(Nothing)

    End Sub 'OnStylusDown


    Protected Overrides Sub OnStylusDownProcessed(ByVal callbackData As Object, ByVal targetVerified As Boolean)

        MyBase.OnStylusDownProcessed(callbackData, targetVerified)

        Dim renderingThreadDispatcher As Dispatcher = Me.GetDispatcher()
        renderingThreadDispatcher.BeginInvoke(DispatcherPriority.Normal, New WorkerMethod(AddressOf DoSomething))

    End Sub 'OnStylusDownProcessed


    Private Sub DoSomething()
        ' Perform work on the rendering thread.
    End Sub 'DoSomething

End Class
'</Snippet19>

Class CustomDynamicRenderer2
    Inherits DynamicRenderer
    <ThreadStatic()> _
    Private Shared brush As Brush = Nothing

    <ThreadStatic()> _
    Private Shared pen As Pen = Nothing

    Private prevPoint As Point


    Public Sub New()

    End Sub 'New

    '<Snippet18>
    Protected Overrides Sub OnIsActiveForInputChanged()

        MyBase.OnIsActiveForInputChanged()

        If Not Me.IsActiveForInput Then
            ' Clean up any resources the plug-in uses.
        Else
            ' Allocate the resources the plug-in uses.
        End If

    End Sub 'OnIsActiveForInputChanged
    '</Snippet18>

    Protected Overrides Sub OnStylusUp(ByVal rawStylusInput As RawStylusInput)

        MyBase.OnStylusUp(rawStylusInput)

        rawStylusInput.NotifyWhenProcessed(Nothing)

    End Sub 'OnStylusUp


    Protected Overrides Sub OnStylusUpProcessed(ByVal callbackData As Object, ByVal targetVerified As Boolean)
        MyBase.OnStylusUpProcessed(callbackData, targetVerified)

    End Sub 'OnStylusUpProcessed
    'NotifyOnNextRenderComplete();

    '<Snippet22>
    Protected Overrides Sub OnAdded()

        MyBase.OnAdded()

        MessageBox.Show(Me.Element.ToString())

    End Sub 'OnAdded
    '</Snippet22>

    Protected Overrides Sub OnRemoved()

        MyBase.OnRemoved()
        MessageBox.Show(Me.Element.ToString())

    End Sub 'OnRemoved


    ' <Snippet16>
    Protected Overrides Sub OnEnabledChanged()

        MyBase.OnEnabledChanged()

        If Me.Enabled Then
            MessageBox.Show("The StylusPlugin is enabled.")
        Else
            MessageBox.Show("The StylusPlugin is not enabled.")
        End If

    End Sub 'OnEnabledChanged
    ' </Snippet16>

    '<Snippet21>
    Protected Overrides Sub OnDrawingAttributesReplaced()

        MyBase.OnDrawingAttributesReplaced()

        MessageBox.Show(Me.DrawingAttributes.Color.ToString())

    End Sub 'OnDrawingAttributesReplaced
    '</Snippet21>

    '<Snippet11>
    Protected Overrides Sub OnDraw(ByVal drawingContext As DrawingContext, _
                                   ByVal stylusPoints As StylusPointCollection, _
                                   ByVal geometry As Geometry, _
                                   ByVal fillBrush As Brush)

        ' Create a new Brush, if necessary
        If brush Is Nothing Then

            Dim primaryColor As Color

            If TypeOf fillBrush Is SolidColorBrush Then
                primaryColor = CType(fillBrush, SolidColorBrush).Color
            Else
                primaryColor = Colors.Red
            End If

            brush = New LinearGradientBrush(Colors.Blue, primaryColor, 20.0)

        End If

        drawingContext.DrawGeometry(brush, Nothing, geometry)

    End Sub 'OnDraw

    '</Snippet11>
End Class 'CustomDynamicRenderer