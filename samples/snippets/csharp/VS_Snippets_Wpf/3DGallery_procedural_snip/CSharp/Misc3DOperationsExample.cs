using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace SDKSample
{

    public class Misc3DOperationsExample : Page
    {

        public Misc3DOperationsExample()
        {

            StackPanel mainPanel = new StackPanel();

            TextBlock subtract3DPointsExampleText = new TextBlock();
            subtract3DPointsExampleText.Text = "subtract3DPointsExample: " + subtract3DPointsExample();
            mainPanel.Children.Add(subtract3DPointsExampleText);

            TextBlock subtract3DVectorsExampleText = new TextBlock();
            subtract3DVectorsExampleText.Text = "subtract3DVectorsExample: " + subtract3DVectorsExample();
            mainPanel.Children.Add(subtract3DVectorsExampleText);

            TextBlock point4DEqualityExampleText = new TextBlock();
            point4DEqualityExampleText.Text = "point4DEqualityExample: " + point4DEqualityExample();
            mainPanel.Children.Add(point4DEqualityExampleText);

            TextBlock size3DEqualityExampleText = new TextBlock();
            size3DEqualityExampleText.Text = "size3DEqualityExample: " + size3DEqualityExample().ToString();
            mainPanel.Children.Add(size3DEqualityExampleText);

            this.Content = mainPanel;
        }

        private string subtract3DPointsExample()
        {
            // <SnippetSubtract3DPointsExample_csharp>
            // instantiate variables
            Point3D point1 = new Point3D();
            Point3D point2 = new Point3D(15, 40, 60);
            Vector3D vector1 = new Vector3D(20, 30, 40);
            Point3D pointResult1 = new Point3D();
            Point3D pointResult2 = new Point3D();
            Vector3D vectorResult1 = new Vector3D();
            Vector3D vectorResult2 = new Vector3D();

            // defining x,y,z of point1
            point1.X = 10;
            point1.Y = 5;
            point1.Z = 1;

            vectorResult1 = Point3D.Subtract(point1, point2);
            // vectorResult1 is equal to (-5, -35, -59)

            vectorResult2 = point2 - point1;
            // vectorResult2 is equal to (5, 35, 59)

            pointResult1 = Point3D.Subtract(point1, vector1);
            //  pointResult1 is equal to (-10, -25, -39)

            pointResult2 = vector1 - point1;
            //  pointResult2 is equal to (10, 25, 39)
            // </SnippetSubtract3DPointsExample_csharp>

            string stringResults = "pointResult1: " + pointResult1.ToString();
            stringResults = stringResults + " pointResult2: " + pointResult2.ToString();
            stringResults = stringResults + " vectorResult1: " + vectorResult1.ToString();
            stringResults = stringResults + " vectorResult2: " + vectorResult2.ToString();
            return stringResults;
        }

        private string subtract3DVectorsExample()
        {
            // <SnippetSubtract3DVectorsExample_csharp>
            // Subtracts two 3-D Vectors using the Subtract method and -

            // Declaring vector1 and initializing x,y,z values
            Vector3D vector1 = new Vector3D(20, 30, 40);

            // Declaring vector2 without initializing x,y,z values
            Vector3D vector2 = new Vector3D();

            // Assigning values to vector2
            vector2.X = 45;
            vector2.Y = 70;
            vector2.Z = 80;

            // Subtracting vectors using overload - operator
            Vector3D vectorResult1 = new Vector3D();
            vectorResult1 = vector1 - vector2;
            // vectorResult1 is equal to (-25, -40, -40)

            // Subtracting vectors using static Subtract method
            Vector3D vectorResult2 = new Vector3D();
            vectorResult2 = Vector3D.Subtract(vector1, vector2);
            // vector2 is equal to (-25, -40, -40)
            // </SnippetSubtract3DVectorsExample_csharp>

            string stringResults = "vectorResult1: " + vectorResult1.ToString();
            stringResults = stringResults + " vectorResult2: " + vectorResult2.ToString();
            return stringResults;
        }

        private string point4DEqualityExample()
        {
            // <SnippetPoint4DEqualityExample_csharp>
            // instantiate Points
            Point4D point4D1 = new Point4D();
            Point4D point4D2 = new Point4D(15, 40, 60, 75);
            Point3D point3D1 = new Point3D(15, 40, 60);

            // result variables
            Boolean areEqual;
            Boolean areNotEqual;
            String stringResult;

            // defining x,y,z,w of point1
            point4D1.X = 10;
            point4D1.Y = 5;
            point4D1.Z = 1;
            point4D1.W = 4;

            // checking if Points are equal
            areEqual = point4D1 == point4D2;

            // areEqual is False

            // checking if Points are not equal
            areNotEqual = point4D1 != point4D2;
            // areNotEqual is True

            if (Point4D.Equals(point4D1, point3D1))
            {
                // the if condition is not true, so this block will not execute
                stringResult = "Both objects are Point4D structures and they are equal";
            }

            else
            {
                // the if condition is false, so this branch will execute
                stringResult = "Parameters are not both Point4D strucutres, or they are but are not equal";
            }
            // </SnippetPoint4DEqualityExample_csharp>

            return stringResult;
        }
        // <SnippetSize3DEqualityExample_csharp>
        private bool size3DEqualityExample()
        {

            // Checks if two Size3D structures are equal using the static Equals method.
            // Returns a Boolean.

            // Declaring Size3D structure without initializing x,y,z values
            Size3D size1 = new Size3D();

            // Declaring Size3D structure and initializing x,y,z values
            Size3D size2 = new Size3D(5, 10, 15);
            Boolean areEqual;

            // Assigning values to size1
            size1.X = 2;
            size1.Y = 4;
            size1.Z = 6;

            // checking for equality
            areEqual = Size3D.Equals(size1, size2);

            // areEqual is False
            return areEqual;
        }
        // </SnippetSize3DEqualityExample_csharp>
    }
}
