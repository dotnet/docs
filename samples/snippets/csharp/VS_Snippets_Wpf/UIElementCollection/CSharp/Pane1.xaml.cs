using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Input;

namespace ElemCollMethods
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : Page
	{
		System.Windows.Controls.Button btn, btn1, btn2, btn3;

        // <Snippet1>
		void AddButton(object sender, MouseButtonEventArgs e)
		{
			sp1.Children.Clear();
			btn = new Button();
			btn.Content = "New Button";
			sp1.Children.Add(btn);
		}
        //</Snippet1>
        // <Snippet7>
		void RemoveButton(object sender, MouseButtonEventArgs e)
		{
            if ((sp1.Children.IndexOf(btn) >= 0) || (sp1.Children.IndexOf(btn1) >= 0) || (sp1.Children.IndexOf(btn2) >= 0) || (sp1.Children.IndexOf(btn3) >= 0))
            {
                sp1.Children.RemoveAt(0);
            }
		}
    //</Snippet7>
		void InsertButton(object sender, MouseButtonEventArgs e)
		{
            sp1.Children.Clear();
            btn = new Button();
			btn.Content = "Click to insert button";
            sp1.Children.Add(btn);
            btn.Click += (InsertControls);
			btn1 = new Button();
			btn1.Content = "Click to insert button";
            sp1.Children.Add(btn1);
            btn1.Click += (InsertControls);
		}
        // <Snippet5>
		void InsertControls(object sender, RoutedEventArgs e)
		{
			btn2 = new Button();
			btn2.Content = "Inserted Button";
            sp1.Children.Insert(1, btn2);
        }
        //</Snippet5>
		void ShowIndex(object sender, MouseButtonEventArgs e)
		{
            sp1.Children.Clear();
            btn = new Button();
			btn.Content = "Click for index";
			btn.Click += (PrintIndex);
            sp1.Children.Add(btn);

            btn1 = new Button();
			btn1.Content = "Click for index";
            sp1.Children.Add(btn1);
            btn1.Click += (PrintIndex1);

			btn2 = new Button();
			btn2.Content = "Click for index";
            sp1.Children.Add(btn2);
            btn2.Click += (PrintIndex2);

			btn3 = new Button();
			btn3.Content = "Click for index";
            sp1.Children.Add(btn3);
            btn3.Click += (PrintIndex3);

		}
		void PrintIndex(object sender, RoutedEventArgs e)
		{
            btn.Content = ((sp1.Children.IndexOf(btn)).ToString());
        }
		void PrintIndex1(object sender, RoutedEventArgs e)
		{
            btn1.Content = ((sp1.Children.IndexOf(btn1)).ToString());
        }
		void PrintIndex2(object sender, RoutedEventArgs e)
		{
            btn2.Content = ((sp1.Children.IndexOf(btn2)).ToString());
        }
		void PrintIndex3(object sender, RoutedEventArgs e)
		{
            btn3.Content = ((sp1.Children.IndexOf(btn3)).ToString());
        }
        // <Snippet9>
		void ClearButtons(object sender, MouseButtonEventArgs e)
		{
            sp1.Children.Clear();
            btn = new Button();
			btn.Content = "Click to clear";
            sp1.Children.Add(btn);
            btn.Click += (ClearControls);
			btn1 = new Button();
			btn1.Content = "Click to clear";
            sp1.Children.Add(btn1);
            btn1.Click += (ClearControls);
			btn2 = new Button();
			btn2.Content = "Click to clear";
            sp1.Children.Add(btn2);
            btn2.Click += (ClearControls);
			btn3 = new Button();
			btn3.Content = "Click to clear";
            sp1.Children.Add(btn3);
            btn3.Click += (ClearControls);
		}
        
		void ClearControls(object sender, RoutedEventArgs e)
		{
            sp1.Children.Clear();
        }
        //</Snippet9>
        
        // <Snippet10>
        void ContainsElement(object sender, RoutedEventArgs e)
        {
            TextBlock txt1 = new TextBlock();
            sp1.Children.Add(txt1);
            txt1.Text = "This StackPanel contains UIElement btn1: " + sp1.Children.Contains(btn1).ToString();
        }
        //</Snippet10>
        
        // <Snippet11>
        void GetItem(object sender, RoutedEventArgs e)
        {
            TextBlock txt2 = new TextBlock();
            sp1.Children.Add(txt2);
            txt2.Text = "UIElement at Index position [0] is " + sp1.Children[0].ToString();
        }
        //</Snippet11>

        // <Snippet12>
        void GetCount(object sender, RoutedEventArgs e)
        {
            TextBlock txt3 = new TextBlock();
            sp1.Children.Add(txt3);
            txt3.Text = "UIElement Count is equal to " + sp1.Children.Count.ToString();
        }
        // </Snippet12>
	}
}