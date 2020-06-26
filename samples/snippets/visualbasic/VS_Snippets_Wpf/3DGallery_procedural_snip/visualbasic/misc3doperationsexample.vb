Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Media3D

Namespace SDKSample

	Public Class Misc3DOperationsExample
		Inherits Page


		Public Sub New()

			Dim mainPanel As New StackPanel()


			Dim subtract3DPointsExampleText As New TextBlock()
			subtract3DPointsExampleText.Text = "subtract3DPointsExample: " & subtract3DPointsExample()
			mainPanel.Children.Add(subtract3DPointsExampleText)

			Dim subtract3DVectorsExampleText As New TextBlock()
			subtract3DVectorsExampleText.Text = "subtract3DVectorsExample: " & subtract3DVectorsExample()
			mainPanel.Children.Add(subtract3DVectorsExampleText)

			Dim point4DEqualityExampleText As New TextBlock()
			point4DEqualityExampleText.Text = "point4DEqualityExample: " & point4DEqualityExample()
			mainPanel.Children.Add(point4DEqualityExampleText)

			Dim size3DEqualityExampleText As New TextBlock()
			size3DEqualityExampleText.Text = "size3DEqualityExample: " & size3DEqualityExample().ToString()
			mainPanel.Children.Add(size3DEqualityExampleText)

			Me.Content = mainPanel
		End Sub




		Private Function subtract3DPointsExample() As String
            ' <SnippetSubtract3DPointsExample>
			' instantiate variables
			Dim point1 As New Point3D()
			Dim point2 As New Point3D(15, 40, 60)
			Dim vector1 As New Vector3D(20, 30, 40)
			Dim pointResult1 As New Point3D()
			Dim pointResult2 As New Point3D()
			Dim vectorResult1 As New Vector3D()
			Dim vectorResult2 As New Vector3D()

			' defining x,y,z of point1
			point1.X = 10
			point1.Y = 5
			point1.Z = 1

			vectorResult1 = Point3D.Subtract(point1, point2)
			' vectorResult1 is equal to (-5, -35, -59)

			vectorResult2 = point2 - point1
			' vectorResult2 is equal to (5, 35, 59)

			pointResult1 = Point3D.Subtract(point1, vector1)
			'  pointResult1 is equal to (-10, -25, -39)

			pointResult2 = vector1 - point1
			'  pointResult2 is equal to (10, 25, 39)
            ' </SnippetSubtract3DPointsExample>

			Dim stringResults As String = "pointResult1: " & pointResult1.ToString()
			stringResults = stringResults & " pointResult2: " & pointResult2.ToString()
			stringResults = stringResults & " vectorResult1: " & vectorResult1.ToString()
			stringResults = stringResults & " vectorResult2: " & vectorResult2.ToString()
			Return stringResults

		End Function

		Private Function subtract3DVectorsExample() As String
            ' <SnippetSubtract3DVectorsExample>
			' Subtracts two 3-D Vectors using the Subtract method and -

			' Declaring vector1 and initializing x,y,z values
			Dim vector1 As New Vector3D(20, 30, 40)

			' Declaring vector2 without initializing x,y,z values
			Dim vector2 As New Vector3D()

			' Assigning values to vector2
			vector2.X = 45
			vector2.Y = 70
			vector2.Z = 80

			' Subtracting vectors using overload - operator
			Dim vectorResult1 As New Vector3D()
			vectorResult1 = vector1 - vector2
			' vectorResult1 is equal to (-25, -40, -40)

			' Subtracting vectors using static Subtract method
			Dim vectorResult2 As New Vector3D()
			vectorResult2 = Vector3D.Subtract(vector1, vector2)
			' vector2 is equal to (-25, -40, -40)
            ' </SnippetSubtract3DVectorsExample>

			Dim stringResults As String = "vectorResult1: " & vectorResult1.ToString()
			stringResults = stringResults & " vectorResult2: " & vectorResult2.ToString()
			Return stringResults

		End Function

		Private Function point4DEqualityExample() As String
            ' <SnippetPoint4DEqualityExample>
			' instantiate Points
			Dim point4D1 As New Point4D()
			Dim point4D2 As New Point4D(15, 40, 60, 75)
			Dim point3D1 As New Point3D(15, 40, 60)

			' result variables
			Dim areEqual As Boolean
			Dim areNotEqual As Boolean
			Dim stringResult As String

			' defining x,y,z,w of point1
			point4D1.X = 10
			point4D1.Y = 5
			point4D1.Z = 1
			point4D1.W = 4

			' checking if Points are equal
			areEqual = point4D1 = point4D2

			' areEqual is False

			' checking if Points are not equal
			areNotEqual = point4D1 <> point4D2
			' areNotEqual is True

			If Point4D.Equals(point4D1, point3D1) Then
				' the if condition is not true, so this block will not execute
				stringResult = "Both objects are Point4D structures and they are equal"

			Else
				' the if condition is false, so this branch will execute
				stringResult = "Parameters are not both Point4D strucutres, or they are but are not equal"
			End If
            ' </SnippetPoint4DEqualityExample>

			Return stringResult

		End Function
        ' <SnippetSize3DEqualityExample>
		Private Function size3DEqualityExample() As Boolean

			' Checks if two Size3D structures are equal using the static Equals method. 
			' Returns a Boolean.

			' Declaring Size3D structure without initializing x,y,z values
			Dim size1 As New Size3D()

			' Delcaring Size3D structure and initializing x,y,z values
			Dim size2 As New Size3D(5, 10, 15)
			Dim areEqual As Boolean

			' Assigning values to size1
			size1.X = 2
			size1.Y = 4
			size1.Z = 6

			' checking for equality
			areEqual = Size3D.Equals(size1, size2)

			' areEqual is False
			Return areEqual

		End Function
        ' </SnippetSize3DEqualityExample>

	End Class

End Namespace
