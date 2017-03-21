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
using System.Collections.ObjectModel;

namespace ControlContentOverviewSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();


            CreateButtons();
            AddFirstListBox();
            AddThirdListBox();
            AddSecondListBox();
            ReportLBIs();

        }

        void ReportLBIs()
        {
            //<Snippet11>
            Console.WriteLine("Items in simpleListBox:");
            foreach (object item in simpleListBox.Items)
            {
                Console.WriteLine(item.GetType().ToString());
            }

            Console.WriteLine("\rItems in listBoxItemListBox:");

            foreach (object item in listBoxItemListBox.Items)
            {
                Console.WriteLine(item.GetType().ToString());
            }
            //</Snippet11>
        }

        //<Snippet12>
        /*
        Items in simpleListBox:
        System.String
        System.Windows.Shapes.Rectangle
        System.Windows.Controls.StackPanel
        System.DateTime

        Items in listBoxItemListBox:
        System.Windows.Controls.ListBoxItem
        System.Windows.Controls.ListBoxItem
        System.Windows.Controls.ListBoxItem
        System.Windows.Controls.ListBoxItem
        */
        //</Snippet12>

        void AddThirdListBox()
        {
            //<Snippet9>
            ListBox listBox1 = new ListBox();
            MyData listData = new MyData();
            Binding binding1 = new Binding();

            binding1.Source = listData;
            listBox1.SetBinding(ListBox.ItemsSourceProperty, binding1);
            //</Snippet9>

            listBox1.SelectionChanged += new SelectionChangedEventHandler(listBox1_SelectionChanged);
            root.Children.Add(listBox1);
        }

        void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox theListBox = sender as ListBox;

            if (theListBox == null)
            {
                MessageBox.Show("theListBox is null");
                return;
            }

            if (e.AddedItems.Count == 0)
            {
                MessageBox.Show("e.AddedItems is empty");
                return;
            }

            MessageBox.Show(e.AddedItems[0].GetType().ToString());
            ListBoxItem lbi = (ListBoxItem)theListBox.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]);

            if (lbi == null)
            {
                MessageBox.Show("lbi is null");

            }
            else
            {
                //MessageBox.Show(lbi.Content.ToString());
                lbi.Background = Brushes.Green;
            }
        }

        void AddSecondListBox()
        {
            ListBox listBox1 = new ListBox();

            // Add a String to a ListBoxItem and add the 
            // ListBoxItem to the ListBox.
            ListBoxItem lbItem1 = new ListBoxItem();
            lbItem1.Content = "This is a string in a ListBox";
            listBox1.Items.Add(lbItem1);

            // Add a Rectangle to a ListBoxItem and add the 
            // ListBoxItem to the ListBox.
            ListBoxItem lbItem2 = new ListBoxItem();
            Rectangle rect1 = new Rectangle();
            rect1.Width = 40;
            rect1.Height = 40;
            rect1.Fill = Brushes.Blue;
            lbItem2.Content = rect1;
            listBox1.Items.Add(lbItem2);

            root.Children.Add(listBox1);
        }

        ListBox listBox1 = new ListBox();
        StackPanel stackPanel1 = new StackPanel();

        void AddFirstListBox()
        {
            //<Snippet4>
            // Add a String to the ListBox.
            listBox1.Items.Add("This is a string in a ListBox");

            // Add a DateTime object to a ListBox.
            DateTime dateTime1 = new DateTime(2004, 3, 4, 13, 6, 55);

            listBox1.Items.Add(dateTime1);

            // Add a Rectangle to the ListBox.
            Rectangle rect1 = new Rectangle();
            rect1.Width = 40;
            rect1.Height = 40;
            rect1.Fill = Brushes.Blue;
            listBox1.Items.Add(rect1);

            // Add a panel that contains multpile objects to the ListBox.
            Ellipse ellipse1 = new Ellipse();
            TextBlock textBlock1 = new TextBlock();

            ellipse1.Width = 40;
            ellipse1.Height = 40;
            ellipse1.Fill = Brushes.Blue;

            textBlock1.TextAlignment = TextAlignment.Center;
            textBlock1.Text = "Text below an Ellipse";

            stackPanel1.Children.Add(ellipse1);
            stackPanel1.Children.Add(textBlock1);

            listBox1.Items.Add(stackPanel1);
            //</Snippet4>

            root.Children.Add(listBox1);


        }

        private void CreateButtons()
        {
            //<Snippet2>           
            // Create a Button with a string as its content.
            Button stringContent = new Button();
            stringContent.Content = "This is string content of a Button";

            // Create a Button with a DateTime object as its content.
            Button objectContent = new Button();
            DateTime dateTime1 = new DateTime(2004, 3, 4, 13, 6, 55);

            objectContent.Content = dateTime1;

            // Create a Button with a single UIElement as its content.
            Button uiElementContent = new Button();

            Rectangle rect1 = new Rectangle();
            rect1.Width = 40;
            rect1.Height = 40;
            rect1.Fill = Brushes.Blue;
            uiElementContent.Content = rect1;

            // Create a Button with a panel that contains multiple objects 
            // as its content.
            Button panelContent = new Button();
            StackPanel stackPanel1 = new StackPanel();
            Ellipse ellipse1 = new Ellipse();
            TextBlock textBlock1 = new TextBlock();

            ellipse1.Width = 40;
            ellipse1.Height = 40;
            ellipse1.Fill = Brushes.Blue;

            textBlock1.TextAlignment = TextAlignment.Center;
            textBlock1.Text = "Button";

            stackPanel1.Children.Add(ellipse1);
            stackPanel1.Children.Add(textBlock1);

            panelContent.Content = stackPanel1;
            //</Snippet2>           

            root.Children.Add(stringContent);
            root.Children.Add(uiElementContent);
            root.Children.Add(panelContent);
            root.Children.Add(objectContent);

            stringContent.Click += new RoutedEventHandler(stringContent_Click);
        }

        void stringContent_Click(object sender, RoutedEventArgs e)
        {
            //<Snippet15>
            ListBoxItem lbi =
                simpleListBox.ItemContainerGenerator.ContainerFromItem(itemToSelect) 
                as ListBoxItem;

            if (lbi != null)
            {
                lbi.IsSelected = true;
            }
            //</Snippet15>
        }

    }

    //<Snippet8>
    public class MyData : ObservableCollection<string>
    {
        public MyData()
        {
            Add("Item 1");
            Add("Item 2");
            Add("Item 3");
        }
    }
    //</Snippet8>
}
