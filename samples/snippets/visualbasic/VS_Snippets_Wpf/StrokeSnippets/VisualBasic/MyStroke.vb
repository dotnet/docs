
Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media

Imports System
Imports System.Collections.Generic
Imports System.Text


Namespace StrokeSnippets_VB

    Class MyStroke
        Inherits Stroke
        ' Let user reset color for all new strokes
        ' by setting the color for any stroke.
        ' We'll start off by setting the color to black.
        Private myColor As Color = Colors.Black

        Private dtGuid As Guid


        Public Sub New(ByVal points As StylusPointCollection)
            MyBase.New(points)
            initialize()

        End Sub 'New
        'MoveStylusPoints();

        Public Sub New(ByVal stylusPoints As StylusPointCollection, ByVal drawingAttributes As DrawingAttributes)
            MyBase.New(stylusPoints, drawingAttributes)

        End Sub 'New

        'MoveStylusPoints();

        Private Sub initialize()
            setTimeStamp()

        End Sub 'initialize


        Public Sub MoveStylusPoints()
            Dim points As StylusPointCollection = Me.StylusPoints

            Dim i As Integer

            While i < points.Count
                Dim p As StylusPoint = points(i)
                p.Y = p.Y + 20
                points(i) = p
                i += 1
            End While

        End Sub 'MoveStylusPoints



        Private Sub setTimeStamp()
            ' See if we have the same timestamp as the border
            Dim sAttr As Attribute = Attribute.GetCustomAttribute(GetType(MyBorder), GetType(GuidAttribute))
            dtGuid = New Guid("03457307-3475-3450-3035-640435034540")

        End Sub 'setTimeStamp


        ' <Snippet15>
        Protected Overrides Sub OnDrawingAttributesChanged(ByVal e As PropertyDataChangedEventArgs)
            ' Notify base class of event
            MyBase.OnDrawingAttributesChanged(e)

            ' See if the change was a new DrawingAttribute.Color property
            Dim eT As Type = e.NewValue.GetType()

        End Sub 'OnDrawingAttributesChanged



        'if (eT == typeof(Color))
        '{
        '    Color c = (Color)e.NewValue;
        '    if (c == Colors.Red)
        '    {
        '        MessageBox.Show("The stroke is now red!");
        '    }
        '}
        ' </Snippet15>


        '<Snippet23>
        Protected Overrides Sub DrawCore(ByVal context As DrawingContext, _
                ByVal overridedAttributes As DrawingAttributes)

            ' Draw the stroke. Calling base.DrawCore accomplishes the same thing.
            Dim geometry As Geometry = GetGeometry(overridedAttributes)
            context.DrawGeometry(New SolidColorBrush(overridedAttributes.Color), Nothing, geometry)

            Dim points As StylusPointCollection

            ' Get the stylus points used to draw the stroke.  The points used depends on
            ' the value of FitToCurve.
            If Me.DrawingAttributes.FitToCurve Then
                points = Me.GetBezierStylusPoints()
            Else
                points = Me.StylusPoints
            End If

            ' Draw a circle at each stylus point.
            Dim p As StylusPoint
            For Each p In points
                context.DrawEllipse(Nothing, New Pen(Brushes.Black, 1), CType(p, Point), 5, 5)
            Next p

        End Sub 'DrawCore

        '</Snippet23>
        Private Sub DrawSelectedStrokeAndPoints(ByVal context As DrawingContext, ByVal overridedAttributes As DrawingAttributes)

        End Sub 'DrawSelectedStrokeAndPoints


        ' <Snippet16>
        Protected Overrides Sub OnDrawingAttributesReplaced(ByVal e As DrawingAttributesReplacedEventArgs)

            '// Notify base class of event
            'base.OnDrawingAttributesReplaced(e);
            'if (e.NewDrawingAttributes.Color == Colors.Red)
            '{
            '    MessageBox.Show("The stroke is now red!");
            '}
        End Sub 'OnDrawingAttributesReplaced

        ' </Snippet16>
        Private Sub MyStroke_PacketsChanged(ByVal sender As Object, ByVal e As EventArgs)

        End Sub 'MyStroke_PacketsChanged


        ' <Snippet17>
        Protected Overrides Sub OnStylusPointsChanged(ByVal e As EventArgs)
            ' Notify base class of event
            MyBase.OnStylusPointsChanged(e)

        End Sub 'OnStylusPointsChanged

        ' </Snippet17>
        Private Sub MyStroke_PropertyDataChanged(ByVal sender As Object, ByVal e As PropertyDataChangedEventArgs)

        End Sub 'MyStroke_PropertyDataChanged


        ' <Snippet18>
        Protected Overrides Sub OnPropertyDataChanged(ByVal e As PropertyDataChangedEventArgs)

            ' Notify base class of event
            MyBase.OnPropertyDataChanged(e)

            ' If the current stroke color changes,
            ' reset the default color for the class.
            If e.PropertyGuid.Equals(DrawingAttributeIds.Color) Then
                myColor = Me.DrawingAttributes.Color
            End If

        End Sub 'OnPropertyDataChanged
        ' </Snippet18>
        Private IsSelected As Boolean


        Public Property Selected() As Boolean
            Get
                Return IsSelected
            End Get

            Set(ByVal value As Boolean)
                If IsSelected <> Value Then
                    IsSelected = Value
                    Me.OnInvalidated(New EventArgs())
                End If
            End Set
        End Property
    End Class 'MyStroke

End Namespace