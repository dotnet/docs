using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PageShowsNavigationUISnippetSample_CSharp
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>

    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            this.SizeChanged += new SizeChangedEventHandler(HomePage_SizeChanged);

            this.r
        }

        void HomePage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            bool tallEnough = (e.NewSize.Height > 100);
            this.ShowsNavigationUI = tallEnough;
        }
    }
}