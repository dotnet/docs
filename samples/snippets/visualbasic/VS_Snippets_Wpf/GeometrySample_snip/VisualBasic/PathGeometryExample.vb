Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class PathGeometryExample
		Inherits Page
		Public Sub New()
			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(SimpleLine())
			mainPanel.Children.Add(SimpleBezierLine())
			mainPanel.Children.Add(SimpleQuadraticBezierLine())
			mainPanel.Children.Add(ArcSegmentLine())
			mainPanel.Children.Add(TwoLineSegments())
			mainPanel.Children.Add(TwoPathFigures())
			Me.Content = mainPanel

		End Sub

		Private Function SimpleLine() As Path
			' <SnippetPathGeometryLineSegmentInline>
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10, 50)

			Dim myLineSegment As New LineSegment()
			myLineSegment.Point = New Point(200, 70)

			Dim myPathSegmentCollection As New PathSegmentCollection()
			myPathSegmentCollection.Add(myLineSegment)

			myPathFigure.Segments = myPathSegmentCollection

			Dim myPathFigureCollection As New PathFigureCollection()
			myPathFigureCollection.Add(myPathFigure)

			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures = myPathFigureCollection

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </SnippetPathGeometryLineSegmentInline>
			Return myPath

		End Function

		Private Function SimpleBezierLine() As Path
			' <Snippet33>
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10, 100)

			Dim myBezierSegment As New BezierSegment()
			myBezierSegment.Point1 = New Point(100, 0)
			myBezierSegment.Point2 = New Point(200, 200)
			myBezierSegment.Point3 = New Point(300, 100)

			Dim myPathSegmentCollection As New PathSegmentCollection()
			myPathSegmentCollection.Add(myBezierSegment)

			myPathFigure.Segments = myPathSegmentCollection

			Dim myPathFigureCollection As New PathFigureCollection()
			myPathFigureCollection.Add(myPathFigure)

			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures = myPathFigureCollection

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </Snippet33>
			Return myPath

		End Function

		Private Function SimpleQuadraticBezierLine() As Path
			' <Snippet34>
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10, 100)

			Dim myQuadraticBezierSegment As New QuadraticBezierSegment()
			myQuadraticBezierSegment.Point1 = New Point(200, 200)
			myQuadraticBezierSegment.Point2 = New Point(300, 100)

			Dim myPathSegmentCollection As New PathSegmentCollection()
			myPathSegmentCollection.Add(myQuadraticBezierSegment)

			myPathFigure.Segments = myPathSegmentCollection

			Dim myPathFigureCollection As New PathFigureCollection()
			myPathFigureCollection.Add(myPathFigure)

			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures = myPathFigureCollection

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </Snippet34>
			Return myPath

		End Function

		Private Function ArcSegmentLine() As Path
			' <Snippet36>
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10, 100)

            Dim myArcSegment As New ArcSegment()
            With myArcSegment
                .Size = New Size(100, 50)
                .RotationAngle = 45
                .IsLargeArc = True
                .SweepDirection = SweepDirection.Counterclockwise
                .Point = New Point(200, 100)
            End With

            Dim myPathSegmentCollection As New PathSegmentCollection()
            myPathSegmentCollection.Add(myArcSegment)

            myPathFigure.Segments = myPathSegmentCollection

            Dim myPathFigureCollection As New PathFigureCollection()
            myPathFigureCollection.Add(myPathFigure)

            Dim myPathGeometry As New PathGeometry()
            myPathGeometry.Figures = myPathFigureCollection

            Dim myPath As New Path()
            myPath.Stroke = Brushes.Black
            myPath.StrokeThickness = 1
            myPath.Data = myPathGeometry
            ' </Snippet36>
            Return myPath

		End Function


		Private Function TwoLineSegments() As Path
			' <Snippet49>
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10, 100)
			myPathFigure.IsClosed = True

			Dim myLineSegment1 As New LineSegment()
			myLineSegment1.Point = New Point(100, 100)
			Dim myLineSegment2 As New LineSegment()
			myLineSegment2.Point = New Point(100, 50)

			Dim myPathSegmentCollection As New PathSegmentCollection()
			myPathSegmentCollection.Add(myLineSegment1)
			myPathSegmentCollection.Add(myLineSegment2)
			myPathFigure.Segments = myPathSegmentCollection

			Dim myPathFigureCollection As New PathFigureCollection()
			myPathFigureCollection.Add(myPathFigure)

			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures = myPathFigureCollection

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </Snippet49>
			Return myPath

		End Function

		Private Function TwoPathFigures() As Path
			' <Snippet38>
			Dim myPathFigure1 As New PathFigure()
			myPathFigure1.StartPoint = New Point(10, 100)
			myPathFigure1.IsClosed = True

			Dim myLineSegment1 As New LineSegment()
			myLineSegment1.Point = New Point(100, 100)
			Dim myLineSegment2 As New LineSegment()
			myLineSegment2.Point = New Point(100, 50)

			Dim myPathFigure2 As New PathFigure()
			myPathFigure2.StartPoint = New Point(10, 10)
			myPathFigure2.IsClosed = True

			Dim myLineSegment3 As New LineSegment()
			myLineSegment3.Point = New Point(100, 10)
			Dim myLineSegment4 As New LineSegment()
			myLineSegment4.Point = New Point(100, 40)

			Dim myPathSegmentCollection1 As New PathSegmentCollection()
			myPathSegmentCollection1.Add(myLineSegment1)
			myPathSegmentCollection1.Add(myLineSegment2)
			myPathFigure1.Segments = myPathSegmentCollection1

			Dim myPathSegmentCollection2 As New PathSegmentCollection()
			myPathSegmentCollection2.Add(myLineSegment3)
			myPathSegmentCollection2.Add(myLineSegment4)
			myPathFigure2.Segments = myPathSegmentCollection2

			Dim myPathFigureCollection As New PathFigureCollection()
			myPathFigureCollection.Add(myPathFigure1)
			myPathFigureCollection.Add(myPathFigure2)

			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures = myPathFigureCollection

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </Snippet38>
			Return myPath

		End Function
	End Class
End Namespace