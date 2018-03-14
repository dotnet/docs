'This is a list of commonly used namespaces for a window.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections
Imports System.Threading

Namespace PointCollectionSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>


	Partial Public Class Window1
		Inherits Window
		Private num As Long = 3
		Private continueCalculating As Boolean = False



		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub PointCollectionOperations(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Dim li As RadioButton = (TryCast(sender, RadioButton))

			' Strings used to display the results
            Dim syntaxString, resultType, operationString As String

			' The local variables point1, point2, vector2, etc are defined in each
			' case block for readability reasons. Each variable is contained within
			' the scope of each case statement.  
			Select Case li.Name

				Case "rb1"
						'<SnippetPointCollectionAdd>

						' Instantiating and initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)
						Dim point4 As New Point(40, 40)

						' Instantiating an array of Points to the points
						Dim pointArray(2) As Point

						' Adding points to array
						pointArray(0) = point1
						pointArray(1) = point2
						pointArray(2) = point3

						' Instantiating a PointCollection and initializing with an array
						Dim pointCollection1 As New PointCollection(pointArray)

						'  Adding a point to the PointCollection
						pointCollection1.Add(point4)

						' pointCollection1 is equal to (10,10 20,20 30,30 40,40)

						'</SnippetPointCollectionAdd>



						Exit Select

				Case "rb2"

						'<SnippetPointCollectionClear>

						' Instantiating and initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)

						' Instantiating a PointCollection 
						Dim pointCollection1 As New PointCollection()

						' Adding Points to the PointCollection
						pointCollection1.Add(point1)
						pointCollection1.Add(point2)
						pointCollection1.Add(point3)

						' pointCollection1 is equal to (10,10 20,20 30,30)

						' clearing the PointCollection
						pointCollection1.Clear()

						' pointCollection1 is now empty

						'</SnippetPointCollectionClear>

						Exit Select

				Case "rb3"

						'<SnippetPointCollectionContains>

						Dim inCollection As Boolean

						' Instantiating and Initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)
						Dim point4 As New Point(40, 40)

						' Instantiating a PointCollection 
						Dim pointCollection1 As New PointCollection()

						pointCollection1.Add(point1)
						pointCollection1.Add(point2)
						pointCollection1.Add(point3)

						' pointCollection1 is equal to (10,10 20,20 30,30)

						inCollection = pointCollection1.Contains(point4)

						' inCollection is equal to False

						'</SnippetPointCollectionContains>

						Exit Select

				Case "rb4"

						'<SnippetPointCollectionIndexOf>

						Dim pIndex As Integer

						' Instantiating and initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)

						' Instantiating a PointCollection 
						Dim pointCollection1 As New PointCollection()

						' Adding Points to PointCollection
						pointCollection1.Add(point1)
						pointCollection1.Add(point2)
						pointCollection1.Add(point3)
						' pointCollection1 is equal to (10,10 20,20 30,30)

						' Getting the index of a Point
						pIndex = pointCollection1.IndexOf(point2)

						' pointIndex is equal to 1

						'</SnippetPointCollectionIndexOf>

						Exit Select

				Case "rb5"
						'<SnippetPointCollectionInsert>

						' Instantiating and initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)
						Dim point4 As New Point(40, 40)

						' Instantiating a PointCollection 
						Dim pointCollection1 As New PointCollection()

						' Adding Points to the PointCollection
						pointCollection1.Add(point1)
						pointCollection1.Add(point2)
						pointCollection1.Add(point3)

						' pointCollection1 is equal to (10,10 20,20 30,30)

						' Inserting a Point into the PointCollection
						pointCollection1.Insert(1, point4)

						' pointCollection1 is now equal to (10,10 40,40 20,20 30,30

						'</SnippetPointCollectionInsert>

						Exit Select

				Case "rb6"

						'<SnippetPointCollectionRemove>

						' Instantiating and initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)

						' Instantiating a PointCollection 
						Dim pointCollection1 As New PointCollection()

						' Adding Points to PointCollection
						pointCollection1.Add(point1)
						pointCollection1.Add(point2)
						pointCollection1.Add(point3)

						' pointCollection1 is equal to (10,10 20,20 30,30)

						' Removing a Point from the PointCollection
						pointCollection1.Remove(point2)

						' pointCollection1 is equal to 10,10 30,30

						'</SnippetPointCollectionRemove>

						Exit Select

				Case "rb7"
						'<SnippetPointCollectionRemoveAt>

						' Instantiating and initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)

						' Instantiating a PointCollection 
						Dim pointCollection1 As New PointCollection()

						' Adding Points to the PointCollection
						pointCollection1.Add(point1)
						pointCollection1.Add(point2)
						pointCollection1.Add(point3)

						' pointCollection1 is equal to (10,10 20,20 30,30)

						' Removing a range of Points
						pointCollection1.RemoveAt(1)

						' pointCollection1 is equal to (10,10 30,30)

						'</SnippetPointCollectionRemoveAt>

						Exit Select
				Case "rb8"
						'<SnippetPointCollectionToString>
						Dim pcString As String

						' Instantiating and initializing Point structures
						Dim point1 As New Point(10, 10)
						Dim point2 As New Point(20, 20)
						Dim point3 As New Point(30, 30)

						' Instantiating a PointCollection 
						Dim pointCollection1 As New PointCollection()

						' Adding Points to PointCollection
						pointCollection1.Add(point1)
						pointCollection1.Add(point2)
						pointCollection1.Add(point3)

						' pointCollection1 is equal to (10,10 20,20 30,30)

						' Getting a string representation of the PointCollection
						pcString = pointCollection1.ToString()


						' pcString is equal to "10,10 20,20 30,30"

						'</SnippetPointCollectionToString>


						Exit Select
				Case "rb9"

						Exit Select
				Case "rb10"

						Exit Select
				Case "rb11"

						Exit Select
				Case "rb12"

						Exit Select
            End Select 'end select
		End Sub




		Private Sub ShowResults(ByVal resultValue As String, ByVal syntax As String, ByVal resultType As String, ByVal opString As String)
		End Sub


	End Class
End Namespace