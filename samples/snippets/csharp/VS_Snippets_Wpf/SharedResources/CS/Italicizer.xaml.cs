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

namespace ElementResourcesCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for Italicizer.xaml
    /// </summary>

    public partial class Italicizer : System.Windows.Controls.UserControl
    {
        public Italicizer()
        {
            this.Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();
        }

        void ToggleItalics_Click(object sender, RoutedEventArgs e)
        {
            if (label1.FontStyle == FontStyles.Italic)
            {
                label1.FontStyle = FontStyles.Normal;
            }
            else
            {
                label1.FontStyle = FontStyles.Italic;
            }
        }
    }
}