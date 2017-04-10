//This is a list of commonly used namespaces for a pane.
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ListBoxEvent
{

    //<Snippet6> 
    public class myColors : ObservableCollection<string>
    {
        public myColors()
        {
            Add("LightBlue");
            Add("Pink");
            Add("Red");
            Add("Purple");
            Add("Blue");
            Add("Green");
        }
    }
    //</Snippet6>

    public partial class Pane1 : Canvas
    {

        public Pane1()
            : base()
        {
            InitializeComponent();
        }
        //<Snippet2>
        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            tb.Text = "   You selected " + lbi.Content.ToString() + ".";
        }
        //</Snippet2>

        //<Snippet9>
        void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {

            BrushConverter converter = new BrushConverter();

            // Show Rectangles that are the selected colors.
            foreach (string color in args.AddedItems)
            {
                if (GetRectangle(color) == null)
                {
                    Rectangle aRect = new Rectangle();
                    aRect.Fill = (Brush) converter.ConvertFrom(color);
                    aRect.Tag = color;
                    rectanglesPanel.Children.Add(aRect);
                }

            }

            // Remove the Rectangles that are the unselected colors.
            foreach (string color in args.RemovedItems)
            {
                FrameworkElement removedItem = GetRectangle(color);
                if (removedItem != null)
                {
                    rectanglesPanel.Children.Remove(removedItem);
                }
            }
        }

        FrameworkElement GetRectangle(string color)
        {
            foreach (FrameworkElement rect in rectanglesPanel.Children)
            {
                if (rect.Tag.ToString() == color)
                    return rect;
            }

            return null;
        }
        //</Snippet9>

        void selectAll_Click(object sender, RoutedEventArgs e)
        {
            myListBox.SelectAll();
        }

        void unselectAll_Click(object sender, RoutedEventArgs e)
        {
            myListBox.UnselectAll();
        }
    }

}