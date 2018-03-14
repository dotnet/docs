Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.VectorExamples

	Public Class VectorExample
		Inherits Page


		Public Sub New()

			Dim mainPanel As New StackPanel()


			Dim addTwoVectorsExampleText As New TextBlock()
			addTwoVectorsExampleText.Text = "addTwoVectorsExample: " & addTwoVectorsExample().ToString()
			mainPanel.Children.Add(addTwoVectorsExampleText)

			Dim addPointAndVectorExampleText As New TextBlock()
			addPointAndVectorExampleText.Text = "addPointAndVectorExample: " & addPointAndVectorExample().ToString()
			mainPanel.Children.Add(addPointAndVectorExampleText)

			Dim angleBetweenExampleText As New TextBlock()
			angleBetweenExampleText.Text = "angleBetweenExample: " & angleBetweenExample().ToString()
			mainPanel.Children.Add(angleBetweenExampleText)

			Dim crossProductExampleText As New TextBlock()
			crossProductExampleText.Text = "crossProductExample: " & crossProductExample().ToString()
			mainPanel.Children.Add(crossProductExampleText)

			Dim determinantExampleText As New TextBlock()
			determinantExampleText.Text = "determinantExample: " & determinantExample().ToString()
			mainPanel.Children.Add(determinantExampleText)

			Dim divideExampleText As New TextBlock()
			divideExampleText.Text = "divideExample: " & divideExample().ToString()
			mainPanel.Children.Add(divideExampleText)

			Dim equalsExample1Text As New TextBlock()
			equalsExample1Text.Text = "equalsExample1: " & equalsExample1().ToString()
			mainPanel.Children.Add(equalsExample1Text)

			Dim equalsExample2Text As New TextBlock()
			equalsExample2Text.Text = "equalsExample2: " & equalsExample2().ToString()
			mainPanel.Children.Add(equalsExample2Text)

			Dim getHashCodeExampleText As New TextBlock()
			getHashCodeExampleText.Text = "getHashCodeExample: " & getHashCodeExample().ToString()
			mainPanel.Children.Add(getHashCodeExampleText)

			Dim multiplyVectorByScalarExample1Text As New TextBlock()
			multiplyVectorByScalarExample1Text.Text = "multiplyVectorByScalarExample1: " & multiplyVectorByScalarExample1().ToString()
			mainPanel.Children.Add(multiplyVectorByScalarExample1Text)

			Dim multiplyVectorByScalarExample2Text As New TextBlock()
			multiplyVectorByScalarExample2Text.Text = "multiplyVectorByScalarExample2: " & multiplyVectorByScalarExample2().ToString()
			mainPanel.Children.Add(multiplyVectorByScalarExample2Text)

			Dim getDotProductExampleText As New TextBlock()
			getDotProductExampleText.Text = "getDotProductExample: " & getDotProductExample().ToString()
			mainPanel.Children.Add(getDotProductExampleText)

			Dim multiplyVectorByMatrixExampleText As New TextBlock()
			multiplyVectorByMatrixExampleText.Text = "multiplyVectorByMatrixExample: " & multiplyVectorByMatrixExample().ToString()
			mainPanel.Children.Add(multiplyVectorByMatrixExampleText)

			Dim negateExampleText As New TextBlock()
			negateExampleText.Text = "negateExample: " & negateExample().ToString()
			mainPanel.Children.Add(negateExampleText)

			Dim normalizeExampleText As New TextBlock()
			normalizeExampleText.Text = "normalizeExample: " & normalizeExample().ToString()
			mainPanel.Children.Add(normalizeExampleText)

			Dim overloadedAdditionOperatorExample1Text As New TextBlock()
			overloadedAdditionOperatorExample1Text.Text = "overloadedAdditionOperatorExample1: " & overloadedAdditionOperatorExample1().ToString()
			mainPanel.Children.Add(overloadedAdditionOperatorExample1Text)

			Dim overloadedAdditionOperatorExample2Text As New TextBlock()
			overloadedAdditionOperatorExample2Text.Text = "overloadedAdditionOperatorExample2: " & overloadedAdditionOperatorExample2().ToString()
			mainPanel.Children.Add(overloadedAdditionOperatorExample2Text)

			Dim overloadedDivisionOperatorExampleText As New TextBlock()
			overloadedDivisionOperatorExampleText.Text = "overloadedDivisionOperatorExample: " & overloadedDivisionOperatorExample().ToString()
			mainPanel.Children.Add(overloadedDivisionOperatorExampleText)

			Dim overloadedEqualityOperatorExampleText As New TextBlock()
			overloadedEqualityOperatorExampleText.Text = "overloadedEqualityOperatorExample: " & overloadedEqualityOperatorExample().ToString()
			mainPanel.Children.Add(overloadedEqualityOperatorExampleText)

			Dim overloadedExplicitOperatorExample1Text As New TextBlock()
			overloadedExplicitOperatorExample1Text.Text = "overloadedExplicitOperatorExample1: " & overloadedExplicitOperatorExample1().ToString()
			mainPanel.Children.Add(overloadedExplicitOperatorExample1Text)

			Dim overloadedExplicitOperatorExample2Text As New TextBlock()
			overloadedExplicitOperatorExample2Text.Text = "overloadedExplicitOperatorExample2: " & overloadedExplicitOperatorExample2().ToString()
			mainPanel.Children.Add(overloadedExplicitOperatorExample2Text)

			Dim overloadedInequalityOperatorExampleText As New TextBlock()
			overloadedInequalityOperatorExampleText.Text = "overloadedInequalityOperatorExample: " & overloadedInequalityOperatorExample().ToString()
			mainPanel.Children.Add(overloadedInequalityOperatorExampleText)

			Dim overloadedMultiplicationOperatorExample1Text As New TextBlock()
			overloadedMultiplicationOperatorExample1Text.Text = "overloadedMultiplicationOperatorExample1: " & overloadedMultiplicationOperatorExample1().ToString()
			mainPanel.Children.Add(overloadedMultiplicationOperatorExample1Text)

			Dim overloadedMultiplicationOperatorExample2Text As New TextBlock()
			overloadedMultiplicationOperatorExample2Text.Text = "overloadedMultiplicationOperatorExample2: " & overloadedMultiplicationOperatorExample2().ToString()
			mainPanel.Children.Add(overloadedMultiplicationOperatorExample2Text)

			Dim overloadedMultiplyVectorByMatrixOperatorExampleText As New TextBlock()
			overloadedMultiplyVectorByMatrixOperatorExampleText.Text = "overloadedMultiplyVectorByMatrixOperatorExample: " & overloadedMultiplyVectorByMatrixOperatorExample().ToString()
			mainPanel.Children.Add(overloadedMultiplyVectorByMatrixOperatorExampleText)

			Dim overloadedOperatorGetDotProductExampleText As New TextBlock()
			overloadedOperatorGetDotProductExampleText.Text = "overloadedOperatorGetDotProductExample: " & overloadedOperatorGetDotProductExample().ToString()
			mainPanel.Children.Add(overloadedOperatorGetDotProductExampleText)

			Dim overloadedSubtractionOperatorExampleText As New TextBlock()
			overloadedSubtractionOperatorExampleText.Text = "overloadedSubtractionOperatorExample: " & overloadedSubtractionOperatorExample().ToString()
			mainPanel.Children.Add(overloadedSubtractionOperatorExampleText)

			Dim overloadedNegationOperatorExampleText As New TextBlock()
			overloadedNegationOperatorExampleText.Text = "overloadedNegationOperatorExample: " & overloadedNegationOperatorExample().ToString()
			mainPanel.Children.Add(overloadedNegationOperatorExampleText)

			Dim parseExampleText As New TextBlock()
			parseExampleText.Text = "parseExample: " & parseExample().ToString()
			mainPanel.Children.Add(parseExampleText)

			Dim subtractExampleText As New TextBlock()
			subtractExampleText.Text = "subtractExample: " & subtractExample().ToString()
			mainPanel.Children.Add(subtractExampleText)

			Dim toStringExampleText As New TextBlock()
			toStringExampleText.Text = "toStringExample: " & toStringExample().ToString()
			mainPanel.Children.Add(toStringExampleText)

			Dim lengthExampleText As New TextBlock()
			lengthExampleText.Text = "lengthExample: " & lengthExample().ToString()
			mainPanel.Children.Add(lengthExampleText)

			Dim lengthSquaredExampleText As New TextBlock()
			lengthSquaredExampleText.Text = "lengthSquaredExample: " & lengthSquaredExample().ToString()
			mainPanel.Children.Add(lengthSquaredExampleText)

			Dim vectorEqualityExampleText As New TextBlock()
			vectorEqualityExampleText.Text = "vectorEqualityExample: " & vectorEqualityExample().ToString()
			mainPanel.Children.Add(vectorEqualityExampleText)

			Dim vectorConverterExampleText As New TextBlock()
			vectorConverterExampleText.Text = "vectorConverterExample: " & vectorConverterExample().ToString()
			mainPanel.Children.Add(vectorConverterExampleText)

			Me.Content = mainPanel
		End Sub

        ' <SnippetVectorConverterExample_visualbasic>
		Private Function vectorConverterExample() As Vector
			Dim vConverter As New VectorConverter()
			Dim vectorResult As New Vector()
			Dim string1 As String = "10,20"

			vectorResult = CType(vConverter.ConvertFromString(string1), Vector)
			' vectorResult is equal to (10, 20)

			Return vectorResult

		End Function
        ' </SnippetVectorConverterExample_visualbasic>

        ' <SnippetAddTwoVectorsExample_visualbasic>
		Private Function addTwoVectorsExample() As Vector
			' Create two Vector structures.
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)
			Dim vectorResult As New Vector()

			' Add the vectors together. 
			' vectorResult is equal to (65, 100).
			vectorResult = Vector.Add(vector1, vector2)

			Return vectorResult

		End Function
        ' </SnippetAddTwoVectorsExample_visualbasic>

        ' <SnippetAddPointAndVectorExample_visualbasic>
		Private Function addPointAndVectorExample() As Point
			Dim vector1 As New Vector(20, 30)
			Dim point1 As New Point(10, 5)
			Dim pointResult As New Point()

			' Add Point and Vector together.
			' pointResult is equal to (30,35).
			pointResult = Vector.Add(vector1, point1)

			Return pointResult

		End Function
        ' </SnippetAddPointAndVectorExample_visualbasic>

        ' <SnippetAngleBetweenExample_visualbasic>
		Private Function angleBetweenExample() As Double
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)
			Dim angleBetween As Double

			' angleBetween is approximately equal to 0.9548
			angleBetween = Vector.AngleBetween(vector1, vector2)

			Return angleBetween

		End Function
        ' </SnippetAngleBetweenExample_visualbasic>

        ' <SnippetCrossProductExample_visualbasic>
		Private Function crossProductExample() As Double
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)
			Dim crossProduct As Double

			' crossProduct is equal to 50    
			crossProduct = Vector.CrossProduct(vector1, vector2)

			Return crossProduct

		End Function
        ' </SnippetCrossProductExample_visualbasic>

        ' <SnippetDeterminantExample_visualbasic>
		Private Function determinantExample() As Double
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)
			Dim determinant As Double

			' determinant is equal to 50
			determinant = Vector.Determinant(vector1, vector2)

			Return determinant

		End Function
        ' </SnippetDeterminantExample_visualbasic>

        ' <SnippetDivideExample_visualbasic>
		Private Function divideExample() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim vectorResult As New Vector()
			Dim scalar1 As Double = 75

			' Divide vector by scalar.
			' vectorResult is approximately equal to (0.26667,0.4)
			vectorResult = Vector.Divide(vector1, scalar1)

			Return vectorResult

		End Function
        ' </SnippetDivideExample_visualbasic>

        ' <SnippetEqualsExample1_visualbasic>
		Private Function equalsExample1() As Boolean

			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(20, 30)
			Dim areEqual As Boolean = False

			' areEqual is True
			If Vector.Equals(vector1, vector2) Then
			  areEqual = True
			End If

			Return areEqual

		End Function
        ' </SnippetEqualsExample1_visualbasic>

        ' <SnippetEqualsExample2_visualbasic>
		Private Function equalsExample2() As Boolean

			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(20, 30)
			Dim areEqual As Boolean = False

			' areEqual is True.  Both parameters are Vector structures, 
			' and they are equal.
			If vector1.Equals(vector2) Then
				areEqual = True
			End If

			Return areEqual

		End Function
        ' </SnippetEqualsExample2_visualbasic>

        ' <SnippetGetHashCodeExample_visualbasic>
		Private Function getHashCodeExample() As Integer
			Dim vector1 As New Vector(20, 30)
			Dim returnHashCode As Integer = vector1.GetHashCode()

			Return returnHashCode

		End Function
        ' </SnippetGetHashCodeExample_visualbasic>

        ' <SnippetMultiplyVectorByScalarExample1_visualbasic>
		Private Function multiplyVectorByScalarExample1() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim scalar1 As Double = 75
			Dim vectorResult As New Vector()

			' Multiply the vector by the scalar.
			' vectorResult is equal to (1500,2250)
			vectorResult = Vector.Multiply(vector1, scalar1)

			Return vectorResult

		End Function
        ' </SnippetMultiplyVectorByScalarExample1_visualbasic>

        ' <SnippetMultiplyVectorByScalarExample2_visualbasic>
		Private Function multiplyVectorByScalarExample2() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim scalar1 As Double = 75
			Dim vectorResult As New Vector()

			' Multiply the vector by the scalar.
			' vectorResult is equal to (1500,2250)
			vectorResult = Vector.Multiply(scalar1, vector1)

			Return vectorResult

		End Function
        ' </SnippetMultiplyVectorByScalarExample2_visualbasic>

        ' <SnippetGetDotProductExample_visualbasic>
		Private Function getDotProductExample() As Double
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)
			Dim doubleResult As Double

			' Return the dot product of the two specified vectors.
			' The dot product is calculated using the following 
			' formula: (vector1.X * vector2.X) + (vector1.Y * vector2.Y).
			' doubleResult is equal to 3000
			doubleResult = Vector.Multiply(vector1, vector2)

			Return doubleResult

		End Function
        ' </SnippetGetDotProductExample_visualbasic>

        ' <SnippetMultiplyVectorByMatrixExample_visualbasic>
		Private Function multiplyVectorByMatrixExample() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim matrix1 As New Matrix(40, 50, 60, 70, 80, 90)
			Dim vectorResult As New Vector()

			' Multiply the vector and matrix.
			' vectorResult is equal to (2600,3100).
			vectorResult = Vector.Multiply(vector1, matrix1)

			Return vectorResult

		End Function
        ' </SnippetMultiplyVectorByMatrixExample_visualbasic>

        ' <SnippetNegateExample_visualbasic>
		Private Function negateExample() As Vector
			Dim vectorResult As New Vector(20, 30)

			' Make the direction of the Vector opposite but
			' leave the vector magnitude the same.
			' vectorResult is equal to (-20, -30)
			vectorResult.Negate()

			Return vectorResult

		End Function
        ' </SnippetNegateExample_visualbasic>

        ' <SnippetNormalizeExample_visualbasic>
		Private Function normalizeExample() As Vector
			Dim vectorResult As New Vector(20, 30)

			' A normalized vector maintains its direction but 
			' its length becomes 1. 
			' vectorResult is approximately equal to (0.5547,0.8321).
			vectorResult.Normalize()

			Return vectorResult

		End Function
        ' </SnippetNormalizeExample_visualbasic>

		' <SnippetOverloadedAdditionOperatorExample1>
		Private Function overloadedAdditionOperatorExample1() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)
			Dim vectorResult As New Vector()

			' Add the two vectors together.
			' vectorResult is equal to (65,100)
			vectorResult = vector1 + vector2

			Return vectorResult

		End Function
		' </SnippetOverloadedAdditionOperatorExample1>

		' <SnippetOverloadedAdditionOperatorExample2>
		Private Function overloadedAdditionOperatorExample2() As Point
			Dim point1 As New Point(10, 5)
			Dim vector1 As New Vector(20, 30)
			Dim pointResult As New Point()

			' Add the point to the vector.
			' pointResult is equal to (30,35).
			pointResult = point1 + vector1

			Return pointResult

		End Function
		' </SnippetOverloadedAdditionOperatorExample2>

		' <SnippetOverloadedDivisionOperatorExample>
		Private Function overloadedDivisionOperatorExample() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim vectorResult As New Vector()
			Dim scalar1 As Double = 75

			' Divide vector by scalar.
			' vectorResult is approximately equal to (0.26667,0.4)
			vectorResult = vector1 / scalar1

			Return vectorResult

		End Function
		' </SnippetOverloadedDivisionOperatorExample>

		' <SnippetOverloadedEqualityOperatorExample>
		Private Function overloadedEqualityOperatorExample() As Boolean
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)

			' If the two vectors are equal, areEqual is True,
			' otherwise it is False. In this example it is False.
			Dim areEqual As Boolean = (vector1 = vector2)

			Return areEqual

		End Function
		' </SnippetOverloadedEqualityOperatorExample>

		' <SnippetOverloadedExplicitOperatorExample1>
		Private Function overloadedExplicitOperatorExample1() As Size
			Dim vector1 As New Vector(20, 30)

			' Explicitly converts a Vector structure into a Size structure.
			' returnSize has a width of 20 and a height of 30.
			Dim returnSize As Size = CType(vector1, Size)

			Return returnSize

		End Function
		' </SnippetOverloadedExplicitOperatorExample1>

		' <SnippetOverloadedExplicitOperatorExample2>
		Private Function overloadedExplicitOperatorExample2() As Point
			Dim vector1 As New Vector(20, 30)

			' Explicitly converts a Vector structure into a Point structure.
			' returnPoint is equal to (20, 30).
			Dim returnPoint As Point = CType(vector1, Point)

			Return returnPoint

		End Function
		' </SnippetOverloadedExplicitOperatorExample2>

		' <SnippetOverloadedInequalityOperatorExample>
		Private Function overloadedInequalityOperatorExample() As Boolean
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)
			Dim areNotEqual As Boolean

			' Check whether the two Vectors are not equal, using the overloaded 
			' inequality operator.
			' areNotEqual is True.
			areNotEqual = (vector1 <> vector2)

			Return areNotEqual

		End Function
		' </SnippetOverloadedInequalityOperatorExample>

		' <SnippetOverloadedMultiplicationOperatorExample1>
		Private Function overloadedMultiplicationOperatorExample1() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim scalar1 As Double = 75

			' vectorResult is equal to (1500,2250)
			Dim vectorResult As Vector = vector1 * scalar1

			Return vectorResult

		End Function
		' </SnippetOverloadedMultiplicationOperatorExample1>

		' <SnippetOverloadedMultiplicationOperatorExample2>
		Private Function overloadedMultiplicationOperatorExample2() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim scalar1 As Double = 75

			' vectorResult is equal to (1500,2250)
			Dim vectorResult As Vector = scalar1 * vector1

			Return vectorResult

		End Function
		' </SnippetOverloadedMultiplicationOperatorExample2>

		' <SnippetOverloadedMultiplyVectorByMatrixOperatorExample>
		Private Function overloadedMultiplyVectorByMatrixOperatorExample() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim matrix1 As New Matrix(40, 50, 60, 70, 80, 90)
			Dim vectorResult As New Vector()

			' Multiply the vector and matrix.
			' vectorResult is equal to (2600,3100).
			vectorResult = vector1 * matrix1

			Return vectorResult

		End Function
		' </SnippetOverloadedMultiplyVectorByMatrixOperatorExample>

		' <SnippetOverloadedOperatorGetDotProductExample>
		Private Function overloadedOperatorGetDotProductExample() As Double
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)

			' Return the dot product of the two specified vectors
			' using the overloaded "*" operator.
			' The dot product is calculated using the following 
			' formula: (vector1.X * vector2.X) + (vector1.Y * vector2.Y).
			' doubleResult is equal to 3000
			Dim doubleResult As Double = Vector.Multiply(vector1, vector2)

			Return doubleResult

		End Function
		' </SnippetOverloadedOperatorGetDotProductExample>

		' <SnippetOverloadedSubtractionOperatorExample>
		Private Function overloadedSubtractionOperatorExample() As Vector
			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)

			' Subtract vector2 from vector1 using the overloaded
			' "-" operator.
			' vector Result is equal to (-25, -40).
			Dim vectorResult As Vector = vector1 - vector2

			Return vectorResult

		End Function
		' </SnippetOverloadedSubtractionOperatorExample>

		' <SnippetOverloadedNegationOperatorExample>
		Private Function overloadedNegationOperatorExample() As Vector
			Dim vector1 As New Vector(20, 30)

			' Negate vector1 with the overloaded negation operator.
			' vectorResult is equal to (-20, -30).
			Dim vectorResult As Vector = -vector1

			Return vectorResult

		End Function
		' </SnippetOverloadedNegationOperatorExample>

		' <SnippetParseExample>
		Private Function parseExample() As Vector

			' Convert string into a Vector structure.
			' vectorResult is equal to (1,3)
			Dim vectorResult As Vector = Vector.Parse("1,3")

			Return vectorResult

		End Function
		' </SnippetParseExample>

		' <SnippetSubtractExample>
		Private Function subtractExample() As Vector

			Dim vector1 As New Vector(20, 30)
			Dim vector2 As New Vector(45, 70)

			' Subtract vector2 from vector1.
			' vectorResult is equal to (-25, -40)
			Dim vectorResult As Vector = Vector.Subtract(vector1, vector2)

			Return vectorResult

		End Function
		' </SnippetSubtractExample>

		' <SnippetToStringExample>
		Private Function toStringExample() As String

			Dim vector1 As New Vector(20, 30)

			' vectorString is equal to "20,30".
			Dim stringResult As String = vector1.ToString()

			Return stringResult

		End Function
		' </SnippetToStringExample>

		' <SnippetLengthExample>
		Private Function lengthExample() As Double

			Dim vector1 As New Vector(20, 30)

			' Get the length of the vector.
			' length is approximately equal to 36.0555
			Dim lengthResult As Double = vector1.Length

			Return lengthResult

		End Function
		' </SnippetLengthExample>

		' <SnippetLengthSquaredExample>
		Private Function lengthSquaredExample() As Double

			Dim vector1 As New Vector(20, 30)

			' Gets the square of the length of a Vector. 
			' lengthSq is equal to 1300.
			Dim lengthSqResult As Double = vector1.LengthSquared

			Return lengthSqResult

		End Function
		' </SnippetLengthSquaredExample>

		' <SnippetVectorEqualityExample>
		' Checks if two Vectors are equal using the overloaded equality operator.
		Private Function vectorEqualityExample() As Boolean

			' Declaring vecto1 and initializing x,y values
			Dim vector1 As New Vector(20, 30)

			' Declaring vector2 without initializing x,y values
			Dim vector2 As New Vector()

			' Boolean to hold the result of the comparison
			Dim areEqual As Boolean

			' assigning values to vector2
			vector2.X = 45
			vector2.Y = 70

			' Comparing Vectors for equality
			' areEqual is False
			areEqual = (vector1 = vector2)

			Return areEqual

		End Function
		' </SnippetVectorEqualityExample>



	End Class

End Namespace
