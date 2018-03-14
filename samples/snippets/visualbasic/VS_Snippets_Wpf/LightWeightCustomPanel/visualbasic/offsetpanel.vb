Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Threading

Namespace OffsetPanel
	Public Class MyApp
		Inherits Application

        Private _mainWindow As Window
		Private offsetPanel1 As OffsetPanel
		Private txt1 As TextBlock
		Private rect1 As Rectangle
		Private btn1 As Button
		Private border1 As Border

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			CreateAndShowMainWindow()
		End Sub

		Private Sub CreateAndShowMainWindow()
			' ********* Create the application's main Window and Border and instantiate a OffsetPanel *********
			border1 = New Border()
			border1.VerticalAlignment = VerticalAlignment.Top
			border1.HorizontalAlignment = HorizontalAlignment.Left
			border1.BorderThickness = New Thickness(2)
			border1.BorderBrush = Brushes.DarkOrange

			offsetPanel1 = New OffsetPanel()
			offsetPanel1.Width = 500
			offsetPanel1.Height = 500
			offsetPanel1.VerticalAlignment = VerticalAlignment.Stretch
			offsetPanel1.HorizontalAlignment = HorizontalAlignment.Stretch

			' ********* Add a child TextBlock Element *********         
			txt1 = New TextBlock()
			txt1.Text = "This is a line of Text within a TextBlock Element."
			txt1.Background = Brushes.Red
			OffsetPanel.SetOffsetLeft(txt1, 100)
			OffsetPanel.SetOffsetTop(txt1, 100)
			OffsetPanel.SetInflateSize(txt1, 50)
			OffsetPanel.SetShareCoordinates(txt1, True)

			' ********* Add a Button Element *********
			btn1 = New Button()
			btn1.Background = Brushes.RoyalBlue
			btn1.Content = "A Button"
			btn1.BorderBrush = Brushes.Black
			OffsetPanel.SetOffsetLeft(btn1, 100)
			OffsetPanel.SetOffsetTop(btn1, 100)
			OffsetPanel.SetInflateSize(btn1, 50)
			OffsetPanel.SetShareCoordinates(btn1, False)

			' ********* Add a child Rectangle Element ********* 
			rect1 = New Rectangle()
			rect1.Fill = Brushes.Purple
			OffsetPanel.SetOffsetLeft(rect1, 100)
			OffsetPanel.SetOffsetTop(rect1, 100)
			OffsetPanel.SetInflateSize(rect1, 10)
			OffsetPanel.SetShareCoordinates(rect1, False)

			' ********* Add the text element defined above as a child of the OffsetPanel *********
			offsetPanel1.Children.Add(txt1)
			offsetPanel1.Children.Add(btn1)
			offsetPanel1.Children.Add(rect1)

			' ********* Add the OffsetPanel to the Border *********
			border1.Child = offsetPanel1

			' ********* Add the OffsetPanel as a Child of the MainWindow and show the Window *********
            _mainWindow = New Window()
            _mainWindow.Content = border1
            _mainWindow.Title = "Custom OffsetPanel Sample"
            _mainWindow.Show()
		End Sub

		' Define the custom OffsetPanel class, derived from Panel

		Public Class OffsetPanel
			Inherits Panel

			' ********* Define a default Constructor *********
			Public Sub New()
				MyBase.New()
			End Sub

			' <Snippet1>
			' Override the OnRender call to add a Background and Border to the OffSetPanel
			Protected Overrides Sub OnRender(ByVal dc As DrawingContext)
				Dim mySolidColorBrush As New SolidColorBrush()
				mySolidColorBrush.Color = Colors.LimeGreen
				Dim myPen As New Pen(Brushes.Blue, 10)
				Dim myRect As New Rect(0, 0, 500, 500)
				dc.DrawRectangle(mySolidColorBrush, myPen, myRect)
			End Sub
			'</Snippet1>
			' ********* Override the Measure method of Panel *********
			Protected Overrides Function MeasureOverride(ByVal constraint As Size) As Size
				Dim childConstraint As New Size(Double.PositiveInfinity, Double.PositiveInfinity)

				For Each child As UIElement In InternalChildren
					If child Is Nothing Then
						Continue For
					End If
					child.Measure(childConstraint)
				Next child

				Return New Size()
			End Function

			' ********* Override the Arrange method of Panel *********
			Protected Overrides Function ArrangeOverride(ByVal arrangeSize As Size) As Size
				For Each child As UIElement In InternalChildren
					If child Is Nothing Then
						Continue For
					End If

					If GetShareCoordinates(child) = True Then
						Dim x As Double = GetOffsetLeft(child)
						Dim y As Double = GetOffsetTop(child)
						Dim z As Double = GetInflateSize(child)

						If z = 0 OrElse z = Double.NaN Then
							child.Arrange(New Rect(New Point(x, y), child.DesiredSize))

						Else
							child.Arrange(New Rect(New Point(x, y), New Size((child.DesiredSize.Width + z), (child.DesiredSize.Height + z))))
						End If

					Else
						Dim x As Double = GetOffsetLeft(child)
						Dim y As Double = GetOffsetTop(child)
						Dim z As Double = GetInflateSize(child)

						For i As Integer = 0 To InternalChildren.Count - 1
							If i + 1 >= InternalChildren.Count Then
								Exit For
							End If
							If GetOffsetLeft(InternalChildren(i)) = GetOffsetLeft(InternalChildren(i + 1)) AndAlso GetOffsetTop(InternalChildren(i)) = GetOffsetTop(InternalChildren(i + 1)) Then
									child.Arrange(New Rect(New Point(0, 0), New Size(0, 0)))
								Else
									If z = 0 OrElse z = Double.NaN Then
										child.Arrange(New Rect(New Point(x, y), child.DesiredSize))
									Else
										child.Arrange(New Rect(New Point(x, y), New Size(z + child.DesiredSize.Width, z + child.DesiredSize.Height)))
									End If
								End If
						Next i

					End If

				Next child
				Return arrangeSize ' Returns the final Arrange size

			End Function

			' ********* OffsetLeft Property *********

			Public Shared ReadOnly OffsetLeftProperty As DependencyProperty = DependencyProperty.RegisterAttached("OffsetLeft", GetType(Double), GetType(OffsetPanel), New FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsParentArrange))


			Public Shared Function GetOffsetLeft(ByVal d As DependencyObject) As Double
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				Return CDbl(d.GetValue(OffsetLeftProperty))
			End Function

			Public Shared Sub SetOffsetLeft(ByVal d As DependencyObject, ByVal length As Double)
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				d.SetValue(OffsetLeftProperty, length)
			End Sub

			' ********* OffsetTop Property *********

			Public Shared ReadOnly OffsetTopProperty As DependencyProperty = DependencyProperty.RegisterAttached("OffsetTop", GetType(Double), GetType(OffsetPanel), New FrameworkPropertyMetadata(Double.NaN, FrameworkPropertyMetadataOptions.AffectsParentArrange))

			Public Shared Function GetOffsetTop(ByVal d As DependencyObject) As Double
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				Return CDbl(d.GetValue(OffsetTopProperty))
			End Function

			Public Shared Sub SetOffsetTop(ByVal d As DependencyObject, ByVal length As Double)
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				d.SetValue(OffsetTopProperty, length)
			End Sub

			' ********* InflateSize Property *********

			Public Shared ReadOnly InflateSizeProperty As DependencyProperty = DependencyProperty.RegisterAttached("InflateSize", GetType(Double), GetType(OffsetPanel), New FrameworkPropertyMetadata(0R, FrameworkPropertyMetadataOptions.AffectsParentArrange))

			Public Shared Function GetInflateSize(ByVal d As DependencyObject) As Double
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				Return CDbl(d.GetValue(InflateSizeProperty))
			End Function

			Public Shared Sub SetInflateSize(ByVal d As DependencyObject, ByVal length As Double)
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				d.SetValue(InflateSizeProperty, length)
			End Sub

			' ********* ShareCoordinates Property *********

			Public Shared ReadOnly ShareCoordinatesProperty As DependencyProperty = DependencyProperty.RegisterAttached("ShareCoordinates", GetType(Boolean), GetType(OffsetPanel))

			Public Shared Function GetShareCoordinates(ByVal d As DependencyObject) As Boolean
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				Return CBool(d.GetValue(ShareCoordinatesProperty))
			End Function

			Public Shared Sub SetShareCoordinates(ByVal d As DependencyObject, ByVal [Boolean] As Boolean)
				If d Is Nothing Then
					Throw New ArgumentNullException("d")
				End If
				d.SetValue(ShareCoordinatesProperty, [Boolean])
			End Sub

		End Class
	End Class

	' Run the application

	Friend NotInheritable Class EntryClass
		Private Sub New()
		End Sub
        <System.STAThread()>
        Shared Sub Main()
            Dim app As New MyApp()
            app.Run()
        End Sub
	End Class
End Namespace
