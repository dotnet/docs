//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using System.Windows.Media;

namespace SDKSample
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

    public partial class Pane1 : Window
    {

        void OnLoad(object sender, RoutedEventArgs e)
        {
           //Create polygon with tooltip to add to shapes collection
            Polygon myPolygon = new Polygon();
            myPolygon.Fill = Brushes.Gray;
            Point Point1 = new Point(0, 30);
            Point Point2 = new Point(40, 50);
            Point Point3 = new Point(50, 70);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPolygon.Points = myPointCollection;
            myPolygon.Margin = new Thickness(10, 0, 0, 0);

            //create ToolTip for myPolygon
            ToolTip aToolTip = new ToolTip();
            TextBlock newtb = new TextBlock();
            newtb.Text = "Polygon";
            aToolTip.Content = newtb;
            //<SnippetCustomPopupPlacementCallback>
            aToolTip.Placement = PlacementMode.Custom;
            aToolTip.CustomPopupPlacementCallback =
                new CustomPopupPlacementCallback(placeToolTip);
            //</SnippetCustomPopupPlacementCallback>
            myPolygon.ToolTip = aToolTip;
            //Add myPolygon to row of other shapes
            myStackPanel.Children.Add(myPolygon);

        }

        //<SnippetDelegateInstance>
        public CustomPopupPlacement[] placeToolTip(Size popupSize,
	                                               Size targetSize,
	                                               Point offset)
        {
            CustomPopupPlacement placement1 =
               new CustomPopupPlacement(new Point(-50, 100), PopupPrimaryAxis.Vertical);

            CustomPopupPlacement placement2 =
                new CustomPopupPlacement(new Point(10, 20), PopupPrimaryAxis.Horizontal);

            CustomPopupPlacement[] ttplaces =
                    new CustomPopupPlacement[] { placement1, placement2 };
            return ttplaces;
        }
        //</SnippetDelegateInstance>
    }
}