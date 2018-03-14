//This is a list of commonly used namespaces for a window.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections;
using System.Threading;

namespace PointCollectionSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>


    public partial class Window1 : Window
    {
        private long num = 3;
        private bool continueCalculating = false;



        public Window1()
        {
            InitializeComponent();

        }

        private void PointCollectionOperations(object sender, SelectionChangedEventArgs e)
        {
            RadioButton li = (sender as RadioButton);

            // Strings used to display the results
            String syntaxString, resultType, operationString;

            // The local variables point1, point2, vector2, etc are defined in each
            // case block for readability reasons. Each variable is contained within
            // the scope of each case statement.  
            switch (li.Name)
            {   //begin switch

                case "rb1":
                    {
                        //<SnippetPointCollectionAdd>

                        // Instantiating and initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);
                        Point point4 = new Point(40, 40);

                        // Instantiating an array of Points to the points
                        Point[] pointArray = new Point[3];

                        // Adding points to array
                        pointArray[0] = point1;
                        pointArray[1] = point2;
                        pointArray[2] = point3;

                        // Instantiating a PointCollection and initializing with an array
                        PointCollection pointCollection1 = new PointCollection(pointArray);

                        //  Adding a point to the PointCollection
                        pointCollection1.Add(point4);

                        // pointCollection1 is equal to (10,10 20,20 30,30 40,40)

                        //</SnippetPointCollectionAdd>



                        break;
                    }

                case "rb2":
                    {
                    
                        //<SnippetPointCollectionClear>

                        // Instantiating and initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);

                        // Instantiating a PointCollection 
                        PointCollection pointCollection1 = new PointCollection();

                        // Adding Points to the PointCollection
                        pointCollection1.Add(point1);
                        pointCollection1.Add(point2);
                        pointCollection1.Add(point3);

                        // pointCollection1 is equal to (10,10 20,20 30,30)

                        // clearing the PointCollection
                        pointCollection1.Clear();

                        // pointCollection1 is now empty

                        //</SnippetPointCollectionClear>

                        break;
                    }

                case "rb3":
                    {
                    
                        //<SnippetPointCollectionContains>

                        Boolean inCollection;

                        // Instantiating and Initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);
                        Point point4 = new Point(40, 40);

                        // Instantiating a PointCollection 
                        PointCollection pointCollection1 = new PointCollection();

                        pointCollection1.Add(point1);
                        pointCollection1.Add(point2);
                        pointCollection1.Add(point3);

                        // pointCollection1 is equal to (10,10 20,20 30,30)

                        inCollection = pointCollection1.Contains(point4);

                        // inCollection is equal to False

                        //</SnippetPointCollectionContains>

                        break;
                    }

                case "rb4":
                    {
                    
                        //<SnippetPointCollectionIndexOf>

                        int pIndex;

                        // Instantiating and initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);

                        // Instantiating a PointCollection 
                        PointCollection pointCollection1 = new PointCollection();

                        // Adding Points to PointCollection
                        pointCollection1.Add(point1);
                        pointCollection1.Add(point2);
                        pointCollection1.Add(point3);
                        // pointCollection1 is equal to (10,10 20,20 30,30)

                        // Getting the index of a Point
                        pIndex = pointCollection1.IndexOf(point2);

                        // pointIndex is equal to 1

                        //</SnippetPointCollectionIndexOf>
                        
                        break;
                    }

                case "rb5":
                    {
                        //<SnippetPointCollectionInsert>

                        // Instantiating and initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);
                        Point point4 = new Point(40, 40);

                        // Instantiating a PointCollection 
                        PointCollection pointCollection1 = new PointCollection();

                        // Adding Points to the PointCollection
                        pointCollection1.Add(point1);
                        pointCollection1.Add(point2);
                        pointCollection1.Add(point3);

                        // pointCollection1 is equal to (10,10 20,20 30,30)

                        // Inserting a Point into the PointCollection
                        pointCollection1.Insert(1, point4);

                        // pointCollection1 is now equal to (10,10 40,40 20,20 30,30

                        //</SnippetPointCollectionInsert>
                        
                        break;
                    }

                case "rb6":
                    {
                    
                        //<SnippetPointCollectionRemove>

                        // Instantiating and initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);

                        // Instantiating a PointCollection 
                        PointCollection pointCollection1 = new PointCollection();

                        // Adding Points to PointCollection
                        pointCollection1.Add(point1);
                        pointCollection1.Add(point2);
                        pointCollection1.Add(point3);

                        // pointCollection1 is equal to (10,10 20,20 30,30)

                        // Removing a Point from the PointCollection
                        pointCollection1.Remove(point2);

                        // pointCollection1 is equal to 10,10 30,30

                        //</SnippetPointCollectionRemove>

                        break;
                    }

                case "rb7":
                    {
                        //<SnippetPointCollectionRemoveAt>

                        // Instantiating and initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);

                        // Instantiating a PointCollection 
                        PointCollection pointCollection1 = new PointCollection();

                        // Adding Points to the PointCollection
                        pointCollection1.Add(point1);
                        pointCollection1.Add(point2);
                        pointCollection1.Add(point3);

                        // pointCollection1 is equal to (10,10 20,20 30,30)

                        // Removing a range of Points
                        pointCollection1.RemoveAt(1);

                        // pointCollection1 is equal to (10,10 30,30)

                        //</SnippetPointCollectionRemoveAt>

                        break;
                    }
                case "rb8":
                    {
                        //<SnippetPointCollectionToString>
                        string pcString;

                        // Instantiating and initializing Point structures
                        Point point1 = new Point(10, 10);
                        Point point2 = new Point(20, 20);
                        Point point3 = new Point(30, 30);

                        // Instantiating a PointCollection 
                        PointCollection pointCollection1 = new PointCollection();

                        // Adding Points to PointCollection
                        pointCollection1.Add(point1);
                        pointCollection1.Add(point2);
                        pointCollection1.Add(point3);

                        // pointCollection1 is equal to (10,10 20,20 30,30)

                        // Getting a string representation of the PointCollection
                        pcString = pointCollection1.ToString();
                       

                        // pcString is equal to "10,10 20,20 30,30"

                        //</SnippetPointCollectionToString>
                        

                        break;
                    }
                case "rb9":
                    {

                        break;
                    }
                case "rb10":
                    {

                        break;
                    }
                case "rb11":
                    {

                        break;
                    }
                case "rb12":
                    {

                        break;
                    }
            } //end switch
        }




        private void ShowResults(String resultValue, String syntax, String resultType, String opString)
        {
        }


    }
}