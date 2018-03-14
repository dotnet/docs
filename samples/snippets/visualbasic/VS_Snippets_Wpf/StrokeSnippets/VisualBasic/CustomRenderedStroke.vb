
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media

Namespace StrokeSnippets_VB

    '<Snippet24>
    ' Enumerator that specifies the drawing mode of the stroke.

    Public Enum DrawingMode
        Solid
        StyulusPoints
    End Enum 'DrawingMode
    '</Snippet24>

    Class CustomRenderedStroke
        Inherits MyStroke

        Public Sub New(ByVal points As StylusPointCollection)
            MyBase.New(points)

        End Sub 'New



        Public Sub New(ByVal stylusPoints As StylusPointCollection, ByVal drawingAttributes As DrawingAttributes)
            MyBase.New(stylusPoints, drawingAttributes)

        End Sub 'New


        '<Snippet25>
        Private strokeMode As DrawingMode = DrawingMode.Solid

        ' Property that specifies whether to draw a solid stroke or the stylus points
        Public Property Mode() As DrawingMode

            Get
                Return strokeMode
            End Get

            Set(ByVal value As DrawingMode)
                If strokeMode <> value Then
                    strokeMode = value
                    Me.OnInvalidated(New EventArgs())
                End If
            End Set

        End Property


        Protected Overrides Sub DrawCore(ByVal context As System.Windows.Media.DrawingContext, _
                    ByVal overridedAttributes As DrawingAttributes)
            Dim strokeBrush As New SolidColorBrush(overridedAttributes.Color)

            ' If strokeMode it set to Solid, draw the strokes regularly.
            ' Otherwise, draw the stylus points.
            If strokeMode = DrawingMode.Solid Then
                Dim geometry As Geometry = GetGeometry(overridedAttributes)
                context.DrawGeometry(strokeBrush, Nothing, geometry)
                ' strokeMode == DrawingMode.StylusPoints
            Else
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
                    context.DrawEllipse(Nothing, New Pen(strokeBrush, 1), CType(p, Point), 5, 5)
                Next p
            End If

        End Sub 'DrawCore
        '</Snippet25>

    End Class 'CustomRenderedStroke 
End Namespace
