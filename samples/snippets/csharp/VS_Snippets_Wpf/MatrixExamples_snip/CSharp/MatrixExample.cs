using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.MatrixExamples
{

    public class MatrixExample : Page
    {

        public MatrixExample()
        {

            StackPanel mainPanel = new StackPanel();

            TextBlock inverseExampleText = new TextBlock();
            inverseExampleText.Text = inverseExample().ToString();
            mainPanel.Children.Add(inverseExampleText);

            TextBlock rotateAboutPointExampleText = new TextBlock();
            rotateAboutPointExampleText.Text = rotateAboutPointExample().ToString();
            mainPanel.Children.Add(rotateAboutPointExampleText);

            TextBlock scaleExampleText = new TextBlock();
            scaleExampleText.Text = "Scale: " + scaleExample().ToString();
            mainPanel.Children.Add(scaleExampleText);

            TextBlock scaleAboutPointExampleText = new TextBlock();
            scaleAboutPointExampleText.Text =
                "Scale about (100,100): " + scaleAboutPointExample().ToString();
            mainPanel.Children.Add(scaleAboutPointExampleText);

            TextBlock scalePrependExampleText = new TextBlock();
            scalePrependExampleText.Text = "Prepend scale: " + scalePrependExample().ToString();
            mainPanel.Children.Add(scalePrependExampleText);

            TextBlock scalePrependAboutPointExampleText = new TextBlock();
            scalePrependAboutPointExampleText.Text =
                "Prepend scale about (100,100): " + scalePrependAboutPointExample().ToString();
            mainPanel.Children.Add(scalePrependAboutPointExampleText);

            TextBlock prependRotateExampleText = new TextBlock();
            prependRotateExampleText.Text =
                prependRotateExample().ToString();
            mainPanel.Children.Add(prependRotateExampleText);

            TextBlock prependRotateAboutPointExampleText = new TextBlock();
            prependRotateAboutPointExampleText.Text =
                prependRotateAboutPointExample().ToString();
            mainPanel.Children.Add(prependRotateAboutPointExampleText);

            TextBlock determinantExampleText = new TextBlock();
            determinantExampleText.Text =
                determinantExample().ToString();
            mainPanel.Children.Add(determinantExampleText);

            TextBlock identityExampleText = new TextBlock();
            identityExampleText.Text =
                identityExample().ToString();
            mainPanel.Children.Add(identityExampleText);

            TextBlock appendExampleText = new TextBlock();
            appendExampleText.Text =
                appendExample().ToString();
            mainPanel.Children.Add(appendExampleText);

            TextBlock getHashCodeExampleText = new TextBlock();
            getHashCodeExampleText.Text =
                getHashCodeExample().ToString();
            mainPanel.Children.Add(getHashCodeExampleText);

            TextBlock parseExampleText = new TextBlock();
            parseExampleText.Text =
                parseExample().ToString();
            mainPanel.Children.Add(parseExampleText);

            TextBlock prependExampleText = new TextBlock();
            prependExampleText.Text =
                prependExample().ToString();
            mainPanel.Children.Add(prependExampleText);

            TextBlock matrixConverterExampleText = new TextBlock();
            prependExampleText.Text = "MatrixConverterExample: " + matrixConverterExample().ToString();
            mainPanel.Children.Add(matrixConverterExampleText);

            equalityExample();

            transformExamples();

            this.Content = mainPanel;
        }

        // <SnippetMatrixConverterExample_csharp>
        private Matrix matrixConverterExample()
        {

            MatrixConverter mConverter = new MatrixConverter();
            Matrix matrixResult = new Matrix();
            string string2 = "10,20,30,40,50,60";

            matrixResult = (Matrix)mConverter.ConvertFromString(string2);
            // matrixResult is equal to (10, 20, 30, 40, 50, 60)

            return matrixResult;
        }
        // </SnippetMatrixConverterExample_csharp>

        // <SnippetMatrixInverseExample_csharp>
        private Matrix inverseExample()
        {

            // Creating a Matrix structure.
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Checking if myMatrix is invertible.
            if (myMatrix.HasInverse)
            {

                // Invert myMatrix. myMatrix is now
                // equal to (-0.4, 0.2 , 0.3, -0.1, 1, -2)
                myMatrix.Invert();

                // Return the inverted matrix.
                return myMatrix;
            }
            else
            {
                throw new InvalidOperationException("The matrix is not invertible.");
            }
        }
        // </SnippetMatrixInverseExample_csharp>

        // <SnippetMatrixRotateExample_csharp>
        private Matrix rotateExample()
        {

            // Creating a Matrix structure.
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Rotate the matrix 90 degrees about the origin.
            // myMatrix becomes equal to (-10, 5, -20, 15, -30, 25).
            myMatrix.Rotate(90);

            return myMatrix;
        }
        // </SnippetMatrixRotateExample_csharp>

        // <SnippetMatrixRotateAboutPointExample_csharp>
        private Matrix rotateAboutPointExample()
        {

            // Creating a Matrix structure.
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Rotate the matrix 90 degrees about the point (100,100).
            // myMatrix becomes equal to (-10, 4, -20, 15, 170, 25).
            myMatrix.RotateAt(90, 100, 100);

            return myMatrix;
        }
        // </SnippetMatrixRotateAboutPointExample_csharp>

        // <SnippetMatrixPrependRotateExamples_csharp>
        // <SnippetMatrixPrependRotateExample_csharp>
        private Matrix prependRotateExample()
        {

            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Prepend a 90 degree rotation about the origin.
            // myMatrix is now equal to  (15,20,-5,-10,25,30).
            myMatrix.RotatePrepend(90);

            return myMatrix;
        }
        // </SnippetMatrixPrependRotateExample_csharp>

        // <SnippetMatrixPrependRotateAboutPointExample_csharp>
        private Matrix prependRotateAboutPointExample()
        {

            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Prepend a 90 degree rotation about the
            // point (100,100).
            // myMatrix is now equal to  (15,20,-5,-10,1025,2030).
            myMatrix.RotateAtPrepend(90, 100, 100);

            return myMatrix;
        }
        // </SnippetMatrixPrependRotateAboutPointExample_csharp>

        // </SnippetMatrixPrependRotateExamples_csharp>

        // <SnippetMatrixScaleExamples_csharp>

        private Matrix scaleExample()
        {
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Scale myMatrix by a horizontal factor of 2
            // and a vertical factor of 4 about the origin.
            // After this operation,
            // myMatrix is equal to (10, 40, 30, 80, 50, 120)
            myMatrix.Scale(2, 4);

            return myMatrix;
        }

        private Matrix scaleAboutPointExample()
        {
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Scale myMatrix by a horizontal factor of 2
            // and a vertical factor of 4 about the
            // point (100,100).
            // After this operation,
            // myMatrix is equal to (10, 40, 30, 80, -50, -180)
            myMatrix.ScaleAt(2, 4, 100, 100);

            return myMatrix;
        }

        // </SnippetMatrixScaleExamples_csharp>

        // <SnippetMatrixPrependScaleExamples_csharp>

        private Matrix scalePrependExample()
        {
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Prepend a scale ab with a horizontal factor of 2
            // and a vertical factor of 4 about the origin.
            // After this operation,
            // myMatrix is equal to (10, 20, 60, 80, 25, 30)
            myMatrix.ScalePrepend(2, 4);

            return myMatrix;
        }

        private Matrix scalePrependAboutPointExample()
        {
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Prepend a scale with a horizontal factor of 2
            // and a vertical factor of 4 about the
            // point (100,100).
            // After this operation,
            // myMatrix is equal to (10, 20, 60, 80, -4975, -6970)
            myMatrix.ScaleAtPrepend(2, 4, 100, 100);

            return myMatrix;
        }

        // </SnippetMatrixPrependScaleExamples_csharp>

        // <SnippetMatrixTransformExamples_csharp>
        private void transformExamples()
        {

             Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

             //
             // Transform a point.
             //
             Point myPoint = new Point(15,25);

             // pointResult is (475, 680).
             Point pointResult = myMatrix.Transform(myPoint);

             //
             // Transform an array of points.
             //
             Point[] myPointArray = new Point[]
                {new Point(15,25), new Point(30,35)};

             // myPointArray[0] becomes (475, 680).
             // myPointArray[1] becomes (700, 1030).
             myMatrix.Transform(myPointArray);

             //
             // Transform a vector.
             //
             Vector myVector = new Vector(15,25);

             // vectorResult becomes (450, 650).
             Vector vectorResult = myMatrix.Transform(myVector);

             //
             // Transform an array of vectors.
             //
             Vector[] myVectorArray = new Vector[]
                {new Vector(15, 25), new Vector(30,35)};

             // myVectorArray[0] becomes (450, 650).
             // myVectorArray[1] becomes (675, 1000).
             myMatrix.Transform(myVectorArray);
        }
        // </SnippetMatrixTransformExamples_csharp>

        // <SnippetMatrixDeterminantExample_csharp>
        private Double determinantExample()
        {
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Get the determinant, which is equal to -50.
            Double determinant = myMatrix.Determinant;

            return determinant;
        }
        // </SnippetMatrixDeterminantExample_csharp>

        // <SnippetMatrixIdentityExample_csharp>
        private Matrix identityExample()
        {

            // Get the identity matrix, which is equal to
            // (1,0,0,1,0,0).
            Matrix myMatrix = Matrix.Identity;

            Matrix m = new Matrix(1,0,0,1,0,0);

            return myMatrix;
        }
        // </SnippetMatrixIdentityExample_csharp>

        // <SnippetMatrixAppendExample_csharp>
        private Matrix appendExample()
        {

            Matrix matrix1 = new Matrix(5, 10, 15, 20, 25, 30);
            Matrix matrix2 = new Matrix(2, 4, 6, 8, 10, 12);

            // matrix1 ibecomes (70,100,150,220,240,352)
            matrix1.Append(matrix2);

            // Reset matrix1 to its original value.
            matrix1 = new Matrix(5, 10, 15, 20, 25, 30);

            matrix1 = matrix1 * matrix2;

            // matrix1 is again equal to (70,100,150,220,240,352)
            return matrix1;
        }
        // </SnippetMatrixAppendExample_csharp>

        // <SnippetMatrixGetHashCodeExample_csharp>
        private int getHashCodeExample()
        {
            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            // Returns
            return myMatrix.GetHashCode();
        }
         // </SnippetMatrixGetHashCodeExample_csharp>

        // <SnippetMatrixMultiplicationExample_csharp>
        private void multiplicationExample()
        {

            Matrix matrix1 = new Matrix(5, 10, 15, 20, 25, 30);
            Matrix matrix2 = new Matrix(2, 4, 6, 8, 10, 12);

            // matrixResult is equal to (70,100,150,220,240,352)
            Matrix matrixResult = Matrix.Multiply(matrix1, matrix2);

            // matrixResult2 is also
            // equal to (70,100,150,220,240,352)
            Matrix matrixResult2 = matrix1 * matrix2;
        }
        // </SnippetMatrixMultiplicationExample_csharp>

        // <SnippetMatrixEqualityExample_csharp>
        private void equalityExample()
        {

            Matrix matrix1 = new Matrix(5, 10, 15, 20, 25, 30);
            Matrix matrix2 = new Matrix(5, 10, 15, 20, 25, 30);

            Boolean result;

            // result is true.
            result = (matrix1 == matrix2);

            // result is false.
            result = (matrix1 != matrix2);
        }
        // </SnippetMatrixEqualityExample_csharp>

        // <SnippetMatrixParseExample_csharp>
        private Matrix parseExample()
        {

            Matrix result = Matrix.Parse("1, 2, 3, 4, 5, 6");

            // result is equal to (1,2,3,4,5,6).
            return result;
        }
        // </SnippetMatrixParseExample_csharp>

        // <SnippetMatrixTranslateExample_csharp>
        private Matrix translateExample()
        {

            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            myMatrix.Translate(5, 10);

            // myMatrix is equal to (5, 10, 15, 20, 30, 40).
            return myMatrix;
        }
        // </SnippetMatrixTranslateExample_csharp>

        // <SnippetMatrixTranslatePrependExample_csharp>
        private Matrix translatePrependExample()
        {

            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            myMatrix.TranslatePrepend(5, 10);

            // myMatrix is equal to (5, 10, 15, 20, 200, 280).
            return myMatrix;
        }
        // </SnippetMatrixTranslatePrependExample_csharp>

        // <SnippetMatrixSkewExample_csharp>
        private Matrix skewExample()
        {

            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            myMatrix.Skew(45, 180);

            // myMatrix is equal to (15, 10, 35, 20, 55, 30).
            return myMatrix;
        }
        // </SnippetMatrixSkewExample_csharp>

        // <SnippetMatrixSkewPrependExample_csharp>
        private Matrix skewPrependExample()
        {

            Matrix myMatrix = new Matrix(5, 10, 15, 20, 25, 30);

            myMatrix.SkewPrepend(45, 180);

            // myMatrix is equal to (5, 10, 20, 30, 25, 30).
            return myMatrix;
        }
        // </SnippetMatrixSkewPrependExample_csharp>

        // <SnippetMatrixPrependExample_csharp>
        private Matrix prependExample()
        {

            Matrix matrix1 = new Matrix(5, 10, 15, 20, 25, 30);
            Matrix matrix2 = new Matrix(2, 4, 6, 8, 10, 12);

            matrix1.Prepend(matrix2);

            // matrix1 is equal to (70,100,150,220,255,370).
            return matrix1;
        }
        // </SnippetMatrixPrependExample_csharp>
    }
}
