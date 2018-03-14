Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.MatrixExamples

	Public Class MatrixExample
		Inherits Page


		Public Sub New()

			Dim mainPanel As New StackPanel()

			Dim inverseExampleText As New TextBlock()
			inverseExampleText.Text = inverseExample().ToString()
			mainPanel.Children.Add(inverseExampleText)

			Dim rotateAboutPointExampleText As New TextBlock()
			rotateAboutPointExampleText.Text = rotateAboutPointExample().ToString()
			mainPanel.Children.Add(rotateAboutPointExampleText)

			Dim scaleExampleText As New TextBlock()
			scaleExampleText.Text = "Scale: " & scaleExample().ToString()
			mainPanel.Children.Add(scaleExampleText)

			Dim scaleAboutPointExampleText As New TextBlock()
			scaleAboutPointExampleText.Text = "Scale about (100,100): " & scaleAboutPointExample().ToString()
			mainPanel.Children.Add(scaleAboutPointExampleText)

			Dim scalePrependExampleText As New TextBlock()
			scalePrependExampleText.Text = "Prepend scale: " & scalePrependExample().ToString()
			mainPanel.Children.Add(scalePrependExampleText)

			Dim scalePrependAboutPointExampleText As New TextBlock()
			scalePrependAboutPointExampleText.Text = "Prepend scale about (100,100): " & scalePrependAboutPointExample().ToString()
			mainPanel.Children.Add(scalePrependAboutPointExampleText)

			Dim prependRotateExampleText As New TextBlock()
			prependRotateExampleText.Text = prependRotateExample().ToString()
			mainPanel.Children.Add(prependRotateExampleText)

			Dim prependRotateAboutPointExampleText As New TextBlock()
			prependRotateAboutPointExampleText.Text = prependRotateAboutPointExample().ToString()
			mainPanel.Children.Add(prependRotateAboutPointExampleText)

			Dim determinantExampleText As New TextBlock()
			determinantExampleText.Text = determinantExample().ToString()
			mainPanel.Children.Add(determinantExampleText)

			Dim identityExampleText As New TextBlock()
			identityExampleText.Text = identityExample().ToString()
			mainPanel.Children.Add(identityExampleText)



			Dim appendExampleText As New TextBlock()
			appendExampleText.Text = appendExample().ToString()
			mainPanel.Children.Add(appendExampleText)

			Dim getHashCodeExampleText As New TextBlock()
			getHashCodeExampleText.Text = getHashCodeExample().ToString()
			mainPanel.Children.Add(getHashCodeExampleText)

			Dim parseExampleText As New TextBlock()
			parseExampleText.Text = parseExample().ToString()
			mainPanel.Children.Add(parseExampleText)

			Dim prependExampleText As New TextBlock()
			prependExampleText.Text = prependExample().ToString()
			mainPanel.Children.Add(prependExampleText)

			Dim matrixConverterExampleText As New TextBlock()
			prependExampleText.Text = "MatrixConverterExample: " & matrixConverterExample().ToString()
			mainPanel.Children.Add(matrixConverterExampleText)

			equalityExample()

			transformExamples()

			Me.Content = mainPanel
		End Sub

        ' <SnippetMatrixConverterExample_visualbasic>
		Private Function matrixConverterExample() As Matrix

			Dim mConverter As New MatrixConverter()
			Dim matrixResult As New Matrix()
			Dim string2 As String = "10,20,30,40,50,60"

			matrixResult = CType(mConverter.ConvertFromString(string2), Matrix)
			' matrixResult is equal to (10, 20, 30, 40, 50, 60)

			Return matrixResult
		End Function
        ' </SnippetMatrixConverterExample_visualbasic>

        ' <SnippetMatrixInverseExample_visualbasic>
		Private Function inverseExample() As Matrix

			' Creating a Matrix structure.
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Checking if myMatrix is invertible.
			If myMatrix.HasInverse Then

				' Invert myMatrix. myMatrix is now 
				' equal to (-0.4, 0.2 , 0.3, -0.1, 1, -2) 
				myMatrix.Invert()

				' Return the inverted matrix.
				Return myMatrix
			Else
				Throw New InvalidOperationException("The matrix is not invertible.")
			End If

		End Function
        ' </SnippetMatrixInverseExample_visualbasic>



        ' <SnippetMatrixRotateExample_visualbasic>
		Private Function rotateExample() As Matrix

			' Creating a Matrix structure.
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Rotate the matrix 90 degrees about the origin.
			' myMatrix becomes equal to (-10, 5, -20, 15, -30, 25).
			myMatrix.Rotate(90)

			Return myMatrix

		End Function
        ' </SnippetMatrixRotateExample_visualbasic>    


        ' <SnippetMatrixRotateAboutPointExample_visualbasic>
		Private Function rotateAboutPointExample() As Matrix

			' Creating a Matrix structure.
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Rotate the matrix 90 degrees about the point (100,100).
			' myMatrix becomes equal to (-10, 4, -20, 15, 170, 25).
			myMatrix.RotateAt(90, 100, 100)

			Return myMatrix

		End Function
        ' </SnippetMatrixRotateAboutPointExample_visualbasic>        



        ' <SnippetMatrixPrependRotateExamples_visualbasic>
        ' <SnippetMatrixPrependRotateExample_visualbasic>
		Private Function prependRotateExample() As Matrix

			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Prepend a 90 degree rotation about the origin.
			' myMatrix is now equal to  (15,20,-5,-10,25,30).
			myMatrix.RotatePrepend(90)

			Return myMatrix
		End Function
        ' </SnippetMatrixPrependRotateExample_visualbasic>


        ' <SnippetMatrixPrependRotateAboutPointExample_visualbasic>
		Private Function prependRotateAboutPointExample() As Matrix

			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Prepend a 90 degree rotation about the 
			' point (100,100). 
			' myMatrix is now equal to  (15,20,-5,-10,1025,2030).
			myMatrix.RotateAtPrepend(90, 100, 100)

			Return myMatrix
		End Function
        ' </SnippetMatrixPrependRotateAboutPointExample_visualbasic>

        ' </SnippetMatrixPrependRotateExamples_visualbasic>


        ' <SnippetMatrixScaleExamples_visualbasic>

		Private Function scaleExample() As Matrix
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Scale myMatrix by a horizontal factor of 2
			' and a vertical factor of 4 about the origin.
			' After this operation,
			' myMatrix is equal to (10, 40, 30, 80, 50, 120)
			myMatrix.Scale(2, 4)

			Return myMatrix

		End Function

		Private Function scaleAboutPointExample() As Matrix
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Scale myMatrix by a horizontal factor of 2
			' and a vertical factor of 4 about the 
			' point (100,100).
			' After this operation,
			' myMatrix is equal to (10, 40, 30, 80, -50, -180)
			myMatrix.ScaleAt(2, 4, 100, 100)

			Return myMatrix

		End Function

        ' </SnippetMatrixScaleExamples_visualbasic>


        ' <SnippetMatrixPrependScaleExamples_visualbasic>

		Private Function scalePrependExample() As Matrix
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Prepend a scale ab with a horizontal factor of 2
			' and a vertical factor of 4 about the origin.
			' After this operation,
			' myMatrix is equal to (10, 20, 60, 80, 25, 30)
			myMatrix.ScalePrepend(2, 4)

			Return myMatrix

		End Function

		Private Function scalePrependAboutPointExample() As Matrix
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Prepend a scale with a horizontal factor of 2
			' and a vertical factor of 4 about the 
			' point (100,100).
			' After this operation,
			' myMatrix is equal to (10, 20, 60, 80, -4975, -6970)
			myMatrix.ScaleAtPrepend(2, 4, 100, 100)

			Return myMatrix

		End Function

        ' </SnippetMatrixPrependScaleExamples_visualbasic>

        ' <SnippetMatrixTransformExamples_visualbasic>
		Private Sub transformExamples()

			 Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)


			 '
			 ' Transform a point.
			 '            
			 Dim myPoint As New Point(15,25)

			 ' pointResult is (475, 680).
			 Dim pointResult As Point = myMatrix.Transform(myPoint)

			 '
			 ' Transform an array of points.
			 '            
			 Dim myPointArray() As Point = {New Point(15,25), New Point(30,35)}

			 ' myPointArray[0] becomes (475, 680).
			 ' myPointArray[1] becomes (700, 1030).
			 myMatrix.Transform(myPointArray)

			 '
			 ' Transform a vector.
			 '
			 Dim myVector As New Vector(15,25)

			 ' vectorResult becomes (450, 650).
			 Dim vectorResult As Vector = myMatrix.Transform(myVector)

			 '
			 ' Transform an array of vectors.
			 '
			 Dim myVectorArray() As Vector = {New Vector(15, 25), New Vector(30,35)}

			 ' myVectorArray[0] becomes (450, 650).
			 ' myVectorArray[1] becomes (675, 1000).             
			 myMatrix.Transform(myVectorArray)


		End Sub
        ' </SnippetMatrixTransformExamples_visualbasic>



        ' <SnippetMatrixDeterminantExample_visualbasic>
		Private Function determinantExample() As Double
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Get the determinant, which is equal to -50.
			Dim determinant As Double = myMatrix.Determinant

			Return determinant

		End Function
        ' </SnippetMatrixDeterminantExample_visualbasic>


        ' <SnippetMatrixIdentityExample_visualbasic>
		Private Function identityExample() As Matrix

			' Get the identity matrix, which is equal to 
			' (1,0,0,1,0,0). 
			Dim myMatrix As Matrix = Matrix.Identity


			Dim m As New Matrix(1,0,0,1,0,0)

			Return myMatrix


		End Function
        ' </SnippetMatrixIdentityExample_visualbasic>




        ' <SnippetMatrixAppendExample_visualbasic>        
		Private Function appendExample() As Matrix


			Dim matrix1 As New Matrix(5, 10, 15, 20, 25, 30)
			Dim matrix2 As New Matrix(2, 4, 6, 8, 10, 12)

			' matrix1 ibecomes (70,100,150,220,240,352) 
			matrix1.Append(matrix2)

			' Reset matrix1 to its original value.
			matrix1 = New Matrix(5, 10, 15, 20, 25, 30)

			matrix1 = matrix1 * matrix2

			' matrix1 is again equal to (70,100,150,220,240,352) 
			Return matrix1

		End Function
        ' </SnippetMatrixAppendExample_visualbasic>        

        ' <SnippetMatrixGetHashCodeExample_visualbasic>
		Private Function getHashCodeExample() As Integer
			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			' Returns
			Return myMatrix.GetHashCode()


		End Function
        ' </SnippetMatrixGetHashCodeExample_visualbasic>


        ' <SnippetMatrixMultiplicationExample_visualbasic>        
		Private Sub multiplicationExample()

			Dim matrix1 As New Matrix(5, 10, 15, 20, 25, 30)
			Dim matrix2 As New Matrix(2, 4, 6, 8, 10, 12)

			' matrixResult is equal to (70,100,150,220,240,352) 
			Dim matrixResult As Matrix = Matrix.Multiply(matrix1, matrix2)

			' matrixResult2 is also
			' equal to (70,100,150,220,240,352) 
			Dim matrixResult2 As Matrix = matrix1 * matrix2


		End Sub
        ' </SnippetMatrixMultiplicationExample_visualbasic> 


        ' <SnippetMatrixEqualityExample_visualbasic>        
		Private Sub equalityExample()

			Dim matrix1 As New Matrix(5, 10, 15, 20, 25, 30)
			Dim matrix2 As New Matrix(5, 10, 15, 20, 25, 30)

			Dim result As Boolean

			' result is true.
			result = (matrix1 = matrix2)

			' result is false.
			result = (matrix1 <> matrix2)

		End Sub
        ' </SnippetMatrixEqualityExample_visualbasic>    


        ' <SnippetMatrixParseExample_visualbasic>
		Private Function parseExample() As Matrix

			Dim result As Matrix = Matrix.Parse("1, 2, 3, 4, 5, 6")

			' result is equal to (1,2,3,4,5,6).
			Return result

		End Function
        ' </SnippetMatrixParseExample_visualbasic>

        ' <SnippetMatrixTranslateExample_visualbasic>
		Private Function translateExample() As Matrix

			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			myMatrix.Translate(5, 10)


			' myMatrix is equal to (5, 10, 15, 20, 30, 40).
			Return myMatrix

		End Function
        ' </SnippetMatrixTranslateExample_visualbasic>     

        ' <SnippetMatrixTranslatePrependExample_visualbasic>
		Private Function translatePrependExample() As Matrix

			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			myMatrix.TranslatePrepend(5, 10)


			' myMatrix is equal to (5, 10, 15, 20, 200, 280).
			Return myMatrix

		End Function
        ' </SnippetMatrixTranslatePrependExample_visualbasic>      

        ' <SnippetMatrixSkewExample_visualbasic>
		Private Function skewExample() As Matrix

			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			myMatrix.Skew(45, 180)


			' myMatrix is equal to (15, 10, 35, 20, 55, 30).
			Return myMatrix

		End Function
        ' </SnippetMatrixSkewExample_visualbasic>     

        ' <SnippetMatrixSkewPrependExample_visualbasic>
		Private Function skewPrependExample() As Matrix

			Dim myMatrix As New Matrix(5, 10, 15, 20, 25, 30)

			myMatrix.SkewPrepend(45, 180)


			' myMatrix is equal to (5, 10, 20, 30, 25, 30).
			Return myMatrix

		End Function
        ' </SnippetMatrixSkewPrependExample_visualbasic>         

        ' <SnippetMatrixPrependExample_visualbasic>
		Private Function prependExample() As Matrix


			Dim matrix1 As New Matrix(5, 10, 15, 20, 25, 30)
			Dim matrix2 As New Matrix(2, 4, 6, 8, 10, 12)

			matrix1.Prepend(matrix2)

			' matrix1 is equal to (70,100,150,220,255,370). 
			Return matrix1


		End Function
        ' </SnippetMatrixPrependExample_visualbasic>                  

	End Class

End Namespace
