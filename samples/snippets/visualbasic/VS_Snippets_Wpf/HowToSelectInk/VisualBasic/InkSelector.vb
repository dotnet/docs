 '<Snippet1>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Windows.Input.StylusPlugIns
Imports System.Windows.Ink


'<Snippet2>
' Enum that keeps track of whether StrokeCollectionDemo is in ink mode 
' or select mode.
Public Enum InkMode
    Ink
    [Select]
End Enum 'InkMode
'</Snippet2>

' This control allows the user to input and select ink.  When the
' user selects ink, the lasso remains visible until they erase, or clip
' the selected strokes, or clear the selection.  When the control is
' in selection mode, strokes that are selected turn red.
Public Class InkSelector
    Inherits Label

    Private modeState As InkMode

    '<Snippet3>
    Private inkDA As DrawingAttributes
    Private selectDA As DrawingAttributes
    '</Snippet3>

    Private presenter As InkPresenter
    Private selectionTester As IncrementalLassoHitTester
    Private selectedStrokes As New StrokeCollection()

    '<Snippet8>
    ' StylusPointCollection that collects the stylus points from the stylus events.
    Private stylusPoints As StylusPointCollection
    '</Snippet8>

    ' Stroke that represents the lasso.
    Private lassoPath As Stroke

    Private renderer As DynamicRenderer


    Public Sub New()
        modeState = InkMode.Ink

        ' Use an InkPresenter to display the strokes on the custom control.
        presenter = New InkPresenter()
        Me.Content = presenter

        '<Snippet4>
        ' In the constructor.
        ' Selection drawing attributes use dark gray ink.
        selectDA = New DrawingAttributes()
        selectDA.Color = Colors.DarkGray

        ' ink drawing attributes use default attributes
        inkDA = New DrawingAttributes()
        inkDA.Width = 5
        inkDA.Height = 5

        AddHandler inkDA.AttributeChanged, _
                   AddressOf DrawingAttributesChanged

        AddHandler selectDA.AttributeChanged, _
                   AddressOf DrawingAttributesChanged
        '</Snippet4>

        ' Add a DynmaicRenderer to the control so ink appears
        ' to "flow" from the tablet pen.
        renderer = New DynamicRenderer()
        renderer.DrawingAttributes = inkDA
        Me.StylusPlugIns.Add(renderer)
        presenter.AttachVisuals(renderer.RootVisual, _
            renderer.DrawingAttributes)

    End Sub


    Shared Sub New()
        ' Allow ink to be drawn only within the bounds of the control.
        Dim owner As Type = GetType(InkSelector)
        ClipToBoundsProperty.OverrideMetadata(owner, _
            New FrameworkPropertyMetadata(True))

    End Sub

    ' Prepare to collect stylus packets. If Mode is set to Select,  
    ' get the IncrementalHitTester from the InkPresenter'newStroke 
    ' StrokeCollection and subscribe to its StrokeHitChanged event.
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs)
        MyBase.OnStylusDown(e)

        Stylus.Capture(Me)

        ' Create a new StylusPointCollection using the StylusPointDescription
        ' from the stylus points in the StylusDownEventArgs.
        stylusPoints = New StylusPointCollection()
        Dim eventPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)

        stylusPoints.Add(eventPoints)

        InitializeHitTester(eventPoints)

    End Sub


    Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonDown(e)

        Mouse.Capture(Me)

        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If

        Dim pt As Point = e.GetPosition(Me)

        Dim collectedPoints As New StylusPointCollection(New Point() {pt})

        stylusPoints = New StylusPointCollection()

        stylusPoints.Add(collectedPoints)

        InitializeHitTester(collectedPoints)

    End Sub


    '<Snippet9>
    Private Sub InitializeHitTester(ByVal collectedPoints As StylusPointCollection)

        ' Deselect any selected strokes.
        Dim selectedStroke As Stroke
        For Each selectedStroke In selectedStrokes
            selectedStroke.DrawingAttributes.Color = inkDA.Color
        Next selectedStroke
        selectedStrokes.Clear()

        If modeState = InkMode.Select Then
            ' Remove the previously drawn lasso, if it exists.
            If Not (lassoPath Is Nothing) Then
                presenter.Strokes.Remove(lassoPath)
                lassoPath = Nothing
            End If

            selectionTester = presenter.Strokes.GetIncrementalLassoHitTester(80)
            AddHandler selectionTester.SelectionChanged, AddressOf selectionTester_SelectionChanged
            selectionTester.AddPoints(collectedPoints)
        End If

    End Sub
    '</Snippet9>

    ' Collect the stylus packets as the stylus moves.
    Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs)

        If stylusPoints Is Nothing Then
            Return
        End If

        Dim collectedPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        stylusPoints.Add(collectedPoints)
        AddPointsToHitTester(collectedPoints)

    End Sub


    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)

        MyBase.OnMouseMove(e)

        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If

        If e.LeftButton = MouseButtonState.Released Then
            Return
        End If

        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If

        Dim pt As Point = e.GetPosition(Me)

        Dim collectedPoints As New StylusPointCollection(New Point() {pt})

        stylusPoints.Add(collectedPoints)

        AddPointsToHitTester(collectedPoints)

    End Sub


    '<Snippet10>
    Private Sub AddPointsToHitTester(ByVal collectedPoints As StylusPointCollection)

        If modeState = InkMode.Select AndAlso _
           Not selectionTester Is Nothing AndAlso _
           selectionTester.IsValid Then

            ' When the control is selecting strokes, add the
            ' stylus packetList to selectionTester.
            selectionTester.AddPoints(collectedPoints)
        End If

    End Sub
    '</Snippet10>

    ' When the user lifts the stylus, create a Stroke from the
    ' collected stylus points and add it to the InkPresenter.
    ' When the control is selecting strokes, add the
    ' point data to the IncrementalHitTester.
    Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs)

        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If

        Dim collectedPoints As StylusPointCollection = _
            e.GetStylusPoints(Me, stylusPoints.Description)

        stylusPoints.Add(collectedPoints)
        AddPointsToHitTester(collectedPoints)
        AddStrokeToPresenter()

        stylusPoints = Nothing

        Stylus.Capture(Nothing)

    End Sub


    Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs)

        MyBase.OnMouseLeftButtonUp(e)

        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If
        Dim pt As Point = e.GetPosition(Me)

        Dim collectedPoints As New StylusPointCollection(New Point() {pt})

        stylusPoints.Add(collectedPoints)
        AddPointsToHitTester(collectedPoints)
        AddStrokeToPresenter()

        stylusPoints = Nothing

        Mouse.Capture(Nothing)

    End Sub


    Private Sub AddStrokeToPresenter()
        Dim newStroke As New Stroke(stylusPoints)

        If modeState = InkMode.Ink Then
            ' Add the stroke to the InkPresenter.
            newStroke.DrawingAttributes = inkDA.Clone()
            presenter.Strokes.Add(newStroke)
        End If

        '<Snippet12>
        If modeState = InkMode.Select AndAlso lassoPath Is Nothing Then
            ' Add the lasso to the InkPresenter and add the packetList
            ' to selectionTester.
            lassoPath = newStroke
            lassoPath.DrawingAttributes = selectDA.Clone()
            presenter.Strokes.Add(lassoPath)
            RemoveHandler selectionTester.SelectionChanged, _
                          AddressOf selectionTester_SelectionChanged
            selectionTester.EndHitTesting()
        End If
        '</Snippet12>

    End Sub

    '<Snippet11>
    Private Sub selectionTester_SelectionChanged(ByVal sender As Object, _
                                         ByVal args As LassoSelectionChangedEventArgs)

        ' Change the color of all selected strokes to red.
        Dim selectedStroke As Stroke
        For Each selectedStroke In args.SelectedStrokes
            selectedStroke.DrawingAttributes.Color = Colors.Red
            selectedStrokes.Add(selectedStroke)
        Next selectedStroke

        ' Change the color of all unselected strokes to 
        ' their original color.
        Dim unselectedStroke As Stroke
        For Each unselectedStroke In args.DeselectedStrokes
            unselectedStroke.DrawingAttributes.Color = inkDA.Color
            selectedStrokes.Remove(unselectedStroke)
        Next unselectedStroke

    End Sub
    '</Snippet11>

    '<Snippet5>
    ' Property to indicate whether the user is inputting or
    ' selecting ink.  
    Public Property Mode() As InkMode
        Get
            Return Mode
        End Get

        Set(ByVal value As InkMode)
            modeState = value

            ' Set the DrawingAttributes of the DynamicRenderer
            If modeState = InkMode.Ink Then
                renderer.DrawingAttributes = inkDA
            Else
                renderer.DrawingAttributes = selectDA
            End If

            ' Reattach the visual of the DynamicRenderer to the InkPresenter.
            presenter.DetachVisuals(renderer.RootVisual)
            presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes)
        End Set
    End Property
    '</Snippet5>
    '<Snippet7>
    Private Sub DrawingAttributesChanged(ByVal sender As Object, _
                                 ByVal e As PropertyDataChangedEventArgs)

        ' Reattach the visual of the DynamicRenderer to the InkPresenter 
        ' whenever the DrawingAttributes change.
        presenter.DetachVisuals(renderer.RootVisual)
        presenter.AttachVisuals(renderer.RootVisual, _
                                renderer.DrawingAttributes)

    End Sub
    '</Snippet7>

    '<Snippet6>
    ' Property to allow the user to change the pen's DrawingAttributes.
    Public ReadOnly Property InkDrawingAttributes() As DrawingAttributes
        Get
            Return inkDA
        End Get
    End Property

    ' Property to allow the user to change the Selector'newStroke DrawingAttributes.
    Public ReadOnly Property SelectDrawingAttributes() As DrawingAttributes
        Get
            Return selectDA
        End Get
    End Property
    '</Snippet6>

End Class
'</Snippet1>