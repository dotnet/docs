using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace StylingIntroSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {
        PhotoList Photos;

        public Window1()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Photos = (PhotoList)(this.Resources["MyPhotos"] as ObjectDataProvider).Data;
            Photos.Path = "...\\...\\Images";
        }

        private void SetNewStyle(object sender, RoutedEventArgs e)
        {
            /*Style TextBlockStyle2 = new Style(typeof(TextBlock), (Style)(this.Resources["TitleText"]));
            TextBlockStyle2.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            textblock1.Style = TextBlockStyle2;*/
        }

        private void UnsetStyle(object sender, RoutedEventArgs e)
        {
            //<SnippetCode>
            textblock1.Style = (Style)(this.Resources["TitleText"]);
            //</SnippetCode>
        }
    }
}