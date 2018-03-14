//<SnippetSetImageSourceCODEBEHIND1>
using System;
using System.Windows.Media.Imaging;
//</SnippetSetImageSourceCODEBEHIND1>
using System.IO;
using System.Windows.Resources;
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