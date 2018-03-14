using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.PointExamples
{

    public class PointExample : Page
    {
    
        
        public PointExample()
        {
            
            StackPanel mainPanel = new StackPanel();

            TextBlock addPointAndVectorExampleText = new TextBlock();
            addPointAndVectorExampleText.Text = "addPointAndVectorExample: " + addPointAndVectorExample().ToString();
            mainPanel.Children.Add(addPointAndVectorExampleText);

            TextBlock staticEqualsExampleText = new TextBlock();
            staticEqualsExampleText.Text = "staticEqualsExample: " + staticEqualsExample().ToString();
            mainPanel.Children.Add(staticEqualsExampleText);

            TextBlock nonStaticEqualsExampleText = new TextBlock();
            nonStaticEqualsExampleText.Text = "nonStaticEqualsExample: " + nonStaticEqualsExample().ToString();
            mainPanel.Children.Add(nonStaticEqualsExampleText);

            TextBlock getHashCodeExampleText = new TextBlock();
            getHashCodeExampleText.Text = "getHashCodeExample: " + getHashCodeExample().ToString();
            mainPanel.Children.Add(getHashCodeExampleText);

            TextBlock multiplyPointByMatrixExampleText = new TextBlock();
            multiplyPointByMatrixExampleText.Text = "multiplyPointByMatrixExample: " + multiplyPointByMatrixExample().ToString();
            mainPanel.Children.Add(multiplyPointByMatrixExampleText);

            TextBlock offsetExampleText = new TextBlock();
            offsetExampleText.Text = "offsetExample: " + offsetExample().ToString();
            mainPanel.Children.Add(offsetExampleText);

            TextBlock overloadedAdditionOperatorExampleText = new TextBlock();
            overloadedAdditionOperatorExampleText.Text = "overloadedAdditionOperatorExample: " + overloadedAdditionOperatorExample().ToString();
            mainPanel.Children.Add(overloadedAdditionOperatorExampleText);

            TextBlock overloadedEqualityOperatorExampleText = new TextBlock();
            overloadedEqualityOperatorExampleText.Text = "overloadedEqualityOperatorExample: " + overloadedEqualityOperatorExample().ToString();
            mainPanel.Children.Add(overloadedEqualityOperatorExampleText);

            TextBlock overloadedExplicitOperatorSizeExampleText = new TextBlock();
            overloadedExplicitOperatorSizeExampleText.Text = "overloadedExplicitOperatorSizeExample: " + overloadedExplicitOperatorSizeExample().ToString();
            mainPanel.Children.Add(overloadedExplicitOperatorSizeExampleText);

            TextBlock overloadedExplicitOperatorVectorExampleText = new TextBlock();
            overloadedExplicitOperatorVectorExampleText.Text = "overloadedExplicitOperatorVectorExample: " + overloadedExplicitOperatorVectorExample().ToString();
            mainPanel.Children.Add(overloadedExplicitOperatorVectorExampleText);

            TextBlock overloadedInequalityOperatorExampleText = new TextBlock();
            overloadedInequalityOperatorExampleText.Text = "overloadedInequalityOperatorExample: " + overloadedInequalityOperatorExample().ToString();
            mainPanel.Children.Add(overloadedInequalityOperatorExampleText);

            TextBlock overloadedMultiplyPointByMatrixOperatorExampleText = new TextBlock();
            overloadedMultiplyPointByMatrixOperatorExampleText.Text = "overloadedMultiplyPointByMatrixOperatorExample: " + overloadedMultiplyPointByMatrixOperatorExample().ToString();
            mainPanel.Children.Add(overloadedMultiplyPointByMatrixOperatorExampleText);

            TextBlock overloadedSubtractionOperatorExample1Text = new TextBlock();
            overloadedSubtractionOperatorExample1Text.Text = "overloadedSubtractionOperatorExample1: " + overloadedSubtractionOperatorExample1().ToString();
            mainPanel.Children.Add(overloadedSubtractionOperatorExample1Text);

            TextBlock overloadedSubtractionOperatorExample2Text = new TextBlock();
            overloadedSubtractionOperatorExample2Text.Text = "overloadedSubtractionOperatorExample2: " + overloadedSubtractionOperatorExample2().ToString();
            mainPanel.Children.Add(overloadedSubtractionOperatorExample2Text);

            TextBlock parseExampleText = new TextBlock();
            parseExampleText.Text = "parseExample: " + parseExample().ToString();
            mainPanel.Children.Add(parseExampleText);

            TextBlock subtractExample1Text = new TextBlock();
            subtractExample1Text.Text = "subtractExample1: " + subtractExample1().ToString();
            mainPanel.Children.Add(subtractExample1Text);

            TextBlock subtractExample2Text = new TextBlock();
            subtractExample2Text.Text = "subtractExample2: " + subtractExample2().ToString();
            mainPanel.Children.Add(subtractExample2Text);

            TextBlock toStringExampleText = new TextBlock();
            toStringExampleText.Text = "toStringExample: " + toStringExample().ToString();
            mainPanel.Children.Add(toStringExampleText);

            TextBlock pointInequalityExampleText = new TextBlock();
            pointInequalityExampleText.Text = "pointInequalityExample: " + pointInequalityExample().ToString();
            mainPanel.Children.Add(pointInequalityExampleText);

            TextBlock pointConverterExampleText = new TextBlock();
            pointConverterExampleText.Text = "pointConverterExample: " + pointConverterExample().ToString();
            mainPanel.Children.Add(pointConverterExampleText);
            
            this.Content = mainPanel;
        }

        // <SnippetPointConverterExample_csharp>
        private Point pointConverterExample()
        {
            PointConverter pConverter = new PointConverter();
            Point pointResult = new Point();
            string string1 = "10,20";

            // pointResult is equal to (10, 20)
            pointResult = (Point)pConverter.ConvertFromString(string1);

            return pointResult;

        }
        // </SnippetPointConverterExample_csharp>

        // <SnippetAddPointAndVectorExample_csharp>
        private Point addPointAndVectorExample()
        {
            Point point1 = new Point(10, 5);
            Vector vector1 = new Vector(20, 30);

            // Add Point and Vector using the static Add method.
            // pointResult is equal to (30,35).
            Point pointResult = Point.Add(point1, vector1);

            return pointResult;

        }
        // </SnippetAddPointAndVectorExample_csharp>

        // <SnippetStaticEqualsExample_csharp>
        private Boolean staticEqualsExample()
        {

            Point point1 = new Point(10, 5);
            Point point2 = new Point(15, 40);

            // Check if the two points are equal using the static Equals method.
            // areEqual is false
            Boolean areEqual = Point.Equals(point1, point2);

            return areEqual;

        }
        // </SnippetStaticEqualsExample_csharp>

        // <SnippetNonStaticEqualsExample_csharp>
        private Boolean nonStaticEqualsExample()
        {

            Point point1 = new Point(10, 5);
            Point point2 = new Point(15, 40);

            // Check if the two points are equal using the non-static Equals method.
            // areEqual is false
            Boolean areEqual = point1.Equals(point2);	

            return areEqual;

        }
        // </SnippetNonStaticEqualsExample_csharp>

        // <SnippetGetHashCodeExample_csharp>
        private int getHashCodeExample()
        {
            
            Point point1 = new Point(10, 5);

            // Get the hashcode of a Point structure
            int returnHashCode = point1.GetHashCode();

            return returnHashCode;

        }
        // </SnippetGetHashCodeExample_csharp>

        // <SnippetMultiplyPointByMatrixExample_csharp>
        private Point multiplyPointByMatrixExample()
        {
              
            Point point1 = new Point(10, 5);
            Matrix matrix1 = new Matrix(40, 50, 60, 70, 80, 90);

            // Multiplies a Point by a Matrix.
            // pointResult is equal to (780,940).
            Point pointResult = Point.Multiply(point1, matrix1);

            return pointResult;

        }
        // </SnippetMultiplyPointByMatrixExample_csharp>

        // <SnippetOffsetExample_csharp>
        private Point offsetExample()
        {
            
            Point pointResult = new Point(10, 5);

            // Offset Point X value by 20 and Y value by 30.
            // point1 is now equal to (30,35)
            pointResult.Offset(20, 30);

            return pointResult;

        }
        // </SnippetOffsetExample_csharp>


        // <SnippetOverloadedAdditionOperatorExample>
        private Point overloadedAdditionOperatorExample()
        {
				
            Point point1 = new Point(10, 5);
            Vector vector1 = new Vector(20, 30);

            // Add point to a Vector using the overloaded (+) operator.
            // pointResult is equal to (30,35).
            Point pointResult = point1 + vector1;

            return pointResult;

        }
        // </SnippetOverloadedAdditionOperatorExample>



        // <SnippetOverloadedEqualityOperatorExample>
        private Boolean overloadedEqualityOperatorExample()
        {
            Point point1 = new Point(10, 5);
            Point point2 = new Point(15, 40);

            // Check if two Points are equal using the overloaded equality operator.
            // areEqual is False.
            Boolean areEqual = (point1 == point2);

            return areEqual;

        }
        // </SnippetOverloadedEqualityOperatorExample>

        // <SnippetOverloadedExplicitOperatorSizeExample>
        private Size overloadedExplicitOperatorSizeExample()
        {

            Point point1 = new Point(10, 5);

            // Explicitly converts a Point structure into a Size structure.
            // returnSize has a width of 10 and a height of 5  
            Size returnSize = (Size)point1;

            return returnSize;
            
        }
        // </SnippetOverloadedExplicitOperatorSizeExample>

        // <SnippetOverloadedExplicitOperatorVectorExample>
        private Vector overloadedExplicitOperatorVectorExample()
        {

            Point point1 = new Point(10, 5);

            // Explicitly converts a Point structure into a Vector structure.
            // returnVector is equal to (10,5).
            Vector returnVector = (Vector)point1;

            return returnVector;

        }
        // </SnippetOverloadedExplicitOperatorVectorExample>

        // <SnippetOverloadedInequalityOperatorExample>
        private Boolean overloadedInequalityOperatorExample()
        {
            Point point1 = new Point(20, 30);
            Point point2 = new Point(45, 70);

            // Check whether the two Points are not equal, using the overloaded 
            // inequality operator.
            // areNotEqual is True.
            Boolean areNotEqual = (point1 != point2);

            return areNotEqual;

        }
        // </SnippetOverloadedInequalityOperatorExample>

        // <SnippetOverloadedMultiplyPointByMatrixOperatorExample>
        private Point overloadedMultiplyPointByMatrixOperatorExample()
        {

            Point point1 = new Point(10, 5);
            Matrix matrix1 = new Matrix(40, 50, 60, 70, 80, 90);

            // Multiply the Point by the Matrix using the overloaded
            // (*) operator.
            // pointResult is equal to (780,940).
            Point pointResult = point1 * matrix1;

            return pointResult;

        }
        // </SnippetOverloadedMultiplyPointByMatrixOperatorExample>



        // <SnippetOverloadedSubtractionOperatorExample1>
        private Point overloadedSubtractionOperatorExample1()
        {

            Point point1 = new Point(10, 5);
            Vector vector1 = new Vector(20, 30);

            // Subtracts a Vector from a Point using the overloaded subtraction (-) operator.
            // pointResult is equal to (-10, -25)
            Point pointResult = point1 - vector1;
            
            return pointResult;

        }
        // </SnippetOverloadedSubtractionOperatorExample1>

        // <SnippetOverloadedSubtractionOperatorExample2>
        private Vector overloadedSubtractionOperatorExample2()
        {
  
            Point point1 = new Point(10, 5);
            Point point2 = new Point(15, 40);

            // Subtracts a Point from another Point using the overloaded subtraction (-)
            // operator and returns the difference as a Vector.
            // vectorResult is equal to (-5, -35).
            Vector vectorResult = point1 - point2;

            return vectorResult;

        }
        // </SnippetOverloadedSubtractionOperatorExample2>


        // <SnippetParseExample>
        private Point parseExample()
        {

            // Converts a string representation of a point into a Point structure
            // using the Parse static method.
            // pointResult is equal to (1,3).
            Point pointResult = Point.Parse("1,3");

            return pointResult;

        }
        // </SnippetParseExample>

        // <SnippetSubtractExample1>
        private Point subtractExample1()
        {
 
            Point point1 = new Point(10, 5);
            Vector vector1 = new Vector(20, 30);

            // Subtracts a Vector from a Point using the static Subtract method
            // and returns the difference as a Point.
            // pointResult is equal to (-10, -25).
            Point pointResult = Point.Subtract(point1, vector1);

            return pointResult;

        }
        // </SnippetSubtractExample1>

        // <SnippetSubtractExample2>
        private Vector subtractExample2()
        {

            Point point1 = new Point(10, 5);
            Point point2 = new Point(15, 40);

            // Subtracts a Point from a Point using the static Subtract method
            // and returns the difference as a Vector.
            // vectorResult is equal to (-5, -35)
            Vector vectorResult = Point.Subtract(point1, point2);

            return vectorResult;

        }
        // </SnippetSubtractExample2>

        // <SnippetToStringExample>
        private String toStringExample()
        {

            Point point1 = new Point(10, 5);

            // Get a string representation of a Point structure.
            // pointString is equal to 10,5	.
            String stringResult = point1.ToString();

            return stringResult;

        }
        // </SnippetToStringExample>


        // <SnippetPointInequalityExample>
        // Checks if two Points are equal using the overloaded inequality operator.
        private Boolean pointInequalityExample()
        {
            // Checks if two Points are not equal using the overloaded inequality operator.

            // Declaring point1 and initializing x,y values
            Point point1 = new Point(10, 5);

            // Declaring point2 without initializing x,y values
            Point point2 = new Point();

            // Boolean to hold the result of the comparison
            Boolean areNotEqual;

            // assigning values to point2
            point2.X = 15;
            point2.Y = 40;

            // Compare Point structures for equality.
            // areNotEqual is True
            areNotEqual = (point1 != point2);

            return areNotEqual;

        }
        // </SnippetPointInequalityExample>
        
    

    }

}
