using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;


namespace SDKSample
{
    public partial class SampleViewer : Page
    {
        public SampleViewer()
        {
            InitializeComponent();
            MySimpleFlowExampleFrame.Content = new SimpleFlowExample();
            MyParagraphExampleFrame.Content = new ParagraphExample();
            MySectionExampleFrame.Content = new SectionExample();
            MyListExampleFrame.Content = new ListExample();
            MyInlineUIContainerExampleFrame.Content = new InlineUIContainerExample();
            MyFigureExampleFrame.Content = new FigureExample();
        }
        
    }

 
}
