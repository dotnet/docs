
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Graphics.Geometries
{

    public partial class SampleViewer : Page
    {
       private Page[] examples;
       private int sampleIndex;
       
       public SampleViewer()
       {      
            InitializeComponent();
            examples = new Page[5];
            
            examples[0] = new GeometryUsageExample();
            examples[1] = new ShapeGeometriesExample(); 
            examples[2] = new PathGeometryExample();
            examples[3] = new CombiningGeometriesExample();
            examples[4] = new GeometryAttributeSyntaxExample();     
       
       }
       
       private void pageLoaded(object sender, RoutedEventArgs args)
       {
   
            Example1RadioButton.IsChecked = true;
       }
       
       
       private void zoomOutStoryboardCompleted(object sender, EventArgs args)
       {
           
            mainFrame.Navigate(examples[sampleIndex]);
        
       }
       
       private void frameContentRendered(object sender, EventArgs args)
       {
            
            Storyboard s = (Storyboard)this.Resources["ZoomInStoryboard"];
            s.Begin(this);
       }
       
       private void zoomInStoryboardCompleted(object sender, EventArgs e)
       {
            scrollViewerBorder.Visibility = Visibility.Visible;
       
       }
       
       
       private void sampleSelected(object sender, RoutedEventArgs args)
       {

         
         Point3DCollection points = new Point3DCollection();
         
         double ratio = myScrollViewer.ActualWidth / myScrollViewer.ActualHeight;
         
         points.Add(new Point3D(5, -5 * ratio, 0));
         points.Add(new Point3D(5, 5 * ratio, 0));
         points.Add(new Point3D(-5, 5 * ratio, 0));
         
         points.Add(new Point3D(-5, 5 * ratio, 0));
         points.Add(new Point3D(-5, -5 * ratio, 0));
         points.Add(new Point3D(5, -5 * ratio, 0));

         points.Add(new Point3D(-5, 5 * ratio, 0));
         points.Add(new Point3D(-5, -5 * ratio, 0));
         points.Add(new Point3D(5, -5 * ratio, 0));           
         
         points.Add(new Point3D(5, -5 * ratio, 0));  
         points.Add(new Point3D(5, 5 * ratio, 0));
         points.Add(new Point3D(-5, 5 * ratio, 0)); 
       
         myGeometry.Positions = points;
         myViewport3D.Width = 100;
         myViewport3D.Height = 100 * ratio;
         
         scrollViewerBorder.Visibility = Visibility.Hidden; 
         
         RadioButton button = sender as RadioButton;

         if (button != null)
         {
         
           if (button.Content.ToString() == "Geometry Usage")
             sampleIndex = 0;
           else if (button.Content.ToString() == "Shape Geometries")
            sampleIndex = 1;

           else if (button.Content.ToString() == "PathGeometry")
            sampleIndex = 2;

           else if (button.Content.ToString() == "Combining Geometries Example")
             sampleIndex = 3;
           else if (button.Content.ToString() == "Geometry Attribute Syntax Example")
            sampleIndex = 4;            
            
         }           
       }  
    }
}