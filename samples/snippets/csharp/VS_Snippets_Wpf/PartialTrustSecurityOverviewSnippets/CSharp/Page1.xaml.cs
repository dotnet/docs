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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : System.Windows.Controls.Page
    {

        public Page1()
        {
            InitializeComponent();

            this.saveButton.Click += new RoutedEventHandler(saveButton_Click);
        }

        void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //FileHandling fileHandling = new FileHandling();
            //fileHandling.Save();

            FileHandlingGraceful fileHandling = new FileHandlingGraceful();
            fileHandling.Save();
        }

    }
}