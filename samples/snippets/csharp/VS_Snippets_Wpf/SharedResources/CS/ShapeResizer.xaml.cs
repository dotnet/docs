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
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    public partial class ShapeResizer : System.Windows.Controls.UserControl
    {
        public ShapeResizer()
        {
            InitializeComponent();

        }

    }

    //This is a dummy class with no ControlTemplate.  It exists solely so the constructor
    //is called NumericUpDown.
    public class NumericUpDown : UserControl
    {
        //<Snippet4>
        public NumericUpDown()
        {
            this.Resources.MergedDictionaries.Add(SharedDictionaryManager.SharedDictionary);
            InitializeComponent();

        }
        //</Snippet4>

        void InitializeComponent()
        {
        }
    }
}