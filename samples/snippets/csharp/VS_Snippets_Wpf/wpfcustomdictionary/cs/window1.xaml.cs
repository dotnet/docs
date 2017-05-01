using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections;

namespace WpfCustomDictionary
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

        //<Snippet2>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IList dictionaries = SpellCheck.GetCustomDictionaries(richTextBox1);
            // customwords2.lex is included as a resource file
            dictionaries.Add(new Uri(@"pack://application:,,,/WPFCustomDictionary;component/customwords2.lex"));
        }
        //</Snippet2>
    }
}
