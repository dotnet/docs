Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.RectExamples

	Public Class RectExample
		Inherits Page


		Public Sub New()

			Dim mainPanel As New StackPanel()

			mainPanel.Children.Add(createRectExample1())

			Dim createRectExample2Text As New TextBlock()
			createRectExample2Text.Text = "createRectExample2: " & createRectExample2().ToString()
			mainPanel.Children.Add(createRectExample2Text)

			Dim createRectExample3Text As New TextBlock()
			createRectExample3Text.Text = "createRectExample3: " & createRectExample3().ToString()
			mainPanel.Children.Add(createRectExample3Text)

			Dim createRectExample4Text As New TextBlock()
			createRectExample4Text.Text = "createRectExample4: " & createRectExample4().ToString()
			mainPanel.Children.Add(createRectExample4Text)

			Dim createRectExample5Text As New TextBlock()
			createRectExample5Text.Text = "createRectExample5: " & createRectExample5().ToString()
			mainPanel.Children.Add(createRectExample5Text)

			Dim createRectExample6Text As New TextBlock()
			createRectExample6Text.Text = "createRectExample6: " & createRectExample6().ToString()
			mainPanel.Children.Add(createRectExample6Text)

			Dim rectContainsExample1Text As New TextBlock()
			rectContainsExample1Text.Text = "rectContainsExample1: " & rectContainsExample1().ToString()
			mainPanel.Children.Add(rectContainsExample1Text)

			Dim rectContainsExample2Text As New TextBlock()
			rectContainsExample2Text.Text = "rectContainsExample2: " & rectContainsExample2().ToString()
			mainPanel.Children.Add(rectContainsExample2Text)

			Dim rectContainsExample3Text As New TextBlock()
			rectContainsExample3Text.Text = "rectContainsExample3: " & rectContainsExample3().ToString()
			mainPanel.Children.Add(rectContainsExample3Text)

			Dim rectEqualsExample1Text As New TextBlock()
			rectEqualsExample1Text.Text = "rectEquals1: " & rectEqualsExample1().ToString()
			mainPanel.Children.Add(rectEqualsExample1Text)

			Dim rectEqualsExample2Text As New TextBlock()
			rectEqualsExample2Text.Text = "rectEquals2: " & rectEqualsExample2().ToString()
			mainPanel.Children.Add(rectEqualsExample2Text)

			Dim getHashCodeExampleText As New TextBlock()
			getHashCodeExampleText.Text = "getHashCodeExample: " & getHashCodeExample().ToString()
			mainPanel.Children.Add(getHashCodeExampleText)

			Dim inflateExample1Text As New TextBlock()
			inflateExample1Text.Text = "inflateExample1: " & inflateExample1().ToString()
			mainPanel.Children.Add(inflateExample1Text)

			Dim inflateExample2Text As New TextBlock()
			inflateExample2Text.Text = "inflateExample2: " & inflateExample2().ToString()
			mainPanel.Children.Add(inflateExample2Text)

			Dim inflateExample3Text As New TextBlock()
			inflateExample3Text.Text = "inflateExample3: " & inflateExample3().ToString()
			mainPanel.Children.Add(inflateExample3Text)

			Dim inflateExample4Text As New TextBlock()
			inflateExample4Text.Text = "inflateExample4: " & inflateExample4().ToString()
			mainPanel.Children.Add(inflateExample4Text)

			Dim intersectExample1Text As New TextBlock()
			intersectExample1Text.Text = "intersectExample1: " & intersectExample1().ToString()
			mainPanel.Children.Add(intersectExample1Text)

			Dim intersectExample2Text As New TextBlock()
			intersectExample2Text.Text = "intersectExample2: " & intersectExample2().ToString()
			mainPanel.Children.Add(intersectExample2Text)

			Dim intersectsWithExampleText As New TextBlock()
			intersectsWithExampleText.Text = "intersectsWithExample: " & intersectsWithExample().ToString()
			mainPanel.Children.Add(intersectsWithExampleText)

			Dim offsetExample1Text As New TextBlock()
			offsetExample1Text.Text = "offsetExample1: " & offsetExample1().ToString()
			mainPanel.Children.Add(offsetExample1Text)

			Dim offsetExample2Text As New TextBlock()
			offsetExample2Text.Text = "offsetExample2: " & offsetExample2().ToString()
			mainPanel.Children.Add(offsetExample2Text)

			Dim offsetExample3Text As New TextBlock()
			offsetExample3Text.Text = "offsetExample3: " & offsetExample3().ToString()
			mainPanel.Children.Add(offsetExample3Text)

			Dim offsetExample4Text As New TextBlock()
			offsetExample4Text.Text = "offsetExample4: " & offsetExample4().ToString()
			mainPanel.Children.Add(offsetExample4Text)

			Dim overloadedEqualityOperatorExampleText As New TextBlock()
			overloadedEqualityOperatorExampleText.Text = "overloadedEqualityOperatorExample: " & overloadedEqualityOperatorExample().ToString()
			mainPanel.Children.Add(overloadedEqualityOperatorExampleText)

			Dim overloadedInequalityOperatorExampleText As New TextBlock()
			overloadedInequalityOperatorExampleText.Text = "overloadedInequalityOperatorExample: " & overloadedInequalityOperatorExample().ToString()
			mainPanel.Children.Add(overloadedInequalityOperatorExampleText)

			Dim parseExampleText As New TextBlock()
			parseExampleText.Text = "parseExample: " & parseExample().ToString()
			mainPanel.Children.Add(parseExampleText)

			Dim scaleExampleText As New TextBlock()
			scaleExampleText.Text = "scaleExample: " & scaleExample().ToString()
			mainPanel.Children.Add(scaleExampleText)

			Dim unionExample1Text As New TextBlock()
			unionExample1Text.Text = "unionExample1: " & unionExample1().ToString()
			mainPanel.Children.Add(unionExample1Text)

			Dim unionExample2Text As New TextBlock()
			unionExample2Text.Text = "unionExample2: " & unionExample2().ToString()
			mainPanel.Children.Add(unionExample2Text)

			Dim unionExample3Text As New TextBlock()
			unionExample3Text.Text = "unionExample3: " & unionExample3().ToString()
			mainPanel.Children.Add(unionExample3Text)

			Dim unionExample4Text As New TextBlock()
			unionExample4Text.Text = "unionExample4: " & unionExample4().ToString()
			mainPanel.Children.Add(unionExample4Text)

			Dim transformExample1Text As New TextBlock()
			transformExample1Text.Text = "transformExample1: " & transformExample1().ToString()
			mainPanel.Children.Add(transformExample1Text)

			Dim transformExample2Text As New TextBlock()
			transformExample2Text.Text = "transformExample2: " & transformExample2().ToString()
			mainPanel.Children.Add(transformExample2Text)

			Me.Content = mainPanel
		End Sub


        ' <SnippetCreateRectExample1_visualbasic>
		' Create a rectangle and add it to the page. Also,
		' find size and coordinate information about this
		' new rectangle and render information in a TextBox 
		' below the rectangle.
		Private Function createRectExample1() As StackPanel
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. Set the Location property to an X coordinate of 10 and a
			' Y coordinate of 5. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			Dim myRectangleGeometry As New RectangleGeometry()
			myRectangleGeometry.Rect = myRectangle

			' This path is defined by the rectangle.
			Dim myPath As New Path()
			myPath.Fill = Brushes.LemonChiffon
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myRectangleGeometry

			'////////// Create string of rectangle property information /////////////
			' This string will contain all the size and coordinate property
			' information about the rectangle.
			'///////////////////////////////////////////////////////////////////////
			Dim rectInfo As String = "Rectangle Property Information: "

			' Bottom property gets the y-axis value of the bottom of the rectangle. 
			' For this rectangle the value is 55.
			rectInfo = rectInfo & "Bottom: " & myRectangle.Bottom

			' BottomLeft property gets the coordinates of the bottom left corner of the rectangle. 
			' For this rectangle the value is 10,55.
            rectInfo = rectInfo & "| BottomLeft: " & myRectangle.BottomLeft.ToString

			' BottomRight property gets the coordinates of the bottom right corner of the rectangle. 
			' For this rectangle the value is 210,55.
            rectInfo = rectInfo & "| BottomRight: " & myRectangle.BottomRight.ToString

			' Height property gets or sets the height of the rectangle. 
			' For this rectangle the value is 50.
			rectInfo = rectInfo & "| Height: " & myRectangle.Height

			' Width property gets or sets the width of the rectangle. 
			' For this rectangle the value is 200.
			rectInfo = rectInfo & "| Width: " & myRectangle.Width

			' Left property gets the x-axis position of the left side of the rectangle which is 
			' equivalent to getting the rectangle's X property. 
			' For this rectangle the value is 10.
			rectInfo = rectInfo & "| Left: " & myRectangle.Left

			' Location property gets or sets the position of the rectangle's top-left corner.
			' For this rectangle the value is 10,5.
            rectInfo = rectInfo & "| Location: " & myRectangle.Location.ToString

			' Right property gets the x-axis value of the right side of the rectangle. 
			' For this rectangle the value is 210.
			rectInfo = rectInfo & "| Right: " & myRectangle.Right

			' Size property gets or sets the width and height of the rectangle.  
			' For this rectangle the value is 200,50.
            rectInfo = rectInfo & "| Size: " & myRectangle.Size.ToString

			' Top property gets the y-axis position of the top of the rectangle which is 
			' equivalent to getting the rectangle's Y property.
			' For this rectangle the value is 5.
			rectInfo = rectInfo & "| Top: " & myRectangle.Top

			' TopLeft property gets the position of the top-left corner of the rectangle, which 
			' is equivalent to (X, Y).   
			' For this rectangle the value is 10,5.
            rectInfo = rectInfo & "| TopLeft: " & myRectangle.TopLeft.ToString

			' TopRight property gets the position of the top-left corner of the rectangle, which 
			' is equivalent to (X + Width, Y).   
			' For this rectangle the value is 210,5.
            rectInfo = rectInfo & "| TopRight: " & myRectangle.TopRight.ToString

			' X property gets or sets the location of the rectangle's left side.  
			' For this rectangle the value is 10.
			rectInfo = rectInfo & "| X: " & myRectangle.X

			' Y property gets or sets the location of the rectangle's top side.  
			' For this rectangle the value is 5.
			rectInfo = rectInfo & "| Y: " & myRectangle.Y

			'////// End of creating string containing rectangle property information ////////

			' This StackPanel will contain the rectangle and TextBlock.
			Dim parentPanel As New StackPanel()

			' Add the rectangle path to the StackPanel. This will display the rectangle.
			parentPanel.Children.Add(myPath)

			' Add a TextBlock to display the rectangle's size and coordinate information.
			Dim myTextBlock As New TextBlock()
			myTextBlock.Text = rectInfo
			parentPanel.Children.Add(myTextBlock)

			' Return the parent container to be displayed to the screen.
			Return parentPanel
		End Function
        ' </SnippetCreateRectExample1_visualbasic> 

        ' <SnippetCreateRectExample2_visualbasic>
		Private Function createRectExample2() As Rect
			' This constructor initializes a new instance of the Rect structure that 
			' is of the specified size and is located at (0,0). 
			Dim myRectangle As New Rect(New Size(200, 50))

			' Returns a rectangle with a width of 200, a height of 50 and a position
			' of 0,0.
			Return myRectangle

		End Function
        ' </SnippetCreateRectExample2_visualbasic>

        ' <SnippetCreateRectExample3_visualbasic>
		Private Function createRectExample3() As Rect
			' This constructor intializes a new instance of the Rect structure that is 
			' exactly large enough to contain the two specified points.  
			Dim myRectangle As New Rect(New Point(15, 30), New Point(50,70))

			' Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
			Return myRectangle

		End Function
        ' </SnippetCreateRectExample3_visualbasic>

        ' <SnippetCreateRectExample4_visualbasic>
		Private Function createRectExample4() As Rect
			' This constructor initializes a new instance of the Rect structure that has the 
			' specified top-left corner location and the specified width and height (Size).    
			Dim myRectangle As New Rect(New Point(15, 30), New Size(35, 40))

			' Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
			Return myRectangle

		End Function
        ' </SnippetCreateRectExample4_visualbasic>

        ' <SnippetCreateRectExample5_visualbasic>
		Private Function createRectExample5() As Rect
			' This constructor Intializes a new instance of the Rect structure that is exactly 
			' large enough to contain the specified point and the sum of the specified point 
			' and the specified vector.   
			Dim myRectangle As New Rect(New Point(15, 30), New Vector(35, 40))

			' Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
			Return myRectangle

		End Function
        ' </SnippetCreateRectExample5_visualbasic>

        ' <SnippetCreateRectExample6_visualbasic>
		Private Function createRectExample6() As Rect
			' This constructor intializes a new instance of the Rect structure with the specified 
			' x- and y-coordinates and the specified width and height. 
			Dim myRectangle As New Rect(15, 30, 35, 40)

			' Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
			Return myRectangle

		End Function
        ' </SnippetCreateRectExample6_visualbasic>


        ' <SnippetContainsExample1_visualbasic>
		Private Function rectContainsExample1() As Boolean
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Using the Contains method, see if the rectangle contains the specified
			' point. doesContain is true because the point is inside of myRectangle.
			Dim doesContain As Boolean = myRectangle.Contains(New Point(13, 30))

			Return doesContain

		End Function
        ' </SnippetContainsExample1_visualbasic>

        ' <SnippetContainsExample2_visualbasic>
		Private Function rectContainsExample2() As Boolean
			' Create a rectangle.
			Dim myRectangle1 As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle1.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle1.Size = New Size(200, 50)

			' Create second rectangle.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(12, 12)
			myRectangle2.Size = New Size(10, 60)

			' Using the Contains method, see if the second rectangle is 
			' contained within the first rectangle. doesContain is false
			' because only part of myRectangle2 is contained in myRectangle1 
			' (myRectangle2 is too wide).
			Dim doesContain As Boolean = myRectangle1.Contains(myRectangle2)

			Return doesContain

		End Function
        ' </SnippetContainsExample2_visualbasic>

        ' <SnippetContainsExample3_visualbasic>
		Private Function rectContainsExample3() As Boolean
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Using the Contains method, see if the rectangle contains the specified
			' point specified by the given X and Y coordinates. doesContain is false 
			' because the X and Y coordinates specify a point outside of myRectangle.
			Dim doesContain As Boolean = myRectangle.Contains(4, 13)

			Return doesContain

		End Function
        ' </SnippetContainsExample3_visualbasic>


        ' <SnippetEqualsExample1_visualbasic>
		Private Function rectEqualsExample1() As Boolean
			' Create a rectangle.
			Dim myRectangle1 As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle1.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle1.Size = New Size(200, 50)

			' Create second rectangle to compare to the first.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(10, 5)
			myRectangle2.Size = New Size(200, 50)

			' Using the Equals method, see if the second rectangle is the
			' same as the first rectangle. doesEqual is true because both
			' rectangles are exactly the same with respect to location and size. 
			Dim doesEqual As Boolean = myRectangle1.Equals(myRectangle2)

			Return doesEqual

		End Function
        ' </SnippetEqualsExample1_visualbasic>

        ' <SnippetEqualsExample2_visualbasic>
		Private Function rectEqualsExample2() As Boolean
			' Create a rectangle.
			Dim myRectangle1 As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle1.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle1.Size = New Size(200, 50)

			' Create second rectangle to compare to the first.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(10, 5)
			myRectangle2.Size = New Size(200, 50)

			' Using the Equals method, see if the second rectangle is 
			' the same as the first rectangle. doesEqual is true because
			' both rectangles are exactly the same in that they both have the 
			' same location and size.
			Dim doesEqual As Boolean = Rect.Equals(myRectangle1, myRectangle2)

			Return doesEqual

		End Function
        ' </SnippetEqualsExample2_visualbasic>

        ' <SnippetGetHashCodeExample_visualbasic>
		Private Function getHashCodeExample() As Integer
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Get the hashcode of the rectangle.
			Dim returnHashCode As Integer = myRectangle.GetHashCode()

			Return returnHashCode

		End Function
        ' </SnippetGetHashCodeExample_visualbasic>

        ' <SnippetInflateExample1_visualbasic>
		Private Function inflateExample1() As Size
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Use the Inflate method to expand the rectangle by the specified Size in all
			' directions. The new size is 240,110. Note: Width of the resulting rectangle  
			' is increased by twice the Width of the specified Size structure because  
			' both the left and right sides of the rectangle are inflated. Likewise, the 
			' Height of the resulting rectangle is increased by twice the Height of the 
			' specified Size structure.
			myRectangle.Inflate(New Size(20,30))

			Return myRectangle.Size

		End Function
        ' </SnippetInflateExample1_visualbasic>

        ' <SnippetInflateExample2_visualbasic>
		Private Function inflateExample2() As Size
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200,50)

			' Use the Inflate method to expand or shrink the rectangle by the specified 
			' width and height amounts. The new size is 160,150 (width shrunk by 40 and  
			' height increased by 100). Note: Width of the resulting rectangle is increased 
			' or shrunk by twice the specified width, because both the left and right sides  
			' of the rectangle are inflated or shrunk. Likewise, the height of the resulting 
			' rectangle is increased or shrunk by twice the specified height.
			myRectangle.Inflate(-20,50)

			Return myRectangle.Size

		End Function
        ' </SnippetInflateExample2_visualbasic>

        ' <SnippetInflateExample3_visualbasic>
		Private Function inflateExample3() As Size
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Use the static Inflate method to return an expanded version of myRectangle1.   
			' The size of myRectangle2 is 240,110. Note: Width of the resulting rectangle is increased 
			' by twice the Width of the specified Size structure, because both the left and right 
			' sides of the rectangle are inflated. Likewise, the Height of the resulting 
			' rectangle is increased by twice the Height of the specified Size structure.
			Dim myRectangle2 As Rect = Rect.Inflate(myRectangle, New Size(20, 30))

			Return myRectangle2.Size

		End Function
        ' </SnippetInflateExample3_visualbasic>

        ' <SnippetInflateExample4_visualbasic>
		Private Function inflateExample4() As Size
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Use the static Inflate method to return a version of myRectangle with a shrunk
			' width and expanded height. The size of myRectangle2 is 160,150. Note: Width of the resulting 
			' rectangle is increased or shrunk by twice the specified width, because both the
			' left and right sides of the rectangle are inflated or shrunk. Likewise, the height 
			' of the resulting rectangle is increased or shrunk by twice the specified height.
			Dim myRectangle2 As Rect = Rect.Inflate(myRectangle, -20, 50)

			Return myRectangle2.Size

		End Function
        ' </SnippetInflateExample4_visualbasic>

        ' <SnippetIntersectExample1_visualbasic>
		Private Function intersectExample1() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle to compare to the first.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' Intersect method finds the intersection between the current rectangle and the 
			' specified rectangle, and stores the result as the current rectangle. If no 
			' intersection exists, the current rectangle becomes the Empty rectangle. 
			' myRectangle now has a size of 190,45 and location of 10,5. 
			myRectangle.Intersect(myRectangle2)

			' myRectangle has been changed into the intersection area between the old myRectangle
			' and myRectangle2 (new size of 190,45 and new location of 10,5).
			Return myRectangle

		End Function
        ' </SnippetIntersectExample1_visualbasic>

        ' <SnippetIntersectExample2_visualbasic>
		Private Function intersectExample2() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle to compare to the first.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' Intersect method finds the intersection between the specified rectangles and 
			' returns the result as a Rect. If there is no intersection then the Empty Rect 
			' is returned. resultRectangle has a size of 190,45 and location of 10,5. 
			Dim resultRectangle As Rect = Rect.Intersect(myRectangle, myRectangle2)

			Return resultRectangle

		End Function
        ' </SnippetIntersectExample2_visualbasic>

        ' <SnippetIntersectsWithExample_visualbasic>
		Private Function intersectsWithExample() As Boolean
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle to compare to the first.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' IntersectsWith method indicates whether the specified rectangle intersects 
			' with this rectangle. doesIntersect returns true because the two rectangles
			' intersect. 
			Dim doesIntersect As Boolean = myRectangle.IntersectsWith(myRectangle2)

			' Returns true.
			Return doesIntersect

		End Function
        ' </SnippetIntersectsWithExample_visualbasic>

        ' <SnippetOffsetExample1_visualbasic>
		Private Function offsetExample1() As Point
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create a vector to use to offset the position of the rectangle.
			Dim vector1 As New Vector(20, 30)

			' The Offset method translates this rectangle by the specified vector.
			' myRectangle location changed from 10,5 to 30,35.
			myRectangle.Offset(vector1)

			' This rectangle's location changed from 10,5 to 30,35.
			Return myRectangle.Location

		End Function
        ' </SnippetOffsetExample1_visualbasic>

        ' <SnippetOffsetExample2_visualbasic>
		Private Function offsetExample2() As Point
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' The Offset method translates this rectangle by the specified horizontal and 
			' vertical amounts. 
			' myRectangle location changed from 10,5 to 30,35.
			myRectangle.Offset(20,30)

			' This rectangle's location changed from 10,5 to 30,35.
			Return myRectangle.Location

		End Function
        ' </SnippetOffsetExample2_visualbasic>

        ' <SnippetOffsetExample3_visualbasic>
		Private Function offsetExample3() As Point
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create a vector to use to offset the position of the rectangle.
			Dim vector1 As New Vector(20, 30)

			' The Offset method translates the specified rectangle by the specified amount 
			' and returns the resulting Rect. 
			' resultRect location changed from 10,5 to 30,35.
			Dim resultRect As Rect = Rect.Offset(myRectangle, vector1)

			' This rectangle's location changed from 10,5 to 30,35.
			Return resultRect.Location

		End Function
        ' </SnippetOffsetExample3_visualbasic>

        ' <SnippetOffsetExample4_visualbasic>
		Private Function offsetExample4() As Point
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create a vector to use to offset the position of the rectangle.
			Dim vector1 As New Vector(20, 30)

			' The Offset method translates the specified rectangle by the specified horizontal 
			' and vertical amounts and returns the resulting Rect. 
			' resultRect location changed from 10,5 to 30,35.
			Dim resultRect As Rect = Rect.Offset(myRectangle, 20, 30)

			' This rectangle's location changed from 10,5 to 30,35.
			Return resultRect.Location

		End Function
        ' </SnippetOffsetExample4_visualbasic>

		' <SnippetOverloadedEqualityOperatorExample>
		Private Function overloadedEqualityOperatorExample() As Boolean
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle to compare to the first.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' Check if the two Rects are exactly equal using the overloaded equality operator.
			' areEqual is false because although the size of each rectangle is the same,
			' the locations are different.
			Dim areEqual As Boolean = (myRectangle = myRectangle2)

			' Returns false.
			Return areEqual

		End Function
		' </SnippetOverloadedEqualityOperatorExample>

		' <SnippetOverloadedInequalityOperatorExample>
		Private Function overloadedInequalityOperatorExample() As Boolean
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle to compare to the first.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' Check if the two Rects are not equal using the overloaded inequality operator.
			' notEqual is true because although the size of each rectangle is the same,
			' the locations are different.
			Dim notEqual As Boolean = (myRectangle <> myRectangle2)

			' Returns true.
			Return notEqual

		End Function
		' </SnippetOverloadedInequalityOperatorExample>

		' <SnippetParseExample>
		Private Function parseExample() As Rect

			' Converts a string representation of a Rect into a Rect structure
			' using the Parse static method.
			Dim resultRect As Rect = Rect.Parse("10,5, 200,50")

			Return resultRect

		End Function
		' </SnippetParseExample>

        ' <SnippetScaleExample_visualbasic>
		Private Function scaleExample() As Size
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' The Scale method multiplies the size of the rectangle by the specified amount. 
			' myRectangle size changed from (200,50) to (4000,1500).
			myRectangle.Scale(20, 30)

			' Returns a size of 4000,1500.
			Return myRectangle.Size

		End Function
        ' </SnippetScaleExample_visualbasic>

        ' <SnippetToStringExample_visualbasic>
		Private Function toStringExample() As String
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Get a string representation of a Rect structure.
			' rectString is equal to "10,5,200,50"	.
			Dim rectString As String = myRectangle.ToString()

			Return rectString

		End Function
        ' </SnippetToStringExample_visualbasic>

        ' <SnippetUnionExample1_visualbasic>
		Private Function unionExample1() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' The Union method expands the current rectangle exactly enough to contain 
			' the specified point. myRectangle expands to a location of 0,0 and a size
			' of 210,55.
			myRectangle.Union(New Point(0,0))

			' Returns 0,0,210,55
			Return myRectangle

		End Function
        ' </SnippetUnionExample1_visualbasic>

        ' <SnippetUnionExample2_visualbasic>
		Private Function unionExample2() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' The Union method expands the current rectangle exactly enough to contain 
			' the specified rectangle. myRectangle expands to a location of 0,0 and a size
			' of 210,55.
			myRectangle.Union(myRectangle2)

			' Returns 0,0,210,55
			Return myRectangle

		End Function
        ' </SnippetUnionExample2_visualbasic>

        ' <SnippetUnionExample3_visualbasic>
		Private Function unionExample3() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' The Union method expands the current rectangle exactly enough to contain 
			' the specified rectangle and the specified Point. In this example, returnRect 
			' expands to a location of 0,0 and a size of 250,60.
			Dim returnRect As Rect = Rect.Union(myRectangle2, New Point(250,60))

			' Returns 0,0,250,60
			Return returnRect

		End Function
        ' </SnippetUnionExample3_visualbasic>

        ' <SnippetUnionExample4_visualbasic>
		Private Function unionExample4() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' The Location property specifies the coordinates of the upper left-hand 
			' corner of the rectangle. 
			myRectangle.Location = New Point(10, 5)

			' Set the Size property of the rectangle with a width of 200
			' and a height of 50.
			myRectangle.Size = New Size(200, 50)

			' Create second rectangle.
			Dim myRectangle2 As New Rect()
			myRectangle2.Location = New Point(0, 0)
			myRectangle2.Size = New Size(200, 50)

			' Create a third rectangle.
			Dim myRectangle3 As New Rect()
			myRectangle3.Location = New Point(210, 60)
			myRectangle3.Size = New Size(50, 50)

			' The Union method expands the current rectangle exactly enough to contain 
			' the two specified rectangles. In this example, returnRect expands to 
			' a location of 0,0 and a size of 260,110.
			Dim returnRect As Rect = Rect.Union(myRectangle2, myRectangle3)

			' Returns 0,0,260,110
			Return returnRect

		End Function
        ' </SnippetUnionExample4_visualbasic>

        ' <SnippetTransformExample1_visualbasic>
		Private Function transformExample1() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' Set the Size property of the rectangle with a width of 200
			' and a height of 60.
			myRectangle.Size = New Size(200, 60)

			' Creating a Matrix structure.
			Dim myMatrix As New Matrix(0, 1, 1, 0, 20, 2)

			' The Transform method transforms this rectangle using the specified matrix.  
			' myRectangle location changed from 0,0 to 20, 2 and the size changed from
			' 200,60 to 60,200.
			myRectangle.Transform(myMatrix)

			Return myRectangle

		End Function
        ' </SnippetTransformExample1_visualbasic>

        ' <SnippetTransformExample2_visualbasic>
		Private Function transformExample2() As Rect
			' Initialize new rectangle.
			Dim myRectangle As New Rect()

			' Set the Size property of the rectangle with a width of 200
			' and a height of 60.
			myRectangle.Size = New Size(200, 60)

			' Creating a Matrix structure.
			Dim myMatrix As New Matrix(0, 1, 1, 0, 20, 2)

			' The Transform method Transforms the specified rectangle using the specified matrix 
			' and returns the results.  
			' resultRect is an alterned version of myRectangle with a location of 20,2 rather
			' then 0,0 and a size of 60,200 rather then 200,60.
			Dim resultRect As Rect = Rect.Transform(myRectangle,myMatrix)

			Return resultRect

		End Function
        ' </SnippetTransformExample2_visualbasic>


	End Class

End Namespace
