//<SnippetSetImageSourceCODEBEHIND1>
using System; // Uri
using System.Windows.Media.Imaging; // BitmapImage
//</SnippetSetImageSourceCODEBEHIND1>
using System.IO; // Stream
using System.Windows.Resources; // StreamResourceInfo
using System.Windows;
using System.Windows.Controls;

namespace ResourcesSample
{
    public partial class ImageSourceSnippetWindow : Window
    {
        public ImageSourceSnippetWindow()
        {
            InitializeComponent();
//<SnippetSetImageSourceCODEBEHIND2>
// Create Uri that maps to a resource
Uri uri = new Uri("EmbeddedOrLooseResource.bmp", UriKind.Relative);
// Load embedded resource
this.resourceImage.Source = new System.Windows.Media.Imaging.BitmapImage(uri);
//</SnippetSetImageSourceCODEBEHIND2>
        }
    }
}