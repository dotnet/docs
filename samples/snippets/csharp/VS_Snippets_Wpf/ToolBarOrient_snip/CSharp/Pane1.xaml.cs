//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ToolBarSimple
{
    /// <summary>
    /// Interaction logic for Pane1.xaml
    /// </summary>

    public partial class Pane1 : Canvas
    {
        public Pane1()
        {
            InitializeComponent();
            CreateToolBar();
        }

        void OnClick(object sender, RoutedEventArgs e)
        {
            //<SnippetToolBarOrientation>
            if (tb1.Orientation == Orientation.Vertical)
            {
                btnText.Content = "This is a vertical toolbar.";
            }
            //</SnippetToolBarOrientation>
            if (tb2.Orientation == Orientation.Vertical)
            {
                btnText.Content = "This is a vertical toolbar.";
            }
        }

        void CreateToolBar()
        {
            ToolBarTray tbartray = new ToolBarTray();
            
            ToolBar tbar = new ToolBar();
            
            Button btn = new Button();
            btn.Content = "File";
            tbar.Items.Add(btn);

            Button btn1 = new Button();
            btn1.Content = "Edit";
            tbar.Items.Add(btn1);
            
            ToolBar tbar1 = new ToolBar();

            Button btn2 = new Button();
            btn2.Content = "Format";
            tbar1.Items.Add(btn2);

            Button btn3 = new Button();
            btn3.Content = "View";
            tbar1.Items.Add(btn3);

            Button btn4 = new Button();
            btn4.Content = "Help";
            tbar1.Items.Add(btn4);
            //<SnippetToolBarTrayToolBars>
            tbartray.ToolBars.Add(tbar);
            tbartray.ToolBars.Add(tbar1);
            //</SnippetToolBarTrayToolBars>

            bd1.Child = tbartray;
        }

    }
}