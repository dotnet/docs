
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Markup
Imports System.Collections.Generic
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.IO
Imports System.Collections.ObjectModel


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>
Class Window1
    Inherits Window '

    Private box As New Rectangle()
    Private textBlock1 As TextBlock
    Private inkFileName As String = "strokes.isf"

    Public Sub New()
        InitializeComponent()

        inkCanvas1.DefaultDrawingAttributes.Width = 3
        inkCanvas1.DefaultDrawingAttributes.Height = 3
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.Firebrick

        AddHandler copyButton.Click, AddressOf copyButton_Click
        AddHandler pasteButton.Click, AddressOf pasteButton_Click
        AddHandler copyXamlButton.Click, AddressOf copyXamlButton_Click
        AddHandler selectElementsButton.Click, AddressOf selectElementsButton_Click
        AddHandler cutSelectionButton.Click, AddressOf cutSelectionButton_Click
        AddHandler Me.KeyDown, AddressOf Window1_KeyDown
        AddHandler comparePointDescriptionsButton.Click, AddressOf comparePointDescriptionsButton_Click
        AddHandler changePointDescriptionsButton.Click, AddressOf changePointDescriptionsButton_Click
        AddHandler changeColorsOfSelectionButton.Click, AddressOf changeColorsOfSelectionButton_Click
        AddHandler replaceStrokeButton.Click, AddressOf switchPlayersButton_Click


        AddHandler inkCanvas1.StylusDown, AddressOf inkCanvas1_StylusDown
        AddHandler inkCanvas1.StrokeCollected, AddressOf inkCanvas1_StrokeCollected

        AddHandler inkCanvas1.StrokeErasing, AddressOf inkCanvas1_StrokeErasing
        AddHandler inkCanvas1.SelectionMoving, AddressOf inkCanvas1_SelectionMoving
        AddHandler inkCanvas1.SelectionChanging, AddressOf inkCanvas1_SelectionChanging
        AddHandler inkCanvas1.SelectionChanged, AddressOf inkCanvas1_SelectionChanged
        AddHandler inkCanvas1.StrokesReplaced, AddressOf inkCanvas1_StrokesReplaced
        AddHandler inkCanvas1.SelectionResizing, AddressOf inkCanvas1_SelectionResizing
        AddHandler inkCanvas1.SelectionResized, AddressOf inkCanvas1_SelectionResized
        AddHandler inkCanvas1.SelectionMoved, AddressOf inkCanvas1_SelectionMoved
        AddHandler inkCanvas1.StrokeErased, AddressOf inkCanvas1_StrokeErased
        'inkCanvas1.Clip = New RectangleGeometry(New Rect(100, 100, 200, 200))
        AddHandler inkCanvas1.EditingModeChanged, AddressOf inkCanvas1_EditingModeChanged
        AddHandler inkCanvas1.EditingModeInvertedChanged, AddressOf inkCanvas1_EditingModeInvertedChanged
        AddHandler inkCanvas1.ActiveEditingModeChanged, AddressOf inkCanvas1_ActiveEditingModeChanged

        Me.WindowState = WindowState.Maximized
        InitializePlayersCanvases()

        AddHandler positionButtonButton.Click, AddressOf positionButtonButton_Click

        ' These methods contain snippets.
        'UseCustomCursorOnInkCanvas();
        'DisableMoveAndResize();
        ShowPreferredPasteFormats()
        PointEraseStrokes()

    End Sub 'New
    'AddTextBlock();


    '<Snippet36>
    Private Sub inkCanvas1_ActiveEditingModeChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Me.Title = inkCanvas1.ActiveEditingMode.ToString()

    End Sub 'inkCanvas1_ActiveEditingModeChanged
    '</Snippet36>

    Private Sub positionButtonButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        AttachedPropertiesSnippets()

    End Sub 'positionButtonButton_Click


    Sub ShowPreferredPasteFormats()
        '<Snippet26>
        Dim formats() As InkCanvasClipboardFormat = _
                        {InkCanvasClipboardFormat.InkSerializedFormat, _
                         InkCanvasClipboardFormat.Xaml}

        inkCanvas1.PreferredPasteFormats = formats
        '</Snippet26>

    End Sub 'ShowPreferredPasteFormats

    '<Snippet20>
    Private Sub inkCanvas1_EditingModeInvertedChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByPoint Then
            erasingModeLabel.Text = "Erase by point"
        ElseIf inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByStroke Then
            erasingModeLabel.Text = "Erase by stroke"
        End If

    End Sub 'inkCanvas1_EditingModeInvertedChanged
    '</Snippet20>

    '<Snippet21>
    Private Sub inkCanvas1_EditingModeChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If inkCanvas1.EditingMode = InkCanvasEditingMode.Ink Then
            modeLabel.Text = "Ink"
        ElseIf inkCanvas1.EditingMode = InkCanvasEditingMode.Select Then
            modeLabel.Text = "select"
        End If

    End Sub 'inkCanvas1_EditingModeChanged
    '</Snippet21>

    ' <Snippet19>
    ' Unselect the items on the InkCanvas once the user has moved them.
    Private Sub inkCanvas1_SelectionMoved(ByVal sender As Object, ByVal e As EventArgs)

        inkCanvas1.Select(Nothing, Nothing)

    End Sub 'inkCanvas1_SelectionMoved
    ' </Snippet19>

    ' <Snippet18>
    Private Sub inkCanvas1_StrokeErased(ByVal sender As Object, ByVal e As RoutedEventArgs)

        Me.Title = "Stroke erased " + inkCanvas1.Strokes.Count.ToString()

    End Sub 'inkCanvas1_StrokeErased
    ' </Snippet18>

    '<Snippet23>
    Private Sub inkCanvas1_SelectionResized(ByVal sender As Object, ByVal e As EventArgs)

        inkCanvas1.Select(Nothing, Nothing)

    End Sub 'inkCanvas1_SelectionResized
    '</Snippet23>

    ' <Snippet16>
    Private selectionBounds As Rect

    ' Don't allow the user to make the selection smaller than its original size.
    Private Sub inkCanvas1_SelectionResizing(ByVal sender As Object, ByVal e As InkCanvasSelectionEditingEventArgs)

        If selectionBounds.IsEmpty Then
            Return
        End If

        Dim resizeHeight As Double
        Dim resizeWidth As Double

        ' If the user made the height of the selection smaller, 
        ' use the selection's original height.
        If e.NewRectangle.Height < selectionBounds.Height Then
            resizeHeight = selectionBounds.Height
        Else
            resizeHeight = e.NewRectangle.Height
        End If

        ' If the user made the width of the selection smaller, 
        ' use the selection's original width.
        If e.NewRectangle.Width < selectionBounds.Width Then
            resizeWidth = selectionBounds.Width
        Else
            resizeWidth = e.NewRectangle.Width
        End If

        ' Create a the new rectangle with the appropriate width and height.
        e.NewRectangle = New Rect(e.NewRectangle.X, e.NewRectangle.Y, resizeWidth, resizeHeight)

    End Sub 'inkCanvas1_SelectionResizing


    ' Keep track of the selection bounds.
    Private Sub inkCanvas1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)

        selectionBounds = inkCanvas1.GetSelectionBounds()

    End Sub 'inkCanvas1_SelectionChanged
    ' </Snippet16>

    '<Snippet15>
    Private player1 As StrokeCollection
    Private player2 As StrokeCollection


    Sub InitializePlayersCanvases()

        player1 = inkCanvas1.Strokes
        player2 = New StrokeCollection()

    End Sub 'InitializePlayersCanvases


    ' Use a different "inking surface" for each player.
    Private Sub switchPlayersButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If StrokeCollection.ReferenceEquals(inkCanvas1.Strokes, player1) Then
            inkCanvas1.Strokes = player2
        Else
            inkCanvas1.Strokes = player1
        End If

    End Sub 'switchPlayersButton_Click


    Private Sub inkCanvas1_StrokesReplaced(ByVal sender As Object, _
                                   ByVal e As InkCanvasStrokesReplacedEventArgs)

        If StrokeCollection.ReferenceEquals(e.NewStrokes, player1) Then
            Title = "Player one's turn"
        Else
            Title = "Player two's turn"
        End If

    End Sub 'inkCanvas1_StrokesReplaced
    '</Snippet15>

    ' <Snippet14>
    Private Sub inkCanvas1_SelectionChanging(ByVal sender As Object, _
                                     ByVal e As InkCanvasSelectionChangingEventArgs)

        Dim selectedStrokes As StrokeCollection = e.GetSelectedStrokes()

        Dim aStroke As Stroke
        For Each aStroke In inkCanvas1.Strokes
            If selectedStrokes.Contains(aStroke) Then
                aStroke.DrawingAttributes.Color = Colors.RoyalBlue
            Else
                aStroke.DrawingAttributes.Color = inkCanvas1.DefaultDrawingAttributes.Color
            End If
        Next aStroke

    End Sub 'inkCanvas1_SelectionChanging
    ' </Snippet14>

    '<Snippet13>
    Private Sub inkCanvas1_SelectionMoving(ByVal sender As Object, _
                                   ByVal e As InkCanvasSelectionEditingEventArgs)

        ' Allow the selection to only move horizontally.
        Dim newRect As Rect = e.NewRectangle
        e.NewRectangle = New Rect(newRect.X, e.OldRectangle.Y, newRect.Width, newRect.Height)

    End Sub 'inkCanvas1_SelectionMoving
    '</Snippet13>

    Private Sub changeColorsOfSelectionButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '<Snippet11>
        Dim selectedStrokes As StrokeCollection = inkCanvas1.GetSelectedStrokes()

        Dim aStroke As Stroke
        For Each aStroke In selectedStrokes
            aStroke.DrawingAttributes.Color = Colors.Red
        Next aStroke
        '</Snippet11>

        '<Snippet12>
        Dim scaler As New ScaleTransform(2, 2)

        Dim selectedElements As ReadOnlyCollection(Of UIElement) = inkCanvas1.GetSelectedElements()

        Dim element As UIElement
        For Each element In selectedElements
            element.RenderTransform = scaler
        Next element
        '</Snippet12>

    End Sub 'changeColorsOfSelectionButton_Click

    Private Sub inkCanvas1_StrokeErasing(ByVal sender As Object, ByVal e As InkCanvasStrokeErasingEventArgs)

    End Sub 'inkCanvas1_StrokeErasing



    Private Sub comparePointDescriptionsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim s As Stroke
        For Each s In inkCanvas1.Strokes
            MessageBox.Show(s.StylusPoints.Description.PropertyCount.ToString())
        Next s

    End Sub 'comparePointDescriptionsButton_Click


    Private Sub changePointDescriptionsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '<Snippet9>
        inkCanvas1.DefaultStylusPointDescription = New StylusPointDescription _
                (New StylusPointPropertyInfo() _
                {New StylusPointPropertyInfo(StylusPointProperties.X), _
                 New StylusPointPropertyInfo(StylusPointProperties.Y), _
                 New StylusPointPropertyInfo(StylusPointProperties.NormalPressure), _
                 New StylusPointPropertyInfo(StylusPointProperties.TipButton)})
        '</Snippet9>    
    End Sub 'changePointDescriptionsButton_Click



    Private Sub SaveStrokes()
        '<Snippet10>
        Dim fs As FileStream = Nothing

        Try
            fs = New FileStream(inkFileName, FileMode.Create)
            inkCanvas1.Strokes.Save(fs)
        Finally
            If Not (fs Is Nothing) Then
                fs.Close()
            End If
        End Try
        '</Snippet10>
    End Sub 'SaveStrokes 

    '<Snippet22>
    Private currentTimeGuid As New Guid("12345678-1234-1234-1234-123456789012")


    Private Sub inkCanvas1_StrokeCollected(ByVal sender As Object, ByVal e As InkCanvasStrokeCollectedEventArgs)

        e.Stroke.AddPropertyData(currentTimeGuid, DateTime.Now)

    End Sub 'inkCanvas1_StrokeCollected
    '</Snippet22>

    Sub AddTextBlock()
        '<Snippet8>
        textBlock1 = New TextBlock()
        textBlock1.Text = "TextBlock content"
        Canvas.SetTop(textBlock1, 100)
        Canvas.SetLeft(textBlock1, 100)
        inkCanvas1.Children.Add(textBlock1)
        '</Snippet8>

        '<Snippet37>
        inkCanvas1.Background = Brushes.LightGreen
        '</Snippet37>

        '<Snippet24>
        Dim enabledGestures As ReadOnlyCollection(Of ApplicationGesture) = _
                            inkCanvas1.GetEnabledGestures()
        '</Snippet24>

    End Sub 'AddTextBlock

    Private Sub inkCanvas1_StylusDown(ByVal sender As Object, ByVal e As StylusDownEventArgs)
        Dim desc As StylusPointDescription = e.GetStylusPoints(inkCanvas1, inkCanvas1.DefaultStylusPointDescription).Description

    End Sub 'inkCanvas1_StylusDown


    Sub DisableMoveAndResize()
        '<Snippet7>
        inkCanvas1.ResizeEnabled = False
        inkCanvas1.MoveEnabled = False
        '</Snippet7>
    End Sub 'DisableMoveAndResize


    Sub UseCustomCursorOnInkCanvas()
        '<Snippet5>
        inkCanvas1.UseCustomCursor = True
        inkCanvas1.Cursor = Cursors.Pen
        '</Snippet5>
    End Sub 'UseCustomCursorOnInkCanvas


    Sub PointEraseStrokes()
        '<Snippet6>
        inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByPoint
        inkCanvas1.EraserShape = New EllipseStylusShape(5, 5)
        '</Snippet6>
    End Sub 'PointEraseStrokes


    Private Sub selectElementsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '<Snippet2>
        inkCanvas1.Select(inkCanvas1.Strokes, New UIElement() {textbox1, button1})
        '</Snippet2>
    End Sub 'selectElementsButton_Click


    Private Sub copyButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '<Snippet3>
        inkCanvas1.Select(New UIElement() {textbox1, button1})
        inkCanvas1.CopySelection()
        '</Snippet3>

    End Sub 'copyButton_Click

    Private Sub cutSelectionButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '<Snippet4>
        inkCanvas1.Select(New UIElement() {textbox1, button1})
        inkCanvas1.CutSelection()
        '</Snippet4>

    End Sub 'cutSelectionButton_Click

    '<Snippet1>
    Private Sub copyXamlButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        'string rectString = Parser.SaveAsXml(rect1);
        Dim rectString As String = XamlWriter.Save(rect1)

        Dim rectangleData As New DataObject(DataFormats.Xaml, rectString)
        Clipboard.SetDataObject(rectangleData)

    End Sub 'copyXamlButton_Click


    Private Sub pasteButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If inkCanvas1.CanPaste() Then
            inkCanvas1.Paste(New Point(100, 100))
        End If

    End Sub 'pasteButton_Click
    '</Snippet1>

    Private Sub Window1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs)
        If e.Key = System.Windows.Input.Key.E Then
            If inkCanvas1.EditingMode = InkCanvasEditingMode.Ink Then
                inkCanvas1.EditingMode = InkCanvasEditingMode.Select
                'modeLabel.Text = "select";
            Else
                inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
            End If 'modeLabel.Text = "Ink";     
        End If

        If e.Key = Key.D Then
            If inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByStroke Then
                inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByPoint
            Else
                inkCanvas1.EditingModeInverted = InkCanvasEditingMode.EraseByStroke
            End If
        End If

        If e.Key = Key.H Then
            inkCanvas1.DefaultDrawingAttributes.IsHighlighter = Not inkCanvas1.DefaultDrawingAttributes.IsHighlighter
        End If

    End Sub 'Window1_KeyDown


    Sub AttachedPropertiesSnippets()
        '<Snippet27>
        InkCanvas.SetTop(button1, 100)
        '</Snippet27>

        '<Snippet28>
        InkCanvas.SetBottom(button1, 100)
        '</Snippet28>

        '<Snippet29>
        InkCanvas.SetLeft(button1, 100)
        '</Snippet29>

        '<Snippet30>
        InkCanvas.SetRight(button1, 100)
        '</Snippet30>

        '<Snippet31>
        Dim buttonLeft As Double = InkCanvas.GetLeft(button1)
        '</Snippet31>

        '<Snippet32>
        Dim buttonRight As Double = InkCanvas.GetRight(button1)
        '</Snippet32>

        '<Snippet33>
        Dim buttonTop As Double = InkCanvas.GetTop(button1)
        '</Snippet33>

        '<Snippet34>
        Dim buttonBottom As Double = InkCanvas.GetBottom(button1)
        '</Snippet34>
    End Sub 'AttachedPropertiesSnippets 
End Class 'Window1
