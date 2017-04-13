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

namespace ThreeDSizeSample
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
        //<SnippetMil3dSize3DN1>
        private void PerformOperation(object sender, RoutedEventArgs e)
		{
			
			RadioButton li = (sender as RadioButton);
			
            // Strings used to display the results
            String syntaxString, resultType, operationString;
					
			// The local variables point1, point2, vector2, etc are defined in each
			// case block for readability reasons. Each variable is contained within
			// the scope of each case statement.  
            //</SnippetMil3dSize3DN1>
			switch (li.Name)
			{   //begin switch


                case "rb1":
                    {
                        //<SnippetMil3dSize3DN2>
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

                        // Displaying Results
                        syntaxString = "areEqual = Size3D.Equals(size1, size2);";
                        resultType = "Boolean";
                        operationString = "Checking if two Size3D structures are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN2>
                        break;
                    }
                case "rb2":
                    {
                        //<SnippetMil3dSize3DN3>
                        // Checks if an Object and a Size3D structure are equal using the non-static Equals method. 
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

                        areEqual = size1.Equals(size2);
                        // areEqual is False

                        // Displaying Results
                        syntaxString = "areEqual = Size3D.Equals(size1, size2);";
                        resultType = "Boolean";
                        operationString = "Checking if an object and a Size3D structure are equal";
                        ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN3>
                        break;
                    }

                case "rb3":
					{
                        //<SnippetMil3dSize3DN4>
                        // Checks if two Size3D structures are equal using the overloaded == operator. 
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

                        // Checking for equality
                        areEqual = size1 == size2;

                        // areEqual is False

                        // Displaying Results
                        syntaxString = " areEqual = size1 == size2;";
                        resultType = "Boolean";
						operationString = "Checking if two Size3D structures are equal";
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN4>
						break;
					}

				case "rb4":
					{
                        //<SnippetMil3dSize3DN5>
                        // Checks if two Size3D structures are not equal using the overloaded != operator. 
                        // Returns a Boolean.

                        Size3D size1 = new Size3D(2, 4, 6);
                        Size3D size2 = new Size3D(5, 10, 15);
                        Boolean areNotEqual;

                        areNotEqual = size1 != size2;
                        // areNotEqual is True

                        // Displaying Results
                        syntaxString = "areNotEqual = size1 != size2;";
                        resultType = "Boolean";
						operationString = "Checking if two Size3D structures are not equal";
						ShowResults(areNotEqual.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN5>
						break;
					}

				case "rb5":
					{
                        //<SnippetMil3dSize3DN6>
                        // Converts a string representation of a 3-D size into a Size3D structure.

                        Size3D sizeResult = new Size3D();

                        sizeResult = Size3D.Parse("10,20,30");
                        // sizeResult is equal to (10,20,30)

                        // Displaying Results
                        syntaxString = "sizeResult = Size3D.Parse(\"10,20,30\");";
                        resultType = "Size3D";
						operationString = "Converting a string into a Size3D structure";
						ShowResults(sizeResult.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN6>
						break;
					}

				case "rb6":
					{
                        //<SnippetMil3dSize3DN7>
                        // Explicitly converts a Size3D structure into a Vector3D structure
                        // Returns a Vector3D.

                        Size3D size1 = new Size3D(2, 4, 6);
                        Vector3D vector1 = new Vector3D();

                        vector1 = (Vector3D)size1;
                        // vector1 is equal to (2, 4, 6)

                        // Displaying Results
                        syntaxString = "vector1 = (Vector3D)size1;";
                        resultType = "Vector3D";
						operationString = "Expliciting casting a Size3D into a Vector3D";
                        ShowResults(vector1.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN7>
                        break;
					}

                case "rb7":
                    {
                        //<SnippetMil3dSize3DN8>
                        // Explicitly converts a Size3D structure into a Point3D structure
                        // Returns a Vector3D.

                        Size3D size1 = new Size3D(2, 4, 6);
                        Point3D point1 = new Point3D();

                        point1 = (Point3D)size1;
                        // point1 is equal to (2, 4, 6)

                        // Displaying Results
                        syntaxString = "point1 = (Point3D)size1;";
                        resultType = "Point3D";
                        operationString = "Expliciting casting a Size3D into a Point3D";
                        ShowResults(point1.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN8>
                        break;
                    }

                case "rb8":
					{
                        //<SnippetMil3dSize3DN9>
                        // Checks if a Size3D structure is empty
                        // Returns Boolean

                        Size3D size1 = new Size3D(0, 0, 0);
                        Boolean isEmpty;

                        isEmpty = size1.IsEmpty;
                        // isEmpty is False 
                       
                        // Displaying Results
                        syntaxString = "isEmpty = size1.IsEmpty;";
                        resultType = "Boolean";
						operationString = "Checking if a Size3D structure is empty";
                        ShowResults(isEmpty.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN9>
                        break;
					}

				case "rb9":
					{
                        //<SnippetMil3dSize3DN10>
                        // Gets an empty Size3D structure
                        Size3D size1 = new Size3D(2, 4, 6);

                        size1 = Size3D.Empty;
                        // size1 is now empty


             
                        // Displaying Results
                        syntaxString = "size1 = Size3D.Empty;";
                        resultType = "Size3D";
						operationString = "Getting an empty Size3D structure";
                        ShowResults(size1.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN10>
                        break;
					}

				case "rb10":
					{
                        //<SnippetMil3dSize3DN11>
                        // Gets a string representation of a Size3D Structure

                        Size3D size1 = new Size3D(2,4,6);
                        String sizeString;

                        sizeString = size1.ToString();
                        // sizeString is equal to "2,4,6"

                        // Displaying Results
						resultType = "String";
                        syntaxString = "sizeString = size1.ToString();";
                        operationString = "Getting the ToString of size1";
                        ShowResults(sizeString.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN11>
                        break;
					}

                case "rb11":
                    {
                        //<SnippetMil3dSize3DN12>
                        // Gets the hashcode of a Size3D Structure

                        Size3D size1 = new Size3D(2, 4, 6);
                        int sizeHashcode;

                        sizeHashcode = size1.GetHashCode();

                        // Displaying Results
                        resultType = "int";
                        syntaxString = "sizeHashcode = size1.GetHashCode;";
                        operationString = "Getting the hashcode of size1";
                        ShowResults(sizeHashcode.ToString(), syntaxString, resultType, operationString);
                        //</SnippetMil3dSize3DN12>
                        break;
                    }
                default:
                    break;

            } //end switch
	
        }


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

            Point3D p1 = new Point3D(10, 5, 1);

            Vector3D v1 = new Vector3D(20, 30, 40);
            Size3D s1 = new Size3D(2, 4, 6);
            Size3D s2 = new Size3D(5, 10, 15);

            // Displaying values in Text objects
            txtPoint1.Text = p1.ToString();
            txtVector1.Text = v1.ToString();
            txtSize1.Text = s1.ToString();
            txtSize2.Text = s2.ToString();
        }
    }
}