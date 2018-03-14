Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.PointExamples

	Public Class PointExample
		Inherits Page


		Public Sub New()

			Dim mainPanel As New StackPanel()

			Dim addPointAndVectorExampleText As New TextBlock()
			addPointAndVectorExampleText.Text = "addPointAndVectorExample: " & addPointAndVectorExample().ToString()
			mainPanel.Children.Add(addPointAndVectorExampleText)

			Dim staticEqualsExampleText As New TextBlock()
			staticEqualsExampleText.Text = "staticEqualsExample: " & staticEqualsExample().ToString()
			mainPanel.Children.Add(staticEqualsExampleText)

			Dim nonStaticEqualsExampleText As New TextBlock()
			nonStaticEqualsExampleText.Text = "nonStaticEqualsExample: " & nonStaticEqualsExample().ToString()
			mainPanel.Children.Add(nonStaticEqualsExampleText)

			Dim getHashCodeExampleText As New TextBlock()
			getHashCodeExampleText.Text = "getHashCodeExample: " & getHashCodeExample().ToString()
			mainPanel.Children.Add(getHashCodeExampleText)

			Dim multiplyPointByMatrixExampleText As New TextBlock()
			multiplyPointByMatrixExampleText.Text = "multiplyPointByMatrixExample: " & multiplyPointByMatrixExample().ToString()
			mainPanel.Children.Add(multiplyPointByMatrixExampleText)

			Dim offsetExampleText As New TextBlock()
			offsetExampleText.Text = "offsetExample: " & offsetExample().ToString()
			mainPanel.Children.Add(offsetExampleText)

			Dim overloadedAdditionOperatorExampleText As New TextBlock()
			overloadedAdditionOperatorExampleText.Text = "overloadedAdditionOperatorExample: " & overloadedAdditionOperatorExample().ToString()
			mainPanel.Children.Add(overloadedAdditionOperatorExampleText)

			Dim overloadedEqualityOperatorExampleText As New TextBlock()
			overloadedEqualityOperatorExampleText.Text = "overloadedEqualityOperatorExample: " & overloadedEqualityOperatorExample().ToString()
			mainPanel.Children.Add(overloadedEqualityOperatorExampleText)

			Dim overloadedExplicitOperatorSizeExampleText As New TextBlock()
			overloadedExplicitOperatorSizeExampleText.Text = "overloadedExplicitOperatorSizeExample: " & overloadedExplicitOperatorSizeExample().ToString()
			mainPanel.Children.Add(overloadedExplicitOperatorSizeExampleText)

			Dim overloadedExplicitOperatorVectorExampleText As New TextBlock()
			overloadedExplicitOperatorVectorExampleText.Text = "overloadedExplicitOperatorVectorExample: " & overloadedExplicitOperatorVectorExample().ToString()
			mainPanel.Children.Add(overloadedExplicitOperatorVectorExampleText)

			Dim overloadedInequalityOperatorExampleText As New TextBlock()
			overloadedInequalityOperatorExampleText.Text = "overloadedInequalityOperatorExample: " & overloadedInequalityOperatorExample().ToString()
			mainPanel.Children.Add(overloadedInequalityOperatorExampleText)

			Dim overloadedMultiplyPointByMatrixOperatorExampleText As New TextBlock()
			overloadedMultiplyPointByMatrixOperatorExampleText.Text = "overloadedMultiplyPointByMatrixOperatorExample: " & overloadedMultiplyPointByMatrixOperatorExample().ToString()
			mainPanel.Children.Add(overloadedMultiplyPointByMatrixOperatorExampleText)

			Dim overloadedSubtractionOperatorExample1Text As New TextBlock()
			overloadedSubtractionOperatorExample1Text.Text = "overloadedSubtractionOperatorExample1: " & overloadedSubtractionOperatorExample1().ToString()
			mainPanel.Children.Add(overloadedSubtractionOperatorExample1Text)

			Dim overloadedSubtractionOperatorExample2Text As New TextBlock()
			overloadedSubtractionOperatorExample2Text.Text = "overloadedSubtractionOperatorExample2: " & overloadedSubtractionOperatorExample2().ToString()
			mainPanel.Children.Add(overloadedSubtractionOperatorExample2Text)

			Dim parseExampleText As New TextBlock()
			parseExampleText.Text = "parseExample: " & parseExample().ToString()
			mainPanel.Children.Add(parseExampleText)

			Dim subtractExample1Text As New TextBlock()
			subtractExample1Text.Text = "subtractExample1: " & subtractExample1().ToString()
			mainPanel.Children.Add(subtractExample1Text)

			Dim subtractExample2Text As New TextBlock()
			subtractExample2Text.Text = "subtractExample2: " & subtractExample2().ToString()
			mainPanel.Children.Add(subtractExample2Text)

			Dim toStringExampleText As New TextBlock()
			toStringExampleText.Text = "toStringExample: " & toStringExample().ToString()
			mainPanel.Children.Add(toStringExampleText)

			Dim pointInequalityExampleText As New TextBlock()
			pointInequalityExampleText.Text = "pointInequalityExample: " & pointInequalityExample().ToString()
			mainPanel.Children.Add(pointInequalityExampleText)

			Dim pointConverterExampleText As New TextBlock()
			pointConverterExampleText.Text = "pointConverterExample: " & pointConverterExample().ToString()
			mainPanel.Children.Add(pointConverterExampleText)

			Me.Content = mainPanel
		End Sub

        ' <SnippetPointConverterExample_visualbasic>
		Private Function pointConverterExample() As Point
			Dim pConverter As New PointConverter()
			Dim pointResult As New Point()
			Dim string1 As String = "10,20"

			' pointResult is equal to (10, 20)
			pointResult = CType(pConverter.ConvertFromString(string1), Point)

			Return pointResult

		End Function
        ' </SnippetPointConverterExample_visualbasic>

        ' <SnippetAddPointAndVectorExample_visualbasic>
		Private Function addPointAndVectorExample() As Point
			Dim point1 As New Point(10, 5)
			Dim vector1 As New Vector(20, 30)

			' Add Point and Vector using the static Add method.
			' pointResult is equal to (30,35).
			Dim pointResult As Point = Point.Add(point1, vector1)

			Return pointResult

		End Function
        ' </SnippetAddPointAndVectorExample_visualbasic>

        ' <SnippetStaticEqualsExample_visualbasic>
		Private Function staticEqualsExample() As Boolean

			Dim point1 As New Point(10, 5)
			Dim point2 As New Point(15, 40)

			' Check if the two points are equal using the static Equals method.
			' areEqual is false
			Dim areEqual As Boolean = Point.Equals(point1, point2)

			Return areEqual

		End Function
        ' </SnippetStaticEqualsExample_visualbasic>

        ' <SnippetNonStaticEqualsExample_visualbasic>
		Private Function nonStaticEqualsExample() As Boolean

			Dim point1 As New Point(10, 5)
			Dim point2 As New Point(15, 40)

			' Check if the two points are equal using the non-static Equals method.
			' areEqual is false
			Dim areEqual As Boolean = point1.Equals(point2)

			Return areEqual

		End Function
        ' </SnippetNonStaticEqualsExample_visualbasic>

        ' <SnippetGetHashCodeExample_visualbasic>
		Private Function getHashCodeExample() As Integer

			Dim point1 As New Point(10, 5)

			' Get the hashcode of a Point structure
			Dim returnHashCode As Integer = point1.GetHashCode()

			Return returnHashCode

		End Function
        ' </SnippetGetHashCodeExample_visualbasic>

        ' <SnippetMultiplyPointByMatrixExample_visualbasic>
		Private Function multiplyPointByMatrixExample() As Point

			Dim point1 As New Point(10, 5)
			Dim matrix1 As New Matrix(40, 50, 60, 70, 80, 90)

			' Multiplies a Point by a Matrix.
			' pointResult is equal to (780,940).
			Dim pointResult As Point = Point.Multiply(point1, matrix1)

			Return pointResult

		End Function
        ' </SnippetMultiplyPointByMatrixExample_visualbasic>

        ' <SnippetOffsetExample_visualbasic>
		Private Function offsetExample() As Point

			Dim pointResult As New Point(10, 5)

			' Offset Point X value by 20 and Y value by 30.
			' point1 is now equal to (30,35)
			pointResult.Offset(20, 30)

			Return pointResult

		End Function
        ' </SnippetOffsetExample_visualbasic>


		' <SnippetOverloadedAdditionOperatorExample>
		Private Function overloadedAdditionOperatorExample() As Point

			Dim point1 As New Point(10, 5)
			Dim vector1 As New Vector(20, 30)

			' Add point to a Vector using the overloaded (+) operator.
			' pointResult is equal to (30,35).
			Dim pointResult As Point = point1 + vector1

			Return pointResult

		End Function
		' </SnippetOverloadedAdditionOperatorExample>



		' <SnippetOverloadedEqualityOperatorExample>
		Private Function overloadedEqualityOperatorExample() As Boolean
			Dim point1 As New Point(10, 5)
			Dim point2 As New Point(15, 40)

			' Check if two Points are equal using the overloaded equality operator.
			' areEqual is False.
			Dim areEqual As Boolean = (point1 = point2)

			Return areEqual

		End Function
		' </SnippetOverloadedEqualityOperatorExample>

		' <SnippetOverloadedExplicitOperatorSizeExample>
		Private Function overloadedExplicitOperatorSizeExample() As Size

			Dim point1 As New Point(10, 5)

			' Explicitly converts a Point structure into a Size structure.
			' returnSize has a width of 10 and a height of 5  
			Dim returnSize As Size = CType(point1, Size)

			Return returnSize

		End Function
		' </SnippetOverloadedExplicitOperatorSizeExample>

		' <SnippetOverloadedExplicitOperatorVectorExample>
		Private Function overloadedExplicitOperatorVectorExample() As Vector

			Dim point1 As New Point(10, 5)

			' Explicitly converts a Point structure into a Vector structure.
			' returnVector is equal to (10,5).
			Dim returnVector As Vector = CType(point1, Vector)

			Return returnVector

		End Function
		' </SnippetOverloadedExplicitOperatorVectorExample>

		' <SnippetOverloadedInequalityOperatorExample>
		Private Function overloadedInequalityOperatorExample() As Boolean
			Dim point1 As New Point(20, 30)
			Dim point2 As New Point(45, 70)

			' Check whether the two Points are not equal, using the overloaded 
			' inequality operator.
			' areNotEqual is True.
			Dim areNotEqual As Boolean = (point1 <> point2)

			Return areNotEqual

		End Function
		' </SnippetOverloadedInequalityOperatorExample>

		' <SnippetOverloadedMultiplyPointByMatrixOperatorExample>
		Private Function overloadedMultiplyPointByMatrixOperatorExample() As Point

			Dim point1 As New Point(10, 5)
			Dim matrix1 As New Matrix(40, 50, 60, 70, 80, 90)

			' Multiply the Point by the Matrix using the overloaded
			' (*) operator.
			' pointResult is equal to (780,940).
			Dim pointResult As Point = point1 * matrix1

			Return pointResult

		End Function
		' </SnippetOverloadedMultiplyPointByMatrixOperatorExample>



		' <SnippetOverloadedSubtractionOperatorExample1>
		Private Function overloadedSubtractionOperatorExample1() As Point

			Dim point1 As New Point(10, 5)
			Dim vector1 As New Vector(20, 30)

			' Subtracts a Vector from a Point using the overloaded subtraction (-) operator.
			' pointResult is equal to (-10, -25)
			Dim pointResult As Point = point1 - vector1

			Return pointResult

		End Function
		' </SnippetOverloadedSubtractionOperatorExample1>

		' <SnippetOverloadedSubtractionOperatorExample2>
		Private Function overloadedSubtractionOperatorExample2() As Vector

			Dim point1 As New Point(10, 5)
			Dim point2 As New Point(15, 40)

			' Subtracts a Point from another Point using the overloaded subtraction (-)
			' operator and returns the difference as a Vector.
			' vectorResult is equal to (-5, -35).
			Dim vectorResult As Vector = point1 - point2

			Return vectorResult

		End Function
		' </SnippetOverloadedSubtractionOperatorExample2>


		' <SnippetParseExample>
		Private Function parseExample() As Point

			' Converts a string representation of a point into a Point structure
			' using the Parse static method.
			' pointResult is equal to (1,3).
			Dim pointResult As Point = Point.Parse("1,3")

			Return pointResult

		End Function
		' </SnippetParseExample>

		' <SnippetSubtractExample1>
		Private Function subtractExample1() As Point

			Dim point1 As New Point(10, 5)
			Dim vector1 As New Vector(20, 30)

			' Subtracts a Vector from a Point using the static Subtract method
			' and returns the difference as a Point.
			' pointResult is equal to (-10, -25).
			Dim pointResult As Point = Point.Subtract(point1, vector1)

			Return pointResult

		End Function
		' </SnippetSubtractExample1>

		' <SnippetSubtractExample2>
		Private Function subtractExample2() As Vector

			Dim point1 As New Point(10, 5)
			Dim point2 As New Point(15, 40)

			' Subtracts a Point from a Point using the static Subtract method
			' and returns the difference as a Vector.
			' vectorResult is equal to (-5, -35)
			Dim vectorResult As Vector = Point.Subtract(point1, point2)

			Return vectorResult

		End Function
		' </SnippetSubtractExample2>

		' <SnippetToStringExample>
		Private Function toStringExample() As String

			Dim point1 As New Point(10, 5)

			' Get a string representation of a Point structure.
			' pointString is equal to 10,5	.
			Dim stringResult As String = point1.ToString()

			Return stringResult

		End Function
		' </SnippetToStringExample>


		' <SnippetPointInequalityExample>
		' Checks if two Points are equal using the overloaded inequality operator.
		Private Function pointInequalityExample() As Boolean
			' Checks if two Points are not equal using the overloaded inequality operator.

			' Declaring point1 and initializing x,y values
			Dim point1 As New Point(10, 5)

			' Declaring point2 without initializing x,y values
			Dim point2 As New Point()

			' Boolean to hold the result of the comparison
			Dim areNotEqual As Boolean

			' assigning values to point2
			point2.X = 15
			point2.Y = 40

			' Compare Point structures for equality.
			' areNotEqual is True
			areNotEqual = (point1 <> point2)

			Return areNotEqual

		End Function
		' </SnippetPointInequalityExample>



	End Class

End Namespace
