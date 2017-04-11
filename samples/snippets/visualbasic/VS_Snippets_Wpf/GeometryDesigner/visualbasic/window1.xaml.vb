Imports System
Imports System.Collections
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes


Namespace SampleApp
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window


		Public Sub New()
			InitializeComponent()
		End Sub
'<SnippetFEParentProperty>
		Private Sub OnUIReady(ByVal sender As Object, ByVal e As System.EventArgs)
			LinePane.Width = (CType(LinePane.Parent, StackPanel)).ActualWidth
			LinePane.Height = (CType(LinePane.Parent, StackPanel)).ActualHeight
			AddHandler DesignerPane.MouseLeave, AddressOf DesignerPane_MouseLeave
			AddHandler SizeChanged, AddressOf Window1_SizeChanged
		End Sub
'</SnippetFEParentProperty>


		Private Sub Window1_SizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
			XAMLPane.BeginAnimation(Canvas.TopProperty, Nothing)
			If IsShow Then
				XAMLPane.SetValue(Canvas.TopProperty, e.NewSize.Height - 70)
			Else
				XAMLPane.SetValue(Canvas.TopProperty, e.NewSize.Height)
			End If
			XAMLPane.Width = e.NewSize.Width - 205
		End Sub


		Private Sub OnShowHideXAML(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim xamlstring As String = System.Windows.Markup.XamlWriter.Save(DrawingPane)
			CType(XAMLPane.Children(0), TextBox).Text = xamlstring

			If Not IsShow Then
				IsShow = Not IsShow
				XAMLPane.Width = Me.ActualWidth - 205
				XAMLPane.Height = 50
				Dim yLocation As Double = DesignerPane.ActualHeight
				XAMLPane.SetValue(Canvas.LeftProperty, DesignerPane.GetValue(Canvas.LeftProperty))
                XAMLPane.SetValue(Canvas.TopProperty, yLocation)
                CType((CType(sender, Button).Content), Label).Content = "Hide XAML"

				'Start animation
				Dim db As New DoubleAnimation()
				db.Duration = TimeSpan.FromMilliseconds(500)
				db.FillBehavior = FillBehavior.HoldEnd
				db.To = yLocation - 50

				XAMLPane.BeginAnimation(Canvas.TopProperty, db)

			Else
                IsShow = Not IsShow
                CType((CType(sender, Button).Content), Label).Content = "Show XAML"

				Dim dbShrink As New DoubleAnimation()
				dbShrink.Duration = TimeSpan.FromMilliseconds(500)
				dbShrink.FillBehavior = FillBehavior.HoldEnd
				dbShrink.To = DesignerPane.ActualHeight
				dbShrink.From = DesignerPane.ActualHeight - 50

				XAMLPane.BeginAnimation(Canvas.TopProperty, dbShrink)

			End If

		End Sub

		Private Sub OnGeometrySelectionChange(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
		  Dim box As ComboBox = TryCast(sender, ComboBox)

		  If box.Name <> "GeometryTypeCB" Then
			Return
		  End If

		  If InitialSelection Then
			InitialSelection = Not InitialSelection
		  Else
			GeometryPaneChange((CType(box.SelectedItem, ComboBoxItem)).Content, True)
		  End If

		End Sub

		' ---------------------------------------------------------------------------------
		#Region "private action functions"
		Private Sub GeometryPaneChange(ByVal GeometryName As Object, ByVal AllowInsert As Boolean)
			For Each c As Canvas In ControlPointPane.Children
				If String.Compare(c.Name, CStr(GeometryName) & "Pane", False, System.Globalization.CultureInfo.InvariantCulture) = 0 Then
					c.Width = (CType(c.Parent, StackPanel)).ActualWidth
					c.Height = (CType(c.Parent, StackPanel)).ActualHeight
					If AllowInsert Then
						For Each b As Object In c.Children
							If TypeOf b Is TextBox Then
								CType(b, TextBox).Text = ""
								Continue For
							End If

							If TypeOf b Is Button AndAlso TypeOf (CType(b, Button)).Content Is String AndAlso (CType((CType(b, Button)).Content, String) = "Insert" OrElse CType((CType(b, Button)).Content, String) = "Update") Then
								CType(b, Button).IsEnabled = True
								CType(b, Button).Content = "Insert"
								IsInsert = True
							End If
						Next b
					Else
						For Each b As Object In c.Children
						   If TypeOf b Is Button AndAlso TypeOf (CType(b, Button)).Content Is String AndAlso CType((CType(b, Button)).Content, String) = "Insert" Then
								CType(b, Button).IsEnabled = False
						   End If
						Next b
					End If
				Else
					c.Width = 0
					c.Height = 0
				End If
			Next c
		End Sub


		'If mouse leaves the DesignerPane, hide all of the control points
		Private Sub DesignerPane_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
			For Each o As Object In DesignerPane.Children
				If TypeOf o Is Ellipse Then
					CType(o, Ellipse).Visibility = Visibility.Hidden
				End If
			Next o
		End Sub


		Private Sub path_MouseEnter(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
			Dim pathID As String = (CType(sender, Path)).Name

			'Search and set visibility on all of the related control points
			For Each o As Object In DesignerPane.Children
				'Search for the control point that contains the element's ID
				'e.g Line1_StartPoint for Line1 element
				If TypeOf o Is Ellipse Then

					If (CType(o, Ellipse)).Name.Contains(pathID) Then
						'show that control point
						CType(o, Ellipse).Visibility = Visibility.Visible

					Else

						'hide all other control points
						CType(o, Ellipse).Visibility = Visibility.Hidden
					End If

				End If
			Next o
		End Sub


		Private Sub OnInsertGeometry(ByVal sender As Object, ByVal e As RoutedEventArgs)

			Try
				If IsInsert Then
					Dim path As New Path()
					path.Stroke = Brushes.Black
					path.StrokeThickness = 2

					Dim gb As GeometryBase = GeometryFactory(CType((CType(sender, Button)).Parent, FrameworkElement))


					Select Case gb.geometryType
						Case "Line"
							path.Name = "Line" & LineCount
							AddControlPoints(gb.controlPoints, "Line")
							LineCount += 1
						Case "Rectangle"
							path.Name = "Rectangle" & RectangleCount
							AddControlPoints(gb.controlPoints, "Rectangle")
							RectangleCount += 1
						Case "Ellipse"
							path.Name = "Ellipse" & ElliipseCount
							AddControlPoints(gb.controlPoints, "Ellipse")
							ElliipseCount += 1
						Case "Arc"
							path.Name = "Arc" & ArcCount
							AddControlPoints(gb.controlPoints, "Arc")
							ArcCount += 1
						Case "Bezier"
							path.Name = "Bezier" & BezierCount
							AddControlPoints(gb.controlPoints, "Bezier")
							BezierCount += 1
						Case Else
							Throw New System.ApplicationException("Error:  Incorrect Geometry type")
					End Select

					path.Data = gb.CreateGeometry()
					AddHandler path.MouseEnter, AddressOf path_MouseEnter
					currentElement = path
					DrawingPane.Children.Add(path)
					CType(sender, Button).Content = "Update"
					IsInsert = Not IsInsert
				Else
					Dim gbUpdate As GeometryBase = GeometryFactory(CType((CType(sender, Button)).Parent, FrameworkElement))
					currentElement.Data = gbUpdate.CreateGeometry()
					UpdateControlPoints(gbUpdate.controlPoints)
				End If
			Catch argExcept As ApplicationException
				MessageBox.Show(argExcept.Message)
			End Try

		End Sub
		#End Region

		' ---------------------------------------------------------------------------------
		#Region "Drag and Move"
		'Special variable for Drag and move actions
		Private IsMoving As Boolean = False
		Private movingPreviousLocation As Point



		Private Sub Ellipse_MouseLeftButtonDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
			Dim el As Ellipse = CType(sender, Ellipse)
			el.Cursor = System.Windows.Input.Cursors.Hand
			IsMoving = True
			movingPreviousLocation = e.GetPosition(DrawingPane)
		End Sub

		Private Sub Ellipse_MouseLeftButtonUp(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
			Dim el As Ellipse = CType(sender, Ellipse)
			el.Cursor = System.Windows.Input.Cursors.Arrow
			IsMoving = False
		End Sub


		Private Sub Ellipse_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
			Dim el As Ellipse = CType(sender, Ellipse)
			Dim movingEndLocation As Point
			If IsMoving Then
				movingEndLocation = e.GetPosition(DrawingPane)


                Canvas.SetLeft(el, movingEndLocation.X - el.Width / 2)
                Canvas.SetTop(el, movingEndLocation.Y - el.Height / 2)

				UpdateGeometries(movingEndLocation, el.Name)
				movingPreviousLocation = movingEndLocation
			End If
		End Sub
		#End Region
		' ---------------------------------------------------------------------------------
		#Region "private helper functions"
		Private Sub UpdateControlPoints(ByVal controlPoints As ArrayList)
			Dim GeometryType As String = GetGeometryTypeInID(currentElement.Name)

			Select Case GeometryType
				Case "Line"
					UpdateLineGeometryControlPoints(controlPoints)
				Case "Ellipse"
					UpdateEllipseGeometryControlPoints(controlPoints)
				Case "Rectangle"
					UpdateRectangleGeometryControlPoints(controlPoints)
				Case "Arc"
					UpdateArcGeometryControlPoints(controlPoints)
				Case "Bezier"
					UpdateBezierGeometryControlPoints(controlPoints)
				Case Else
					Throw New System.ApplicationException("Error: incorrect Element name")
			End Select
		End Sub


		Private Sub UpdateLineGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 2 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for LineGeometry")
			End If

			For i As Integer = 0 To controlPoints.Count - 1
				Select Case i
					Case 0
						Dim eStartPoint As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_StartPoint"), Ellipse)
                        Canvas.SetLeft(eStartPoint, (CType(controlPoints(i), Point)).X - eStartPoint.Width / 2)
                        Canvas.SetTop(eStartPoint, (CType(controlPoints(i), Point)).Y - eStartPoint.Height / 2)
					Case 1
						Dim eEndPoint As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_EndPoint"), Ellipse)
                        Canvas.SetLeft(eEndPoint, (CType(controlPoints(i), Point)).X - eEndPoint.Width / 2)
                        Canvas.SetTop(eEndPoint, (CType(controlPoints(i), Point)).Y - eEndPoint.Height / 2)
					Case Else
						Throw New System.ApplicationException("Error: incorrect # of control points in LineG")
				End Select
			Next i
		End Sub

		Private Sub UpdateEllipseGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 5 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for EllipseGeometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Select Case i
					Case 0
						Dim eCenter As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_Center"), Ellipse)
                        Canvas.SetLeft(eCenter, (CType(controlPoints(i), Point)).X - eCenter.Width / 2)
                        Canvas.SetTop(eCenter, (CType(controlPoints(i), Point)).Y - eCenter.Height / 2)
					Case 1
						Dim eTopLeft As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_TopLeft"), Ellipse)
                        Canvas.SetLeft(eTopLeft, (CType(controlPoints(i), Point)).X - eTopLeft.Width / 2)
                        Canvas.SetTop(eTopLeft, (CType(controlPoints(i), Point)).Y - eTopLeft.Height / 2)
					Case 2
						Dim eTopMiddle As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_TopMiddle"), Ellipse)
                        Canvas.SetLeft(eTopMiddle, (CType(controlPoints(i), Point)).X - eTopMiddle.Width / 2)
                        Canvas.SetTop(eTopMiddle, (CType(controlPoints(i), Point)).Y - eTopMiddle.Height / 2)
					Case 3
						Dim eTopRight As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_TopRight"), Ellipse)
                        Canvas.SetLeft(eTopRight, (CType(controlPoints(i), Point)).X - eTopRight.Width / 2)
                        Canvas.SetTop(eTopRight, (CType(controlPoints(i), Point)).Y - eTopRight.Height / 2)
					Case 4
						Dim eBottomMiddle As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_BottomMiddle"), Ellipse)
                        Canvas.SetLeft(eBottomMiddle, (CType(controlPoints(i), Point)).X - eBottomMiddle.Width / 2)
                        Canvas.SetTop(eBottomMiddle, (CType(controlPoints(i), Point)).Y - eBottomMiddle.Height / 2)
					Case Else
						Throw New System.ApplicationException("Error: incorrect # of control points in EllipseG")
				End Select

			Next i
		End Sub

		Private Sub UpdateRectangleGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 5 AndAlso controlPoints.Count <> 4 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for RectangleGeometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Select Case i
					Case 0
						Dim eTopLeft As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_TopLeft"), Ellipse)
                        Canvas.SetLeft(eTopLeft, (CType(controlPoints(i), Point)).X - eTopLeft.Width / 2)
                        Canvas.SetTop(eTopLeft, (CType(controlPoints(i), Point)).Y - eTopLeft.Height / 2)
					Case 1
						Dim eTopRight As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_TopRight"), Ellipse)
                        Canvas.SetLeft(eTopRight, (CType(controlPoints(i), Point)).X - eTopRight.Width / 2)
                        Canvas.SetTop(eTopRight, (CType(controlPoints(i), Point)).Y - eTopRight.Height / 2)
					Case 2
						Dim eBottomLeft As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_BottomLeft"), Ellipse)
                        Canvas.SetLeft(eBottomLeft, (CType(controlPoints(i), Point)).X - eBottomLeft.Width / 2)
                        Canvas.SetTop(eBottomLeft, (CType(controlPoints(i), Point)).Y - eBottomLeft.Height / 2)
					Case 3
						Dim eBottomRight As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_BottomRight"), Ellipse)
                        Canvas.SetLeft(eBottomRight, (CType(controlPoints(i), Point)).X - eBottomRight.Width / 2)
                        Canvas.SetTop(eBottomRight, (CType(controlPoints(i), Point)).Y - eBottomRight.Height / 2)
					Case 4
						Dim eCorner As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_Corner"), Ellipse)
                        Canvas.SetLeft(eCorner, (CType(controlPoints(i), Point)).X - eCorner.Width / 2)
                        Canvas.SetTop(eCorner, (CType(controlPoints(i), Point)).Y - eCorner.Height / 2)
					Case Else
						Throw New System.ApplicationException("Error: incorrect # of control points in RectangleG")
				End Select
			Next i
		End Sub

		Private Sub UpdateArcGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 2 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for Arc Geometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Select Case i
					Case 0
						Dim eStartPoint As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_StartPoint"), Ellipse)
                        Canvas.SetLeft(eStartPoint, (CType(controlPoints(i), Point)).X - eStartPoint.Width / 2)
                        Canvas.SetTop(eStartPoint, (CType(controlPoints(i), Point)).Y - eStartPoint.Height / 2)
					Case 1
						Dim ePoint1 As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_Point"), Ellipse)
                        Canvas.SetLeft(ePoint1, (CType(controlPoints(i), Point)).X - ePoint1.Width / 2)
                        Canvas.SetTop(ePoint1, (CType(controlPoints(i), Point)).Y - ePoint1.Height / 2)
					Case Else
						Throw New System.ApplicationException("Error: Incorrect # of control points in ArcG")
				End Select
			Next i
		End Sub

		Private Sub UpdateBezierGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 4 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for Bezier Geometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Select Case i
					Case 0
						Dim eStartPoint As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_StartPoint"), Ellipse)
                        Canvas.SetLeft(eStartPoint, (CType(controlPoints(i), Point)).X - eStartPoint.Width / 2)
                        Canvas.SetTop(eStartPoint, (CType(controlPoints(i), Point)).Y - eStartPoint.Height / 2)
					Case 1
						Dim ePoint1 As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_Point1"), Ellipse)
                        Canvas.SetLeft(ePoint1, (CType(controlPoints(i), Point)).X - ePoint1.Width / 2)
                        Canvas.SetTop(ePoint1, (CType(controlPoints(i), Point)).Y - ePoint1.Height / 2)
					Case 2
						Dim ePoint2 As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_Point2"), Ellipse)
                        Canvas.SetLeft(ePoint2, (CType(controlPoints(i), Point)).X - ePoint2.Width / 2)
                        Canvas.SetTop(ePoint2, (CType(controlPoints(i), Point)).Y - ePoint2.Height / 2)
					Case 3
						Dim ePoint3 As Ellipse = TryCast(LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name & "_Point3"), Ellipse)
                        Canvas.SetLeft(ePoint3, (CType(controlPoints(i), Point)).X - ePoint3.Width / 2)
                        Canvas.SetTop(ePoint3, (CType(controlPoints(i), Point)).Y - ePoint3.Height / 2)
					Case Else
						Throw New ApplicationException("Error: incorrect # of control points in BezierG")
				End Select
			Next i
		End Sub

		Private Sub UpdateGeometries(ByVal movingEndLocation As Point, ByVal ID As String)
			Dim GeometryType As String = GetGeometryTypeInID(ID)

			'Switch the controlpoint pane to the right panel
			GeometryPaneChange(GeometryType, False)

			Select Case GeometryType
				Case "Line"
					UpdateLineGeometry(movingEndLocation, ID)
				Case "Ellipse"
					UpdateEllipseGeometry(movingEndLocation, ID)
				Case "Rectangle"
					UpdateRectangleGeometry(movingEndLocation, ID)
				Case "Bezier"
					UpdateBezierGeometry(movingEndLocation, ID)
				Case "Arc"
					UpdateArcGeometry(movingEndLocation, ID)
				Case Else
					Throw New System.ApplicationException("Error: incorrect GeometryType in UpdateGeometries()")
			End Select
		End Sub

		Private Function SearchUpdatedElement(ByVal p As String) As Object
			For Each o As Object In DrawingPane.Children
				If TypeOf o Is Path AndAlso (CType(o, Path)).Name = p Then
					Return o
				End If
			Next o
			Return Nothing
		End Function

		Private Sub UpdateArcGeometry(ByVal movingEndLocation As Point, ByVal ID As String)
			Dim s() As String = ID.Split("_"c)
			Dim controlPointType As String = GetContronPointTypeInID(ID)
			Dim p As Path = TryCast(SearchUpdatedElement(s(0)), Path)
			If p Is Nothing Then
				Throw New System.ApplicationException("Error: incorrect geometry ID")
			End If
			currentElement = p
			Dim pg As PathGeometry = TryCast(p.Data, PathGeometry)
			Dim pf As PathFigure = pg.Figures(0)

			Select Case controlPointType
				Case "StartPoint"
					pf.StartPoint = movingEndLocation
					ArcStartPoint.Text = movingEndLocation.X & " " & movingEndLocation.Y
				Case "Point"
					CType(pf.Segments(0), ArcSegment).Point = movingEndLocation
					ArcPoint.Text = movingEndLocation.X & " " & movingEndLocation.Y
				Case Else
					Throw New System.ApplicationException("Error: incorrect control point type")
			End Select

			p.Data = pg
			Dim xamlstring As String = System.Windows.Markup.XamlWriter.Save(DrawingPane)
			CType(XAMLPane.Children(0), TextBox).Text = xamlstring
		End Sub

		Private Sub UpdateLineGeometry(ByVal movingEndLocation As Point, ByVal ID As String)
			Dim s() As String = ID.Split("_"c)
			Dim controlPointType As String = GetContronPointTypeInID(ID)
			Dim p As Path = TryCast(SearchUpdatedElement(s(0)), Path)
			If p Is Nothing Then
				Throw New System.ApplicationException("Error: incorrect geometry ID")
			End If
			currentElement = p
			Dim lg As LineGeometry = TryCast(p.Data, LineGeometry)

			Select Case controlPointType
				Case "StartPoint"
					LineStartPoint.Text = movingEndLocation.X & " " & movingEndLocation.Y
					lg.StartPoint = movingEndLocation

				Case "EndPoint"
					LineEndPoint.Text = movingEndLocation.X & " " & movingEndLocation.Y
					lg.EndPoint = movingEndLocation

				Case Else
					Throw New System.ApplicationException("Error: Incorrect controlpoint type, '" & controlPointType & "' in UpdateLineGeometry()")
			End Select
			Dim xamlstring As String = System.Windows.Markup.XamlWriter.Save(DrawingPane)
			CType(XAMLPane.Children(0), TextBox).Text = xamlstring
		End Sub

		Private Sub UpdateEllipseGeometry(ByVal movingEndLocation As Point, ByVal ID As String)


			Dim s() As String = ID.Split("_"c)
			Dim controlPointType As String = GetContronPointTypeInID(ID)
			Dim p As Path = TryCast(SearchUpdatedElement(s(0)), Path)
			If p Is Nothing Then
				Throw New System.ApplicationException("Error: incorrect geometry ID")
			End If
			currentElement = p
			Dim eg As EllipseGeometry = TryCast(p.Data.Clone(), EllipseGeometry)
			Dim diffX As Double = movingEndLocation.X - eg.Center.X
			Dim diffY As Double = movingEndLocation.Y - eg.Center.Y

			Dim radians, angle As Double
			radians = Math.Atan2(diffY, diffX)
			angle = radians * (180 / Math.PI)

			Select Case controlPointType
				Case "Center"
					eg.Center = movingEndLocation

					'Update the center in the RotateTransform when the ellipsegeometry's center is moved
					If eg.Transform IsNot Nothing AndAlso TypeOf eg.Transform Is RotateTransform Then
						Dim rtWithNewCenter As RotateTransform = TryCast(eg.Transform, RotateTransform)
						rtWithNewCenter.CenterX = eg.Center.X
						rtWithNewCenter.CenterY = eg.Center.Y
					End If
					For Each o As Object In DesignerPane.Children
						If TypeOf o Is Ellipse AndAlso (CType(o, Ellipse)).Name.Contains(s(0)) AndAlso (CType(o, Ellipse)).Name <> s(0) Then
							Canvas.SetLeft((CType(o, Ellipse)), Canvas.GetLeft((CType(o, Ellipse))) + diffX)
							Canvas.SetTop((CType(o, Ellipse)), Canvas.GetTop((CType(o, Ellipse))) + diffY)
						End If
					Next o
					p.Data = eg

					EllipseCenterPoint.Text = eg.Center.X & " " & eg.Center.Y

				Case "TopLeft"
					Dim v0 As New Vector(-eg.RadiusX, 0)
					Dim v1 As New Vector(diffX, diffY)

					Dim rt_TopLeft As New RotateTransform(angle + 180, eg.Center.X, eg.Center.Y)
					eg.Transform = rt_TopLeft
					eg.RadiusX = v1.Length
					EllipseRadiusX.Text = v1.Length.ToString()
					p.Data = eg

					'Update the TopRight control point for this EllipseGeometry
					Dim e_TopRight As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopRight"), Ellipse)
                    Canvas.SetLeft(e_TopRight, (eg.Center.X - diffX) - e_TopRight.Width / 2)
                    Canvas.SetTop(e_TopRight, (eg.Center.Y - diffY) - e_TopRight.Height / 2)

					Dim e_TopMiddle As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopMiddle"), Ellipse)
                    Canvas.SetLeft(e_TopMiddle, (eg.Center.X - diffY * eg.RadiusY / v1.Length) - e_TopMiddle.Width / 2)
                    Canvas.SetTop(e_TopMiddle, eg.Center.Y + diffX * eg.RadiusY / v1.Length - e_TopMiddle.Height / 2)

					Dim e_BottomMiddle As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_BottomMiddle"), Ellipse)
                    Canvas.SetLeft(e_BottomMiddle, (eg.Center.X + diffY * eg.RadiusY / v1.Length) - e_BottomMiddle.Width / 2)
                    Canvas.SetTop(e_BottomMiddle, (eg.Center.Y - diffX * eg.RadiusY / v1.Length) - e_BottomMiddle.Height / 2)

				Case "TopMiddle"
					Dim v1_TopMiddle As New Vector(diffX, diffY)
					Dim rt_TopMiddle As New RotateTransform(angle + 90, eg.Center.X, eg.Center.Y)
					eg.Transform = rt_TopMiddle
					eg.RadiusY = v1_TopMiddle.Length
					EllipseRadiusY.Text = v1_TopMiddle.Length.ToString()
					p.Data = eg

					Dim e_TopLeft2 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopLeft"), Ellipse)
                    Canvas.SetLeft(e_TopLeft2, (eg.Center.X + diffY * eg.RadiusX / v1_TopMiddle.Length) - e_TopLeft2.Width / 2)
                    Canvas.SetTop(e_TopLeft2, (eg.Center.Y - diffX * eg.RadiusX / v1_TopMiddle.Length) - e_TopLeft2.Height / 2)

					Dim e_TopRight2 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopRight"), Ellipse)
                    Canvas.SetLeft(e_TopRight2, (eg.Center.X - diffY * eg.RadiusX / v1_TopMiddle.Length) - e_TopRight2.Width / 2)
                    Canvas.SetTop(e_TopRight2, (eg.Center.Y + diffX * eg.RadiusX / v1_TopMiddle.Length) - e_TopRight2.Height / 2)

					Dim e_BottomMiddle2 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_BottomMiddle"), Ellipse)
                    Canvas.SetLeft(e_BottomMiddle2, (eg.Center.X - diffX) - e_BottomMiddle2.Width / 2)
                    Canvas.SetTop(e_BottomMiddle2, (eg.Center.Y - diffY) - e_BottomMiddle2.Height / 2)

				Case "TopRight"
					Dim v1_TopRight As New Vector(diffX, diffY)
					Dim rt_TopRight As New RotateTransform(angle, eg.Center.X, eg.Center.Y)
					eg.Transform = rt_TopRight
					eg.RadiusX = v1_TopRight.Length
					EllipseRadiusX.Text = v1_TopRight.Length.ToString()
					p.Data = eg

					Dim e_TopLeft3 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopLeft"), Ellipse)
                    Canvas.SetLeft(e_TopLeft3, (eg.Center.X - diffX) - e_TopLeft3.Width / 2)
                    Canvas.SetTop(e_TopLeft3, (eg.Center.Y - diffY) - e_TopLeft3.Height / 2)

					Dim e_TopMiddle3 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopMiddle"), Ellipse)
                    Canvas.SetLeft(e_TopMiddle3, (eg.Center.X + diffY * eg.RadiusY / v1_TopRight.Length) - e_TopMiddle3.Width / 2)
                    Canvas.SetTop(e_TopMiddle3, (eg.Center.Y - diffX * eg.RadiusY / v1_TopRight.Length) - e_TopMiddle3.Height / 2)

					Dim e_BottomMiddle3 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_BottomMiddle"), Ellipse)
                    Canvas.SetLeft(e_BottomMiddle3, (eg.Center.X - diffY * eg.RadiusY / v1_TopRight.Length) - e_BottomMiddle3.Width / 2)
                    Canvas.SetTop(e_BottomMiddle3, (eg.Center.Y + diffX * eg.RadiusY / v1_TopRight.Length) - e_BottomMiddle3.Height / 2)

				Case "BottomMiddle"
					Dim v1_BottomMiddle As New Vector(diffX, diffY)
					Dim rt_BottomMiddle As New RotateTransform(angle - 90, eg.Center.X, eg.Center.Y)
					eg.Transform = rt_BottomMiddle
					eg.RadiusY = v1_BottomMiddle.Length
					EllipseRadiusY.Text = v1_BottomMiddle.Length.ToString()
					p.Data = eg

					Dim e_TopLeft4 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopLeft"), Ellipse)
                    Canvas.SetLeft(e_TopLeft4, (eg.Center.X - diffY * eg.RadiusX / v1_BottomMiddle.Length) - e_TopLeft4.Width / 2)
                    Canvas.SetTop(e_TopLeft4, (eg.Center.Y + diffX * eg.RadiusX / v1_BottomMiddle.Length) - e_TopLeft4.Height / 2)

					Dim e_TopRight4 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopRight"), Ellipse)
                    Canvas.SetLeft(e_TopRight4, (eg.Center.X + diffY * eg.RadiusX / v1_BottomMiddle.Length) - e_TopRight4.Width / 2)
                    Canvas.SetTop(e_TopRight4, (eg.Center.Y - diffX * eg.RadiusX / v1_BottomMiddle.Length) - e_TopRight4.Height / 2)

					Dim e_TopMiddle4 As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopMiddle"), Ellipse)
                    Canvas.SetLeft(e_TopMiddle4, (eg.Center.X - diffX) - e_TopMiddle4.Width / 2)
                    Canvas.SetTop(e_TopMiddle4, (eg.Center.Y - diffY) - e_TopMiddle4.Height / 2)

				Case Else
					Throw New System.ApplicationException("Error: incorrect EllipseGeometry controlpoint type")
			End Select
			Dim xamlstring As String = System.Windows.Markup.XamlWriter.Save(DrawingPane)
			CType(XAMLPane.Children(0), TextBox).Text = xamlstring
		End Sub

		Private Sub UpdateRectangleGeometry(ByVal movingEndLocation As Point, ByVal ID As String)

			Dim width, height As Double
			Dim s() As String = ID.Split("_"c)
			Dim controlPointType As String = GetContronPointTypeInID(ID)
			Dim p As Path = TryCast(SearchUpdatedElement(s(0)), Path)
			If p Is Nothing Then
				Throw New System.ApplicationException("Error:  incorrect geometry ID")
			End If
			currentElement = p
			Dim rg As RectangleGeometry = TryCast(p.Data, RectangleGeometry)

			'Get all of the related control points in DesignerPane
			Dim r_TopLeft As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopLeft"), Ellipse)
			Dim r_TopRight As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_TopRight"), Ellipse)
			Dim r_BottomLeft As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_BottomLeft"), Ellipse)
			Dim r_BottomRight As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_BottomRight"), Ellipse)
			Dim r_Corner As Ellipse = CType(LogicalTreeHelper.FindLogicalNode(DesignerPane, s(0) & "_Corner"), Ellipse)


			Select Case controlPointType
				Case "TopLeft"
					width = rg.Rect.Width + (rg.Rect.X - movingEndLocation.X)
					height = rg.Rect.Height + (rg.Rect.Y - movingEndLocation.Y)
					RectangleWidth.Text = width.ToString()
					RectangleHeight.Text = height.ToString()

					'Update the RectangleGeometry.
					rg.Rect = New Rect(movingEndLocation.X, movingEndLocation.Y, width, height)

					'Update the control points
                    Canvas.SetLeft(r_TopRight, (movingEndLocation.X + width) - r_TopRight.Width / 2)
                    Canvas.SetTop(r_TopRight, (movingEndLocation.Y) - r_TopRight.Height / 2)
                    Canvas.SetLeft(r_BottomLeft, movingEndLocation.X - r_BottomLeft.Width / 2)

					If r_Corner IsNot Nothing Then
                        Canvas.SetLeft(r_Corner, movingEndLocation.X + rg.RadiusX - r_Corner.Width / 2)
                        Canvas.SetTop(r_Corner, movingEndLocation.Y + rg.RadiusY - r_Corner.Height / 2)
					End If

					RectangleTopLeftPoint.Text = movingEndLocation.X & " " & movingEndLocation.Y
				Case "TopRight"
					width = movingEndLocation.X - rg.Rect.X
					height = (rg.Rect.Y + rg.Rect.Height) - movingEndLocation.Y
					RectangleWidth.Text = width.ToString()
					RectangleHeight.Text = height.ToString()

					'Update the control points
                    Canvas.SetTop(r_TopLeft, movingEndLocation.Y - r_TopLeft.Height / 2)
                    Canvas.SetLeft(r_BottomRight, movingEndLocation.X - r_BottomRight.Width / 2)

					If r_Corner IsNot Nothing Then
                        Canvas.SetTop(r_Corner, Canvas.GetTop(r_Corner) + (movingEndLocation.Y - rg.Rect.Y) - r_Corner.Height / 2)
					End If

					'Update the RectangleGeometry
                    rg.Rect = New Rect(Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2, Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2, width, height)

					'Update the TopLeft control field
					RectangleTopLeftPoint.Text = movingEndLocation.X & " " & movingEndLocation.Y

				Case "BottomLeft"

					width = rg.Rect.Width + (rg.Rect.X - movingEndLocation.X)
					height = movingEndLocation.Y - rg.Rect.Y
					RectangleWidth.Text = width.ToString()
					RectangleHeight.Text = height.ToString()

					'Update the control points
                    Canvas.SetLeft(r_TopLeft, movingEndLocation.X - r_TopLeft.Width / 2)
                    Canvas.SetLeft(r_BottomRight, movingEndLocation.X + width - r_BottomRight.Width / 2)
                    Canvas.SetTop(r_BottomRight, movingEndLocation.Y - r_BottomRight.Height / 2)

					If r_Corner IsNot Nothing Then
                        Canvas.SetLeft(r_Corner, movingEndLocation.X + rg.RadiusX - r_Corner.Width / 2)
					End If

                    RectangleTopLeftPoint.Text = Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2 & " " & Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2

					'Update the RectangleGeometry
                    rg.Rect = New Rect(Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2, Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2, width, height)


				Case "BottomRight"
					width = movingEndLocation.X - rg.Rect.X
					height = movingEndLocation.Y - rg.Rect.Y
					RectangleWidth.Text = width.ToString()
					RectangleHeight.Text = height.ToString()

					'Update the control points
                    Canvas.SetLeft(r_TopRight, movingEndLocation.X - r_TopRight.Width / 2)
                    Canvas.SetTop(r_BottomLeft, movingEndLocation.Y - r_BottomLeft.Height / 2)

					'Update the RectangleGeometry
                    rg.Rect = New Rect(Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2, Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2, width, height)

					p.Data = rg
				Case "Corner"
					Dim radiusx As Double = movingEndLocation.X - rg.Rect.X
					Dim radiusy As Double = movingEndLocation.Y - rg.Rect.Y

					If radiusx <= 0 Then
						Canvas.SetLeft(r_Corner, rg.Rect.X + 0.1 - r_Corner.Width)
						radiusx = 0.1
					End If
					If radiusy <= 0 Then
                        Canvas.SetTop(r_Corner, rg.Rect.Y + 0.1 - r_Corner.Height / 2)
						radiusy = 0.1
					End If

					RectangleWidth.Text = radiusx.ToString()
					RectangleHeight.Text = radiusy.ToString()

					rg.RadiusX = radiusx
					rg.RadiusY = radiusy

					p.Data = rg
				Case Else
					Throw New System.ApplicationException("Error: Incorrect control point type")
			End Select
			Dim xamlstring As String = System.Windows.Markup.XamlWriter.Save(DrawingPane)
			CType(XAMLPane.Children(0), TextBox).Text = xamlstring
		End Sub

		Private Sub UpdateBezierGeometry(ByVal movingEndLocation As Point, ByVal ID As String)
			Dim s() As String = ID.Split("_"c)
			Dim controlPointType As String = GetContronPointTypeInID(ID)
			Dim p As Path = TryCast(SearchUpdatedElement(s(0)), Path)
			If p Is Nothing Then
				Throw New System.ApplicationException("Error:  incorrect geometry ID")
			End If
			currentElement = p
			Dim pg As PathGeometry = TryCast(p.Data.Clone(), PathGeometry)
			Dim pf As PathFigure = pg.Figures(0)
			Select Case controlPointType
				Case "StartPoint"
					pf.StartPoint = movingEndLocation
					BezierStartPoint.Text = movingEndLocation.X & " " & movingEndLocation.Y
				Case "Point1"
					BezierPoint1.Text = movingEndLocation.X & " " & movingEndLocation.Y
					CType(pf.Segments(0), BezierSegment).Point1 = movingEndLocation
				Case "Point2"
					BezierPoint2.Text = movingEndLocation.X & " " & movingEndLocation.Y
					CType(pf.Segments(0), BezierSegment).Point2 = movingEndLocation
				Case "Point3"
					BezierPoint3.Text = movingEndLocation.X & " " & movingEndLocation.Y
					CType(pf.Segments(0), BezierSegment).Point3 = movingEndLocation
				Case Else
					Throw New System.ApplicationException("Error:  Incorrect control point type")
			End Select

			p.Data = pg
			Dim xamlstring As String = System.Windows.Markup.XamlWriter.Save(DrawingPane)
			CType(XAMLPane.Children(0), TextBox).Text = xamlstring
		End Sub

		Private Function GetContronPointTypeInID(ByVal ID As String) As String
			Dim s() As String = ID.Split("_"c)
			Return s(1)
		End Function

		Private Function GetGeometryTypeInID(ByVal ID As String) As String
			Dim s() As String = ID.Split("_"c)
			If s(0).Contains("Line") Then
				Return "Line"
			Else
				If s(0).Contains("Ellipse") Then
					Return "Ellipse"
				Else
					If s(0).Contains("Rectangle") Then
						Return "Rectangle"
					Else
						If s(0).Contains("Arc") Then
							Return "Arc"
						Else
							Return "Bezier"
						End If
					End If
				End If
			End If
		End Function

		Private Function GetControlPointName(ByVal ID As String) As String
			Return Nothing
		End Function

		Private Sub AddControlPoints(ByVal controlPoints As ArrayList, ByVal geometryType As String)
			Select Case geometryType
				Case "Line"
					AddLineGeometryControlPoints(controlPoints)
				Case "Ellipse"
					AddEllipseGeometryControlPoints(controlPoints)
				Case "Rectangle"
					AddRectangleGeometryControlPoints(controlPoints)
				Case "Arc"
					AddArcGeometryControlPoints(controlPoints)
				Case "Bezier"
					AddBezierGeometryControlPoints(controlPoints)
				Case Else
					Throw New System.ApplicationException("Error:  incorrect Geometry type")
			End Select
		End Sub


		Private Shared ControlPointMarkerWidth As Double = 20
		Private Shared ControlPointMarkerHeight As Double = 20

		Private Sub AddLineGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 2 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for LineGeometry")
			End If

			For i As Integer = 0 To controlPoints.Count - 1
				Dim e As New Ellipse()
				e.Visibility = Visibility.Hidden
				e.Stroke = Brushes.Black
				e.StrokeThickness = 1
				e.Fill = Brushes.White
				e.Opacity = 0.5
				e.Width = 3
				e.Height = 3

				If i = 0 Then
					e.Name = "Line" & LineCount & "_StartPoint"
				Else
					e.Name = "Line" & LineCount & "_EndPoint"
				End If

				e.Width = ControlPointMarkerWidth
				e.Height = ControlPointMarkerHeight
                Canvas.SetLeft(e, (CType(controlPoints(i), Point)).X - e.Width / 2)
                Canvas.SetTop(e, (CType(controlPoints(i), Point)).Y - e.Height / 2)


				AddHandler e.MouseLeftButtonDown, AddressOf Ellipse_MouseLeftButtonDown
				AddHandler e.MouseLeftButtonUp, AddressOf Ellipse_MouseLeftButtonUp
				AddHandler e.MouseMove, AddressOf Ellipse_MouseMove

				'Add the control point to the Designer Pane
				'DesignerPane.Children.Add(e)
				DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e)
			Next i

		End Sub

		Private Sub AddEllipseGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 5 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for EllipseGeometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Dim e As New Ellipse()
				e.Visibility = Visibility.Hidden
				e.Stroke = Brushes.Black
				e.StrokeThickness = 1
				e.Fill = Brushes.White
				e.Opacity = 0.5
				e.Width = 3
				e.Height = 3

				Select Case i
					Case 0
						e.Name = "Ellipse" & ElliipseCount & "_Center"
					Case 1
						e.Name = "Ellipse" & ElliipseCount & "_TopLeft"
					Case 2
						e.Name = "Ellipse" & ElliipseCount & "_TopMiddle"
					Case 3
						e.Name = "Ellipse" & ElliipseCount & "_TopRight"
					Case 4
						e.Name = "Ellipse" & ElliipseCount & "_BottomMiddle"
					Case Else
						Throw New System.ApplicationException("Error: Incorrect control point ")
				End Select

				e.Width = ControlPointMarkerWidth
				e.Height = ControlPointMarkerHeight
                Canvas.SetLeft(e, (CType(controlPoints(i), Point)).X - e.Width / 2)
                Canvas.SetTop(e, (CType(controlPoints(i), Point)).Y - e.Height / 2)

				AddHandler e.MouseLeftButtonDown, AddressOf Ellipse_MouseLeftButtonDown
				AddHandler e.MouseLeftButtonUp, AddressOf Ellipse_MouseLeftButtonUp
				AddHandler e.MouseMove, AddressOf Ellipse_MouseMove

				'Add the control point to the Designer Pane
				DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e)
			Next i
		End Sub

		Private Sub AddRectangleGeometryControlPoints(ByVal controlPoints As ArrayList)

			If controlPoints.Count <> 5 AndAlso controlPoints.Count <> 4 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for RectangleGeometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Dim e As New Ellipse()
				e.Visibility = Visibility.Hidden
				e.Stroke = Brushes.Black
				e.StrokeThickness = 1
				e.Fill = Brushes.White
				e.Opacity = 0.5
				e.Width = 3
				e.Height = 3

				Select Case i
					Case 0
						e.Name = "Rectangle" & RectangleCount & "_TopLeft"
					Case 1
						e.Name = "Rectangle" & RectangleCount & "_TopRight"
					Case 2
						e.Name = "Rectangle" & RectangleCount & "_BottomLeft"
					Case 3
						e.Name = "Rectangle" & RectangleCount & "_BottomRight"
					Case 4
						e.Name = "Rectangle" & RectangleCount & "_Corner"
					Case Else
						Throw New System.ApplicationException("Error: Incorrect control point ")
				End Select


				e.Width = ControlPointMarkerWidth
				e.Height = ControlPointMarkerHeight
                Canvas.SetLeft(e, (CType(controlPoints(i), Point)).X - e.Width / 2)
                Canvas.SetTop(e, (CType(controlPoints(i), Point)).Y - e.Height / 2)
				AddHandler e.MouseLeftButtonDown, AddressOf Ellipse_MouseLeftButtonDown
				AddHandler e.MouseLeftButtonUp, AddressOf Ellipse_MouseLeftButtonUp
				AddHandler e.MouseMove, AddressOf Ellipse_MouseMove

				'Add the control point to the Designer Pane
				DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e)

			Next i
		End Sub

		Private Sub AddArcGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 2 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for Arc Geometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Dim e As New Ellipse()
				e.Visibility = Visibility.Hidden
				e.Stroke = Brushes.Black
				e.StrokeThickness = 1
				e.Fill = Brushes.White
				e.Opacity = 0.5
				e.Width = 3
				e.Height = 3

				Select Case i
					Case 0
						e.Name = "Arc" & ArcCount & "_StartPoint"
					Case 1
						e.Name = "Arc" & ArcCount & "_Point"
					Case Else
						Throw New System.ApplicationException("Error: Incorrect control point ")
				End Select

				e.Width = ControlPointMarkerWidth
				e.Height = ControlPointMarkerHeight
                Canvas.SetLeft(e, (CType(controlPoints(i), Point)).X - e.Width / 2)
                Canvas.SetTop(e, (CType(controlPoints(i), Point)).Y - e.Height / 2)

				AddHandler e.MouseLeftButtonDown, AddressOf Ellipse_MouseLeftButtonDown
				AddHandler e.MouseLeftButtonUp, AddressOf Ellipse_MouseLeftButtonUp
				AddHandler e.MouseMove, AddressOf Ellipse_MouseMove

				'Add the control point to the Designer Pane
				'DesignerPane.Children.Insert(DesignerPane.Children.Count - 2, e)
				DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e)

			Next i
		End Sub

		Private Sub AddBezierGeometryControlPoints(ByVal controlPoints As ArrayList)
			If controlPoints.Count <> 4 Then
				Throw New System.ApplicationException("Error:  incorrect # of control points for Bezier Geometry")
			End If
			For i As Integer = 0 To controlPoints.Count - 1
				Dim e As New Ellipse()
				e.Visibility = Visibility.Hidden
				e.Stroke = Brushes.Black
				e.StrokeThickness = 1
				e.Fill = Brushes.White
				e.Opacity = 0.5
				e.Width = 3
				e.Height = 3

				Select Case i
					Case 0
						e.Name = "Bezier" & BezierCount & "_StartPoint"
					Case 1
						e.Name = "Bezier" & BezierCount & "_Point1"
					Case 2
						e.Name = "Bezier" & BezierCount & "_Point2"
					Case 3
						e.Name = "Bezier" & BezierCount & "_Point3"
					Case Else
						Throw New System.ApplicationException("Error: Incorrect control point ")
				End Select

				e.Width = ControlPointMarkerWidth
				e.Height = ControlPointMarkerHeight
                Canvas.SetLeft(e, (CType(controlPoints(i), Point)).X - e.Width / 2)
                Canvas.SetTop(e, (CType(controlPoints(i), Point)).Y - e.Height / 2)
				AddHandler e.MouseLeftButtonDown, AddressOf Ellipse_MouseLeftButtonDown
				AddHandler e.MouseLeftButtonUp, AddressOf Ellipse_MouseLeftButtonUp
				AddHandler e.MouseMove, AddressOf Ellipse_MouseMove

				'Add the control point to the Designer Pane
				DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e)
			Next i

		End Sub

		''' <summary>
		''' The function takes the design pane element,e.g. LinePane, RectanglePane, 
		''' and extract the value from the different control point fields from the pane and construct 
		''' a Path with the correct Geometry
		''' </summary>
		''' <param name="pane"></param>
		''' <returns></returns>
		Private Function GeometryFactory(ByVal pane As FrameworkElement) As GeometryBase

			Select Case pane.Name.Remove(pane.Name.LastIndexOf("Pane"))
				Case "Line"
					Return New LineG(pane)
				Case "Ellipse"
					Return New EllipseG(pane)
				Case "Rectangle"
					Return New RectanlgeG(pane)
				Case "Arc"
					Return New ArcG(pane)
				Case "Bezier"
					Return New BezierG(pane)
				Case Else
					Throw New System.ApplicationException("Error:  Unknow Geometry name?")
			End Select

		End Function
		#End Region

		#Region "Data members"
		Private InitialSelection As Boolean = True
		Private LineCount As Integer = 1
		Private ElliipseCount As Integer = 1
		Private RectangleCount As Integer = 1
		Private ArcCount As Integer = 1
		Private BezierCount As Integer = 1
		Private IsShow As Boolean = False
		Private currentElement As Path = Nothing
		Private IsInsert As Boolean = True
		#End Region

		Public MustInherit Class GeometryBase
			Public Sub New(ByVal pane As FrameworkElement)
				parentPane = pane
			End Sub

			Public MustOverride Sub Parse()
			Public MustOverride Function CreateGeometry() As Geometry

			Protected Function doubleParser(ByVal s As String) As Double

				Return Double.Parse(s)
			End Function

			Protected Function pointParser(ByVal o As String) As Point

				Try

					Return Point.Parse(o)


				Catch ex As Exception
					MessageBox.Show(ex.ToString())
					Throw New System.ApplicationException("Error: please enter two numeric values separated  by a comma or a space; for example, 10,30.")
				End Try

			End Function
			Protected Function sizeParser(ByVal o As String) As Size
				Dim retval As New Size()

				Dim sizeString() As String = o.Split(New Char() { " "c, ","c, ";"c })
				If sizeString.Length = 0 OrElse sizeString.Length <> 2 Then
					Throw New System.ApplicationException("Error: a size should contain two double that seperated by a space or ',' or ';'")
				End If

				Try
					Dim d1 As Double = Convert.ToDouble(sizeString(0), System.Globalization.CultureInfo.InvariantCulture)
					Dim d2 As Double = Convert.ToDouble(sizeString(1), System.Globalization.CultureInfo.InvariantCulture)
					retval.Width = d1
					retval.Height = d2
				Catch e1 As Exception
					Throw New System.ApplicationException("Error: please enter only two numeric values into the field")
				End Try

				Return retval
			End Function

			#Region "Data member"
			Protected parentPane As FrameworkElement
			Public controlPoints As ArrayList
			Public geometryType As String
			#End Region
		End Class

		Public Class LineG
			Inherits GeometryBase
			Public Sub New(ByVal pane As FrameworkElement)
				MyBase.New(pane)
				controlPoints = New ArrayList()
				geometryType = "Line"
				Parse()
			End Sub

			Public Overrides Sub Parse()
				Dim tb_startPoint As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "LineStartPoint"), TextBox)
				Dim tb_endPoint As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "LineEndPoint"), TextBox)

				startPoint = pointParser(tb_startPoint.Text)
				endPoint = pointParser(tb_endPoint.Text)

				controlPoints.Add(startPoint)
				controlPoints.Add(endPoint)
			End Sub

			Public Overrides Function CreateGeometry() As Geometry
				Dim lg As New LineGeometry(startPoint, endPoint)
				Return lg
			End Function

			#Region "Data members"
			Private startPoint As Point
			Private endPoint As Point
			#End Region
		End Class

		Public Class EllipseG
			Inherits GeometryBase
			Public Sub New(ByVal pane As FrameworkElement)
				MyBase.New(pane)
				controlPoints = New ArrayList()
				geometryType = "Ellipse"
				Parse()
			End Sub

			Public Overrides Sub Parse()
				Dim tb_center As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "EllipseCenterPoint"), TextBox)
				Dim tb_radiusx As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "EllipseRadiusX"), TextBox)
				Dim tb_radiusy As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "EllipseRadiusY"), TextBox)

				center = pointParser(tb_center.Text)
				radiusx = doubleParser(tb_radiusx.Text)
				radiusy = doubleParser(tb_radiusy.Text)

				'Center point
				controlPoints.Add(center)

				'TopLeft
				controlPoints.Add(New Point(center.X - radiusx, center.Y))

				'TopMiddle
				controlPoints.Add(New Point(center.X, center.Y - radiusy))

				'TopRight
				controlPoints.Add(New Point(center.X + radiusx, center.Y))

				'BottomMiddle
				controlPoints.Add(New Point(center.X, center.Y + radiusy))

			End Sub

			Public Overrides Function CreateGeometry() As Geometry
				Dim retval As New EllipseGeometry(center, radiusx, radiusy)
				Return retval
			End Function

			#Region "Data Members"
			Private center As Point
			Private radiusx As Double
			Private radiusy As Double
			#End Region
		End Class

		Public Class RectanlgeG
			Inherits GeometryBase
			Public Sub New(ByVal pane As FrameworkElement)
				MyBase.New(pane)
				controlPoints = New ArrayList()
				geometryType = "Rectangle"
				Parse()
			End Sub

			Public Overrides Function CreateGeometry() As Geometry
				Dim retval As New RectangleGeometry(New Rect(topleft.X, topleft.Y, width, height), radiusx, radiusy)

				Return retval
			End Function

			Public Overrides Sub Parse()
				Dim tb_topleft As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleTopLeftPoint"), TextBox)
				Dim tb_radiusx As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleRadiusX"), TextBox)
				Dim tb_radiusy As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleRadiusY"), TextBox)
				Dim tb_width As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleWidth"), TextBox)
				Dim tb_height As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleHeight"), TextBox)

				topleft = pointParser(tb_topleft.Text)
				radiusx = doubleParser(tb_radiusx.Text)
				radiusy = doubleParser(tb_radiusy.Text)
				width = doubleParser(tb_width.Text)
				height = doubleParser(tb_height.Text)

				'TopLeft point
				controlPoints.Add(topleft)

				'TopRight
				controlPoints.Add(New Point(topleft.X + width, topleft.Y))

				'BottomLeft
				controlPoints.Add(New Point(topleft.X, topleft.Y + height))

				'BottomRight
				controlPoints.Add(New Point(topleft.X + width, topleft.Y + height))

				If radiusx <> 0 AndAlso radiusy <> 0 Then
					controlPoints.Add(New Point(topleft.X + radiusx, topleft.Y + radiusy))
				End If

			End Sub

			#Region "Data Members"
			Private topleft As Point
			Private width As Double
			Private height As Double
			Private radiusx As Double
			Private radiusy As Double
			#End Region
		End Class

		Public Class BezierG
			Inherits GeometryBase
			Public Sub New(ByVal pane As FrameworkElement)
				MyBase.New(pane)
				controlPoints = New ArrayList()
				geometryType = "Bezier"
				Parse()
			End Sub

			Public Overrides Function CreateGeometry() As Geometry
				Dim retval As New PathGeometry()
				Dim pf As New PathFigure()
				pf.StartPoint = startpoint
				pf.Segments.Add(New BezierSegment(p1, p2, p3, True))
				retval.Figures.Add(pf)
				Return retval
			End Function

			Public Overrides Sub Parse()
				Dim tb_startpoint As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "BezierStartPoint"), TextBox)
				Dim tb_point1 As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "BezierPoint1"), TextBox)
				Dim tb_point2 As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "BezierPoint2"), TextBox)
				Dim tb_point3 As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "BezierPoint3"), TextBox)

				startpoint = pointParser(tb_startpoint.Text)
				p1 = pointParser(tb_point1.Text)
				p2 = pointParser(tb_point2.Text)
				p3 = pointParser(tb_point3.Text)

				controlPoints.Add(startpoint)
				controlPoints.Add(p1)
				controlPoints.Add(p2)
				controlPoints.Add(p3)
			End Sub

			#Region "Data Members"
			Private startpoint, p1, p2, p3 As Point
			#End Region


		End Class

		Public Class ArcG
			Inherits GeometryBase
			Public Sub New(ByVal pane As FrameworkElement)
				MyBase.New(pane)
				controlPoints = New ArrayList()
				geometryType = "Arc"
				Parse()
			End Sub

			Public Overrides Function CreateGeometry() As Geometry
				Dim retval As New PathGeometry()
				Dim pf As New PathFigure()
				pf.StartPoint = startpoint
				pf.Segments.Add(New ArcSegment(point, size, xrotation, largearc, sweepArcDirection, True))
				retval.Figures.Add(pf)
				Return retval
			End Function

			Public Overrides Sub Parse()
				Dim tb_startpoint As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "ArcStartPoint"), TextBox)
				Dim tb_point As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "ArcPoint"), TextBox)
				Dim tb_size As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "ArcSize"), TextBox)
				Dim tb_xrotation As TextBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "ArcXRotation"), TextBox)
				Dim cb_sweeparc As ComboBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "ArcSweepArc"), ComboBox)
				Dim cb_largearc As ComboBox = TryCast(LogicalTreeHelper.FindLogicalNode(parentPane, "ArcLargeArc"), ComboBox)

				startpoint = pointParser(tb_startpoint.Text)
				point = pointParser(tb_point.Text)
				size = sizeParser(tb_size.Text)
				xrotation = doubleParser(tb_xrotation.Text)
				sweepArcDirection = CType(System.Enum.Parse(GetType(SweepDirection), (CStr((CType(cb_sweeparc.SelectedItem, ComboBoxItem)).Content))), SweepDirection)

				largearc = Boolean.Parse((CType((CType(cb_largearc.SelectedItem, ComboBoxItem)).Content, String)))
				controlPoints.Add(startpoint)
				controlPoints.Add(point)
			End Sub

			#Region "Data Members"
			Private startpoint, point As Point
			Private size As Size
			Private largearc As Boolean
			Private sweepArcDirection As SweepDirection
			Private xrotation As Double
			#End Region


		End Class


	End Class


End Namespace