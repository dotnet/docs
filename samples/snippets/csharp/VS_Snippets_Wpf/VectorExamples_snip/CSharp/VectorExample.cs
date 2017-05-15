

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.VectorExamples
{

    public class VectorExample : Page
    {
    
        
        public VectorExample()
        {
            
            StackPanel mainPanel = new StackPanel();


            TextBlock addTwoVectorsExampleText = new TextBlock();
            addTwoVectorsExampleText.Text = "addTwoVectorsExample: " + addTwoVectorsExample().ToString();
            mainPanel.Children.Add(addTwoVectorsExampleText);

            TextBlock addPointAndVectorExampleText = new TextBlock();
            addPointAndVectorExampleText.Text = "addPointAndVectorExample: " + addPointAndVectorExample().ToString();
            mainPanel.Children.Add(addPointAndVectorExampleText);

            TextBlock angleBetweenExampleText = new TextBlock();
            angleBetweenExampleText.Text = "angleBetweenExample: " + angleBetweenExample().ToString();
            mainPanel.Children.Add(angleBetweenExampleText);

            TextBlock crossProductExampleText = new TextBlock();
            crossProductExampleText.Text = "crossProductExample: " + crossProductExample().ToString();
            mainPanel.Children.Add(crossProductExampleText);

            TextBlock determinantExampleText = new TextBlock();
            determinantExampleText.Text = "determinantExample: " + determinantExample().ToString();
            mainPanel.Children.Add(determinantExampleText);

            TextBlock divideExampleText = new TextBlock();
            divideExampleText.Text = "divideExample: " + divideExample().ToString();
            mainPanel.Children.Add(divideExampleText);

            TextBlock equalsExample1Text = new TextBlock();
            equalsExample1Text.Text = "equalsExample1: " + equalsExample1().ToString();
            mainPanel.Children.Add(equalsExample1Text);

            TextBlock equalsExample2Text = new TextBlock();
            equalsExample2Text.Text = "equalsExample2: " + equalsExample2().ToString();
            mainPanel.Children.Add(equalsExample2Text);

            TextBlock getHashCodeExampleText = new TextBlock();
            getHashCodeExampleText.Text = "getHashCodeExample: " + getHashCodeExample().ToString();
            mainPanel.Children.Add(getHashCodeExampleText);

            TextBlock multiplyVectorByScalarExample1Text = new TextBlock();
            multiplyVectorByScalarExample1Text.Text = "multiplyVectorByScalarExample1: " + multiplyVectorByScalarExample1().ToString();
            mainPanel.Children.Add(multiplyVectorByScalarExample1Text);

            TextBlock multiplyVectorByScalarExample2Text = new TextBlock();
            multiplyVectorByScalarExample2Text.Text = "multiplyVectorByScalarExample2: " + multiplyVectorByScalarExample2().ToString();
            mainPanel.Children.Add(multiplyVectorByScalarExample2Text);

            TextBlock getDotProductExampleText = new TextBlock();
            getDotProductExampleText.Text = "getDotProductExample: " + getDotProductExample().ToString();
            mainPanel.Children.Add(getDotProductExampleText);

            TextBlock multiplyVectorByMatrixExampleText = new TextBlock();
            multiplyVectorByMatrixExampleText.Text = "multiplyVectorByMatrixExample: " + multiplyVectorByMatrixExample().ToString();
            mainPanel.Children.Add(multiplyVectorByMatrixExampleText);

            TextBlock negateExampleText = new TextBlock();
            negateExampleText.Text = "negateExample: " + negateExample().ToString();
            mainPanel.Children.Add(negateExampleText);

            TextBlock normalizeExampleText = new TextBlock();
            normalizeExampleText.Text = "normalizeExample: " + normalizeExample().ToString();
            mainPanel.Children.Add(normalizeExampleText);

            TextBlock overloadedAdditionOperatorExample1Text = new TextBlock();
            overloadedAdditionOperatorExample1Text.Text = "overloadedAdditionOperatorExample1: " + overloadedAdditionOperatorExample1().ToString();
            mainPanel.Children.Add(overloadedAdditionOperatorExample1Text);

            TextBlock overloadedAdditionOperatorExample2Text = new TextBlock();
            overloadedAdditionOperatorExample2Text.Text = "overloadedAdditionOperatorExample2: " + overloadedAdditionOperatorExample2().ToString();
            mainPanel.Children.Add(overloadedAdditionOperatorExample2Text);

            TextBlock overloadedDivisionOperatorExampleText = new TextBlock();
            overloadedDivisionOperatorExampleText.Text = "overloadedDivisionOperatorExample: " + overloadedDivisionOperatorExample().ToString();
            mainPanel.Children.Add(overloadedDivisionOperatorExampleText);

            TextBlock overloadedEqualityOperatorExampleText = new TextBlock();
            overloadedEqualityOperatorExampleText.Text = "overloadedEqualityOperatorExample: " + overloadedEqualityOperatorExample().ToString();
            mainPanel.Children.Add(overloadedEqualityOperatorExampleText);

            TextBlock overloadedExplicitOperatorExample1Text = new TextBlock();
            overloadedExplicitOperatorExample1Text.Text = "overloadedExplicitOperatorExample1: " + overloadedExplicitOperatorExample1().ToString();
            mainPanel.Children.Add(overloadedExplicitOperatorExample1Text);

            TextBlock overloadedExplicitOperatorExample2Text = new TextBlock();
            overloadedExplicitOperatorExample2Text.Text = "overloadedExplicitOperatorExample2: " + overloadedExplicitOperatorExample2().ToString();
            mainPanel.Children.Add(overloadedExplicitOperatorExample2Text);

            TextBlock overloadedInequalityOperatorExampleText = new TextBlock();
            overloadedInequalityOperatorExampleText.Text = "overloadedInequalityOperatorExample: " + overloadedInequalityOperatorExample().ToString();
            mainPanel.Children.Add(overloadedInequalityOperatorExampleText);

            TextBlock overloadedMultiplicationOperatorExample1Text = new TextBlock();
            overloadedMultiplicationOperatorExample1Text.Text = "overloadedMultiplicationOperatorExample1: " + overloadedMultiplicationOperatorExample1().ToString();
            mainPanel.Children.Add(overloadedMultiplicationOperatorExample1Text);

            TextBlock overloadedMultiplicationOperatorExample2Text = new TextBlock();
            overloadedMultiplicationOperatorExample2Text.Text = "overloadedMultiplicationOperatorExample2: " + overloadedMultiplicationOperatorExample2().ToString();
            mainPanel.Children.Add(overloadedMultiplicationOperatorExample2Text);

            TextBlock overloadedMultiplyVectorByMatrixOperatorExampleText = new TextBlock();
            overloadedMultiplyVectorByMatrixOperatorExampleText.Text = "overloadedMultiplyVectorByMatrixOperatorExample: " + overloadedMultiplyVectorByMatrixOperatorExample().ToString();
            mainPanel.Children.Add(overloadedMultiplyVectorByMatrixOperatorExampleText);

            TextBlock overloadedOperatorGetDotProductExampleText = new TextBlock();
            overloadedOperatorGetDotProductExampleText.Text = "overloadedOperatorGetDotProductExample: " + overloadedOperatorGetDotProductExample().ToString();
            mainPanel.Children.Add(overloadedOperatorGetDotProductExampleText);

            TextBlock overloadedSubtractionOperatorExampleText = new TextBlock();
            overloadedSubtractionOperatorExampleText.Text = "overloadedSubtractionOperatorExample: " + overloadedSubtractionOperatorExample().ToString();
            mainPanel.Children.Add(overloadedSubtractionOperatorExampleText);

            TextBlock overloadedNegationOperatorExampleText = new TextBlock();
            overloadedNegationOperatorExampleText.Text = "overloadedNegationOperatorExample: " + overloadedNegationOperatorExample().ToString();
            mainPanel.Children.Add(overloadedNegationOperatorExampleText);

            TextBlock parseExampleText = new TextBlock();
            parseExampleText.Text = "parseExample: " + parseExample().ToString();
            mainPanel.Children.Add(parseExampleText);

            TextBlock subtractExampleText = new TextBlock();
            subtractExampleText.Text = "subtractExample: " + subtractExample().ToString();
            mainPanel.Children.Add(subtractExampleText);

            TextBlock toStringExampleText = new TextBlock();
            toStringExampleText.Text = "toStringExample: " + toStringExample().ToString();
            mainPanel.Children.Add(toStringExampleText);

            TextBlock lengthExampleText = new TextBlock();
            lengthExampleText.Text = "lengthExample: " + lengthExample().ToString();
            mainPanel.Children.Add(lengthExampleText);

            TextBlock lengthSquaredExampleText = new TextBlock();
            lengthSquaredExampleText.Text = "lengthSquaredExample: " + lengthSquaredExample().ToString();
            mainPanel.Children.Add(lengthSquaredExampleText);

            TextBlock vectorEqualityExampleText = new TextBlock();
            vectorEqualityExampleText.Text = "vectorEqualityExample: " + vectorEqualityExample().ToString();
            mainPanel.Children.Add(vectorEqualityExampleText);

            TextBlock vectorConverterExampleText = new TextBlock();
            vectorConverterExampleText.Text = "vectorConverterExample: " + vectorConverterExample().ToString();
            mainPanel.Children.Add(vectorConverterExampleText);
            
            this.Content = mainPanel;
        }

        // <SnippetVectorConverterExample_csharp>
        private Vector vectorConverterExample()
        {
            VectorConverter vConverter = new VectorConverter();
            Vector vectorResult = new Vector();
            string string1 = "10,20";

            vectorResult = (Vector)vConverter.ConvertFromString(string1);
            // vectorResult is equal to (10, 20)

            return vectorResult;

        }
        // </SnippetVectorConverterExample_csharp>

        // <SnippetAddTwoVectorsExample_csharp>
        private Vector addTwoVectorsExample()
        {
            // Create two Vector structures.
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);
            Vector vectorResult = new Vector();

            // Add the vectors together. 
            // vectorResult is equal to (65, 100).
            vectorResult = Vector.Add(vector1, vector2);

            return vectorResult;

        }
        // </SnippetAddTwoVectorsExample_csharp>

        // <SnippetAddPointAndVectorExample_csharp>
        private Point addPointAndVectorExample()
        {
            Vector vector1 = new Vector(20, 30);
            Point point1 = new Point(10, 5);
            Point pointResult = new Point();

            // Add Point and Vector together.
            // pointResult is equal to (30,35).
            pointResult = Vector.Add(vector1, point1);

            return pointResult;

        }
        // </SnippetAddPointAndVectorExample_csharp>

        // <SnippetAngleBetweenExample_csharp>
        private Double angleBetweenExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);
            Double angleBetween;

            // angleBetween is approximately equal to 0.9548
            angleBetween = Vector.AngleBetween(vector1, vector2);

            return angleBetween;

        }
        // </SnippetAngleBetweenExample_csharp>

        // <SnippetCrossProductExample_csharp>
        private Double crossProductExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);
            Double crossProduct;

            // crossProduct is equal to 50    
            crossProduct = Vector.CrossProduct(vector1, vector2);

            return crossProduct;

        }
        // </SnippetCrossProductExample_csharp>

        // <SnippetDeterminantExample_csharp>
        private Double determinantExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);
            Double determinant;

            // determinant is equal to 50
            determinant = Vector.Determinant(vector1, vector2);

            return determinant;

        }
        // </SnippetDeterminantExample_csharp>

        // <SnippetDivideExample_csharp>
        private Vector divideExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vectorResult = new Vector();
            Double scalar1 = 75;

            // Divide vector by scalar.
            // vectorResult is approximately equal to (0.26667,0.4)
            vectorResult = Vector.Divide(vector1, scalar1);

            return vectorResult;

        }
        // </SnippetDivideExample_csharp>

        // <SnippetEqualsExample1_csharp>
        private Boolean equalsExample1()
        {

            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(20, 30);
            Boolean areEqual = false;

            // areEqual is True
            if (Vector.Equals(vector1, vector2))
            {
              areEqual = true;
            }

            return areEqual;

        }
        // </SnippetEqualsExample1_csharp>

        // <SnippetEqualsExample2_csharp>
        private Boolean equalsExample2()
        {

            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(20, 30);
            Boolean areEqual = false;

            // areEqual is True.  Both parameters are Vector structures, 
            // and they are equal.
            if (vector1.Equals(vector2))
            {
                areEqual = true;
            }

            return areEqual;

        }
        // </SnippetEqualsExample2_csharp>

        // <SnippetGetHashCodeExample_csharp>
        private int getHashCodeExample()
        {
            Vector vector1 = new Vector(20, 30);
            int returnHashCode = vector1.GetHashCode();

            return returnHashCode;

        }
        // </SnippetGetHashCodeExample_csharp>

        // <SnippetMultiplyVectorByScalarExample1_csharp>
        private Vector multiplyVectorByScalarExample1()
        {
            Vector vector1 = new Vector(20, 30);
            Double scalar1 = 75;
            Vector vectorResult = new Vector();

            // Multiply the vector by the scalar.
            // vectorResult is equal to (1500,2250)
            vectorResult = Vector.Multiply(vector1, scalar1);

            return vectorResult;

        }
        // </SnippetMultiplyVectorByScalarExample1_csharp>

        // <SnippetMultiplyVectorByScalarExample2_csharp>
        private Vector multiplyVectorByScalarExample2()
        {
            Vector vector1 = new Vector(20, 30);
            Double scalar1 = 75;
            Vector vectorResult = new Vector();

            // Multiply the vector by the scalar.
            // vectorResult is equal to (1500,2250)
            vectorResult = Vector.Multiply(scalar1, vector1);

            return vectorResult;

        }
        // </SnippetMultiplyVectorByScalarExample2_csharp>

        // <SnippetGetDotProductExample_csharp>
        private Double getDotProductExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);
            Double doubleResult;

            // Return the dot product of the two specified vectors.
            // The dot product is calculated using the following 
            // formula: (vector1.X * vector2.X) + (vector1.Y * vector2.Y).
            // doubleResult is equal to 3000
            doubleResult = Vector.Multiply(vector1, vector2);

            return doubleResult;

        }
        // </SnippetGetDotProductExample_csharp>

        // <SnippetMultiplyVectorByMatrixExample_csharp>
        private Vector multiplyVectorByMatrixExample()
        {
            Vector vector1 = new Vector(20, 30);
            Matrix matrix1 = new Matrix(40, 50, 60, 70, 80, 90);
            Vector vectorResult = new Vector();

            // Multiply the vector and matrix.
            // vectorResult is equal to (2600,3100).
            vectorResult = Vector.Multiply(vector1, matrix1);

            return vectorResult;

        }
        // </SnippetMultiplyVectorByMatrixExample_csharp>

        // <SnippetNegateExample_csharp>
        private Vector negateExample()
        {
            Vector vectorResult = new Vector(20, 30);

            // Make the direction of the Vector opposite but
            // leave the vector magnitude the same.
            // vectorResult is equal to (-20, -30)
            vectorResult.Negate();

            return vectorResult;

        }
        // </SnippetNegateExample_csharp>

        // <SnippetNormalizeExample_csharp>
        private Vector normalizeExample()
        {
            Vector vectorResult = new Vector(20, 30);

            // A normalized vector maintains its direction but 
            // its length becomes 1. 
            // vectorResult is approximately equal to (0.5547,0.8321).
            vectorResult.Normalize();

            return vectorResult;

        }
        // </SnippetNormalizeExample_csharp>

        // <SnippetOverloadedAdditionOperatorExample1>
        private Vector overloadedAdditionOperatorExample1()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);
            Vector vectorResult = new Vector();

            // Add the two vectors together.
            // vectorResult is equal to (65,100)
            vectorResult = vector1 + vector2;

            return vectorResult;

        }
        // </SnippetOverloadedAdditionOperatorExample1>

        // <SnippetOverloadedAdditionOperatorExample2>
        private Point overloadedAdditionOperatorExample2()
        {
            Point point1 = new Point(10, 5);
            Vector vector1 = new Vector(20, 30);
            Point pointResult = new Point();

            // Add the point to the vector.
            // pointResult is equal to (30,35).
            pointResult = point1 + vector1;

            return pointResult;

        }
        // </SnippetOverloadedAdditionOperatorExample2>

        // <SnippetOverloadedDivisionOperatorExample>
        private Vector overloadedDivisionOperatorExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vectorResult = new Vector();
            Double scalar1 = 75;

            // Divide vector by scalar.
            // vectorResult is approximately equal to (0.26667,0.4)
            vectorResult = vector1 / scalar1;

            return vectorResult;

        }
        // </SnippetOverloadedDivisionOperatorExample>

        // <SnippetOverloadedEqualityOperatorExample>
        private Boolean overloadedEqualityOperatorExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);

            // If the two vectors are equal, areEqual is True,
            // otherwise it is False. In this example it is False.
            Boolean areEqual = (vector1 == vector2);

            return areEqual;

        }
        // </SnippetOverloadedEqualityOperatorExample>

        // <SnippetOverloadedExplicitOperatorExample1>
        private Size overloadedExplicitOperatorExample1()
        {
            Vector vector1 = new Vector(20, 30);

            // Explicitly converts a Vector structure into a Size structure.
            // returnSize has a width of 20 and a height of 30.
            Size returnSize = (Size)vector1;

            return returnSize;
            
        }
        // </SnippetOverloadedExplicitOperatorExample1>

        // <SnippetOverloadedExplicitOperatorExample2>
        private Point overloadedExplicitOperatorExample2()
        {
            Vector vector1 = new Vector(20, 30);

            // Explicitly converts a Vector structure into a Point structure.
            // returnPoint is equal to (20, 30).
            Point returnPoint = (Point)vector1;

            return returnPoint;

        }
        // </SnippetOverloadedExplicitOperatorExample2>

        // <SnippetOverloadedInequalityOperatorExample>
        private Boolean overloadedInequalityOperatorExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);
            Boolean areNotEqual;

            // Check whether the two Vectors are not equal, using the overloaded 
            // inequality operator.
            // areNotEqual is True.
            areNotEqual = (vector1 != vector2);

            return areNotEqual;

        }
        // </SnippetOverloadedInequalityOperatorExample>

        // <SnippetOverloadedMultiplicationOperatorExample1>
        private Vector overloadedMultiplicationOperatorExample1()
        {
            Vector vector1 = new Vector(20, 30);
            Double scalar1 = 75;

            // vectorResult is equal to (1500,2250)
            Vector vectorResult = vector1 * scalar1;

            return vectorResult;
            
        }
        // </SnippetOverloadedMultiplicationOperatorExample1>

        // <SnippetOverloadedMultiplicationOperatorExample2>
        private Vector overloadedMultiplicationOperatorExample2()
        {
            Vector vector1 = new Vector(20, 30);
            Double scalar1 = 75;

            // vectorResult is equal to (1500,2250)
            Vector vectorResult = scalar1 * vector1;

            return vectorResult;

        }
        // </SnippetOverloadedMultiplicationOperatorExample2>

        // <SnippetOverloadedMultiplyVectorByMatrixOperatorExample>
        private Vector overloadedMultiplyVectorByMatrixOperatorExample()
        {
            Vector vector1 = new Vector(20, 30);
            Matrix matrix1 = new Matrix(40, 50, 60, 70, 80, 90);
            Vector vectorResult = new Vector();

            // Multiply the vector and matrix.
            // vectorResult is equal to (2600,3100).
            vectorResult = vector1 * matrix1;

            return vectorResult;

        }
        // </SnippetOverloadedMultiplyVectorByMatrixOperatorExample>

        // <SnippetOverloadedOperatorGetDotProductExample>
        private Double overloadedOperatorGetDotProductExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);

            // Return the dot product of the two specified vectors
            // using the overloaded "*" operator.
            // The dot product is calculated using the following 
            // formula: (vector1.X * vector2.X) + (vector1.Y * vector2.Y).
            // doubleResult is equal to 3000
            Double doubleResult = Vector.Multiply(vector1, vector2);

            return doubleResult;

        }
        // </SnippetOverloadedOperatorGetDotProductExample>

        // <SnippetOverloadedSubtractionOperatorExample>
        private Vector overloadedSubtractionOperatorExample()
        {
            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);

            // Subtract vector2 from vector1 using the overloaded
            // "-" operator.
            // vector Result is equal to (-25, -40).
            Vector vectorResult = vector1 - vector2;

            return vectorResult;

        }
        // </SnippetOverloadedSubtractionOperatorExample>

        // <SnippetOverloadedNegationOperatorExample>
        private Vector overloadedNegationOperatorExample()
        {
            Vector vector1 = new Vector(20, 30);

            // Negate vector1 with the overloaded negation operator.
            // vectorResult is equal to (-20, -30).
            Vector vectorResult = -vector1;

            return vectorResult;

        }
        // </SnippetOverloadedNegationOperatorExample>

        // <SnippetParseExample>
        private Vector parseExample()
        {

            // Convert string into a Vector structure.
            // vectorResult is equal to (1,3)
            Vector vectorResult = Vector.Parse("1,3");

            return vectorResult;

        }
        // </SnippetParseExample>

        // <SnippetSubtractExample>
        private Vector subtractExample()
        {

            Vector vector1 = new Vector(20, 30);
            Vector vector2 = new Vector(45, 70);

            // Subtract vector2 from vector1.
            // vectorResult is equal to (-25, -40)
            Vector vectorResult = Vector.Subtract(vector1, vector2);

            return vectorResult;

        }
        // </SnippetSubtractExample>

        // <SnippetToStringExample>
        private String toStringExample()
        {

            Vector vector1 = new Vector(20, 30);

            // vectorString is equal to "20,30".
            String stringResult = vector1.ToString();

            return stringResult;

        }
        // </SnippetToStringExample>

        // <SnippetLengthExample>
        private Double lengthExample()
        {  

            Vector vector1 = new Vector(20, 30);

            // Get the length of the vector.
            // length is approximately equal to 36.0555
            Double lengthResult = vector1.Length;

            return lengthResult;

        }
        // </SnippetLengthExample>

        // <SnippetLengthSquaredExample>
        private Double lengthSquaredExample()
        {

            Vector vector1 = new Vector(20, 30); 

            // Gets the square of the length of a Vector. 
            // lengthSq is equal to 1300.
            Double lengthSqResult = vector1.LengthSquared;

            return lengthSqResult;

        }
        // </SnippetLengthSquaredExample>

        // <SnippetVectorEqualityExample>
        // Checks if two Vectors are equal using the overloaded equality operator.
        private Boolean vectorEqualityExample()
        {

            // Declaring vecto1 and initializing x,y values
            Vector vector1 = new Vector(20, 30);

            // Declaring vector2 without initializing x,y values
            Vector vector2 = new Vector();

            // Boolean to hold the result of the comparison
            Boolean areEqual;

            // assigning values to vector2
            vector2.X = 45;
            vector2.Y = 70;

            // Comparing Vectors for equality
            // areEqual is False
            areEqual = (vector1 == vector2);

            return areEqual;

        }
        // </SnippetVectorEqualityExample>
        
    

    }

}
