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

Namespace ThreeDSizeSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
		'<SnippetMil3dSize3DN1>
		Private Sub PerformOperation(ByVal sender As Object, ByVal e As RoutedEventArgs)

			Dim li As RadioButton = (TryCast(sender, RadioButton))

			' Strings used to display the results
			Dim syntaxString, resultType, operationString As String

			' The local variables point1, point2, vector2, etc are defined in each
			' case block for readability reasons. Each variable is contained within
			' the scope of each case statement.  
			'</SnippetMil3dSize3DN1>
			Select Case li.Name


				Case "rb1"
						'<SnippetMil3dSize3DN2>
						' Checks if two Size3D structures are equal using the static Equals method. 
						' Returns a Boolean.

						' Declaring Size3D structure without initializing x,y,z values
						Dim size1 As New Size3D()

						' Declaring Size3D structure and initializing x,y,z values
						Dim size2 As New Size3D(5, 10, 15)
						Dim areEqual As Boolean

						' Assigning values to size1
						size1.X = 2
						size1.Y = 4
						size1.Z = 6

						' checking for equality
						areEqual = Size3D.Equals(size1, size2)

						' areEqual is False

						' Displaying Results
						syntaxString = "areEqual = Size3D.Equals(size1, size2)"
						resultType = "Boolean"
						operationString = "Checking if two Size3D structures are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN2>
						Exit Select
				Case "rb2"
						'<SnippetMil3dSize3DN3>
						' Checks if an Object and a Size3D structure are equal using the non-static Equals method. 
						' Returns a Boolean.

						' Declaring Size3D structure without initializing x,y,z values
						Dim size1 As New Size3D()

						' Declaring Size3D structure and initializing x,y,z values
						Dim size2 As New Size3D(5, 10, 15)
						Dim areEqual As Boolean

						' Assigning values to size1
						size1.X = 2
						size1.Y = 4
						size1.Z = 6

						areEqual = size1.Equals(size2)
						' areEqual is False

						' Displaying Results
						syntaxString = "areEqual = Size3D.Equals(size1, size2)"
						resultType = "Boolean"
						operationString = "Checking if an object and a Size3D structure are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN3>
						Exit Select

				Case "rb3"
						'<SnippetMil3dSize3DN4>
						' Checks if two Size3D structures are equal using the overloaded == operator. 
						' Returns a Boolean.

						' Declaring Size3D structure without initializing x,y,z values
						Dim size1 As New Size3D()

						' Declaring Size3D structure and initializing x,y,z values
						Dim size2 As New Size3D(5, 10, 15)
						Dim areEqual As Boolean

						' Assigning values to size1
						size1.X = 2
						size1.Y = 4
						size1.Z = 6

						' Checking for equality
						areEqual = size1 = size2

						' areEqual is False

						' Displaying Results
						syntaxString = " areEqual = size1 == size2"
						resultType = "Boolean"
						operationString = "Checking if two Size3D structures are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN4>
						Exit Select

				Case "rb4"
						'<SnippetMil3dSize3DN5>
						' Checks if two Size3D structures are not equal using the overloaded != operator. 
						' Returns a Boolean.

						Dim size1 As New Size3D(2, 4, 6)
						Dim size2 As New Size3D(5, 10, 15)
						Dim areNotEqual As Boolean

						areNotEqual = size1 <> size2
						' areNotEqual is True

						' Displaying Results
						syntaxString = "areNotEqual = size1 != size2"
						resultType = "Boolean"
						operationString = "Checking if two Size3D structures are not equal"
						ShowResults(areNotEqual.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN5>
						Exit Select

				Case "rb5"
						'<SnippetMil3dSize3DN6>
						' Converts a string representation of a 3-D size into a Size3D structure.

						Dim sizeResult As New Size3D()

						sizeResult = Size3D.Parse("10,20,30")
						' sizeResult is equal to (10,20,30)

						' Displaying Results
						syntaxString = "sizeResult = Size3D.Parse(""10,20,30"")"
						resultType = "Size3D"
						operationString = "Converting a string into a Size3D structure"
						ShowResults(sizeResult.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN6>
						Exit Select

				Case "rb6"
						'<SnippetMil3dSize3DN7>
						' Explicitly converts a Size3D structure into a Vector3D structure
						' Returns a Vector3D.

						Dim size1 As New Size3D(2, 4, 6)
						Dim vector1 As New Vector3D()

						vector1 = CType(size1, Vector3D)
						' vector1 is equal to (2, 4, 6)

						' Displaying Results
						syntaxString = "vector1 = (Vector3D)size1"
						resultType = "Vector3D"
						operationString = "Expliciting casting a Size3D into a Vector3D"
						ShowResults(vector1.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN7>
						Exit Select

				Case "rb7"
						'<SnippetMil3dSize3DN8>
						' Explicitly converts a Size3D structure into a Point3D structure
						' Returns a Vector3D.

						Dim size1 As New Size3D(2, 4, 6)
						Dim point1 As New Point3D()

						point1 = CType(size1, Point3D)
						' point1 is equal to (2, 4, 6)

						' Displaying Results
						syntaxString = "point1 = (Point3D)size1"
						resultType = "Point3D"
						operationString = "Expliciting casting a Size3D into a Point3D"
						ShowResults(point1.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN8>
						Exit Select

				Case "rb8"
						'<SnippetMil3dSize3DN9>
						' Checks if a Size3D structure is empty
						' Returns Boolean

						Dim size1 As New Size3D(0, 0, 0)
						Dim isEmpty As Boolean

						isEmpty = size1.IsEmpty
						' isEmpty is False 

						' Displaying Results
						syntaxString = "isEmpty = size1.IsEmpty"
						resultType = "Boolean"
						operationString = "Checking if a Size3D structure is empty"
						ShowResults(isEmpty.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN9>
						Exit Select

				Case "rb9"
						'<SnippetMil3dSize3DN10>
						' Gets an empty Size3D structure
						Dim size1 As New Size3D(2, 4, 6)

						size1 = Size3D.Empty
						' size1 is now empty



						' Displaying Results
						syntaxString = "size1 = Size3D.Empty"
						resultType = "Size3D"
						operationString = "Getting an empty Size3D structure"
						ShowResults(size1.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN10>
						Exit Select

				Case "rb10"
						'<SnippetMil3dSize3DN11>
						' Gets a string representation of a Size3D Structure

						Dim size1 As New Size3D(2,4,6)
						Dim sizeString As String

						sizeString = size1.ToString()
						' sizeString is equal to "2,4,6"

						' Displaying Results
						resultType = "String"
						syntaxString = "sizeString = size1.ToString()"
						operationString = "Getting the ToString of size1"
						ShowResults(sizeString.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN11>
						Exit Select

				Case "rb11"
						'<SnippetMil3dSize3DN12>
						' Gets the hashcode of a Size3D Structure

						Dim size1 As New Size3D(2, 4, 6)
						Dim sizeHashcode As Integer

						sizeHashcode = size1.GetHashCode()

						' Displaying Results
						resultType = "int"
						syntaxString = "sizeHashcode = size1.GetHashCode"
						operationString = "Getting the hashcode of size1"
						ShowResults(sizeHashcode.ToString(), syntaxString, resultType, operationString)
						'</SnippetMil3dSize3DN12>
						Exit Select
				Case Else
					Exit Select

			End Select 'end switch

		End Sub


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

			Dim v1 As New Vector3D(20, 30, 40)
			Dim s1 As New Size3D(2, 4, 6)
			Dim s2 As New Size3D(5, 10, 15)

			' Displaying values in Text objects
			txtPoint1.Text = p1.ToString()
			txtVector1.Text = v1.ToString()
			txtSize1.Text = s1.ToString()
			txtSize2.Text = s2.ToString()
		End Sub
	End Class
End Namespace