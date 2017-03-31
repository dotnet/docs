//This is a list of commonly used namespaces for a window.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace FourDPointSample
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
   


	public partial class Window1 : Window
	{

        public Window1()
        {
            InitializeComponent();
        }

        // This method performs the Point4D operations
        //<SnippetMil4DPoints3DN1>
        private void PerformOperation(object sender, System.Windows.RoutedEventArgs e)
		{
			
			//RadioButton li = ((sender as RadioButtonList).SelectedItem as RadioButton);
            RadioButton li = (sender as RadioButton);
			
            // Strings used to display the results
            String syntaxString, resultType, operationString;
					
			// The local variables point1, point2, vector2, etc are defined in each
			// case block for readability reasons. Each variable is contained within
			// the scope of each case statement.  
            //</SnippetMil4DPoints3DN1>
			switch (li.Name)
			{   //begin switch


                case "rb1":
                    {
                        //<SnippetMil4DPoints3DN3>
                        // Add a Point4D to a Point4D using the overloaded + operator. 
                        // Returns a Point4D.

                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D point2 = new Point4D(15, 40, 60, 75);
                        Point4D pointResult = new Point4D();

                        pointResult = point1 + point2;
                        // pointResult is equal to (25, 45, 61, 79))

                        // Displaying Results
                        syntaxString = "pointResult = point1 + point2;";
                        resultType = "Point4D";
                        operationString = "Adding a 3D Point and a 3D Vector";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN3>
                        break;
                    }

                case "rb2":
					{
                        //<SnippetMil4DPoints3DN4>
                        // Add a Point4D to a Point4D using the static Add method.
                        // Returns a Point4D.
 
                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D point2 = new Point4D(15, 40, 60, 75);
                        Point4D pointResult = new Point4D();

                        pointResult = Point4D.Add(point1, point2);
                        // pointResult is equal to (25, 45, 61, 79)

                        // Displaying Results
                        syntaxString = "pointResult = Point4D.Add(point1, point2);";
                        resultType = "Point4D";
						operationString = "Adding a 3D Point and a 3D Vector";
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN4>
						break;
					}

				case "rb3":
					{
                        //<SnippetMil4DPoints3DN5>
                        // Subtracts a Point4D from a Point4D using the overloaded - operator.
                        // Returns a Point4D.

                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D point2 = new Point4D(15, 40, 60, 75);
                        Point4D pointResult = new Point4D();

                        pointResult = point1 - point2;
                        // pointResult is equal to (-5, -35, -59, -71) 

                        // Displaying Results
                        syntaxString = "pointResult = point1 - point2;";
                        resultType = "Point4D";
						operationString = "Subtracting a Vector3D from a Point4D";
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN5>
						break;
					}

				case "rb4":
					{
                        //<SnippetMil4DPoints3DN6>
                        // Subtracts a Point3D from a Point4D using the static Subtract method. 
                        // Returns a Point4D.

                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D point2 = new Point4D(15, 40, 60, 75);
                        Point4D pointResult = new Point4D();

                        pointResult = Point4D.Subtract(point1, point2);
                        // pointResult is equal to (-5, -35, -59, -71)

                        // Displaying Results
                        syntaxString = "pointResult = Point4D.Subtract(point1, point2);";
                        resultType = "Point4D";
						operationString = "Subtracting a Vector3D from a Point4D";
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN6>
						break;
					}


				case "rb5":
					{
                        //<SnippetMil4DPoints3DN7>
                        // Offsets the X, Y, Z, and W values of a Point4D.

                        Point4D point1 = new Point4D(10, 5, 1, 4);

                        point1.Offset(20, 30, 40, 50);
                        // point1 is equal to (30, 35, 41, 54)

                        // Displaying Results
                        syntaxString = "point1.Offset(20, 30, 41, 54);";
                        resultType = "Point4D";
						operationString = "Offsetting a Point4D";
						ShowResults(point1.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN7>
						break;
					}

				case "rb6":
					{
                        //<SnippetMil4DPoints3DN8>
                        // Multiplies a Point4D by a Matrix.  
                        // Returns a Point4D.

						Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D pointResult = new Point4D();
                        Matrix3D matrix1 = new Matrix3D(10, 10, 10, 0, 20, 20, 20, 0, 30, 30, 30, 0, 5, 10, 15, 1);

                        pointResult = point1 * matrix1;
                        // pointResult is equal to (250, 270, 290, 4)

						// Displaying Results
						resultType = "Point4D";
                        syntaxString = "pointResult = point1 * matrix1;";
                        operationString = "Multiplying a Point4D by a Matrix3D";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN8>
                        break;
					}

				case "rb7":
					{
                        //<SnippetMil4DPoints3DN9>
                        // Multiplies a Point4D by a Matrix.  
                        // Returns a Point4D.

						Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D pointResult = new Point4D();
                        Matrix3D matrix1 = new Matrix3D(10, 10, 10, 0, 20, 20, 20, 0, 30, 30, 30, 0, 5, 10, 15, 1);

                        pointResult = Point4D.Multiply(point1, matrix1);
                        // pointResult is equal to (250, 270, 290, 4)

                        // Displaying Results
						resultType = "Point4D";
                        syntaxString = "pointResult = Point4D.Multiply(point1, matrix1);";
                        operationString = "Multiplying a Point4D by a Matrix3D";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN9>
                        break;
					}

                case "rb8":
                    {
                        //<SnippetMil4DPoints3DN10>
                        // Checks if two Point4D structures are equal using the overloaded equality operator.

                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D point2 = new Point4D(15, 40, 60, 75);
                        Boolean areEqual;

                        areEqual = (point1 == point2);
                        // areEqual is False

                        // Displaying Results
                        syntaxString = "areEqual = (point1 == point2);";
                        resultType = "Boolean";
                        operationString = "Checking if two 3D points are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN10>
                        break;
                    }
    

                case "rb9":
                    {
                        //<SnippetMil4DPoints3DN11>
                        // Checks if two Point4D structures are equal using the static Equals method.
                         
                        // point1's x,y,z,w properties set when the structure is created  
                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        
                        Point4D point2 = new Point4D();
                        Boolean areEqual;

                        // settting point2's x,y,z,w properties   
                        point2.X = 15;
                        point2.Y = 40;
                        point2.Z = 60;
                        point2.W = 75;

                        areEqual = Point4D.Equals(point1, point2);
                        // areEqual is False	

                        //Displaying Results
                        syntaxString = "areEqual = Point4D.Equals(point1, point2);";
                        resultType = "Boolean";
                        operationString = "Checking if 3D two points are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN11>
                        break;
                    }
                case "rb10":
                    {
                        //<SnippetMil4DPoints3DN12>
                        // Compares an Object and a Point4D for equality using the non-static Equals method.

                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D point2 = new Point4D(15, 40, 60, 75);
                        Boolean areEqual;

                        areEqual = point1.Equals(point2);
                        // areEqual is False.  point2 is a Point4D structure, but it is not equal to point1.	


                        // Displaying Results
                        syntaxString = "areEqual = point1.Equals(point2);";
                        resultType = "Boolean";
                        operationString = "Checking if two 3D points are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN12>
                        break;
                    }
                

                case "rb11":
                    {
                        //<SnippetMil4DPoints3DN13>
                        // Converts a string representation of a 4D point into a Point4D structure.

                        Point4D pointResult = new Point4D();

                        pointResult = Point4D.Parse("1,3,5,7");
                        // pointResult is equal to (1, 3, 5, 7)

                        // Displaying Results
                        syntaxString = "pointResult = Point4D.Parse(\"1,3,5,7\");";
                        resultType = "Point4D";
                        operationString = "Converts a string into a Point4D structure.";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN13>
                        break;
                    }

                case "rb12":
                    {
                        //<SnippetMil4DPoints3DN14>
                        // Checks if two Point4Ds are not equal using the overloaded inequality operator.

                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        Point4D point2 = new Point4D(15, 40, 60, 75);
                        Boolean areNotEqual;

                        areNotEqual = (point1 != point2);
                        // areNotEqual is True

                        // Displaying Results
                        syntaxString = "areNotEqual = (point1 != point2);";
                        resultType = "Boolean";
                        operationString = "Checking if two 3D points are not equal";
                        ShowResults(areNotEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN14>
                        break;
                    }

                case "rb13":
                    {
                        //<SnippetMil4DPoints3DN15>
                        // Gets a string representation of the structure
                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        String pointString;

                        pointString = point1.ToString();
                        // matrixString is equal to 10, 5, 1, 4

                        // Displaying Results
                        syntaxString = "pointString = point1.ToString();";
                        resultType = "String";
                        operationString = "Getting the string representation of a Point4D";
                        ShowResults(pointString.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN15>
                        break;
                    }

                case "rb14":
                    {
                        //<SnippetMil4DPoints3DN16>
                        // Gets the hashcode of a Point4D structure

                        Point4D point1 = new Point4D(10, 5, 1, 4);
                        int pointHashCode;

                        pointHashCode = point1.GetHashCode();

                        // Displaying Results
                        syntaxString = "pointHashCode = point1.GetHashCode();";
                        resultType = "int";
                        operationString = "Getting the hashcode of Point4D";
                        ShowResults(pointHashCode.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN16>
                        break;
                    }
                case "rb15":
                    {
                        //<SnippetMil4DPoints3DN17>
                        // Point4D Equality and Inequality operations

                        // instantiate variables
                        Point4D point4D1 = new Point4D();
                        Point4D point4D2 = new Point4D(15, 40, 60, 75);
                        Point3D point3D1 = new Point3D(15, 40, 60);
                       
                        // result variables
                        Boolean areEqual;
                        Boolean areNotEqual;
                        String stringResult;

                        // defining x,y,z of point1
                        point4D1.X = 10;
                        point4D1.Y = 5;
                        point4D1.Z = 1;
                        point4D1.W = 4;

                        // equality operations

                        areEqual = point4D1 == point4D2;
                        // areEqual is False

                        areNotEqual = point4D1 != point4D2;
                        // areNotEqual is True

                       
                        if(Point4D.Equals(point4D1, point3D1))
                        {
                            // the if condition is not true, so this block will not execute
                            stringResult = "Both objects are Point4D structures and they are equal";
                        }
                        else
                        {
                            // the if condition is false, so this branch will execute
                            stringResult = "parameters are not Point4D strucutres, or they are but are not equal";
                        }
                     
                        // Displaying Results
                        syntaxString = "areNotEqual = (point1 != point2);";
                        resultType = "Boolean";
                        operationString = "Checking if two 3D points are not equal";
                        ShowResults(areNotEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil4DPoints3DN17>
                        break;
                    }

                default:
                    break;

            } //end switch
            //<SnippetMil4DPoints3DN2>
        }

        //</SnippetMil4DPoints3DN2>
        // Displays the results of the operation
        private void ShowResults(String resultValue, String syntax, String resultType, String opString)
        {

            txtResultValue.Text = resultValue;
            txtSyntax.Text = syntax;
            txtResultType.Text = resultType;
            txtOperation.Text = opString;
        }

        // Displays the values of the variables
        public void ShowVars()
        {

            Point4D p1 = new Point4D(10, 5, 1, 4);
            Point4D p2 = new Point4D(15, 40, 60, 75);

            Matrix3D m1 = new Matrix3D(10,10,10,0,20,20,20,0,30,30,30,0,5,10,15,1);

            // Displaying values in Text objects
            txtPoint1.Text = p1.ToString();
            txtPoint2.Text = p2.ToString();
            txtMatrix1.Text = m1.ToString();
        }
    }
}