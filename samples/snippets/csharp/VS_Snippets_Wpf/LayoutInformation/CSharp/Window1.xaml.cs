using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace layout_information
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        // <Snippet2>
        private void getLayoutSlot1(object sender, System.Windows.RoutedEventArgs e)
        {
            // <Snippet3>
            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = LayoutInformation.GetLayoutSlot(txt1);
            GeometryDrawing myGeometryDrawing = new GeometryDrawing();
            Path myPath = new Path();
            myPath.Data = myRectangleGeometry;
            //</Snippet3>
            myPath.Stroke = Brushes.LightGoldenrodYellow;
            myPath.StrokeThickness = 5;
            Grid.SetColumn(myPath, 0);
            Grid.SetRow(myPath, 0);
            myGrid.Children.Add(myPath);
            txt2.Text = "LayoutSlot is equal to " + LayoutInformation.GetLayoutSlot(txt1).ToString();
        }
        //</Snippet2>
	}
}