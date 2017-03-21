//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Input;

namespace ComboBoxSimple
{
    /// <summary>
    /// Interaction logic for Pane1.xaml
    /// </summary>

    public partial class Pane1 : Canvas
    {
        System.Windows.Controls.ComboBox cbox;
        System.Windows.Controls.ComboBoxItem cboxitem, cboxitem2, cboxitem3;

        void OnHover(object sender, RoutedEventArgs e)
        {
            //<Snippet3>
            if (cbi1.IsHighlighted == true)
            {
                cbi2.Content = "Item2";
                cbi3.Content = "Item3";
                cbi1.Content = "Highlighted Item";
            }
            //</Snippet3>
            else if (cbi2.IsHighlighted == true)
            {
                cbi1.Content = "Item1";
                cbi3.Content = "Item3";
                cbi2.Content = "Highlighted Item";
            }
            else if (cbi3.IsHighlighted == true)
            {
                cbi1.Content = "Item1";
                cbi2.Content = "Item2";
                cbi3.Content = "Highlighted Item";
            }
        }

        //<SnippetComboBoxEvents2>
        void OnDropDownOpened(object sender, EventArgs e)
        {
            if (cb.IsDropDownOpen == true)
            {
                cb.Text = "Combo box opened";
            }
        }

        void OnDropDownClosed(object sender, EventArgs e)
        {
            if (cb.IsDropDownOpen == false)
            {
                cb.Text = "Combo box closed";
            }
        }
        //</SnippetComboBoxEvents2>

        //<SnippetOnClick>
        void OnClick(object sender, RoutedEventArgs e)
        {
            //<Snippet2>
            cbox = new ComboBox();
            cbox.Background = Brushes.LightBlue;
            cboxitem = new ComboBoxItem();
            cboxitem.Content = "Created with C#";
            cbox.Items.Add(cboxitem);
            cboxitem2 = new ComboBoxItem();
            cboxitem2.Content = "Item 2";
            cbox.Items.Add(cboxitem2);
            cboxitem3 = new ComboBoxItem();
            cboxitem3.Content = "Item 3";
            cbox.Items.Add(cboxitem3);

            cv2.Children.Add(cbox);
            //</Snippet2>
            //</SnippetOnClick>

        }
    }
}