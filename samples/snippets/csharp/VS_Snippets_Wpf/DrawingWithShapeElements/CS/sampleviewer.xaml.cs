
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace Microsoft.Samples.Graphics
{

    public partial class SampleViewer : Window
    {
    
    	private Page[] navigationArray;

		public SampleViewer()
		{
		
			navigationArray = new Page[11];
			navigationArray[0] = new ShapeTypes();
			navigationArray[1] = new LineExample();
			navigationArray[2] = new RectangleExample();
			navigationArray[3] = new EllipseExample();
			navigationArray[4] = new PolylineExample();
			navigationArray[5] = new PolygonExample();
			navigationArray[6] = new PathExample();
			navigationArray[7] = new FillRuleExample();
			navigationArray[8] = new LineCapsAndJoinsExample();
			navigationArray[9] = new MiterLimitExample();
           	  	navigationArray[10] = new StretchExample();
			InitializeComponent();
			
			
			
		}
		
		private void sampleSelected(object sender, RoutedEventArgs args)
		{
			//Page selectedSample = navigationArray[sampleSelector.SelectedIndex];
			//mainFrame.Navigate(selectedSample);
		
		
		}


    }
}