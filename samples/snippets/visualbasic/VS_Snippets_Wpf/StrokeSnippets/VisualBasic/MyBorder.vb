
Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Input.StylusPlugIns


Namespace StrokeSnippets_VB

    ' This control initializes with strokes already on it and allows the
    ' user to erase the strokes with the stylus.
    ' Need this in MyStroke
    <Guid("03457307-3475-3450-3035-640435034540")> _
    Public Class MyBorder
        Inherits Border

        Public Enum sMode
            add
            clip
            remove
            surround
        End Enum 'sMode

        Private _state As sMode


        Public Property state() As sMode
            Get
                Return _state
            End Get
            Set(ByVal value As sMode)
                _state = Value
            End Set
        End Property

        Private _shadow As Boolean


        Public Property shadow() As Boolean
            Get
                Return _shadow
            End Get
            Set(ByVal value As Boolean)
                _shadow = Value
            End Set
        End Property

        Private _fitToCurve As Boolean = False


        Public Property FitToCurve() As Boolean
            Get
                Return _fitToCurve
            End Get

            Set(ByVal value As Boolean)
                _fitToCurve = Value
            End Set
        End Property


        Private gotFirstStroke As Boolean

        ' To save strokes in a file
        Private myFile As StreamWriter
        Private Shared STROKE_FILE As String = "c:\temp\stroke"

        Private myStroke, shadowStroke As Stroke
        Private myNewStroke As MyStroke
        Private myStrokeCollection As StrokeCollection
        'StylusPackets[] myStylusPacketsArray;
        Private stylusPoints As StylusPointCollection
        Private myIncrementalHitTester As IncrementalHitTester
        Private myInkPresenter As InkPresenter
        Private renderer As DynamicRenderer

        Private inkAttributes As DrawingAttributes

        ' The base-64 encoded string that contains ink data 
        ' in ink serialized format (ISF).
        Private strokesString As String = "base64:AOoFAxBIEEVqGwIAWf9GahsCAFn/GRQyCACAEAIAAABCMwgAgA" + "wCAAAAQhWrqtNBq6rTQaVh0MSr+ivFHyEVVFVVVVV1OkBUVVVVVXU6QJ7" + "0SZ80DJrAVFVVVVV/pcAKU3yC/gEb+AX/k5Z8PwWBO5KktgJSUAAKjzyC" + "wBZYLEoCJLd+Cbti873JlTUvn158doCC/gKb+ApwAJslSywE2ALAAWPPI" + "FhKWBKWAKAmwJVglAKACiMjgv3d+8Xi+fHWM2WC0zcm89+NSoL+A5P4Dl" + "uNlhFIqpLKAAoaF4L+AhP4CFAWAWCggv4Dc/gNty2yy5SrlKAKIhyC/gI" + "b+Ai+JZc2XZOyb46vLQCC/gOL+A5YDNlWFjN3CwAKQFeC/gOr+A7VhUFZ" + "KCsS2WTc2SyhKuWVLR3ly2LAXx574ssUgv4Dm/gOcCwEEpUTYSixUsuWy" + "gVZ79AQsWGyWUAKLCiC/gQT+BA9SWbllDfGqy3Lcu+OmfH8EIL+BDv4EP" + "XLKSpY3lVFhZuVZvKACkFggv4F2/gXlKLFuCVKTcsqUlkoRKBmk8zfFll" + "S2ySlACwAgv4Ds/gO+WWWWLBLFllllSksAoSkWG1kSbFu5AoAAAo/YoL+" + "Biv4GJJU+P4qSalUBKWdkBYCbm+Nliyk1CVKgCxYNYqC/gQb+BBwO8ABY" + "olDz4gAEzaw2AVCUKAsWCooCiAegv4Hw/gfEJe8zUoSgLCC/gNT+A0xM7" + "Gdmdliay2VaAo0PoL+B7v4Hx5Yq3lc2xZsseeC3N8aDXjUpWW4UIL+A5P" + "4DnhYqAIWFkqpcrLZuJuWqSyxVAovNoL+CJP4IjnlkDvHeSbSVd9FqFlI" + "oWAAgv4Dk/gOVc7gbmdyZ1LajFFJmlRKsoAKVXmC/go7+CjdRvredypaK" + "myLC7ytZQqFiyWbikAEvfg2pSVKS7liSwWJNsrbi4CC/gQD+A/9M2ACxU" + "qKjcVuXKiosCWWKQSyhvKRUUWULCwEmyyu4gA="


        Public Sub New()
            gotFirstStroke = False

            ' Set the default state if no button is clicked
            state = sMode.add
            myInkPresenter = New InkPresenter()

            Child = myInkPresenter

            inkAttributes = New DrawingAttributes()
            inkAttributes.Color = Colors.Green
            inkAttributes.Width = 5
            inkAttributes.Height = 5

            renderer = New DynamicRenderer()
            renderer.DrawingAttributes = inkAttributes
            Me.StylusPlugIns.Add(renderer)
            myInkPresenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes)

            StrokeConstructorSample()

        End Sub 'New


        Shared Sub New()
            ' Allow ink to be drawn only within the bounds of the control.
            Dim owner As Type = GetType(MyBorder)
            ClipToBoundsProperty.OverrideMetadata(owner, New FrameworkPropertyMetadata(True))

        End Sub 'New




        ' Prepare to collect stylus packets. Get the 
        ' IncrementalHitTester from the InkPresenter's 
        ' StrokeCollection and subscribe to its StrokeHitChanged event.
        Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs)
            MyBase.OnStylusDown(e)

            Select Case state
                Case sMode.add
                    Dim eventPoints As StylusPointCollection = e.GetStylusPoints(Me)
                    stylusPoints = New StylusPointCollection(eventPoints.Description)
                Case sMode.surround
                    ' Use StrokeChanged event handler to detect stroke encirclement when using percentage
                    myIncrementalHitTester = myInkPresenter.Strokes.GetIncrementalLassoHitTester(50)

                    AddHandler CType(myIncrementalHitTester, IncrementalLassoHitTester).SelectionChanged, AddressOf myIHT_StrokeHitChanged

                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(Me))
                Case Else
                    ' Otherwise we detect when the IHT hits the existing strokes
                    ' Use StrokeIntersectionChanged event handler to detect stroke hit when using stylus
                    Dim eraserTip As New EllipseStylusShape(3, 3, 0)

                    myIncrementalHitTester = myInkPresenter.Strokes.GetIncrementalStrokeHitTester(eraserTip)

                    AddHandler CType(myIncrementalHitTester, IncrementalStrokeHitTester).StrokeHit, AddressOf myIHT_StrokeIntersectionChanged

                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(Me))
            End Select

            e.Handled = True

        End Sub 'OnStylusDown


        ' Collect the StylusPackets as the stylus moves.
        Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs)
            Select Case state
                Case sMode.add
                    stylusPoints.Add(e.GetStylusPoints(Me))
                Case Else
                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(Me))
            End Select

            e.Handled = True

        End Sub 'OnStylusMove


        ' Unsubscribe from the StrokeHitChanged event when the
        ' user lifts the stylus.
        Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs)
            Select Case state
                Case sMode.add
                    ' Add the stylus points to a StylusPointCollection 
                    ' in the StylusUp event. e is a StylusEventArgs object.
                    stylusPoints.Add(e.GetStylusPoints(Me))

                    ' Create new stroke from the collected stylus points.
                    'myNewStroke = new MyStroke(stylusPoints, inkAttributes.Clone());
                    myNewStroke = New CustomRenderedStroke(stylusPoints, inkAttributes.Clone())

                    ' <Snippet8>
                    ' Handle DrawingAtributesChanged event on stroke
                    AddHandler myNewStroke.DrawingAttributesChanged, AddressOf myNewStroke_DrawingAttributesChanged
                    ' </Snippet8>

                    ' <Snippet9>
                    ' Handle DrawingAttributesReplaced event on stroke
                    AddHandler myNewStroke.DrawingAttributesReplaced, AddressOf myNewStroke_DrawingAttributesReplaced
                    ' </Snippet9>

                    AddHandler myNewStroke.StylusPointsChanged, AddressOf myNewStroke_StylusPointsChanged
                    AddHandler myNewStroke.StylusPointsReplaced, AddressOf myNewStroke_StylusPointsReplaced
                    AddHandler myNewStroke.StylusPoints.Changed, AddressOf StylusPoints_Changed

                    'myNewStroke.MoveStylusPoints();

                    ' <Snippet20>
                    ' Handle PropertyDataChanged event on stroke
                    AddHandler myNewStroke.PropertyDataChanged, AddressOf myNewStroke_PropertyDataChanged
                    ' </Snippet20>

                    ' <Snippet21>
                    ' Get packets from stroke
                    'StylusPackets myStylusPackets = myNewStroke.StylusPackets;
                    ' </Snippet21>

                    ' This should fire a DrawingAttributesChanged event

                    ' <Snippet7>
                    ' Make the new stroke green.
                    myNewStroke.DrawingAttributes.Color = Colors.Green
                    ' </Snippet7>

                    ' Add stroke to InkPresenter
                    'myNewStroke.DrawingAttributes = inkAttributes.Clone();
                    myNewStroke.DrawingAttributes.FitToCurve = FitToCurve

                    myInkPresenter.Strokes.Add(myNewStroke)

                    CompareStrokePoints(myNewStroke)

                    ' Add pink shadow if requested
                    If shadow Then
                        shadowStroke = myNewStroke.Clone()
                        shadowStroke.Transform(New Matrix(1, 0, 0, 1, 2, 0), False)
                        shadowStroke.DrawingAttributes.Color = Colors.Pink
                        myInkPresenter.Strokes.Add(shadowStroke)
                    End If

                Case sMode.surround

                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(Me))

                    ' Disable SelectionChanged event handler when using encirclement
                    RemoveHandler CType(myIncrementalHitTester, IncrementalLassoHitTester).SelectionChanged, _
                                AddressOf myIHT_StrokeHitChanged

                    'removehandler myincrementalhittester.se
                Case Else
                    myIncrementalHitTester.AddPoints(e.GetStylusPoints(Me))

                    ' Disable StrokeHit event handler when using stylus hits
                    AddHandler CType(myIncrementalHitTester, IncrementalStrokeHitTester).StrokeHit, _
                                AddressOf myIHT_StrokeIntersectionChanged
            End Select

            e.Handled = True

        End Sub 'OnStylusUp


        '<Snippet27>
        Private Sub StylusPoints_Changed(ByVal sender As Object, ByVal e As EventArgs)

            MessageBox.Show("stylus points changed")

        End Sub 'StylusPoints_Changed

        '</Snippet27>
        '<Snippet28>
        Private Sub myNewStroke_StylusPointsChanged(ByVal sender As Object, ByVal e As EventArgs)

            MessageBox.Show("stylus points changed")

        End Sub 'myNewStroke_StylusPointsChanged

        '</Snippet28>
        '<Snippet29>
        Private Sub myNewStroke_StylusPointsReplaced(ByVal sender As Object, ByVal e As StylusPointsReplacedEventArgs)

            MessageBox.Show("stylus points replaced")

        End Sub 'myNewStroke_StylusPointsReplaced

        '</Snippet29>
        Sub CompareStrokePoints(ByVal aStroke As Stroke)

        End Sub 'CompareStrokePoints



        Private Sub myNewStroke_PropertyDataChanged(ByVal sender As Object, ByVal e As PropertyDataChangedEventArgs)

        End Sub 'myNewStroke_PropertyDataChanged


        Private Sub myNewStroke_DrawingAttributesReplaced(ByVal sender As Object, ByVal e As DrawingAttributesReplacedEventArgs)

        End Sub 'myNewStroke_DrawingAttributesReplaced


        Private Sub myNewStroke_DrawingAttributesChanged(ByVal sender As Object, ByVal e As PropertyDataChangedEventArgs)

        End Sub 'myNewStroke_DrawingAttributesChanged


        ' When the stylus clips a stroke,
        ' delete that stroke.
        ' When the stylus erases a stoke,
        ' replace the stroke with the strokes returned by
        ' the Stroke.Erase method.
        Private Sub myIHT_StrokeIntersectionChanged(ByVal sender As Object, ByVal e As StrokeHitEventArgs)
            Dim thisStroke As Stroke = e.HitStroke

            ' <Snippet11>
            Dim myRect As Rect = thisStroke.GetBounds()
            ' </Snippet11>

            If state = sMode.clip Then

                ' ***Stroke.Clip***
                ' <Snippet4>
                ' Get the intersections when the stroke is clipped.
                ' e is a StrokeIntersectionChangedEventArgs object in the
                ' StrokeIntersectionChanged event handler.
                Dim clipResult As StrokeCollection = e.GetPointEraseResults()

                Dim strokesToReplace As New StrokeCollection()

                strokesToReplace.Add(thisStroke)

                ' Replace the old stroke with the new one.
                If clipResult.Count > 0 Then
                    myInkPresenter.Strokes.Replace(strokesToReplace, clipResult)
                Else
                    myInkPresenter.Strokes.Remove(strokesToReplace)
                End If
                ' </Snippet4>

                If Not gotFirstStroke Then

                    ' <Snippet3>
                    ' Create a guid for the date/timestamp.
                    Dim dtGuid As New Guid("03457307-3475-3450-3035-640435034540")

                    Dim now As DateTime = DateTime.Now

                    ' Check whether the property is already saved
                    If thisStroke.ContainsPropertyData(dtGuid) Then
                        ' Check whether the existing property matches the current date/timestamp
                        Dim oldDT As DateTime = CType(thisStroke.GetPropertyData(dtGuid), DateTime)

                        If oldDT <> now Then
                            ' Update the current date and time
                            thisStroke.AddPropertyData(dtGuid, now)
                        End If
                    End If
                    ' </Snippet3>

                    ' <Snippet30>
                    ' Create a guid for the date/timestamp.
                    Dim dateTimeGuid As New Guid("03457307-3475-3450-3035-045430534046")

                    Dim current As DateTime = DateTime.Now

                    ' Check whether the property is already saved
                    If thisStroke.ContainsPropertyData(dateTimeGuid) Then
                        Dim oldDateTime As DateTime = CType(thisStroke.GetPropertyData(dateTimeGuid), DateTime)

                        ' Check whether the existing property matches the current date/timestamp
                        If Not oldDateTime = current Then
                            ' Delete the custom property
                            thisStroke.RemovePropertyData(dateTimeGuid)
                        End If
                    End If
                    ' </Snippet30>

                End If

                ' <Snippet12>
                ' Save the stroke as an array of Point objects
                'Point[] myPoints = thisStroke.GetRenderingPoints();
                ' </Snippet12>
                ' Port to VB if I ever get this working!
                ' See if we can figure out which stroke point(s) got hit
                'StrokeIntersection[] myStrokeIntersections = e.GetHitStrokeIntersections();
                'Point[] myStrokeIntersectionPoints = new Point[myStrokeIntersections.Length];
                'int p = 0;
                'for (int k = 0; k < myStrokeIntersections.Length; k++)
                '{
                '    StrokeIntersection s = myStrokeIntersections[k];
                '    if (s.HitBegin != StrokeIntersection.BeforeFirst && s.HitEnd != StrokeIntersection.        AfterLast)
                '    {
                '        // Get stroke point that is closest to average between HitBegin and HitEnd:
                '        double x = s.HitBegin;
                '        double y = s.HitEnd;
                '        double midPoint = (x + y) / 2;
                '        int middlePoint = (int)midPoint;
                '        // Now add that Point from the existing stroke points
                '        myStrokeIntersectionPoints[p] = myPoints[middlePoint];
                '        p++;
                '    }
                '}
                ' Get DrawingContext for InkPresenter
                'VisualCollection myVisuals = VisualOperations.GetChildren(myInkPresenter);
                'DrawingVisual myVisual = new DrawingVisual();
                'DrawingContext myContext = myVisual.RenderOpen();
                '// Draw midpoints of stroke intersections a little green circles
                'for (int j = 0; j < myStrokeIntersectionPoints.Length; j++)
                '{
                '    // Draw green circles around each point
                '    myContext.DrawGeometry(Brushes.Green,
                '        new Pen(Brushes.Green, 1.0),
                '        new EllipseGeometry(myStrokeIntersectionPoints[j], 4.0, 4.0));
                '}
                'myContext.Close();
                'myVisuals.Add(myVisual);

                ' Do I have to do something here to display the revised InkPresenter?

                ' Open the file to hold strokes
                ' if the file already exists, overwrite it
                'myFile = new StreamWriter(File.Open(STROKE_FILE, FileMode.Create));
                'Point myPoint;
                'int xVal, yVal;
                'for (int i = 0; i < myPoints.Length; i++)
                '{
                '    myPoint = myPoints[i];
                '    xVal = (int)myPoint.X;
                '    yVal = (int)myPoint.Y;
                '    // Save the point to a file
                '    myFile.WriteLine(xVal.ToString() + " " + yVal.ToString());
                '}
                'myFile.Flush();
                'myFile.Close();
                'gotFirstStroke = true;
            Else
                ' ***erase**
                ' <Snippet10>
                ' Remove the stokee that is hit.
                myInkPresenter.Strokes.Remove(e.HitStroke)
            End If
            ' </Snippet10> 
        End Sub 'myIHT_StrokeIntersectionChanged


        ' When the stylus encircles a stroke,
        ' erase that stroke.
        Private Sub myIHT_StrokeHitChanged(ByVal sender As Object, ByVal e As LassoSelectionChangedEventArgs)

            'Dim selectedStroke As MyStroke
            For Each selectedStroke As MyStroke In e.SelectedStrokes
                selectedStroke.Selected = True
            Next selectedStroke 'stroke.DrawingAttributes.Color = Colors.Red;

            For Each stroke As MyStroke In e.DeselectedStrokes
                stroke.Selected = False
            Next stroke
            'stroke.DrawingAttributes.Color = Colors.Green;
        End Sub 'myIHT_StrokeHitChanged


        ' Remove the encircled stroke.
        'if (eraseResult.Count > 0)
        '{
        '    myInkPresenter.Strokes.Remove(eraseResult);
        '}

        Public Sub ChangeDrawingMode(ByVal mode As DrawingMode)
            If myInkPresenter.Strokes.Count = 0 Then
                Return
            End If

            If Not TypeOf myInkPresenter.Strokes(0) Is CustomRenderedStroke Then
                Return
            End If

            Dim s As CustomRenderedStroke
            For Each s In myInkPresenter.Strokes
                s.Mode = mode
            Next s

        End Sub 'ChangeDrawingMode


        Private Sub StrokeConstructorSample()
            ' <Snippet2>
            Dim drawingAttributes1 As New DrawingAttributes()
            drawingAttributes1.Color = Colors.Green

            Dim stylusPoint1 As StylusPoint = New StylusPoint(100, 100)
            Dim stylusPoint2 As StylusPoint = New StylusPoint(100, 200)
            Dim stylusPoint3 As StylusPoint = New StylusPoint(200, 200)
            Dim stylusPoint4 As StylusPoint = New StylusPoint(200, 100)
            Dim stylusPoint5 As StylusPoint = New StylusPoint(100, 100)

            Dim points() As StylusPoint = {stylusPoint1, stylusPoint2, _
                                stylusPoint3, stylusPoint4, stylusPoint1}

            Dim pointCollection As New StylusPointCollection(points)

            Dim NewStroke As Stroke = New Stroke(pointCollection, drawingAttributes1)

            myInkPresenter.Strokes.Add(NewStroke)
            ' </Snippet2>

        End Sub 'StrokeConstructorSample

        ' <Snippet5>

        ' <Snippet22>
        Function GetLittleRedStroke(ByVal theStroke As Stroke) As Stroke
            ' Copy the incoming stroke
            Dim sCopy As Stroke = theStroke.Clone()

            ' Scale it by 50%
            Dim xform As New Matrix()
            xform.Scale(0.5, 0.5)

            sCopy.Transform(xform, False)

            ' Color it red
            sCopy.DrawingAttributes.Color = Colors.Red

            ' Return the new stroke
            Return sCopy

        End Function 'getLittleRedStroke

        ' </Snippet22>

        ' </Snippet5>
    End Class 'MyBorder 

End Namespace
