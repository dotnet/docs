
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.VectorExamples
{
    /// <summary>
    /// Interaction logic for SampleViewer.xaml
    /// </summary>

    public partial class SampleViewer : Page
    {
       public SampleViewer()
       {
            InitializeComponent();
            
            VectorExampleFrame.Content = new VectorExample();
                 
       }
       
    }
}