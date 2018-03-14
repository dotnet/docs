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

namespace Vector3DSample
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
        //<SnippetMil3dVectorSample3DN1>
        private void PerformOperation(object sender, RoutedEventArgs e)
		{
			
			RadioButton li = (sender as RadioButton);
			
            // Strings used to display results
            String syntaxString, resultType, operationString;
					
			///The local variables point1, point2, vector2, etc are defined in each
			///case block for readability reasons. Each variable is contained within
			///the scope of each case statement.  
            //</SnippetMil3dVectorSample3DN1>
			switch (li.Name)
			{   //begin switch

                case "rb1":
                    {
                        //<SnippetMil3dVectorSample3DN2>
                        // Translates a Point3D by a Vector3D using the overloaded + operator.  
                        // Returns a Point3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Point3D point1 = new Point3D(10, 5, 1);
                        Point3D pointResult = new Point3D();

                        pointResult = point1 + vector1;
                        // vectorResult is equal to (30, 35, 41)

                        //</SnippetMil3dVectorSample3DN2>
                        // Displaying Results
                        syntaxString = "pointResult = point1 + vector1;";
                        resultType = "Point3D";
                        operationString = "Adding a Vector3D to a Vector3D";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        
                        break;
                    }

                case "rb2":
					{
                        //<SnippetMil3dVectorSample3DN3>
						// Adds a Vector3D to a Vector3D using the overloaded + operator.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Vector3D vector2 = new Vector3D(45, 70, 80);
						Vector3D vectorResult = new Vector3D();

						vectorResult = vector1 + vector2;
                        // vectorResult is equal to (65, 100, 120)
                        //</SnippetMil3dVectorSample3DN3>
                        // Displaying Results
                        syntaxString = "vectorResult = vector1 + vector2;";
                        resultType = "Vector3D";
						operationString = "Adding a Vector3D to a Vector3D";
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
						break;
					}



                case "rb3":
                    {
                        //<SnippetMil3dVectorSample3DN4>
                        // Translates a Point3D by a Vector3D using the static Add method.  
                        // Returns a Point3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Point3D point1 = new Point3D(10, 5, 1);
                        Point3D pointResult = new Point3D();

                        pointResult = Vector3D.Add(vector1, point1);
                        // vectorResult is equal to (30, 35, 41)
                        //</SnippetMil3dVectorSample3DN4>

                        // Displaying Results
                        syntaxString = " pointResult = Vector3D.Add(vector1, point1);";
                        resultType = "Point3D";
                        operationString = "Adding a Vector3D to a Vector3D";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb4":
                    {
                        //<SnippetMil3dVectorSample3DN5>
                        // Adds a Vector3D to a Vector3D using the static Add method.  
                        // Returns a Vector3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vector2 = new Vector3D(45, 70, 80);
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = Vector3D.Add(vector1, vector2);
                        // vectorResult is equal to (65, 100, 120)
                        //</SnippetMil3dVectorSample3DN5>

                        // Displaying Results
                        syntaxString = "vectorResult = Vector3D.Add(vector1, vector2);";
                        resultType = "Vector3D";
                        operationString = "Adding a Vector3D to a Vector3D";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }



                case "rb5":
					{
                        //<SnippetMil3dVectorSample3DN6>
						// Subtracts a Vector3D from a Vector3D using the overloaded - operator.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Vector3D vector2 = new Vector3D(45, 70, 80);
						Vector3D vectorResult = new Vector3D();

						vectorResult = vector1 - vector2;
                        // vector Result is equal to (-25, -40, -40)
                        //</SnippetMil3dVectorSample3DN6>

						// Displaying Results 
                        syntaxString = "vectorResult = vector1 - vector2;";
                        resultType = "Vector3D";
						operationString = "Subtracting a Vector3D from a Vector3D";
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
						break;
					}

				case "rb6":
					{
                        //<SnippetMil3dVectorSample3DN7>
						// Subtracts a Vector3D from a Vector3D using the static Subtract method.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Vector3D vector2 = new Vector3D(45, 70, 80);
						Vector3D vectorResult = new Vector3D();

						vectorResult = Vector3D.Subtract(vector1, vector2);
                        // vector Result is equal to (-25, -40, -40)
                        //</SnippetMil3dVectorSample3DN7>

                        // Displaying Results
                        syntaxString = "vectorResult = Vector3D.Subtract(vector1, vector2);";
                        resultType = "Vector3D";
						operationString = "Subtracting a Vector3D from a Vector3D";
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
						break;
					}

                case "rb7":
                    {
                        //<SnippetMil3dVectorSample3DN8>
                        // Subtracts a Vector3D from a Point3D using the overloaded - operator.
                        // Returns a Point3D.

                        Point3D point1 = new Point3D(10, 5, 1);
                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Point3D pointResult = new Point3D();

                        // Subtracting the vector from the point
                        pointResult = vector1 - point1;

                        // pointResult is equal to (10, 25, 39) 
                        //</SnippetMil3dVectorSample3DN8>
                        // Displaying Results
                        syntaxString = " pointResult = point1 - vector1;";
                        resultType = "Point3D";
                        operationString = "Subtracting a Vector3D from a Point3D";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }
                case "rb8":
                    {
                        //<SnippetMil3dVectorSample3DN9>
                        // Subtracts a Vector3D from a Point3D using the static Subtract method.
                        // Returns a Point3D.

                        Point3D point1 = new Point3D(10, 5, 1);
                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Point3D pointResult = new Point3D();

                        pointResult = Vector3D.Subtract(vector1, point1); 
                        // pointResult is equal to (10, 25, 39) 
                        //</SnippetMil3dVectorSample3DN9>

                        // Displaying Results
                        syntaxString = "pointResult = Vector3D.Subtract(vector1, point1);";
                        resultType = "Point3D";
                        operationString = "Subtracting a Vector3D from a Point3D";
                        ShowResults(pointResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }
                case "rb9":
					{
                        //<SnippetMil3dVectorSample3DN10>
						// Multiplies a Vector3D by a Scalar using the overloaded * operator.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Double scalar1 = 75;
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = vector1 * scalar1;
                        // vectorResult is equal to (1500, 2250, 3000)
                        //</SnippetMil3dVectorSample3DN10>

                        // Displaying Results
                        syntaxString = "vectorResult = vector1 * scalar1;";
                        resultType = "Vector3D";
						operationString = "Multiplies a Vector3D by a Scalar";
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
						break;
					}

                case "rb10":
                    {
                        //<SnippetMil3dVectorSample3DN11>
                        // Multiplies a Scalar by a Vector3D using the overloaded * operator.  
                        // Returns a Vector3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Double scalar1 = 75;
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = scalar1 * vector1;
                        // vectorResult is equal to (1500, 2250, 3000)
                        //</SnippetMil3dVectorSample3DN11>

                        // Displaying Results
                        syntaxString = "vectorResult = scalar1 * vector1;";
                        resultType = "Vector3D";
                        operationString = "Multiplies a Scalar by a Vector3D";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }


                case "rb11":
                    {
                        //<SnippetMil3dVectorSample3DN12>
                        // Multiplies a Vector3D by a Matrix3D using the overloaded * operator.  
                        // Returns a Vector3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Matrix3D matrix1 = new Matrix3D(10, 10, 10, 0, 20, 20, 20, 0, 30, 30, 30, 0, 5, 10, 15, 1);
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = vector1 * matrix1;
                        // vector Result is equal to (2000, 2000, 2000)
                        //</SnippetMil3dVectorSample3DN12>

                        // Displaying Results
                        syntaxString = "vectorResult = vector1 * matrix1;";
                        resultType = "Vector3D";
                        operationString = "Multiplies a Vector3D by a Matrix3D";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb12":
                    {
                        //<SnippetMil3dVectorSample3DN13>
                        // Multiplies a Vector3D by a Scalar using the static Multiply method.  
                        // Returns a Vector3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Double scalar1 = 75;
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = Vector3D.Multiply(vector1, scalar1);
                        // vectorResult is equal to (1500, 2250, 3000)
                        //</SnippetMil3dVectorSample3DN13>

                        // Displaying Results
                        syntaxString = "vectorResult = Vector3D.Multiply(vector1, scalar1);";
                        resultType = "Vector3D";
                        operationString = "Multiplies a Vector3D by a Scalar";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb13":
                    {
                        //<SnippetMil3dVectorSample3DN14>
                        // Multiplies a Scalar by a Vector3D using the static Multiply method.  
                        // Returns a Vector3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Double scalar1 = 75;
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = Vector3D.Multiply(scalar1, vector1);
                        // vectorResult is equal to (1500, 2250, 3000)
                        //</SnippetMil3dVectorSample3DN14>

                        // Displaying Results
                        syntaxString = "vectorResult = Vector3D.Multiply(scalar1, vector1);";
                        resultType = "Vector3D";
                        operationString = "Multiplies a Scalar by a Vector3D";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }


                case "rb14":
                    {
                        //<SnippetMil3dVectorSample3DN15>
                        // Multiplies a Vector3D by a Matrix3D using the static Multiply method.  
                        // Returns a Vector3D.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Matrix3D matrix1 = new Matrix3D(10, 10, 10, 0, 20, 20, 20, 0, 30, 30, 30, 0, 5, 10, 15, 1);
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = Vector3D.Multiply(vector1,matrix1);
                        // vector Result is equal to (2000, 2000, 2000)
                        //</SnippetMil3dVectorSample3DN15>

                        // Displaying Results
                        syntaxString = "vectorResult = Vector3D.Multiply(vector1,matrix1);";
                        resultType = "Vector3D";
                        operationString = "Multiplies a Vector3D by a Matrix3D";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb15":
					{
                        //<SnippetMil3dVectorSample3DN16>
						// Divides a Vector3D by a Scalar using the overloaded / operator.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Vector3D vectorResult = new Vector3D();
						Double scalar1 = 75;

						vectorResult = vector1 / scalar1;
                        // vectorResult is approximately equal to (0.26667, 0.4, 0.53333)
                        //</SnippetMil3dVectorSample3DN16>

                        // Displaying Results
						syntaxString = "vectorResult = vector1 / scalar1;";
						resultType = "Vector3D";
						operationString = "Dividing a Vector3D by a Scalar";
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
						break;
					}
				case "rb16":
					{
                        //<SnippetMil3dVectorSample3DN17>
						// Divides a Vector3D by a Double using the static Divide method.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Vector3D vectorResult = new Vector3D();
						Double scalar1 = 75;

						vectorResult = Vector3D.Divide(vector1, scalar1);
                        // vectorResult is approximately equal to (0.26667, 0.4, 0.53333)
                        //</SnippetMil3dVectorSample3DN17>

                        // Displaying Results
						syntaxString = "vectorResult = Vector3D.Divide(vector1, scalar1);";
						resultType = "Vector3D";
						operationString = "Dividing a Vector3D by a Scalar";
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
						break;
					}

				case "rb17":
					{
                        //<SnippetMil3dVectorSample3DN18>
						// Unary Negate a Vector3D using the - unary operator.  
						// Returns a Vector3D.
						 
						Vector3D vector1 = new Vector3D(20, 30, 40);
						Vector3D vectorResult = new Vector3D();

						vectorResult = -vector1;
                        //  vectorResult is equal to (-20, -30, -40)
                        //</SnippetMil3dVectorSample3DN18>

						//Displaying Results
						syntaxString = "vectorResult = -vector1;";
						resultType = "Vector3D";
						operationString = "Unary Negate a Vector3D";
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
						break;
					}


				case "rb18":
					{
                        //<SnippetMil3dVectorSample3DN19>
						// Gets the length of a Vector3D.  
						// Returns a Double.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Double length;

						length = vector1.Length;
                        // length is approximately equal to 53.85165
                        //</SnippetMil3dVectorSample3DN19>

                        // Displaying Results
						syntaxString = "length = vector1.Length();";
						resultType = "Double";
						operationString = "Getting the length of a Vector3D";
						ShowResults(length.ToString(), syntaxString, resultType, operationString);
						break;
					}

				case "rb19":
					{
                        //<SnippetMil3dVectorSample3DN20>
						// Gets the square of the length of a Vector3D.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Double lengthSq;

						lengthSq = vector1.LengthSquared;
                        // lengthSq is equal to 2900
                        //</SnippetMil3dVectorSample3DN20>

                        // Displaying Results
						syntaxString = "lengthSq = vector1.LengthSquared;";
						resultType = "Double";
						operationString = "Getting the length square of a Vector3D";
						ShowResults(lengthSq.ToString(), syntaxString, resultType, operationString);
						break;
					}
				case "rb20":
					{
                        //<SnippetMil3dVectorSample3DN21>
						// Normalizes a Vector3D using the Normalize method.  
						// Returns a Vector3D.

						Vector3D vector1 = new Vector3D(20, 30, 40);

						vector1.Normalize();
                        // vector1 is approximately equal to (0.37139, 0.55709, 0.74278) 
                        //</SnippetMil3dVectorSample3DN21>

                        // Displaying Results
						syntaxString = "vector1.Normalize();";
						resultType = "Void";
						operationString = "Normalizing a Vector3D";
						ShowResults(vector1.ToString(), syntaxString, resultType, operationString);
						break;
					}
				
				case "rb21":
					{
                        //<SnippetMil3dVectorSample3DN22>
						// Calculates the angle between two Vector3Ds using the static AngleBetween method. 
						// Returns a Double.
	
                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vector2 = new Vector3D(45, 70, 80);
                        Double angleBetween;

						angleBetween = Vector3D.AngleBetween(vector1, vector2 );
                        // angleBetween is approximately equal to 4.15129
                        //</SnippetMil3dVectorSample3DN22>

                        // Displaying Results
						syntaxString = "angleBetween = Vector3D.AngleBetween(vector1, vector2);";
						resultType = "Double";
						operationString = "Calculating the angle between two Vector3Ds";
						ShowResults(angleBetween.ToString(), syntaxString, resultType, operationString);
						break;
					}

				case "rb22":
					{
                        //<SnippetMil3dVectorSample3DN23>
						// Calculates the cross product of two Vector3D structures 
                        // using the static CrossProduct method.  
						// Returns a Double.	

						Vector3D vector1 = new Vector3D(20, 30, 40);
						Vector3D vector2 = new Vector3D(45, 70, 80);
                        Vector3D crossProduct = new Vector3D();

                        crossProduct = Vector3D.CrossProduct(vector1,vector2);
                        // crossProduct is equal to (-400, 200, 50)
                        //</SnippetMil3dVectorSample3DN23>

						// Displaying Results
						syntaxString = "crossProduct = Vector3D.CrossProduct(vector1,vector2);";
						resultType = "Vector3D";
						operationString = "Calculating the crossproduct of two Vector3Ds";
						ShowResults(crossProduct.ToString(), syntaxString, resultType, operationString);
						break;
					}


                case "rb23":
                    {
                        //<SnippetMil3dVectorSample3DN24>
                        // Calculates the Dot Product of two Vectors.
                    
                        // Declaring vector1 and initializing x,y,z values
                        Vector3D vector1 = new Vector3D(20, 30, 40);

                        // Declaring vector2 without initializing x,y,z values
                        Vector3D vector2 = new Vector3D();

                        // A Double to hold the result of the operation
                        Double dotProduct;

                        // Assigning values to vector2
                        vector2.X = 45;
                        vector2.Y = 70;
                        vector2.Z = 80;

                        // Calculating the dot product of vector1 and vector2
                        dotProduct = Vector3D.DotProduct(vector1, vector2);

                        // vectorResult is equal to (6200)
                        //</SnippetMil3dVectorSample3DN24>

                        // Displaying Results
                        syntaxString = "dotProduct = Vector3D.DotProduct(vector1, vector2);";
                        resultType = "Vector3D";
                        operationString = "Calculating the dot product of vector1 and vector2";
                        ShowResults(dotProduct.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb24":
                    {
                        //<SnippetMil3dVectorSample3DN25>
                        // Checks if two Vector3D structures are equal using the overloaded equality operator.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vector2 = new Vector3D(45, 70, 80);
                        Boolean areEqual;

                        areEqual = (vector1 == vector2);
                        // areEqual is False
                        //</SnippetMil3dVectorSample3DN25>

                        // Displaying Results
                        syntaxString = "areEqual = (vector1 == vector2);";
                        resultType = "Boolean";
                        operationString = "Checking if two vectors are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        break;
                    }


                case "rb25":
                    {
                        //<SnippetMil3dVectorSample3DN26>
                        // Checks if two Vector3D structures are equal using the static Equals method.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vector2 = new Vector3D(45, 70, 80);
                        Boolean areEqual;

                        areEqual = Vector3D.Equals(vector1, vector2);
                        // areEqual is False	
                        //</SnippetMil3dVectorSample3DN26>

                        // Displaying Results
                        syntaxString = "areEqual = Vector3D.Equals(vector1, vector2);";
                        resultType = "Boolean";
                        operationString = "Checking if two vectors are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        break;
                    }
                case "rb26":
                    {
                        //<SnippetMil3dVectorSample3DN27>
                        // Compares an Object and a Vector3D for equality using the non-static Equals method.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vector2 = new Vector3D(45, 70, 80);
                        Boolean areEqual;

                        areEqual = vector1.Equals(vector2);
                        // areEqual is False	
                        //</SnippetMil3dVectorSample3DN27>

                        // Displaying Results
                        syntaxString = "areEqual = vector1.Equals(vector2);";
                        resultType = "Boolean";
                        operationString = "Checking if two vectors are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb27":
                    {
                        //<SnippetMil3dVectorSample3DN28>
                        // Converts a string representation of a vector into a Vector3D structure

                        Vector3D vectorResult = new Vector3D();

                        vectorResult = Vector3D.Parse("1,3,5");
                        // vectorResult is equal to (1, 3, 5)
                        //</SnippetMil3dVectorSample3DN28>

                        // Displaying Results
                        syntaxString = "vectorResult = Vector3D.Parse(\"1,3,5\");";
                        resultType = "Boolean";
                        operationString = "Checking if two points are not equal";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb28":
                    {
                        //<SnippetMil3dVectorSample3DN29>
                        // Checks if two Vector3D structures are not equal using the overloaded inequality operator.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vector2 = new Vector3D(45, 70, 80);
                        Boolean areNotEqual;

                        areNotEqual = (vector1 != vector2);
                        // areNotEqual is True
                        //</SnippetMil3dVectorSample3DN29>

                        // Displaying Results
                        syntaxString = "areNotEqual = (vector1 != vector2);";
                        resultType = "Boolean";
                        operationString = "Checking if two points are not equal";
                        ShowResults(areNotEqual.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb29":
                    {
                        //<SnippetMil3dVectorSample3DN30>
                        // Negates a Vector3D using the Negate method.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vectorResult = new Vector3D();

                        vector1.Negate();
                        // vector1 is equal to (-20, -30, -40)
                        //</SnippetMil3dVectorSample3DN30>

                        // Displaying Results
                        syntaxString = "vector1.Negate(vector1);";
                        resultType = "void";
                        operationString = "Negating a vector";
                        ShowResults(vector1.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb30":
                    {
                        //<SnippetMil3dVectorSample3DN31>
                        // Negates a Vector3D using the overloaded unary negation operator.

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        Vector3D vectorResult = new Vector3D();

                        vectorResult = -vector1;
                        // vectorResult is equal to (-20, -30, -40)
                        //</SnippetMil3dVectorSample3DN31>

                        // Displaying Results
                        syntaxString = "vectorResult = -vector1;";
                        resultType = "Vector3D";
                        operationString = "Negating a vector";
                        ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                case "rb31":
                    {
                        //<SnippetMil3dVectorSample3DN32>
                        // Gets a string representation of the structure
                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        String vectorString;

                        vectorString = vector1.ToString();
                        // vectorString is equal to 20, 30, 40
                        //</SnippetMil3dVectorSample3DN32>

                        // Displaying Results
                        syntaxString = "vectorString = vector1.ToString();";
                        resultType = "String";
                        operationString = "Getting the string representation of a Vector3D";
                        ShowResults(vectorString.ToString(), syntaxString, resultType, operationString);
                        break;
                    }
                case "rb32":
                    {
                        //<SnippetMil3dVectorSample3DN33>
                        // Gets the hashcode of a Vector3D structure

                        Vector3D vector1 = new Vector3D(20, 30, 40);
                        int vectorHashCode;

                        vectorHashCode = vector1.GetHashCode();
                        //</SnippetMil3dVectorSample3DN33>

                        // Displaying Results
                        syntaxString = "vectorHashCode = vector1.GetHashCode();";
                        resultType = "int";
                        operationString = "Getting the hashcode of Vector3D";
                        ShowResults(vectorHashCode.ToString(), syntaxString, resultType, operationString);
                        break;
                    }


                case "rb50":
                    {
                        //<SnippetMil3dVectorSample3DN34>
                        // Subtracts two 3D Vectors using the Subtract method  and -

                        // Declaring vector1 and initializing x,y,z values
                        Vector3D vector1 = new Vector3D(20, 30, 40);

                        // Declaring vector2 without initializing x,y,z values
                        Vector3D vector2 = new Vector3D();
    
                        // Assigning values to vector2
                        vector2.X = 45;
                        vector2.Y = 70;
                        vector2.Z = 80;

                        // subtracted Vectors using overload - operator
                        vector1 = vector1 - vector2;

                        // vector1 is now equal to (-25, -40, -40)


                        // Subtracting vectors using static Subtract method
                        vector1 = Vector3D.Subtract(vector1, vector2);

                        // vector1 is now equal to (-70, -110, -120)
                        //</SnippetMil3dVectorSample3DN34>

                        // Displaying Results
                        syntaxString = "vector1 = vector1 - vector2;";
                        resultType = "Vector3D";
                        operationString = "Negating a vector";
                        ShowResults(vector1.ToString(), syntaxString, resultType, operationString);
                        break;
                    }

                default:
                    break;

            }   // end switch
		}

        // Method to display the results of the operations
		private void ShowResults(String resultValue, String syntax, String resultType, String opString)	
		{
			// Displays the results of the operation
			txtResultValue.Text = resultValue;
			txtSyntax.Text = syntax;
			txtResultType.Text = resultType;
			txtOperation.Text = opString;
		}

        // Method to display the variables used in the operations
		public void ShowVars()
		{
			// Displays the values of the variables
			Point3D p1 = new Point3D(10, 5, 1);
			Point3D p2 = new Point3D(15, 40, 60);

			Vector3D v1 = new Vector3D(20, 30, 40);
			Vector3D v2 = new Vector3D(45, 70, 80);

			Matrix3D m1 = new Matrix3D(10,10,10,0,20,20,20,0,30,30,30,0,5,10,15,1);

			Double s1 = 75;

			txtPoint1.Text = p1.ToString();
			txtPoint2.Text = p2.ToString();
			txtVector1.Text = v1.ToString();
			txtVector2.Text = v2.ToString();	
			txtMatrix1.Text = m1.ToString();
			txtScalar1.Text = s1.ToString();
		}

	}
}