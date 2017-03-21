 '<Snippet3>
Imports System
Imports System.Windows
Imports System.Windows.Controls
'Imports System.Windows.Design
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Windows.Ink
Imports System.Collections
Imports System.Windows.Input.StylusPlugIns


Namespace CustomInkControlSample

    ' Enum that keeps track of whether StrokeCollectionDemo is in ink mode 
    ' or select mode.
    Public Enum InkMode
        InkMode
        SelectMode
    End Enum 'InkMode

    ' This control allows the user to input and select ink.  When the
    ' user selects ink, the lasso remains visible until they erase, or clip
    ' the selected strokes, or clear the selection.  When the control is
    ' in selection mode, strokes that are selected turn red.
    Public Class InkSelector

        Inherits Border
        Private mode As InkMode

        Private inkDA As DrawingAttributes
        Private selectDA As DrawingAttributes

        Private presenter As InkPresenter
        Private selectionTester As IncrementalLassoHitTester
        Private selectedStrokes As StrokeCollection

        ' Stroke that represents the lasso.
        Private lassoPath As Stroke

        ' StylusPointCollection that collects the stylus points from the stylus events.
        Dim stylusPoints As StylusPointCollection

        Dim renderer As DynamicRenderer

        Public Sub New()

            mode = InkMode.InkMode

            presenter = New InkPresenter()
            Me.Child = presenter

            ' ink drawing attributes use default attributes
            inkDA = New DrawingAttributes()
            inkDA.Width = 5
            inkDA.Height = 5

            ' Selection drawing attributes use dark gray ink.
            selectDA = New DrawingAttributes()
            selectDA.Color = Colors.DarkGray

            ' Add a DynmaicRenderer to the control so ink appears
            ' to "flow" from the tablet pen.
            renderer = New DynamicRenderer()
            renderer.DrawingAttributes = inkDA
            Me.StylusPlugIns.Add(renderer)
            presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes)

            selectedStrokes = New StrokeCollection()

            AddHandler inkDA.AttributeChanged, AddressOf DrawingAttributesChanged
            AddHandler selectDA.AttributeChanged, AddressOf DrawingAttributesChanged

        End Sub 'New

        Shared Sub New()
            ' Allow ink to be drawn only within the bounds of the control.
            Dim owner As Type = GetType(InkSelector)
            ClipToBoundsProperty.OverrideMetadata(owner, New FrameworkPropertyMetadata(True))

        End Sub 'New

        ' Prepare to collect stylus packets. If Mode is set to Select,  
        ' get the IncrementalHitTester from the InkPresenter's 
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

        End Sub 'OnStylusDown


        Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)

            MyBase.OnMouseLeftButtonDown(e)

            If Not (e.StylusDevice Is Nothing) Then
                Return
            End If

            Mouse.Capture(Me)

            Dim pt As Point = e.GetPosition(Me)

            Dim collectedPoints As New StylusPointCollection(New Point() {pt})

            stylusPoints = New StylusPointCollection()

            stylusPoints.Add(collectedPoints)

            InitializeHitTester(collectedPoints)

        End Sub 'OnMouseLeftButtonDown

        '<Snippet17>
        Private Sub InitializeHitTester(ByVal collectedPoints As StylusPointCollection)
            ' Deselect any selected strokes.
            Dim selectedStroke As Stroke
            For Each selectedStroke In selectedStrokes
                selectedStroke.DrawingAttributes.Color = inkDA.Color
            Next selectedStroke
            selectedStrokes.Clear()


            If mode = InkMode.SelectMode Then

                ' Remove the previously drawn lasso, if it exists.
                If Not (lassoPath Is Nothing) Then
                    presenter.Strokes.Remove(lassoPath)
                    lassoPath = Nothing
                End If

                selectionTester = presenter.Strokes.GetIncrementalLassoHitTester(80)
                AddHandler selectionTester.SelectionChanged, AddressOf selectionTester_SelectionChanged
                selectionTester.AddPoints(collectedPoints)
            End If

        End Sub 'InitializeHitTester
        '</Snippet17>

        ' Collect the stylus packets as the stylus moves.
        Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs)
            If stylusPoints Is Nothing Then
                Return
            End If

            Dim collectedPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
            stylusPoints.Add(collectedPoints)
            AddPointsToHitTester(collectedPoints)

        End Sub 'OnStylusMove


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

        End Sub 'OnMouseMove


        Private Sub AddPointsToHitTester(ByVal collectedPoints As StylusPointCollection)

            If mode = InkMode.SelectMode AndAlso selectionTester.IsValid Then
                ' When the control is selecting strokes, add the
                ' stylus packetList to selectionTester.
                selectionTester.AddPoints(collectedPoints)
            End If

        End Sub 'AddPointsToHitTester

        ' When the user lifts the stylus, create a Stroke from the
        ' collected stylus packetList and add it to the InkPresenter.
        ' When the control is selecting strokes, add the
        ' point data to the IncrementalHitTester.
        Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs)

            If stylusPoints Is Nothing Then
                stylusPoints = New StylusPointCollection()
            End If
            Dim collectedPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)

            stylusPoints.Add(collectedPoints)
            AddPointsToHitTester(collectedPoints)
            AddStrokeToPresenter()

            stylusPoints = Nothing

            Stylus.Capture(Nothing)

        End Sub 'OnStylusUp


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

        End Sub 'OnMouseLeftButtonUp


        '<Snippet38>
        Private Sub AddStrokeToPresenter()

            Dim newStroke As New Stroke(stylusPoints)

            If mode = InkMode.InkMode Then
                ' Add the stroke to the InkPresenter.
                newStroke.DrawingAttributes = inkDA.Clone()
                presenter.Strokes.Add(newStroke)
            End If

            If mode = InkMode.SelectMode AndAlso lassoPath Is Nothing Then
                ' Add the lasso to the InkPresenter and add the packetList
                ' to selectionTester.
                lassoPath = newStroke
                lassoPath.DrawingAttributes = selectDA.Clone()
                presenter.Strokes.Add(lassoPath)
                RemoveHandler selectionTester.SelectionChanged, AddressOf selectionTester_SelectionChanged
                selectionTester.EndHitTesting()
            End If

        End Sub 'AddStrokeToPresenter

        '</Snippet38>

        '<Snippet18>
        Private Sub selectionTester_SelectionChanged(ByVal sender As Object, _
            ByVal args As LassoSelectionChangedEventArgs)

            ' Change the color of all selected strokes to red.
            For Each selectedStroke As Stroke In args.SelectedStrokes
                selectedStroke.DrawingAttributes.Color = Colors.Red
                selectedStrokes.Add(selectedStroke)
            Next selectedStroke

            ' Change the color of all unselected strokes to 
            ' their original color.
            For Each unselectedStroke As Stroke In args.DeselectedStrokes
                unselectedStroke.DrawingAttributes.Color = inkDA.Color
                selectedStrokes.Remove(unselectedStroke)
            Next unselectedStroke

        End Sub 'selectionHT_StrokeHitChanged
        '</Snippet18>

        '<Snippet19>
        ' Remove all the strokes from the control.
        Public Sub ClearStrokes()

            presenter.Strokes.Clear()
            lassoPath = Nothing

        End Sub 'ClearStrokes
        '</Snippet19>

        ' Property to indicate whether the user is inputting or
        ' selecting ink.  
        Public Property CurrentMode() As InkMode

            Get
                Return mode
            End Get

            Set(ByVal value As InkMode)
                mode = value

                If (mode = InkMode.InkMode) Then
                    renderer.DrawingAttributes = inkDA
                Else
                    renderer.DrawingAttributes = selectDA
                End If

                ' Reattach the visual of the DynamicRenderer to the InkPresenter.
                presenter.DetachVisuals(renderer.RootVisual)
                presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes)

            End Set

        End Property

        '<Snippet39>
        Private Sub DrawingAttributesChanged(ByVal sender As Object, ByVal e As PropertyDataChangedEventArgs)

            ' Reattach the visual of the DynamicRenderer to the InkPresenter 
            ' whenever the DrawingAttributes change.
            presenter.DetachVisuals(renderer.RootVisual)
            presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes)

        End Sub
        '</Snippet39>


        ' Property to allow the user to change the pen's DrawingAttributes.
        Public ReadOnly Property InkDrawingAttributes() As DrawingAttributes

            Get
                Return inkDA
            End Get

        End Property

        ' Property to allow the user to change the Selector's DrawingAttributes.
        Public ReadOnly Property SelectDrawingAttributes() As DrawingAttributes

            Get
                Return selectDA
            End Get

        End Property

        '</Snippet3>
        ' Allow subclasses access to the InkPresenter

        Protected ReadOnly Property InkPresenter() As InkPresenter

            Get
                Return presenter
            End Get

        End Property

        ' Allow subclasses access to the selecting

        Protected Property Lasso() As Stroke

            Get
                Return lassoPath
            End Get

            Set(ByVal value As Stroke)
                lassoPath = value
            End Set

        End Property

        '<Snippet4>
    End Class
End Namespace
'</Snippet4>