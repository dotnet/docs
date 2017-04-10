'This is a list of commonly used namespaces for a window.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Media3D

Namespace ThreeDPointSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub


		' This method performs the Point3D operations
		'<SnippetMil3DPoints3DN1>
		Private Sub PerformOperation(ByVal sender As Object, ByVal e As RoutedEventArgs)

			Dim li As RadioButton = (TryCast(sender, RadioButton))

			' Strings used to display the results
			Dim syntaxString, resultType, operationString As String

			' The local variables point1, point2, vector2, etc are defined in each
			' case block for readability reasons. Each variable is contained within
			' the scope of each case statement.  
			Select Case li.Name

			'</SnippetMil3DPoints3DN1>
				Case "rb1"
						'<SnippetMil3DPoints3DN3>
						' Translates a Point3D by a Vector3D using the overloaded + operator. 
						' Returns a Point3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim vector1 As New Vector3D(20, 30, 40)
						Dim pointResult As New Point3D()

						pointResult = point1 + vector1
						' point3DResult is equal to (30, 35, 41)

						' Displaying Results
						syntaxString = "pointResult = point1 + vector1"
						resultType = "Point3D"
						operationString = "Adding a 3D Point and a 3D Vector"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN3>
						Exit Select

				Case "rb2"
						'<SnippetMil3DPoints3DN4>
						' Translates a Point3D by a Vector3D using the static Add method.
						' Returns a Point3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim vector1 As New Vector3D(20, 30, 40)
						Dim pointResult As New Point3D()

						pointResult = Point3D.Add(point1, vector1)
						' pointResult is equal to (30, 35, 41)

						' Displaying Results
						syntaxString = "pointResult = Point3D.Add(point1, vector1)"
						resultType = "Point3D"
						operationString = "Adding a 3D Point and a 3D Vector"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN4>
						Exit Select

				Case "rb3"
						'<SnippetMil3DPoints3DN5>
						' Subtracts a Vector3D from a Point3D using the overloaded - operator.
						' Returns a Point3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim vector1 As New Vector3D(20, 30, 40)
						Dim pointResult As New Point3D()

						pointResult = point1 - vector1
						' pointResult is equal to (-10, -25, -39) 

						' Displaying Results
						syntaxString = "pointResult = point1 - vector1"
						resultType = "Point3D"
						operationString = "Subtracting a Vector3D from a Point3D"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN5>
						Exit Select

				Case "rb4"
						'<SnippetMil3DPoints3DN6>
						' Subtracts a Vector3D from a Point3D using the static Subtract method. 
						' Returns a Point3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim vector1 As New Vector3D(20, 30, 40)
						Dim pointResult As New Point3D()

						pointResult = Point3D.Subtract(point1, vector1)
						' pointResult is equal to (-10, -25, -39)

						' Displaying Results
						syntaxString = "pointResult = Point3D.Subtract(point1, vector1)"
						resultType = "Point3D"
						operationString = "Subtracting a Vector3D from a Point3D"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN6>
						Exit Select

				Case "rb5"
						'<SnippetMil3DPoints3DN7>
						' Subtracts a Point3D from a Point3D using the overloaded - operator.
						' Returns a Vector3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim point2 As New Point3D(15, 40, 60)
						Dim vectorResult As New Vector3D()

						vectorResult = point1 - point2
						' vectorResult is equal to (-5, -35, -59)

						' Displaying Results
						syntaxString = " vectorResult = point1 - point2"
						resultType = "Vector3D"
						operationString = "Subtracting a Point3D from a Point3D"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN7>
						Exit Select

				Case "rb6"
						'<SnippetMil3DPoints3DN8>
						' Subtracts a Point3D from a Point3D using the static Subtract method.  
						' Returns a Vector3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim point2 As New Point3D(15, 40, 60)
						Dim vectorResult As New Vector3D()

						vectorResult = Point3D.Subtract(point1, point2)
						' vectorResult is equal to (-5, -35, -59)

						' Displaying Results
						syntaxString = "vectorResult = Point3D.Subtract(point1, point2)"
						resultType = "Vector3D"
						operationString = "Subtracting a Point3D from a Point3D"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN8>
						Exit Select

				Case "rb7"
						'<SnippetMil3DPoints3DN9>
						' Offsets the X, Y and Z values of a Point3D.

						Dim point1 As New Point3D(10, 5, 1)

						point1.Offset(20, 30, 40)
						' point1 is equal to (30, 35, 41)

						' Note: This operation is equivalent to adding a point 
						' to vector with the corresponding X,Y, Z values.

						' Displaying Results
						syntaxString = "point1.Offset(20, 30, 40)"
						resultType = "Point3D"
						operationString = "Offsetting a Point3D"
						ShowResults(point1.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN9>
						Exit Select

				Case "rb8"
						'<SnippetMil3DPoints3DN10>
						' Multiplies a Point3D by a Matrix.  
						' Returns a Point3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim pointResult As New Point3D()
						Dim matrix1 As New Matrix3D(10, 10, 10, 0, 20, 20, 20, 0, 30, 30, 30, 0, 5, 10, 15, 1)

						pointResult = point1 * matrix1
						' pointResult is equal to (235, 240, 245)

						' Displaying Results
						resultType = "Point3D"
						syntaxString = "pointResult = point1 * matrix1"
						operationString = "Multiplying a Point3D by a Matrix3D"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN10>
						Exit Select

				Case "rb9"
						'<SnippetMil3DPoints3DN11>
						' Multiplies a Point3D by a Matrix.  
						' Returns a Point3D.

						Dim point1 As New Point3D(10, 5, 1)
						Dim pointResult As New Point3D()
						Dim matrix1 As New Matrix3D(10, 10, 10, 0, 20, 20, 20, 0, 30, 30, 30, 0, 5, 10, 15, 1)

						pointResult = Point3D.Multiply(point1, matrix1)
						' pointResult is equal to (235, 240, 245)

						' Displaying Results
						resultType = "Point3D"
						syntaxString = "pointResult = Point3D.Multiply(point1, matrix1)"
						operationString = "Multiplying a Point3D by a Matrix"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN11>
						Exit Select

				Case "rb10"
						'<SnippetMil3DPoints3DN12>
						' Checks if two Point3Ds are equal using the overloaded equality operator.

						Dim point1 As New Point3D(10, 5, 1)
						Dim point2 As New Point3D(15, 40, 60)
						Dim areEqual As Boolean

						areEqual = (point1 = point2)
						' areEqual is False

						' Displaying Results
						syntaxString = "areEqual = (point1 == point2)"
						resultType = "Boolean"
						operationString = "Checking if two 3D points are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN12>
						Exit Select


				Case "rb11"
						'<SnippetMil3DPoints3DN13>
						' Checks if two Point3D structures are equal using the static Equals method.

						Dim point1 As New Point3D(10, 5, 1)
						Dim point2 As New Point3D(15, 40, 60)
						Dim areEqual As Boolean

						areEqual = Point3D.Equals(point1, point2)
						' areEqual is False	

						'Displaying Results
						syntaxString = "areEqual = Point3D.Equals(point1, point2)"
						resultType = "Boolean"
						operationString = "Checking if 3D two points are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN13>
						Exit Select
				Case "rb12"
						'<SnippetMil3DPoints3DN14>
						' Compares an Object and a Point3D for equality using the non-static Equals method.

						Dim point1 As New Point3D(10, 5, 1)
						Dim point2 As New Point3D(15, 40, 60)
						Dim areEqual As Boolean

						areEqual = point1.Equals(point2)
						' areEqual is False.  point2 is a Point3D structure, but it is not equal to point1.	


						' Displaying Results
						syntaxString = "areEqual = point1.Equals(point2)"
						resultType = "Boolean"
						operationString = "Checking if two 3D points are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN14>
						Exit Select


				Case "rb13"
						'<SnippetMil3DPoints3DN15>
						' Converts a string representation of a 3-D point into a Point3D structure.

						Dim pointResult As New Point3D()

						pointResult = Point3D.Parse("1,3,5")
						' pointResult is equal to (1,3,5)

						' Displaying Results
						syntaxString = "ointResult = Point3D.Parse(""1,3,5"")"
						resultType = "Matrix"
						operationString = "Converting a string into a Point3D structure."
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN15>
						Exit Select

				Case "rb14"
						'<SnippetMil3DPoints3DN16>
						' Checks if two Point3Ds are not equal using the overloaded inequality operator.

						Dim point1 As New Point3D(10, 5, 1)
						Dim point2 As New Point3D(15, 40, 60)
						Dim areNotEqual As Boolean

						areNotEqual = (point1 <> point2)
						' areNotEqual is True

						' Displaying Results
						syntaxString = "areNotEqual = (point1 != point2)"
						resultType = "Boolean"
						operationString = "Checking if two 3D points are not equal"
						ShowResults(areNotEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN16>
						Exit Select

				Case "rb15"
						'<SnippetMil3DPoints3DN17>
						' Point3D Subtraction

						' instantiate variables
						Dim point1 As New Point3D()
						Dim point2 As New Point3D(15, 40, 60)
						Dim vector1 As New Vector3D(20, 30, 40)
						Dim pointResult As New Point3D()
						Dim vectorResult As New Vector3D()

						' defining x,y,z of point1
						point1.X = 10
						point1.Y = 5
						point1.Z = 1

						vectorResult = Point3D.Subtract(point1, point2)
						' vectorResult is equal to (-5, -35, -39)

						vectorResult = point2 - point1
						' vectorResult is equal to (5, 35, 59)

						'pointResult = Point3D.Subtract(point1, vector1)
						'  pointResult is equal to (-10, -25, -39)

						pointResult = vector1 - point1
						'  pointResult is equal to (10, 25, 39)


						' Displaying Results
						syntaxString = "areNotEqual = (point1 != point2)"
						resultType = "Boolean"
						operationString = "Checking if two 3D points are not equal"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3DPoints3DN17>
						Exit Select

				Case Else
					Exit Select
				'<SnippetMil3DPoints3DN2>
            End Select 'end Select

		End Sub
		'</SnippetMil3DPoints3DN2>

		' Displays the results of the operation
		Private Sub ShowResults(ByVal resultValue As String, ByVal syntax As String, ByVal resultType As String, ByVal opString As String)

			txtResultValue.Text = resultValue
			txtSyntax.Text = syntax
			txtResultType.Text = resultType
			txtOperation.Text = opString
		End Sub

		' Displays the values of the variables
		Public Sub ShowVars()

			Dim p1 As New Point3D(10, 5, 1)
			Dim p2 As New Point3D(15, 40, 60)

			Dim v1 As New Vector3D(20, 30, 40)
			Dim v2 As New Vector3D(45, 70, 80)

			Dim m1 As New Matrix3D(10,10,10,0,20,20,20,0,30,30,30,0,5,10,15,1)

			' Displaying values in Text objects
			txtPoint1.Text = p1.ToString()
			txtPoint2.Text = p2.ToString()
			txtVector1.Text = v1.ToString()
			txtVector2.Text = v2.ToString()
			txtMatrix1.Text = m1.ToString()
		End Sub

		Public Sub AddSubOperations()
			Dim point3D1 As New Point3D()
			Dim point3D2 As New Point3D(5, 6, 7)
			Dim vector3D1 As New Vector3D(10, 15, 25)
			Dim point3DResult As New Point3D()
			Dim vector3DResult As New Vector3D()

			' Assigning x,y,z values to Point3D1
			point3D1.X = 10
			point3D1.Y = 12
			point3D1.Z = 15

			' Add a Vector3D and a Point3D using the overloaded + operator
			' Returns a Point3D

			point3DResult = vector3D1 + point3D1
			' point3DResult is equal to 

			' Add a Point3D and a Vector3D using the static Add method
			' Returns a Point3D

			point3DResult = Point3D.Add(point3D1, vector3D1)
			' point3DResult is equal to 

			' Subtract a Vector3D from a Point3D using the overloaded - operator
			' Returns a Point3D

			point3DResult = point3D1 - vector3D1
			' point3DResult is equal to 

			' Subtracts a Point3D from a Point3D using the overload - operator
			' Returns a Vector3D

			vector3DResult = point3D1 - point3D2
			' vector3DResult is equal to 


			' Subtracts a Vector3D from a Point3D using the static Subtract method
			' Returns a Point3D

			point3DResult = Point3D.Subtract(point3D1, vector3D1)
			' point3DResult is equal to  

			' Subtracts a Point3D from a Point3D
			' Returns a Vector3D

			vector3DResult = Point3D.Subtract(point3D1, point3D2)
			' vector3Dresult is equal to 

		End Sub
	End Class
End Namespace