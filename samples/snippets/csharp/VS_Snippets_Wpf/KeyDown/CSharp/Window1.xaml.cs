using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WCSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }
        //<SnippetKeyDownSample>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                textBlock1.Text = "You Entered: " + textBox1.Text;
            }
        }
        //</SnippetKeyDownSample>
    }
}