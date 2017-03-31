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


namespace CSharp
{
    public partial class Window1 : System.Windows.Window
    {
        public Window1()
        {
            InitializeComponent();

            this.Title = this.SizeToContent.ToString();
            this.button.Content = this.button.Width.ToString() + "," + this.button.Height.ToString();
            this.SizeChanged += new SizeChangedEventHandler(Window1_SizeChanged);
        }

        void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Title = this.SizeToContent.ToString();
            this.button.Content = this.button.Width.ToString() + "," + this.button.Height.ToString();
        }

        void bob(object sender, RoutedEventArgs e)
        {
//<SnippetShowSync>
Window w = new Window();
w.Loaded += delegate { System.Console.WriteLine("This is written first."); };
w.Show();
System.Console.WriteLine("This is written last.");
//</SnippetShowSync>

//<SnippetShowASync>
Window w2 = new Window();
w2.Loaded += delegate { System.Console.WriteLine("This is written last."); };
w2.Visibility = Visibility.Visible;
System.Console.WriteLine("This is written first.");
//</SnippetShowASync>
            //if (this.SizeToContent == SizeToContent.WidthAndHeight)
            //{
            //    this.Width += 100;
            //    this.Height += 100;
            //}
            //else
            //{
            //    //this.button.Width += 30;
            //    //this.button.Height += 30;

            //    this.Width += 100;
            //    this.Height += 100;
            //}

            //this.Title = this.SizeToContent.ToString();
            //this.button.Content = this.button.Width.ToString() + "," + this.button.Height.ToString();
        }

        void widthAndHeightClick(object sender, RoutedEventArgs e)
        {
            this.button.Width = 200;
            this.button.Height = 200;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.Title = this.SizeToContent.ToString();
            this.button.Content = this.button.Width.ToString() + "," + this.button.Height.ToString();
        }

        void widthClick(object sender, RoutedEventArgs e)
        {
            this.button.Width = 200;
            this.button.Height = 200;
            this.SizeToContent = SizeToContent.Width;
            this.Title = this.SizeToContent.ToString();
            this.button.Content = this.button.Width.ToString() + "," + this.button.Height.ToString();
        }

        void heightClick(object sender, RoutedEventArgs e)
        {
            this.button.Width = 200;
            this.button.Height = 200;
            this.SizeToContent = SizeToContent.Height;
            this.Title = this.SizeToContent.ToString();
            this.button.Content = this.button.Width.ToString() + "," + this.button.Height.ToString();
        }

        void manualClick(object sender, RoutedEventArgs e)
        {
            this.button.Width = 200;
            this.button.Height = 200;
            this.SizeToContent = SizeToContent.Manual;
            this.Title = this.SizeToContent.ToString();
            this.button.Content = this.button.Width.ToString() + "," + this.button.Height.ToString();
        }
    }
}